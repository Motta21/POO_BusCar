using POO_Buscarr.model;
using POO_Buscarr.database;
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace POO_Buscarr.view
{
    public partial class TelaPrincipalAdministrador : Form
    {
        private int _userId;
        private readonly string _connectionString = "server=localhost;database=buscard;uid=root;pwd=;";

        public TelaPrincipalAdministrador(int userId, string connectionString)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _userId = userId;
            _connectionString = connectionString;
        }

        public TelaPrincipalAdministrador(int userId)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _userId = userId;
        }

        private void TelaPrincipalAdministrador_Load(object sender, EventArgs e)
        {
            try
            {
                textBoxTotalAlunos.Text = ObterContagem("SELECT COUNT(*) FROM aluno").ToString();
                textBoxTotalMotorista.Text = ObterContagem("SELECT COUNT(*) FROM motorista").ToString();
                textBoxTotalVeiculos.Text = ObterContagem("SELECT COUNT(*) FROM carro").ToString();
                textBoxTotalVeiculosManut.Text = ObterContagem("SELECT COUNT(*) FROM carro WHERE status = 'Unavailable'").ToString();
                textBoxTotalVeiculosFunc.Text = ObterContagem("SELECT COUNT(*) FROM carro WHERE status = 'InMaintenance'").ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar contadores:\n{ex.Message}",
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
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

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            try
            {
                var telaVisualizar = new Visualizar_Alunos_Tela();
                telaVisualizar.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tela aberta com Sucesso!",
                               "BusCar");
                //  MessageBoxButtons.OK,
                //  MessageBoxIcon.Error);
            }
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            try
            {
                var telaVisualizarMotora = new Visualizar_Morotista_Tela();
                telaVisualizarMotora.Show();
                MessageBox.Show("Tela aberta com Sucesso!", "Hello");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir tela de motoristas:\n{ex.Message}",
                              "Erro",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            try
            {
                var telaVercarros = new Visualizar_Veiculo();
                telaVercarros.Show();
                MessageBox.Show("Tela aberta com Sucesso!", "Hello");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir tela de veículos:\n{ex.Message}",
                              "Erro",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            var telaLogin = new TelaLogin();
            telaLogin.FormClosed += (s, args) => this.Close();
            telaLogin.Show();
            this.Hide();
        }

        // Métodos do v2 que não existiam no v1 (adicionados sem duplicar)
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
                var database = new Database();
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
                    () => MessageBox.Show("Motorista cadastrado com sucesso!", "Sucesso")))
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
            try
            {
                var telaPerfil = new TelaPerfilAdministrador();
                telaPerfil.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o perfil do motorista:\n{ex.Message}",
                               "Erro",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private int ObterContagem(string query)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private void textBoxTotalAlunos_TextChanged(object sender, EventArgs e) { }
        private void textBoxTotalMotorista_TextChanged(object sender, EventArgs e) { }
        private void textBoxTotalVeiculos_TextChanged(object sender, EventArgs e) { }
        private void textBoxTotalVeiculosManut_TextChanged(object sender, EventArgs e) { }
        private void textBoxTotalVeiculosFunc_TextChanged(object sender, EventArgs e) { }

       
    }
}