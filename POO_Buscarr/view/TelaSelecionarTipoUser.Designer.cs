namespace POO_Buscarr.view
{
    partial class TelaSelecionarTipoUser
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
            this.btnSouAdministrador = new System.Windows.Forms.PictureBox();
            this.btnSouMotorista = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnSouAdministrador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSouMotorista)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSouAdministrador
            // 
            this.btnSouAdministrador.BackColor = System.Drawing.Color.Transparent;
            this.btnSouAdministrador.Location = new System.Drawing.Point(1310, 496);
            this.btnSouAdministrador.Name = "btnSouAdministrador";
            this.btnSouAdministrador.Size = new System.Drawing.Size(310, 282);
            this.btnSouAdministrador.TabIndex = 1;
            this.btnSouAdministrador.TabStop = false;
            this.btnSouAdministrador.Click += new System.EventHandler(this.btnSouAdministrador_Click);
            // 
            // btnSouMotorista
            // 
            this.btnSouMotorista.BackColor = System.Drawing.Color.Transparent;
            this.btnSouMotorista.Location = new System.Drawing.Point(902, 496);
            this.btnSouMotorista.Name = "btnSouMotorista";
            this.btnSouMotorista.Size = new System.Drawing.Size(310, 282);
            this.btnSouMotorista.TabIndex = 2;
            this.btnSouMotorista.TabStop = false;
            this.btnSouMotorista.Click += new System.EventHandler(this.btnSouMotorista_Click);
            // 
            // TelaSelecionarTipoUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::POO_Buscarr.Properties.Resources.TelaSelecionarTipoUser;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.btnSouMotorista);
            this.Controls.Add(this.btnSouAdministrador);
            this.Name = "TelaSelecionarTipoUser";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.btnSouAdministrador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSouMotorista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox btnSouAdministrador;
        private System.Windows.Forms.PictureBox btnSouMotorista;
    }
}