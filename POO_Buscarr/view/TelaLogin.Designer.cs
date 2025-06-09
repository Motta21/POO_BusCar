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
            this.btnFazerLogin = new System.Windows.Forms.Button();
            this.campoEmailLogin = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnIrCadastro = new System.Windows.Forms.Button();
            this.campoSenhaLogin = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFazerLogin
            // 
            this.btnFazerLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnFazerLogin.FlatAppearance.BorderSize = 0;
            this.btnFazerLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFazerLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFazerLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFazerLogin.ForeColor = System.Drawing.Color.Transparent;
            this.btnFazerLogin.Location = new System.Drawing.Point(1060, 737);
            this.btnFazerLogin.Name = "btnFazerLogin";
            this.btnFazerLogin.Size = new System.Drawing.Size(437, 90);
            this.btnFazerLogin.TabIndex = 2;
            this.btnFazerLogin.UseVisualStyleBackColor = false;
            this.btnFazerLogin.Click += new System.EventHandler(this.btnFazerLogin_Click);
            // 
            // campoEmailLogin
            // 
            this.campoEmailLogin.BackColor = System.Drawing.SystemColors.Window;
            this.campoEmailLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.campoEmailLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.campoEmailLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoEmailLogin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.campoEmailLogin.Location = new System.Drawing.Point(967, 416);
            this.campoEmailLogin.Name = "campoEmailLogin";
            this.campoEmailLogin.Size = new System.Drawing.Size(623, 73);
            this.campoEmailLogin.TabIndex = 5;
            this.campoEmailLogin.TextChanged += new System.EventHandler(this.campoEmailLogin_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(949, 649);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(259, 41);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnIrCadastro
            // 
            this.btnIrCadastro.BackColor = System.Drawing.Color.Transparent;
            this.btnIrCadastro.FlatAppearance.BorderSize = 0;
            this.btnIrCadastro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnIrCadastro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnIrCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIrCadastro.ForeColor = System.Drawing.Color.Transparent;
            this.btnIrCadastro.Location = new System.Drawing.Point(1060, 917);
            this.btnIrCadastro.Name = "btnIrCadastro";
            this.btnIrCadastro.Size = new System.Drawing.Size(437, 40);
            this.btnIrCadastro.TabIndex = 8;
            this.btnIrCadastro.UseVisualStyleBackColor = false;
            this.btnIrCadastro.Click += new System.EventHandler(this.button1_Click);
            // 
            // campoSenhaLogin
            // 
            this.campoSenhaLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.campoSenhaLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.campoSenhaLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.campoSenhaLogin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.campoSenhaLogin.Location = new System.Drawing.Point(967, 552);
            this.campoSenhaLogin.Name = "campoSenhaLogin";
            this.campoSenhaLogin.Size = new System.Drawing.Size(623, 73);
            this.campoSenhaLogin.TabIndex = 9;
            this.campoSenhaLogin.TextChanged += new System.EventHandler(this.campoSenhaLogin_TextChanged);
            // 
            // TelaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::POO_Buscarr.Properties.Resources.Tela_de_Login;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.campoSenhaLogin);
            this.Controls.Add(this.btnIrCadastro);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.campoEmailLogin);
            this.Controls.Add(this.btnFazerLogin);
            this.Name = "TelaLogin";
            this.Text = "TelaLogin";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnFazerLogin;
        private TextBox campoEmailLogin;
        private PictureBox pictureBox1;
        private Button btnIrCadastro;
        private TextBox campoSenhaLogin;
    }
}

