using MySql.Data.MySqlClient;
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
    public partial class Visualizar_Morotista_Tela : Form
    {
        private readonly string connectionString = "Server=127.0.0.1;Database=buscard;Uid=root;Pwd=;";
        private DataGridView dgvMotoristas;

        public Visualizar_Morotista_Tela()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            InicializarDataGridView();
            CarregarMotorista();
        }

        private void Visualizar_Morotista_Tela_Load(object sender, EventArgs e)
        {

        }


        private void InicializarDataGridView()
        {
            dgvMotoristas = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Font = new Font("Segoe UI", 10)
            };

            dgvMotoristas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", DataPropertyName = "nome" });
            dgvMotoristas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", DataPropertyName = "email" });
            dgvMotoristas.Columns.Add(new DataGridViewTextBoxColumn { Name = "CPF", HeaderText = "CPF", DataPropertyName = "cpf" });
            dgvMotoristas.Columns.Add(new DataGridViewTextBoxColumn { Name = "CNH", HeaderText = "CNH", DataPropertyName = "cnh" });
            ;

            dataGridView1.Controls.Add(dgvMotoristas);
        }



        private void CarregarMotorista()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
    SELECT u.nome, u.email, u.cpf, m.cnh
    FROM usuarios u
    INNER JOIN motorista m ON u.id = m.id
    WHERE m.cnh IS NOT NULL";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dgvMotoristas.Rows.Clear();

                        while (reader.Read())
                        {
                            dgvMotoristas.Rows.Add(
                                reader["nome"]?.ToString(),
                                reader["email"]?.ToString(),
                                reader["cpf"]?.ToString(),
                                reader["cnh"]?.ToString()
                            );
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar tabela:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }









        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}