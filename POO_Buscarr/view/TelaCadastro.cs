using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx;
using POO_Buscarr.controller;
using POO_Buscarr.database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace POO_Buscarr.view
{
    public partial class TelaCadastro: Form
    {
        public TelaCadastro()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnIrLogin_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            var telaLogin = new TelaLogin(); // Instancia o formulário de Cadastro
            telaLogin.FormClosed += (s, args) => this.Close(); // Fecha o formulário de Login quando o de Cadastro for fechado
            telaLogin.Show(); // Exibe o formulário de Cadastro
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            this.Hide();
            var telaLogin = new TelaLogin();
            telaLogin.FormClosed += (s, args) => this.Close();
            telaLogin.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
          

        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            //Dados

            string nome = campoNome.Text;
            string email = campoEmail.Text;
            string cpf = campoCPF.Text;
            string senha1 = campoSenha1.Text;
            string senha2 = campoSenha2.Text;

            //Verificação do preenchimento ||:D||

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(senha1) || string.IsNullOrEmpty(senha2))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
                return;
            }

            //Validações
            bool emailValido = Email_controller.IsValid(email);
            bool cpfValido = CPFController.ValidateCpf(cpf);
            bool senhaValida = Password_controller.Verify(senha1);
            bool senhasIguais = senha1 == senha2;

            // Verificar cada validação
            if (!emailValido)
            {
                MessageBox.Show("E-mail inválido.");
                return;
            }

            if (!cpfValido)
            {
                MessageBox.Show("CPF inválido.");
                return;
            }

            if (!senhaValida)
            {
                MessageBox.Show("A senha não atende aos critérios.");
                return;
            }

            if (!senhasIguais)
            {
                MessageBox.Show("As senhas não coincidem.");
                return;
            }


            var db = new POO_Buscarr.database.Database();
            var userController = new POO_Buscarr.controller.UserController(db);
            bool cadastrado = userController.AddUser(nome, email, senha1, cpf);


            if (cadastrado)
            {
                string mensagem = $"Usuário cadastrado com sucesso!\n\n" +
                                  $"Nome: {nome}\n" +
                                  $"E-mail: {email}\n" +
                                  $"CPF: {cpf}";
                MessageBox.Show(mensagem);

                if (checkBox1.Checked)
                {
                    TelaDigitarCnpj tela1 = new TelaDigitarCnpj();
                    tela1.Show();
                    this.Hide();
                }
                else if (checkBox2.Checked)
                {
                    TelaDigitarCnh tela2 = new TelaDigitarCnh();
                    tela2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Selecione uma das opções para continuar.");
                }
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar usuário. Verifique os dados e tente novamente.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                checkBox1.Checked = false;
        }


        private void campoEmail_TextChanged(object sender, EventArgs e)
        {
            string email = campoEmail.Text;
            bool emailValido = Email_controller.IsValid(email);


        }

        private void campoCPF_TextChanged(object sender, EventArgs e)
        {
            string cpf = campoCPF.Text;
            bool cpfValido = CPFController.ValidateCpf(cpf);

        }

        private void campoSenha1_TextChanged(object sender, EventArgs e)
        {
            string senha = campoSenha1.Text;
            bool senhaValida = Password_controller.Verify(senha); 

        }

        private void campoSenha2_TextChanged(object sender, EventArgs e)
        {
            string senha = campoSenha2.Text;
            bool senhaValida = Password_controller.Verify(senha); 
        
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }
           
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
        }
    }
}
