using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POO_Buscarr.database;
using POO_Buscarr.view;

namespace POO_Buscarr.view
{

    public partial class TelaVeiculos : Form
    {
        public TelaVeiculos()
        {
            InitializeComponent();
            CarregarDados();
            btnBuscar.Click += BtnBuscar_Click;
            btnAtualizar.Click += BtnAtualizar_Click;
            Adicionar.Click += Adicionar_Click;
            btnExcluir.Click += BtnExcluir_Click;
            dgvVeiculos.CellDoubleClick += DgvVeiculos_CellDoubleClick;
            btnVoltar.Click += (s, e) => this.Close();
            Editar.Click += Editar_Click;
            btnExportar.Click += btnExportar_Click; 

        }

        private void CarregarDados(string filtro = "")
        {
            try
            {
                using (var db = new Database())
                {
                    if (db.OpenConnection())
                    {
                        using (var conn = db.GetConnection())
                        {
                            string query = "SELECT id, modelo, placa, renavam, status FROM carro";
                            if (!string.IsNullOrWhiteSpace(filtro))
                                query += " WHERE modelo LIKE @filtro OR " +
                                "placa LIKE @filtro OR " +
                                "renavam LIKE @filtro OR " +
                                "status LIKE @filtro";  
                            using (var cmd = new MySqlCommand(query, conn))
                            {
                                if (!string.IsNullOrWhiteSpace(filtro))
                                    cmd.Parameters.AddWithValue("@filtro", $"%{filtro}%");

                                var adapter = new MySqlDataAdapter(cmd);
                                var tabela = new DataTable();
                                adapter.Fill(tabela);

                                // Adiciona coluna de ícone visual
                                tabela.Columns.Add("Situação", typeof(string));
                                foreach (DataRow row in tabela.Rows)
                                {
                                    row["Situação"] = ObterIconeStatus(row["status"].ToString());
                                }

                                dgvVeiculos.DataSource = tabela;

                                // Esconde a coluna "status" crua
                                if (dgvVeiculos.Columns.Contains("status"))
                                    dgvVeiculos.Columns["status"].Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar veículos: " + ex.Message);
            }
        }

        private string ObterIconeStatus(string status)
        {
            switch (status)
            {
                case "Available":
                    return "🟢 Disponível";
                case "Unavailable":
                    return "🔴 Indisponível";
                case "InMaintenance":
                    return "🔧 Manutenção";
                default:
                    return "❓ Desconhecido";
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();
            CarregarDados(filtro);
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CarregarDados();
        }

        private void Adicionar_Click(object sender, EventArgs e)
        {
            var telaAdd = new TelaAdicionarVeiculo();
            telaAdd.FormClosed += (s, args) => CarregarDados();
            telaAdd.ShowDialog();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvVeiculos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um veículo para excluir.");
                return;
            }

            var id = dgvVeiculos.SelectedRows[0].Cells["id"].Value.ToString();
            var confirm = MessageBox.Show("Deseja excluir este veículo?", "Confirmação", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (var db = new Database())
                    {
                        if (db.OpenConnection())
                        {
                            using (var conn = db.GetConnection())
                            {
                                string query = "DELETE FROM carro WHERE id = @id";
                                using (var cmd = new MySqlCommand(query, conn))
                                {
                                    cmd.Parameters.AddWithValue("@id", id);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    CarregarDados();
                    MessageBox.Show("Veículo excluído com sucesso.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao excluir: " + ex.Message);
                }
            }
        }

        private void DgvVeiculos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvVeiculos.Rows[e.RowIndex].Cells["id"].Value);
                string modelo = dgvVeiculos.Rows[e.RowIndex].Cells["modelo"].Value.ToString();
                string placa = dgvVeiculos.Rows[e.RowIndex].Cells["placa"].Value.ToString();
                string renavam = dgvVeiculos.Rows[e.RowIndex].Cells["renavam"].Value.ToString();
                string status = dgvVeiculos.Rows[e.RowIndex].Cells["status"].Value.ToString();

                var telaEdit = new TelaAdicionarVeiculo(id, modelo, placa, renavam, status);
                telaEdit.FormClosed += (s, args) => CarregarDados();
                telaEdit.ShowDialog();

            }
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            if (dgvVeiculos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um veículo para editar.");
                return;
            }

            int id = Convert.ToInt32(dgvVeiculos.SelectedRows[0].Cells["id"].Value);
            string modelo = dgvVeiculos.SelectedRows[0].Cells["modelo"].Value.ToString();
            string placa = dgvVeiculos.SelectedRows[0].Cells["placa"].Value.ToString();
            string renavam = dgvVeiculos.SelectedRows[0].Cells["renavam"].Value.ToString();
            string status = dgvVeiculos.SelectedRows[0].Cells["status"].Value.ToString();

            var telaEdit = new TelaAdicionarVeiculo(id, modelo, placa, renavam, status);
            telaEdit.FormClosed += (s, args) => CarregarDados();
            telaEdit.ShowDialog();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Arquivo CSV (*.csv)|*.csv";
                saveFileDialog.Title = "Exportar lista de veículos";
                saveFileDialog.FileName = $"veiculos_{DateTime.Now:yyyyMMdd}.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog.FileName))
                    {
                        // Cabeçalho
                        file.WriteLine("Modelo,Placa,Renavam,Situação");

                        // Dados
                        foreach (DataGridViewRow row in dgvVeiculos.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                file.WriteLine(
                                    $"\"{row.Cells["modelo"].Value}\"," +
                                    $"\"{row.Cells["placa"].Value}\"," +
                                    $"\"{row.Cells["renavam"].Value}\"," +
                                    $"\"{row.Cells["Situação"].Value}\""
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

    }

}
