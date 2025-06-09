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
                    string query = "SELECT COUNT(*) FROM admin WHERE email = @Email AND password = @Senha";


                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@Senha", Senha); ; // CUIDADO: senha deveria estar com hash

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Login realizado com sucesso!", "Sucesso");
                            this.Hide();

                            var TelaSelecionarTipoUser = new TelaSelecionarTipoUser();
                            TelaSelecionarTipoUser.FormClosed += (s, args) => this.Close();
                            TelaSelecionarTipoUser.Show();
                        }
                        else
                        {
                            MessageBox.Show("E-mail ou senha incorretos.", "Erro");
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

            this.Hide();
            var telaCadastro = new TelaCadastro();
            telaCadastro.FormClosed += (s, args) => this.Close();
            telaCadastro.Show();

        }

        private void campoEmailLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void campoSenhaLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
