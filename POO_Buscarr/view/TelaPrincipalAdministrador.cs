using POO_Buscarr.model;
using System;
using System.Windows.Forms;

namespace POO_Buscarr.view
{
    public partial class TelaPrincipalAdministrador : Form
    {
        private int _userId;
        private readonly string _connectionString = "server=localhost;database=buscard;uid=root;pwd=;";
        public TelaPrincipalAdministrador(int userId, string connectionString) // Modificado construtor
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _userId = userId;
            _connectionString = connectionString; // Armazena a connection string
        }
        public TelaPrincipalAdministrador(int userId) // Modificado construtor
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _userId = userId;
        // Armazena a connection string
        }

        private void TelaPrincipalAdministrador_Load(object sender, EventArgs e)
        {
            // Código de inicialização adicional pode ser colocado aqui
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            try
            {
                var telaPassageiros = new TelaPassageiros();
                telaPassageiros.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir tela de passageiros:\n{ex.Message}",
                              "Erro",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            try
            {
                var telaVeiculos = new TelaVeiculos();
                telaVeiculos.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir a tela de veículos:\n{ex.Message}",
                               "Erro",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            try
            {
                var telaAdicionar = new TelaAdicionarAluno(_connectionString);
                telaAdicionar.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir formulário de aluno:\n{ex.Message}",
                               "Erro",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }
    }
}