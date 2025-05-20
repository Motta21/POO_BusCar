using System.Drawing;
using System.Windows.Forms;

namespace POO_Buscarr.view
{
    partial class TelaCadastro
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
            this.campoNomeCadastro = new System.Windows.Forms.TextBox();
            this.checkTermos = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbBotao = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.campoEmailCadastro = new System.Windows.Forms.TextBox();
            this.campoCpfCadastro = new System.Windows.Forms.TextBox();
            this.campoSenha1Cadastro = new System.Windows.Forms.TextBox();
            this.campoSenha2Cadastro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBotao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // campoNomeCadastro
            // 
            this.campoNomeCadastro.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.campoNomeCadastro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.campoNomeCadastro.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.campoNomeCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.campoNomeCadastro.ForeColor = System.Drawing.SystemColors.WindowText;
            this.campoNomeCadastro.Location = new System.Drawing.Point(967, 220);
            this.campoNomeCadastro.Name = "campoNomeCadastro";
            this.campoNomeCadastro.Size = new System.Drawing.Size(611, 73);
            this.campoNomeCadastro.TabIndex = 7;
            // 
            // checkTermos
            // 
            this.checkTermos.Location = new System.Drawing.Point(979, 772);
            this.checkTermos.Name = "checkTermos";
            this.checkTermos.Size = new System.Drawing.Size(30, 30);
            this.checkTermos.TabIndex = 12;
            this.checkTermos.UseVisualStyleBackColor = true;
            this.checkTermos.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(1064, 827);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(440, 91);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pbBotao
            // 
            this.pbBotao.BackColor = System.Drawing.Color.Transparent;
            this.pbBotao.Location = new System.Drawing.Point(100, 100);
            this.pbBotao.Name = "pbBotao";
            this.pbBotao.Size = new System.Drawing.Size(100, 50);
            this.pbBotao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbBotao.TabIndex = 0;
            this.pbBotao.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(1095, 942);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(384, 35);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // campoEmailCadastro
            // 
            this.campoEmailCadastro.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.campoEmailCadastro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.campoEmailCadastro.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.campoEmailCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.campoEmailCadastro.ForeColor = System.Drawing.SystemColors.WindowText;
            this.campoEmailCadastro.Location = new System.Drawing.Point(967, 332);
            this.campoEmailCadastro.Name = "campoEmailCadastro";
            this.campoEmailCadastro.Size = new System.Drawing.Size(611, 73);
            this.campoEmailCadastro.TabIndex = 7;
            // 
            // campoCpfCadastro
            // 
            this.campoCpfCadastro.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.campoCpfCadastro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.campoCpfCadastro.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.campoCpfCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.campoCpfCadastro.ForeColor = System.Drawing.SystemColors.WindowText;
            this.campoCpfCadastro.Location = new System.Drawing.Point(967, 443);
            this.campoCpfCadastro.Name = "campoCpfCadastro";
            this.campoCpfCadastro.Size = new System.Drawing.Size(611, 73);
            this.campoCpfCadastro.TabIndex = 16;
            // 
            // campoSenha1Cadastro
            // 
            this.campoSenha1Cadastro.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.campoSenha1Cadastro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.campoSenha1Cadastro.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.campoSenha1Cadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.campoSenha1Cadastro.ForeColor = System.Drawing.SystemColors.WindowText;
            this.campoSenha1Cadastro.Location = new System.Drawing.Point(967, 560);
            this.campoSenha1Cadastro.Name = "campoSenha1Cadastro";
            this.campoSenha1Cadastro.Size = new System.Drawing.Size(611, 73);
            this.campoSenha1Cadastro.TabIndex = 17;
            // 
            // campoSenha2Cadastro
            // 
            this.campoSenha2Cadastro.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.campoSenha2Cadastro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.campoSenha2Cadastro.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.campoSenha2Cadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.campoSenha2Cadastro.ForeColor = System.Drawing.SystemColors.WindowText;
            this.campoSenha2Cadastro.Location = new System.Drawing.Point(967, 673);
            this.campoSenha2Cadastro.Name = "campoSenha2Cadastro";
            this.campoSenha2Cadastro.Size = new System.Drawing.Size(611, 73);
            this.campoSenha2Cadastro.TabIndex = 18;
            // 
            // TelaCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::POO_Buscarr.Properties.Resources.TelaCadastro;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.campoSenha2Cadastro);
            this.Controls.Add(this.campoSenha1Cadastro);
            this.Controls.Add(this.campoCpfCadastro);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.checkTermos);
            this.Controls.Add(this.campoEmailCadastro);
            this.Controls.Add(this.campoNomeCadastro);
            this.Name = "TelaCadastro";
            this.Text = "TelaCadastro";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBotao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox campoNomeCadastro;
        private System.Windows.Forms.Button checkTermos;
        private System.Windows.Forms.PictureBox pictureBox2;
        private PictureBox pbBotao;
        private PictureBox pictureBox1;
        private TextBox campoEmailCadastro;
        private TextBox campoCpfCadastro;
        private TextBox campoSenha1Cadastro;
        private TextBox campoSenha2Cadastro;
    }
}