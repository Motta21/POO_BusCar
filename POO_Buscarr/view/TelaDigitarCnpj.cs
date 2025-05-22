using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POO_Buscarr.controller;

namespace POO_Buscarr.view
{
    public partial class TelaDigitarCnpj: Form
    {
        public TelaDigitarCnpj()
        {
            InitializeComponent();
        }

        private void campoCnpjCadastro_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string cnpj = campoCnpjCadastro.Text;
            bool cnpjValido = CNPJController.ValidateCnpj(cnpj);
            if (cnpjValido)
            {
                MessageBox.Show("CNPJ válidO.");
            }
            else
            {
                MessageBox.Show("CNPJ inválidO.");
            }
        }
    }
}
