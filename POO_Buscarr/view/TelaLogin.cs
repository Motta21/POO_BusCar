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
    }
}
