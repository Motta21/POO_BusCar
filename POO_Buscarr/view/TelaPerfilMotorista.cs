using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POO_Buscarr.database;
using POO_Buscarr.model;
using POO_Buscarr.model.session;

namespace POO_Buscarr.view
{
    public partial class TelaPerfilMotorista : Form
    {
        private TextBox txtNome;
        private TextBox txtEmail;
        private TextBox txtCpf;
        private TextBox txtCnh;
        private Button btnSalvar;
        private Button btnVoltar;

        public TelaPerfilMotorista()
        {
            InitializeComponent();
            CarregarDadosMotorista();
        }

        private void InitializeComponent()
        {
            this.Text = "Perfil do Motorista";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Cabeçalho azul
            Panel header = new Panel();
            header.BackColor = Color.FromArgb(0, 102, 204);
            header.Dock = DockStyle.Top;
            header.Height = 80;
            this.Controls.Add(header);

            Label titulo = new Label();
            titulo.Text = "Perfil do Motorista";
            titulo.ForeColor = Color.White;
            titulo.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            titulo.AutoSize = true;
            titulo.Location = new Point(20, 20);
            header.Controls.Add(titulo);

            // Labels e TextBoxes
            int startY = 120;
            int spacing = 50;

            Label lblNome = new Label();
            lblNome.Text = "Nome:";
            lblNome.Location = new Point(50, startY);
            lblNome.Size = new Size(100, 30);
            lblNome.Font = new Font("Segoe UI", 12);
            this.Controls.Add(lblNome);

            txtNome = new TextBox();
            txtNome.Location = new Point(160, startY);
            txtNome.Size = new Size(550, 30);
            txtNome.Font = new Font("Segoe UI", 11);
            this.Controls.Add(txtNome);

            Label lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.Location = new Point(50, startY + spacing);
            lblEmail.Size = new Size(100, 30);
            lblEmail.Font = new Font("Segoe UI", 12);
            this.Controls.Add(lblEmail);

            txtEmail = new TextBox();
            txtEmail.Location = new Point(160, startY + spacing);
            txtEmail.Size = new Size(550, 30);
            txtEmail.Font = new Font("Segoe UI", 11);
            this.Controls.Add(txtEmail);

            Label lblCpf = new Label();
            lblCpf.Text = "CPF:";
            lblCpf.Location = new Point(50, startY + spacing);
            lblCpf.Size = new Size(100, 30);
            lblCpf.Font = new Font("Segoe UI", 12);
            this.Controls.Add(lblCpf);

            txtCpf = new TextBox();
            txtCpf.Location = new Point(160, startY + 2 * spacing);
            txtCpf.Size = new Size(550, 30);
            txtCpf.Font = new Font("Segoe UI", 11);
            this.Controls.Add(txtCpf);

            Label lblCnh = new Label();
            lblCnh.Text = "CNH:";
            lblCnh.Location = new Point(50, startY + 3 * spacing);
            lblCnh.Size = new Size(100, 30);
            lblCnh.Font = new Font("Segoe UI", 12);
            this.Controls.Add(lblCnh);

            txtCnh = new TextBox();
            txtCnh.Location = new Point(160, startY + 3 * spacing);
            txtCnh.Size = new Size(550, 30);
            txtCnh.Font = new Font("Segoe UI", 11);
            this.Controls.Add(txtCnh);

            // Botão Salvar
            btnSalvar = new Button();
            btnSalvar.Text = "Salvar";
            btnSalvar.Size = new Size(100, 35);
            btnSalvar.Location = new Point(160, startY + 4 * spacing + 20);
            btnSalvar.BackColor = Color.FromArgb(0, 102, 204);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Click += BtnSalvar_Click;
            this.Controls.Add(btnSalvar);

            // Botão Voltar
            btnVoltar = new Button();
            btnVoltar.Text = "Voltar";
            btnVoltar.Size = new Size(100, 35);
            btnVoltar.Location = new Point(310, startY + 4 * spacing + 20);
            btnVoltar.BackColor = Color.Gainsboro;
            btnVoltar.Click += (s, e) => { this.Close(); };
            this.Controls.Add(btnVoltar);
        }

        private void CarregarDadosMotorista()
        {
            var user = Session.GetLoggedUser();
            if (user == null)
            {
                MessageBox.Show("Usuário não está logado.");
                this.Close();
                return;
            }

            using (var db = new Database())
            {
                if (!db.OpenConnection())
                {
                    MessageBox.Show("Erro ao conectar com o banco de dados.");
                    return;
                }

                try
                {
                    string query = @"
                        SELECT u.nome, u.email, u.cpf, m.cnh
                        FROM usuarios u
                        INNER JOIN motorista m ON u.id = m.id
                        WHERE u.id = @idUser";

                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@idUser", user.Id);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNome.Text = reader.GetString("nome");
                                txtEmail.Text = reader.GetString("email");
                                txtCpf.Text = reader.GetString("cpf");
                                txtCnh.Text = reader.GetString("cnh");
                            }
                            else
                            {
                                MessageBox.Show("Dados do motorista não encontrados.");
                                this.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
                finally
                {
                    db.CloseConnection();
                }
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            var user = Session.GetLoggedUser();
            if (user == null)
            {
                MessageBox.Show("Usuário não está logado.");
                this.Close();
                return;
            }

            using (var db = new Database())
            {
                if (!db.OpenConnection())
                {
                    MessageBox.Show("Erro ao conectar com o banco de dados.");
                    return;
                }

                try
                {
                    string updateUsuario = @"
                        UPDATE usuarios SET
                        nome = @nome,
                        email = @email,
                        cpf = @cpf
                        WHERE id = @idUser";

                    using (MySqlCommand cmd = new MySqlCommand(updateUsuario, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                        cmd.Parameters.AddWithValue("@idUser", user.Id);

                        cmd.ExecuteNonQuery();
                    }

                    string updateMotorista = @"
                        UPDATE motorista SET
                        cnh = @cnh
                        WHERE id = @idUser";

                    using (MySqlCommand cmd = new MySqlCommand(updateMotorista, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@cnh", txtCnh.Text);
                        cmd.Parameters.AddWithValue("@idUser", user.Id);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Dados atualizados com sucesso!");

                    // Atualizar dados na Session (se quiser)
                    user.Name = txtNome.Text;
                    user.Email = txtEmail.Text;
                    user.Cpf = txtCpf.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar dados: " + ex.Message);
                }
                finally
                {
                    db.CloseConnection();
                }
            }
        }
    }
}
