using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_Buscarr.view
{
    public partial class TelaPrincipalMotorista : Form
    {
        private int _userId;
        private readonly string _connectionString = "server=localhost;database=buscard;uid=root;pwd=;";

        public TelaPrincipalMotorista(int userId, string connectionString)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _userId = userId;
            _connectionString = connectionString;

        }
        public TelaPrincipalMotorista(int userId) // Modificado construtor
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _userId = userId;
            // Armazena a connection string
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
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

        private void pictureBox11_Click(object sender, EventArgs e)
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

        private void pictureBox13_Click(object sender, EventArgs e)
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
    }
}
