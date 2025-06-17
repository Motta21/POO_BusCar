using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace POO_Buscarr.view
{
    public partial class Visualizar_Alunos_Tela : Form
    {
        private readonly string connectionString = "Server=127.0.0.1;Database=buscard;Uid=root;Pwd=;";
        private DataGridView dgvAlunos;

        public Visualizar_Alunos_Tela()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            InicializarDataGridView();
            CarregarAlunos();
        }

        private void InicializarDataGridView()
        {
            dgvAlunos = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Font = new Font("Segoe UI", 10)
            };

            dgvAlunos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", DataPropertyName = "nome_Aluno" });
            dgvAlunos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Idade", HeaderText = "Idade", DataPropertyName = "idade" });
            dgvAlunos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Endereco", HeaderText = "Endereço", DataPropertyName = "endereco" });
            dgvAlunos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Escola", HeaderText = "Escola", DataPropertyName = "escola" });
            dgvAlunos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Responsavel", HeaderText = "Responsável", DataPropertyName = "nome_Responsavel" });
            dgvAlunos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefone", HeaderText = "Telefone", DataPropertyName = "telefone_Responsavel" });

            // Adiciona no painel — substitua "panelConteudo" pelo nome real do seu painel
            dataGridView1.Controls.Add(dgvAlunos);
        }

        private void CarregarAlunos()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT nome_Aluno, idade, endereco, escola, nome_Responsavel, telefone_Responsavel FROM aluno";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dgvAlunos.Rows.Clear();

                        while (reader.Read())
                        {
                            dgvAlunos.Rows.Add(
                                reader["nome_Aluno"]?.ToString(),
                                reader["idade"]?.ToString(),
                                reader["endereco"]?.ToString(),
                                reader["escola"]?.ToString(),
                                reader["nome_Responsavel"]?.ToString(),
                                reader["telefone_Responsavel"]?.ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar alunos:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
            // Nada aqui por enquanto
        }

        private void Sair_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // Se você tiver algum evento que abre outra tela (como veículos), comente ou implemente:
        // private void AbrirTelaVeiculos()
        // {
        //     throw new NotImplementedException(); // Isso está gerando o erro!
        // }
    }
}
