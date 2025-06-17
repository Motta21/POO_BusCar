using System;
using System.Windows.Forms;
using POO_Buscarr.database;
using MySql.Data.MySqlClient;
using POO_Buscarr.model;

namespace POO_Buscarr.view
{
    public partial class TelaAdicionarVeiculo : Form
    {
        private bool modoEdicao = false;
        private int idVeiculo = -1;

        public TelaAdicionarVeiculo()
        {
            InitializeComponent();
            cmbSituacao.DataSource = Enum.GetValues(typeof(CarSituation));
            btnSalvar.Click += BtnSalvar_Click;
            btnCancelar.Click += (s, e) => this.Close();
        }
        private string _connectionString;

    public TelaAdicionarVeiculo(string connectionString)
{
    InitializeComponent();
    _connectionString = connectionString;
    cmbSituacao.DataSource = Enum.GetValues(typeof(CarSituation));
    btnSalvar.Click += BtnSalvar_Click;
    btnCancelar.Click += (s, e) => this.Close();
}
        public TelaAdicionarVeiculo(int id, string modelo, string placa, string renavam, string status, string connectionString) : this(connectionString)
        {
            this.Text = "Editar Veículo";
            lblTitulo.Text = "Editar Veículo";
            modoEdicao = true;
            idVeiculo = id;

            txtModelo.Text = modelo;
            txtPlaca.Text = placa;
            txtRenavam.Text = renavam;

            if (Enum.TryParse(status, out CarSituation parsedStatus))
                cmbSituacao.SelectedItem = parsedStatus;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            string modelo = txtModelo.Text.Trim();
            string placa = txtPlaca.Text.Trim();
            string renavam = txtRenavam.Text.Trim();
            string status = cmbSituacao.SelectedItem.ToString();

            try
            {
                using (var db = new Database())
                {
                    if (db.OpenConnection())
                    {
                        using (var conn = db.GetConnection())
                        {
                            string query;

                            if (modoEdicao)
                            {
                                query = "UPDATE carro SET modelo = @modelo, placa = @placa, renavam = @renavam, status = @status WHERE id = @id";
                            }
                            else
                            {
                                query = "INSERT INTO carro (modelo, placa, renavam, status) VALUES (@modelo, @placa, @renavam, @status)";
                            }

                            using (var cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@modelo", modelo);
                                cmd.Parameters.AddWithValue("@placa", placa);
                                cmd.Parameters.AddWithValue("@renavam", renavam);
                                cmd.Parameters.AddWithValue("@status", status);

                                if (modoEdicao)
                                    cmd.Parameters.AddWithValue("@id", idVeiculo);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                MessageBox.Show(modoEdicao ? "Veículo atualizado com sucesso!" : "Veículo adicionado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar veículo: " + ex.Message);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtModelo.Text) ||
                string.IsNullOrWhiteSpace(txtPlaca.Text) ||
                string.IsNullOrWhiteSpace(txtRenavam.Text) ||
                cmbSituacao.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha todos os campos!");
                return false;
            }

            return true;
        }
    }
}
