using POO_Buscarr.model;
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
    public partial class TelaPrincipalAdministrador : Form
    {
    private int _userId;
    public TelaPrincipalAdministrador(int userId)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        _userId = userId;

    }

        private void TelaPrincipalAdministrador_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            TelaPassageiros telaPassageiros = new TelaPassageiros();
            telaPassageiros.ShowDialog(); // ShowDialog() para abrir como janela modal
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            try
            {
                // Cria uma instância da tela de veículos
                var telaVeiculos = new TelaVeiculos();

                // Define a tela como filha do formulário principal (se aplicável)
                telaVeiculos.MdiParent = this.MdiParent; // Opcional, se estiver usando MDI

                // Exibe a tela de forma não-modal (permite trabalhar com outras telas)
                telaVeiculos.Show();

                // Alternativa para exibir como modal (bloqueia outras janelas até fechar)
                // telaVeiculos.ShowDialog();
            }
            catch (Exception ex)
            {
                // Tratamento de erro genérico
                MessageBox.Show($"Erro ao abrir a tela de veículos:\n{ex.Message}",
                               "Erro",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }
    }
}
