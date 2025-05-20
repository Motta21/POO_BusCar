using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_Buscarr.view
{
    public partial class TelaCadastro: Form
    {
        public TelaCadastro()
        {
            InitializeComponent();
        }

        private void btnIrLogin_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            var telaLogin = new TelaLogin(); // Instancia o formulário de Cadastro
            telaLogin.FormClosed += (s, args) => this.Close(); // Fecha o formulário de Login quando o de Cadastro for fechado
            telaLogin.Show(); // Exibe o formulário de Cadastro
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

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
    }
}
