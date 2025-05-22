namespace POO_Buscarr.view
{
    partial class TelaDigitarCnpj
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
            this.campoCnpjCadastro = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // campoCnpjCadastro
            // 
            this.campoCnpjCadastro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.campoCnpjCadastro.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.campoCnpjCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.campoCnpjCadastro.ForeColor = System.Drawing.SystemColors.WindowText;
            this.campoCnpjCadastro.Location = new System.Drawing.Point(967, 489);
            this.campoCnpjCadastro.Name = "campoCnpjCadastro";
            this.campoCnpjCadastro.Size = new System.Drawing.Size(619, 73);
            this.campoCnpjCadastro.TabIndex = 8;
            this.campoCnpjCadastro.TextChanged += new System.EventHandler(this.campoCnpjCadastro_TextChanged);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.ForeColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.Location = new System.Drawing.Point(1061, 709);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(437, 90);
            this.btnConfirmar.TabIndex = 9;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // TelaDigitarCnpj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::POO_Buscarr.Properties.Resources.TelaDigiteCnpj;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.campoCnpjCadastro);
            this.Name = "TelaDigitarCnpj";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox campoCnpjCadastro;
        private System.Windows.Forms.Button btnConfirmar;
    }
}