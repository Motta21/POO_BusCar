using POO_Buscarr.database;
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
                var telaVeiculos = new TelaVeiculos(_connectionString);
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

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            try
            {
                var telaAdicionarVeiculo = new TelaAdicionarVeiculo(_connectionString);
                telaAdicionarVeiculo.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir formulário de veículo:\n{ex.Message}",
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            try
            {
                // Cria uma instância do Database
                var database = new Database();

                // Cria e exibe a tela de motoristas
                var telaMotoristas = new TelaMotoristas();
                telaMotoristas.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir tela de motoristas:\n{ex.Message}",
                              "Erro",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            try
            {
                var database = new Database();

                using (var tela = new TelaAdicionarMotorista(
                    database,
                    () => {
                        // Ação após cadastro bem-sucedido
                        MessageBox.Show("Motorista cadastrado com sucesso!", "Sucesso");
                    }))
                {
                    tela.StartPosition = FormStartPosition.CenterScreen;
                    tela.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir tela de cadastro:\n{ex.Message}",
                              "Erro",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
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

        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                var telaAdicionarVeiculo = new TelaAdicionarVeiculo(_connectionString);
                telaAdicionarVeiculo.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir formulário de veículo:\n{ex.Message}",
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

    }
}