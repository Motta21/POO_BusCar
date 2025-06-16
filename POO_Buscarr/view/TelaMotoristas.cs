using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POO_Buscarr.controller;
using POO_Buscarr.database;
using POO_Buscarr.model;

namespace POO_Buscarr.view
{
    public partial class TelaMotoristas : Form
    {
        private readonly string connectionString = "Server=127.0.0.1;Database=buscard;Uid=root;Pwd=;";
        private readonly Database _database;

        public TelaMotoristas()
        {
            InitializeComponent();
            _database = new Database();
            ConfigurePlaceholder();
            ConfigureDataGridView();
            CarregarMotoristas();
            dgvMotoristas.CellDoubleClick += DgvMotoristas_CellDoubleClick;
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
            dgvMotoristas.AutoGenerateColumns = false;
            dgvMotoristas.AllowUserToAddRows = false;
            dgvMotoristas.AllowUserToDeleteRows = false;
            dgvMotoristas.ReadOnly = true;
            dgvMotoristas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Configurar colunas
            var colId = new DataGridViewTextBoxColumn();
            colId.Name = "Id";
            colId.HeaderText = "ID";
            colId.Visible = false;
            dgvMotoristas.Columns.Add(colId);

            dgvMotoristas.Columns.Add("Nome", "Nome");
            dgvMotoristas.Columns.Add("Email", "Email");
            dgvMotoristas.Columns.Add("CPF", "CPF");
            dgvMotoristas.Columns.Add("CNH", "CNH");
        }

        private void CarregarMotoristas()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT u.id, u.nome, u.email, u.cpf, m.cnh 
                                   FROM usuarios u 
                                   JOIN motorista m ON u.id = m.id 
                                   WHERE u.tipoUser = 2";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dgvMotoristas.Rows.Clear();

                        while (reader.Read())
                        {
                            dgvMotoristas.Rows.Add(
                                reader["id"]?.ToString() ?? "",
                                reader["nome"]?.ToString() ?? "",
                                reader["email"]?.ToString() ?? "",
                                reader["cpf"]?.ToString() ?? "",
                                reader["cnh"]?.ToString() ?? ""
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar motoristas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string termoBusca = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(termoBusca) || termoBusca == "Buscar por nome...")
            {
                CarregarMotoristas();
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT u.id, u.nome, u.email, u.cpf, m.cnh 
                                   FROM usuarios u 
                                   JOIN motorista m ON u.id = m.id 
                                   WHERE u.tipoUser = 2 AND 
                                   (u.nome LIKE @termo OR 
                                    u.email LIKE @termo OR 
                                    u.cpf LIKE @termo OR 
                                    m.cnh LIKE @termo)";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@termo", $"%{termoBusca}%");

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dgvMotoristas.Rows.Clear();

                        while (reader.Read())
                        {
                            dgvMotoristas.Rows.Add(
                                reader["id"]?.ToString() ?? "",
                                reader["nome"]?.ToString() ?? "",
                                reader["email"]?.ToString() ?? "",
                                reader["cpf"]?.ToString() ?? "",
                                reader["cnh"]?.ToString() ?? ""
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar motoristas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarMotoristas();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Arquivo CSV (*.csv)|*.csv";
                saveFileDialog.Title = "Exportar lista de motoristas";
                saveFileDialog.FileName = $"motoristas_{DateTime.Now:yyyyMMdd}.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog.FileName))
                    {
                        // Cabeçalho
                        file.WriteLine("Nome,Email,CPF,CNH");

                        // Dados
                        foreach (DataGridViewRow row in dgvMotoristas.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                file.WriteLine(
                                    $"\"{row.Cells["Nome"].Value}\"," +
                                    $"\"{row.Cells["Email"].Value}\"," +
                                    $"\"{row.Cells["CPF"].Value}\"," +
                                    $"\"{row.Cells["CNH"].Value}\""
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
            var telaAdicionar = new TelaAdicionarMotorista(_database, CarregarMotoristas);
            telaAdicionar.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMotoristas.SelectedRows.Count == 0) return;

            int idMotorista = Convert.ToInt32(dgvMotoristas.SelectedRows[0].Cells["Id"].Value);
            var motorista = ObterMotoristaPorId(idMotorista);

            if (motorista != null)
            {
                var telaEditar = new TelaAdicionarMotorista(_database, CarregarMotoristas, motorista);
                telaEditar.ShowDialog();
            }
        }

        private Motorista ObterMotoristaPorId(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT u.id, u.nome, u.email, u.cpf, m.cnh 
                                   FROM usuarios u 
                                   JOIN motorista m ON u.id = m.id 
                                   WHERE u.id = @id";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Motorista
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nome = reader["nome"].ToString(),
                                Email = reader["email"].ToString(),
                                CPF = reader["cpf"].ToString(),
                                CNH = reader["cnh"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter motorista: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        private void DgvMotoristas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idMotorista = Convert.ToInt32(dgvMotoristas.Rows[e.RowIndex].Cells["Id"].Value);
                var motorista = ObterMotoristaPorId(idMotorista);

                if (motorista != null)
                {
                    var telaEditar = new TelaAdicionarMotorista(_database, CarregarMotoristas, motorista);
                    telaEditar.ShowDialog();
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvMotoristas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um motorista para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Deseja realmente excluir este motorista?", "Confirmação",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    int idMotorista = Convert.ToInt32(dgvMotoristas.SelectedRows[0].Cells["Id"].Value);

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        // Primeiro exclui da tabela motorista
                        string queryMotorista = "DELETE FROM motorista WHERE id = @id";
                        using (MySqlCommand cmdMotorista = new MySqlCommand(queryMotorista, connection))
                        {
                            cmdMotorista.Parameters.AddWithValue("@id", idMotorista);
                            cmdMotorista.ExecuteNonQuery();
                        }

                        // Depois exclui da tabela usuarios
                        string queryUsuario = "DELETE FROM usuarios WHERE id = @id";
                        using (MySqlCommand cmdUsuario = new MySqlCommand(queryUsuario, connection))
                        {
                            cmdUsuario.Parameters.AddWithValue("@id", idMotorista);
                            int rowsAffected = cmdUsuario.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Motorista excluído com sucesso!", "Sucesso",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CarregarMotoristas();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum motorista foi excluído.", "Aviso",
                                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir motorista:\n{ex.Message}", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}