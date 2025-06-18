using POO_Buscarr.database;
using POO_Buscarr.model;
using POO_Buscarr.model.session;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace POO_Buscarr.view
{
    public partial class TelaPerfilAdministrador : Form
    {
        private TextBox txtNome;
        private TextBox txtEmail;
        private TextBox txtCpf;
        private TextBox txtCnpj;
        private Button btnSalvar;
        private Button btnVoltar;

        public TelaPerfilAdministrador()
        {
            InitializeComponent();
            MontarInterface();
            CarregarDadosAdministrador();
        }

        private void MontarInterface()
        {
            this.Text = "Perfil do Administrador";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Panel header = new Panel
            {
                BackColor = Color.FromArgb(0, 102, 204),
                Dock = DockStyle.Top,
                Height = 80
            };

            Label titulo = new Label
            {
                Text = "Perfil do Administrador",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            header.Controls.Add(titulo);
            this.Controls.Add(header);

            int startY = 100;
            int spacing = 50;

            string[] nomesCampos = { "Nome", "Email", "CPF", "CNPJ" };
            Label[] labels = new Label[nomesCampos.Length];
            TextBox[] textBoxes = new TextBox[nomesCampos.Length];

            for (int i = 0; i < nomesCampos.Length; i++)
            {
                labels[i] = new Label
                {
                    Text = nomesCampos[i] + ":",
                    Location = new Point(50, startY + i * spacing),
                    Size = new Size(100, 30),
                    Font = new Font("Segoe UI", 12)
                };
                this.Controls.Add(labels[i]);

                textBoxes[i] = new TextBox
                {
                    Location = new Point(160, startY + i * spacing),
                    Size = new Size(500, 30),
                    Font = new Font("Segoe UI", 11)
                };
                this.Controls.Add(textBoxes[i]);
            }

            txtNome = textBoxes[0];
            txtEmail = textBoxes[1];
            txtCpf = textBoxes[2];
            txtCnpj = textBoxes[3];

            btnSalvar = new Button
            {
                Text = "Salvar",
                Size = new Size(100, 35),
                Location = new Point(530, 360),
                BackColor = Color.LightGreen
            };
            btnSalvar.Click += BtnSalvar_Click;
            this.Controls.Add(btnSalvar);

            btnVoltar = new Button
            {
                Text = "Voltar",
                Size = new Size(100, 35),
                Location = new Point(650, 360),
                BackColor = Color.Gainsboro
            };
            btnVoltar.Click += (s, e) => { this.Close(); };
            this.Controls.Add(btnVoltar);
        }

        private void CarregarDadosAdministrador()
        {
            var user = Session.GetLoggedUser();
            if (user == null)
            {
                MessageBox.Show("Usuário não logado.");
                this.Close();
                return;
            }

            using (Database db = new Database())
            {
                try
                {
                    db.OpenConnection();
                    string sql = @"
                        SELECT u.nome, u.email, u.cpf, a.cnpj
                        FROM usuarios u
                        INNER JOIN admin a ON u.id = a.id
                        WHERE u.id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@id", user.Id);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNome.Text = reader.GetString("nome");
                                txtEmail.Text = reader.GetString("email");
                                txtCpf.Text = reader.GetString("cpf");
                                txtCnpj.Text = reader.GetString("cnpj");
                            }
                            else
                            {
                                MessageBox.Show("Dados do administrador não encontrados.");
                                this.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                    this.Close();
                }
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            var user = Session.GetLoggedUser();
            if (user == null) return;

            using (Database db = new Database())
            {
                try
                {
                    db.OpenConnection();

                    string sqlUsuarios = "UPDATE usuarios SET nome = @nome, email = @email, cpf = @cpf WHERE id = @id";
                    using (MySqlCommand cmdUsuarios = new MySqlCommand(sqlUsuarios, db.GetConnection()))
                    {
                        cmdUsuarios.Parameters.AddWithValue("@nome", txtNome.Text);
                        cmdUsuarios.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmdUsuarios.Parameters.AddWithValue("@cpf", txtCpf.Text);
                        cmdUsuarios.Parameters.AddWithValue("@id", user.Id);
                        cmdUsuarios.ExecuteNonQuery();
                    }

                    string sqlAdmin = "UPDATE admin SET cnpj = @cnpj WHERE id = @id";
                    using (MySqlCommand cmdAdmin = new MySqlCommand(sqlAdmin, db.GetConnection()))
                    {
                        cmdAdmin.Parameters.AddWithValue("@cnpj", txtCnpj.Text);
                        cmdAdmin.Parameters.AddWithValue("@id", user.Id);
                        cmdAdmin.ExecuteNonQuery();
                    }

                    MessageBox.Show("Dados atualizados com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar dados: " + ex.Message);
                }
            }
        }
    }
}
