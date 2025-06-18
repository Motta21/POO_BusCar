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
    public partial class Visualizar_Veiculo : Form
    {
        private readonly string connectionString = "Server=127.0.0.1;Database=buscard;Uid=root;Pwd=;";
        private DataGridView dgvVeiculos;

        public Visualizar_Veiculo()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            InicializarDataGridView();
            CarregarCarros();
        }


        private void InicializarDataGridView()
        {
            dgvVeiculos = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Font = new Font("Segoe UI", 10)
            };

            dgvVeiculos.Columns.Add(new DataGridViewTextBoxColumn { Name = "ID", HeaderText = "ID", DataPropertyName = "id" });
            dgvVeiculos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Modelo", HeaderText = "Modelo", DataPropertyName = "modelo" });
            dgvVeiculos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Placa", HeaderText = "Placa", DataPropertyName = "placa" });
            dgvVeiculos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Renavam", HeaderText = "Renavam", DataPropertyName = "renavam" });
            dgvVeiculos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "status" });

            // Adiciona no painel — substitua "panelConteudo" pelo nome real do seu painel
            dataGridView1.Controls.Add(dgvVeiculos);
        }


        private void CarregarCarros()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, modelo, placa, renavam, status FROM carro";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dgvVeiculos.Rows.Clear();

                        while (reader.Read())
                        {
                            dgvVeiculos.Rows.Add(
                                reader["id"]?.ToString(),
                                reader["modelo"]?.ToString(),
                                reader["placa"]?.ToString(),
                                reader["renavam"]?.ToString(),
                                reader["status"]?.ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar carros:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
