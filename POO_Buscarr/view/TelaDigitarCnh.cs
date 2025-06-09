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
    public partial class TelaDigitarCnh: Form
    {
        public TelaDigitarCnh()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void campoCnhCadastro_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string cnh = campoCnhCadastro.Text;
            bool cnhValida = CNHController.ValidateCnh(cnh);
            if (cnhValida)
            {
                MessageBox.Show("CNH válida.");
            }
            else
            {
                MessageBox.Show("CNH inválida.");
            }
        }
    }
}
