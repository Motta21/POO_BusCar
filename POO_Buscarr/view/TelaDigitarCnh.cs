using POO_Buscarr.controller;
using POO_Buscarr.database;
using POO_Buscarr.model;
using System;
using System.Windows.Forms;

namespace POO_Buscarr.view
{
    public partial class TelaDigitarCnh : Form
    {
        private readonly UserController _userController;

        private int _userId;

        public TelaDigitarCnh(int userId)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            // Inicialização igual ao cadastro
            var db = new POO_Buscarr.database.Database();
            _userController = new POO_Buscarr.controller.UserController(db);
            _userId = userId;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string cnh = campoCnhCadastro.Text.Trim();

            if (string.IsNullOrEmpty(cnh))
            {
                MessageBox.Show("Por favor, digite uma CNH.");
                return;
            }

            try
            {
                bool cadastroSucesso = _userController.AddDriverUser(_userId, cnh);

                if (cadastroSucesso)
                {
                    MessageBox.Show("Motorista cadastrado com sucesso!");

                    this.Hide();
                    var telaMotorista = new TelaPrincipalMotorista(_userId);
                    telaMotorista.FormClosed += (s, args) => this.Close();
                    telaMotorista.Show();               
                }
                else
                {
                    MessageBox.Show("Falha no cadastro. CNH pode ser inválida ou já existente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }
    }
}