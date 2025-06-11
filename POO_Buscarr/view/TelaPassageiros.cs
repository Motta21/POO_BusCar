using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POO_Buscarr.controller;
using POO_Buscarr.model;

namespace POO_Buscarr.view
{
    public partial class TelaPassageiros : Form
    {
        private readonly string connectionString = "Server=127.0.0.1;Database=buscard;Uid=root;Pwd=;";

        public TelaPassageiros()
        {
            InitializeComponent();
            ConfigurePlaceholder();
            ConfigureDataGridView();
            CarregarPassageiros();
        }

        private void ConfigurePlaceholder()
        {
            txtBuscar.Text = "Buscar por nome...";
            txtBuscar.ForeColor = Color.Gray;
            txtBuscar.Enter += (s, e) =>
            {
                if (txtBuscar.Text == "Buscar por nome...")
                {
                    txtBuscar.Text = "";
                    txtBuscar.ForeColor = Color.Black;
                }
            };
            txtBuscar.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    txtBuscar.Text = "Buscar por nome...";
                    txtBuscar.ForeColor = Color.Gray;
                }
            };
        }

        private void ConfigureDataGridView()
        {
            dgvPassageiros.AutoGenerateColumns = false;
            dgvPassageiros.AllowUserToAddRows = false;
            dgvPassageiros.AllowUserToDeleteRows = false;
            dgvPassageiros.ReadOnly = true;
            dgvPassageiros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            var colId = new DataGridViewTextBoxColumn();
            colId.Name = "Id";
            colId.HeaderText = "ID";
            colId.Visible = false;
            dgvPassageiros.Columns.Add(colId);

            // Configurar colunas
            dgvPassageiros.Columns.Add("Nome", "Nome");
            dgvPassageiros.Columns.Add("Idade", "Idade");
            dgvPassageiros.Columns.Add("Endereco", "Endereço");
            dgvPassageiros.Columns.Add("Escola", "Escola");
            dgvPassageiros.Columns.Add("Responsavel", "Responsável");
            dgvPassageiros.Columns.Add("Telefone", "Telefone");
        }

        private void CarregarPassageiros()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idAluno, nome_Aluno, idade, endereco, escola, nome_Responsavel, telefone_Responsavel FROM aluno";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dgvPassageiros.Rows.Clear();

                        while (reader.Read())
                        {
                            dgvPassageiros.Rows.Add(
                                reader["idAluno"]?.ToString() ?? "",
                                reader["nome_Aluno"]?.ToString() ?? "",
                                reader["idade"]?.ToString() ?? "",
                                reader["endereco"]?.ToString() ?? "",
                                reader["escola"]?.ToString() ?? "",
                                reader["nome_Responsavel"]?.ToString() ?? "",
                                reader["telefone_Responsavel"]?.ToString() ?? ""
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar passageiros: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string termoBusca = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(termoBusca) || termoBusca == "Buscar por nome...")
            {
                CarregarPassageiros();
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT nome_Aluno, idade, endereco, escola, nome_Responsavel, telefone_Responsavel " +
                                   "FROM aluno WHERE nome_Aluno LIKE @termo";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@termo", $"%{termoBusca}%");

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dgvPassageiros.Rows.Clear();

                        while (reader.Read())
                        {
                            dgvPassageiros.Rows.Add(
                                reader["nome_Aluno"].ToString(),
                                reader["idade"].ToString(),
                                reader["endereco"].ToString(),
                                reader["escola"].ToString(),
                                reader["nome_Responsavel"].ToString(),
                                reader["telefone_Responsavel"].ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar passageiros: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarPassageiros();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Arquivo CSV (*.csv)|*.csv";
                saveFileDialog.Title = "Exportar lista de passageiros";
                saveFileDialog.FileName = $"passageiros_{DateTime.Now:yyyyMMdd}.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog.FileName))
                    {
                        // Cabeçalho
                        file.WriteLine("Nome,Idade,Endereço,Escola,Responsável,Telefone");

                        // Dados
                        foreach (DataGridViewRow row in dgvPassageiros.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                file.WriteLine(
                                    $"\"{row.Cells[0].Value}\"," +
                                    $"\"{row.Cells[1].Value}\"," +
                                    $"\"{row.Cells[2].Value}\"," +
                                    $"\"{row.Cells[3].Value}\"," +
                                    $"\"{row.Cells[4].Value}\"," +
                                    $"\"{row.Cells[5].Value}\""
                                );
                            }
                        }
                    }

                    MessageBox.Show("Lista exportada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar lista: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var telaAdicionar = new TelaAdicionarAluno(connectionString, CarregarPassageiros);
            telaAdicionar.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPassageiros.SelectedRows.Count == 0) return;

            int idAluno = Convert.ToInt32(dgvPassageiros.SelectedRows[0].Cells["Id"].Value);
            var alunoController = new AlunoController(connectionString);
            var aluno = alunoController.ObterAlunoPorId(idAluno);

            if (aluno != null)
            {
                var telaEditar = new TelaAdicionarAluno(connectionString, CarregarPassageiros, aluno);
                telaEditar.ShowDialog();
            }
        }

        
    }
}