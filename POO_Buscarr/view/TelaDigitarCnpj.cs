using System;
using System.Windows.Forms;
using POO_Buscarr.controller;
using POO_Buscarr.database;
using POO_Buscarr.model.session;

namespace POO_Buscarr.view
{
    public partial class TelaDigitarCnpj : Form
    {
        private readonly UserController _userController;
        private int _userId;
        private short _userType;

        public TelaDigitarCnpj(int userId)
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
            string cnpj = campoCnpjCadastro.Text.Trim();

            if (string.IsNullOrEmpty(cnpj))
            {
                MessageBox.Show("Por favor, digite um CNPJ.");
                return;
            }

            try
            {
                bool cadastroSucesso = _userController.AddAdminUser(_userId, cnpj);

                if (cadastroSucesso)
                {
                    MessageBox.Show("Admin cadastrado com sucesso!");

                    // Buscar os dados do usuário para armazenar na sessão

                    // Buscar o usuário pelo ID
                    var user = _userController.BuscarPorId(_userId);
                    if (user != null)
                    {
                        // Salvar na sessão
                        Session.Login(user); // <-- Aqui você está logando o usuário na sessão
                    }

                    this.Hide();
                    var telaAdministrador = new TelaPrincipalAdministrador(_userId);
                    telaAdministrador.FormClosed += (s, args) => this.Close();
                    telaAdministrador.Show();

                }
                else
                {
                    MessageBox.Show("Falha no cadastro. CNPJ pode ser inválido ou já existente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }
    }
}