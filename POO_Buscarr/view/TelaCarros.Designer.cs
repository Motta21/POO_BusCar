namespace POO_Buscarr
{
    partial class TelaCarros
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvCarros;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.TextBox txtRenavam;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.Label lblRenavam;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvCarros = new System.Windows.Forms.DataGridView();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.txtRenavam = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.lblModelo = new System.Windows.Forms.Label();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.lblRenavam = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCarros)).BeginInit();
            this.SuspendLayout();

            // dgvCarros
            this.dgvCarros.AllowUserToAddRows = false;
            this.dgvCarros.AllowUserToDeleteRows = false;
            this.dgvCarros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "Id", HeaderText = "ID", Width = 50 },
                new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "Modelo", HeaderText = "Modelo", Width = 180 },
                new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "Placa", HeaderText = "Placa", Width = 120 },
                new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "Renavam", HeaderText = "Renavam", Width = 150 },
                new System.Windows.Forms.DataGridViewTextBoxColumn() { Name = "Status", HeaderText = "Status", Width = 100 }
            });
            this.dgvCarros.Location = new System.Drawing.Point(12, 12);
            this.dgvCarros.MultiSelect = false;
            this.dgvCarros.Name = "dgvCarros";
            this.dgvCarros.ReadOnly = true;
            this.dgvCarros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarros.Size = new System.Drawing.Size(700, 250);
            this.dgvCarros.TabIndex = 0;
            this.dgvCarros.SelectionChanged += new System.EventHandler(this.dgvCarros_SelectionChanged);

            // lblModelo
            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(12, 280);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(51, 17);
            this.lblModelo.TabIndex = 1;
            this.lblModelo.Text = "Modelo";

            // txtModelo
            this.txtModelo.Location = new System.Drawing.Point(70, 277);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(180, 22);
            this.txtModelo.TabIndex = 2;

            // lblPlaca
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Location = new System.Drawing.Point(270, 280);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(43, 17);
            this.lblPlaca.TabIndex = 3;
            this.lblPlaca.Text = "Placa";

            // txtPlaca
            this.txtPlaca.Location = new System.Drawing.Point(320, 277);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(120, 22);
            this.txtPlaca.TabIndex = 4;

            // lblRenavam
            this.lblRenavam.AutoSize = true;
            this.lblRenavam.Location = new System.Drawing.Point(460, 280);
            this.lblRenavam.Name = "lblRenavam";
            this.lblRenavam.Size = new System.Drawing.Size(64, 17);
            this.lblRenavam.TabIndex = 5;
            this.lblRenavam.Text = "Renavam";

            // txtRenavam
            this.txtRenavam.Location = new System.Drawing.Point(530, 277);
            this.txtRenavam.Name = "txtRenavam";
            this.txtRenavam.Size = new System.Drawing.Size(150, 22);
            this.txtRenavam.TabIndex = 6;

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 320);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 17);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status";

            // cmbStatus
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
                "Funcionando",
                "Ocioso",
                "Estragado"});
            this.cmbStatus.Location = new System.Drawing.Point(70, 317);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(180, 24);
            this.cmbStatus.TabIndex = 8;

            // btnAdicionar
            this.btnAdicionar.Location = new System.Drawing.Point(270, 310);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(100, 35);
            this.btnAdicionar.TabIndex = 9;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);

            // btnEditar
            this.btnEditar.Location = new System.Drawing.Point(380, 310);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 35);
            this.btnEditar.TabIndex = 10;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            // btnExcluir
            this.btnExcluir.Location = new System.Drawing.Point(490, 310);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(100, 35);
            this.btnExcluir.TabIndex = 11;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            // TelaCarros (Form)
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 360);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtRenavam);
            this.Controls.Add(this.lblRenavam);
            this.Controls.Add(this.txtPlaca);
            this.Controls.Add(this.lblPlaca);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.dgvCarros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TelaCarros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciamento de Carros";

            ((System.ComponentModel.ISupportInitialize)(this.dgvCarros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
