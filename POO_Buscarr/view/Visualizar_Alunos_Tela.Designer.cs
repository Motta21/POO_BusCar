using System;

namespace POO_Buscarr.view
{
    partial class Visualizar_Alunos_Tela
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.painelTopo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Sair_out = new System.Windows.Forms.Button();
            this.painelTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // painelTopo
            // 
            this.painelTopo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.painelTopo.Controls.Add(this.lblTitulo);
            this.painelTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.painelTopo.Location = new System.Drawing.Point(0, 0);
            this.painelTopo.Name = "painelTopo";
            this.painelTopo.Size = new System.Drawing.Size(1904, 80);
            this.painelTopo.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(316, 45);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "🎓 Visualizar Aluno\r\n";
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(84, 135);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1701, 702);
            this.dataGridView1.TabIndex = 2;
            // 
            // Sair_out
            // 
            this.Sair_out.Location = new System.Drawing.Point(1652, 875);
            this.Sair_out.Name = "Sair_out";
            this.Sair_out.Size = new System.Drawing.Size(133, 38);
            this.Sair_out.TabIndex = 3;
            this.Sair_out.Text = "Sair";
            this.Sair_out.UseVisualStyleBackColor = true;
            this.Sair_out.Click += new System.EventHandler(this.Sair_out_Click);
            // 
            // Visualizar_Alunos_Tela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.Sair_out);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.painelTopo);
            this.Name = "Visualizar_Alunos_Tela";
            this.Text = "Visualizar_Alunos_Tela";
            this.Load += new System.EventHandler(this.Visualizar_Alunos_Tela_Load);
            this.painelTopo.ResumeLayout(false);
            this.painelTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private void Visualizar_Alunos_Tela_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Panel painelTopo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Sair_out;
    }
}