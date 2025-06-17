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
    public partial class TelaPerfilMotorista : Form
    {
        public TelaPerfilMotorista()
        {
            this.Text = "Perfil do Motorista";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Cabeçalho azul
            Panel header = new Panel();
            header.BackColor = Color.FromArgb(0, 102, 204); // Azul
            header.Dock = DockStyle.Top;
            header.Height = 80;

            Label titulo = new Label();
            titulo.Text = "Perfil do Motorista";
            titulo.ForeColor = Color.White;
            titulo.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            titulo.AutoSize = true;
            titulo.Location = new Point(20, 20);
            header.Controls.Add(titulo);
            this.Controls.Add(header);

            // Campos
            int startY = 100;
            int spacing = 50;

            string[] nomesCampos = { "Nome", "Email", "CPF", "CNH" };
            Label[] labels = new Label[nomesCampos.Length];
            TextBox[] textBoxes = new TextBox[nomesCampos.Length];

            for (int i = 0; i < nomesCampos.Length; i++)
            {
                labels[i] = new Label();
                labels[i].Text = nomesCampos[i] + ":";
                labels[i].Location = new Point(50, startY + i * spacing);
                labels[i].Size = new Size(100, 30);
                labels[i].Font = new Font("Segoe UI", 12);
                this.Controls.Add(labels[i]);

                textBoxes[i] = new TextBox();
                textBoxes[i].Location = new Point(160, startY + i * spacing);
                textBoxes[i].Size = new Size(500, 30);
                textBoxes[i].Font = new Font("Segoe UI", 11);
                this.Controls.Add(textBoxes[i]);
            }

            // Botão Voltar
            Button btnVoltar = new Button();
            btnVoltar.Text = "Voltar";
            btnVoltar.Size = new Size(100, 35);
            btnVoltar.Location = new Point(650, 400);
            btnVoltar.BackColor = Color.Gainsboro;
            btnVoltar.Click += (s, e) => { this.Close(); };
            this.Controls.Add(btnVoltar);
        }
    }
}

