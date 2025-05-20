namespace POO_Buscarr.view
{
    partial class TelaDigitarCnh
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
            this.campoCnhCadastro = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // campoCnhCadastro
            // 
            this.campoCnhCadastro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.campoCnhCadastro.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.campoCnhCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F);
            this.campoCnhCadastro.ForeColor = System.Drawing.SystemColors.WindowText;
            this.campoCnhCadastro.Location = new System.Drawing.Point(967, 491);
            this.campoCnhCadastro.Name = "campoCnhCadastro";
            this.campoCnhCadastro.Size = new System.Drawing.Size(625, 73);
            this.campoCnhCadastro.TabIndex = 8;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.ForeColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.Location = new System.Drawing.Point(1061, 708);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(437, 90);
            this.btnConfirmar.TabIndex = 9;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // TelaDigitarCnh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::POO_Buscarr.Properties.Resources.TelaDigiteCnh;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.campoCnhCadastro);
            this.Name = "TelaDigitarCnh";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox campoCnhCadastro;
        private System.Windows.Forms.Button btnConfirmar;
    }
}