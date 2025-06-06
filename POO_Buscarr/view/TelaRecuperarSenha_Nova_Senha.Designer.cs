namespace POO_Buscarr.view
{
    partial class TelaRecuperarSenha_Nova_Senha
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
            this.btn_redefinir_senha = new System.Windows.Forms.Button();
            this.lbl_redefinir_senha = new System.Windows.Forms.TextBox();
            this.lbl_confirmar_redefinir_senha = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_redefinir_senha
            // 
            this.btn_redefinir_senha.BackColor = System.Drawing.Color.Transparent;
            this.btn_redefinir_senha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_redefinir_senha.Location = new System.Drawing.Point(1058, 736);
            this.btn_redefinir_senha.Name = "btn_redefinir_senha";
            this.btn_redefinir_senha.Size = new System.Drawing.Size(442, 92);
            this.btn_redefinir_senha.TabIndex = 0;
            this.btn_redefinir_senha.UseVisualStyleBackColor = false;
            // 
            // lbl_redefinir_senha
            // 
            this.lbl_redefinir_senha.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_redefinir_senha.Location = new System.Drawing.Point(962, 429);
            this.lbl_redefinir_senha.Name = "lbl_redefinir_senha";
            this.lbl_redefinir_senha.Size = new System.Drawing.Size(634, 44);
            this.lbl_redefinir_senha.TabIndex = 1;
            // 
            // lbl_confirmar_redefinir_senha
            // 
            this.lbl_confirmar_redefinir_senha.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_confirmar_redefinir_senha.Location = new System.Drawing.Point(962, 569);
            this.lbl_confirmar_redefinir_senha.Name = "lbl_confirmar_redefinir_senha";
            this.lbl_confirmar_redefinir_senha.Size = new System.Drawing.Size(634, 44);
            this.lbl_confirmar_redefinir_senha.TabIndex = 2;
            // 
            // TelaRecuperarSenha_Nova_Senha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.BackgroundImage = global::POO_Buscarr.Properties.Resources.Criar_Nova_Senha;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.lbl_confirmar_redefinir_senha);
            this.Controls.Add(this.lbl_redefinir_senha);
            this.Controls.Add(this.btn_redefinir_senha);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "TelaRecuperarSenha_Nova_Senha";
            this.Text = "TelaRecuperarSenha_Nova_Senha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_redefinir_senha;
        private System.Windows.Forms.TextBox lbl_redefinir_senha;
        private System.Windows.Forms.TextBox lbl_confirmar_redefinir_senha;
    }
}