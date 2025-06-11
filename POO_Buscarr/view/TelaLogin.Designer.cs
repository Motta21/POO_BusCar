using System.Drawing;
using System.Windows.Forms;

namespace POO_Buscarr
{
    partial class TelaLogin
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.campoEmailLogin = new System.Windows.Forms.TextBox();
            this.btnIrCadastro = new System.Windows.Forms.Button();
            this.campoSenhaLogin = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFazerLogin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // campoEmailLogin
            // 
            this.campoEmailLogin.BackColor = System.Drawing.SystemColors.Window;
            this.campoEmailLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.campoEmailLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.campoEmailLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoEmailLogin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.campoEmailLogin.Location = new System.Drawing.Point(1327, 450);
            this.campoEmailLogin.Margin = new System.Windows.Forms.Padding(4);
            this.campoEmailLogin.Name = "campoEmailLogin";
            this.campoEmailLogin.Size = new System.Drawing.Size(831, 73);
            this.campoEmailLogin.TabIndex = 5;
            this.campoEmailLogin.TextChanged += new System.EventHandler(this.campoEmailLogin_TextChanged_1);
            // 
            // btnIrCadastro
            // 
            this.btnIrCadastro.BackColor = System.Drawing.Color.Transparent;
            this.btnIrCadastro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIrCadastro.FlatAppearance.BorderSize = 0;
            this.btnIrCadastro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnIrCadastro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnIrCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIrCadastro.ForeColor = System.Drawing.Color.Transparent;
            this.btnIrCadastro.Location = new System.Drawing.Point(1420, 1135);
            this.btnIrCadastro.Margin = new System.Windows.Forms.Padding(4);
            this.btnIrCadastro.Name = "btnIrCadastro";
            this.btnIrCadastro.Size = new System.Drawing.Size(548, 42);
            this.btnIrCadastro.TabIndex = 8;
            this.btnIrCadastro.UseVisualStyleBackColor = false;
            this.btnIrCadastro.Click += new System.EventHandler(this.btnIrCadastro_Click_1);
            // 
            // campoSenhaLogin
            // 
            this.campoSenhaLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.campoSenhaLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.campoSenhaLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.campoSenhaLogin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.campoSenhaLogin.Location = new System.Drawing.Point(1327, 724);
            this.campoSenhaLogin.Margin = new System.Windows.Forms.Padding(4);
            this.campoSenhaLogin.Name = "campoSenhaLogin";
            this.campoSenhaLogin.Size = new System.Drawing.Size(831, 73);
            this.campoSenhaLogin.TabIndex = 9;
            this.campoSenhaLogin.UseSystemPasswordChar = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(1327, 853);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(345, 47);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnFazerLogin
            // 
            this.btnFazerLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnFazerLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFazerLogin.FlatAppearance.BorderSize = 0;
            this.btnFazerLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFazerLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFazerLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFazerLogin.ForeColor = System.Drawing.Color.Transparent;
            this.btnFazerLogin.Location = new System.Drawing.Point(1411, 971);
            this.btnFazerLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnFazerLogin.Name = "btnFazerLogin";
            this.btnFazerLogin.Size = new System.Drawing.Size(583, 109);
            this.btnFazerLogin.TabIndex = 2;
            this.btnFazerLogin.UseVisualStyleBackColor = false;
            this.btnFazerLogin.Click += new System.EventHandler(this.btnFazerLogin_Click);
            // 
            // TelaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::POO_Buscarr.Properties.Resources.TelaLoginAtualizada;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.campoSenhaLogin);
            this.Controls.Add(this.btnIrCadastro);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.campoEmailLogin);
            this.Controls.Add(this.btnFazerLogin);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TelaLogin";
            this.Text = "TelaLogin";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox campoEmailLogin;
        private Button btnIrCadastro;
        private TextBox campoSenhaLogin;
        private PictureBox pictureBox1;
        private Button btnFazerLogin;
    }
}

