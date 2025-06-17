using POO_Buscarr.controller;
using POO_Buscarr.view;
using POO_Buscarr.model;
using POO_Buscarr.database;

using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace POO_Buscarr
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnFazerLogin_Click(object sender, EventArgs e)
        {
            string Email = campoEmailLogin.Text;
            string Senha = campoSenhaLogin.Text;

            // Validações básicas
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Senha))
            {
                MessageBox.Show("Preencha e-mail e senha!", "Erro");
                return;
            }

            if (!Email_controller.IsValid(Email) || !Password_controller.Verify(Senha))
            {
                MessageBox.Show("E-mail ou senha inválidos.", "Erro");
                return;
            }

            // Tenta fazer login
            try
            {
                using (Database db = new Database()) // Fecha a conexão automaticamente
                {
                    if (!db.OpenConnection())
                    {
                        MessageBox.Show("Erro ao conectar ao banco de dados.", "Erro");
                        return;
                    }

                    string queryLogin = "SELECT id, senha, nome, email, cpf, tipoUser FROM usuarios WHERE email = @Email";

                    using (MySqlCommand cmd = new MySqlCommand(queryLogin, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@Email", Email);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string senhaHash = reader.GetString("senha");
                                bool senhaValida = BCrypt.Net.BCrypt.EnhancedVerify(Senha, senhaHash);

                                if (senhaValida)
                                {
                                    int tipoUser = reader.GetInt32("tipoUser");

                                    User user = new User
                                    {
                                        Id = reader.GetInt32("id"),
                                        Email = reader.GetString("email"),
                                        Name = reader.GetString("nome"),
                                        Cpf = reader.GetString("cpf")
                                    };

                                    POO_Buscarr.model.session.Session.Login(user);

                                    MessageBox.Show("Login realizado com sucesso!", "Sucesso");
                                    this.Hide();

                                    Form telaPrincipal;
                                    if (tipoUser == 1)
                                    {
                                        telaPrincipal = new TelaPrincipalAdministrador(user.Id);
                                    }
                                    else if (tipoUser == 2)
                                    {
                                        telaPrincipal = new TelaPrincipalMotorista(user.Id);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Tipo de usuário inválido.", "Erro");
                                        return;
                                    }

                                    telaPrincipal.FormClosed += (s, args) => this.Close();
                                    telaPrincipal.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Senha incorreta.", "Erro");
                                }
                            }
                            else
                            {
                                MessageBox.Show("E-mail não cadastrado.", "Erro");
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro no banco de dados: {ex.Message}", "Erro");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}", "Erro");
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Deu certo");
        }

        private void btnIrCadastro_Click(object sender, EventArgs e)
        {
            this.Hide();
            var telaCadastro = new TelaCadastro();
            telaCadastro.FormClosed += (s, args) => this.Close();
            telaCadastro.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
        }

        private void campoEmailLogin_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void campoSenhaLogin_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void btnIrCadastro_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var telaCadastro = new TelaCadastro();
            telaCadastro.FormClosed += (s, args) => this.Close();
            telaCadastro.Show();
        }

        private void campoEmailLogin_TextChanged_1(object sender, EventArgs e)
        {
     
        }
    }
}
