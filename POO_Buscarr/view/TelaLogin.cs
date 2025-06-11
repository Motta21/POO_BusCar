using POO_Buscarr.controller;
using POO_Buscarr.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using POO_Buscarr.database;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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

            bool validacao_email_login = Email_controller.IsValid(Email);
            bool validacao_senha_login = Password_controller.Verify(Senha);

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Senha))
            {
                MessageBox.Show("Há campos obrigatórios vazios :(", "Alerta");
                return;
            }

            if (!validacao_email_login || !validacao_senha_login)
            {
                MessageBox.Show("Formato de e-mail ou senha inválido.", "Erro");
                return;
            }

            Database db = new Database();

            if (db.OpenConnection())
            {
                try
                {
                    string query = "SELECT id, senha FROM usuarios WHERE email = @Email";

                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@Email", Email);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32("id");
                                string senhaHash = reader.GetString("senha");

                                bool senhaValida = BCrypt.Net.BCrypt.EnhancedVerify(Senha, senhaHash);

                                if (senhaValida)
                                {
                                    MessageBox.Show("Login realizado com sucesso!", "Sucesso");
                                    this.Hide();

                                    var telaPrincipal = new TelaPrincipalAdministrador(userId);
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
                                MessageBox.Show("E-mail não encontrado.", "Erro");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao verificar login: " + ex.Message);
                }
                finally
                {
                    db.CloseConnection();
                }
            }
            else
            {
                MessageBox.Show("Erro ao conectar ao banco de dados.", "Erro");
            }
        }





        private void label1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Deu certo"); ;
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
    }
}
