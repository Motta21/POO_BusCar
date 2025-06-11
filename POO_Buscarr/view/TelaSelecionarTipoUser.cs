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
    public partial class TelaSelecionarTipoUser : Form
    {
        private int UserId;

        public TelaSelecionarTipoUser()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }


        private void btnSouAdministrador_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login como administrador");
            this.Hide();
            var telaDigitarCnpj = new TelaDigitarCnpj(UserId);
            telaDigitarCnpj.FormClosed += (s, args) => this.Close();
            telaDigitarCnpj.Show();
        }

        private void btnSouMotorista_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login como motorista");
            this.Hide();
            var telaDigitarCnh = new TelaDigitarCnh(UserId);
            telaDigitarCnh.FormClosed += (s, args) => this.Close();
            telaDigitarCnh.Show();
        }
    }
}
