namespace POO_Buscarr.view
{
    partial class TelaAdicionarAluno
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtNome = new System.Windows.Forms.TextBox();
            this.numIdade = new System.Windows.Forms.NumericUpDown();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtEscola = new System.Windows.Forms.TextBox();
            this.txtResponsavel = new System.Windows.Forms.TextBox();
            this.txtCpfResponsavel = new System.Windows.Forms.TextBox();
            this.txtTelefoneResponsavel = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblIdade = new System.Windows.Forms.Label();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.lblEscola = new System.Windows.Forms.Label();
            this.lblResponsavel = new System.Windows.Forms.Label();
            this.lblCpf = new System.Windows.Forms.Label();
            this.lblTelefone = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.numIdade)).BeginInit();
            this.SuspendLayout();

            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(150, 20);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(300, 23);

            // 
            // numIdade
            // 
            this.numIdade.Location = new System.Drawing.Point(150, 60);
            this.numIdade.Name = "numIdade";
            this.numIdade.Size = new System.Drawing.Size(60, 23);

            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(150, 100);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(300, 23);

            // 
            // txtEscola
            // 
            this.txtEscola.Location = new System.Drawing.Point(150, 140);
            this.txtEscola.Name = "txtEscola";
            this.txtEscola.Size = new System.Drawing.Size(300, 23);

            // 
            // txtResponsavel
            // 
            this.txtResponsavel.Location = new System.Drawing.Point(150, 180);
            this.txtResponsavel.Name = "txtResponsavel";
            this.txtResponsavel.Size = new System.Drawing.Size(300, 23);

            // 
            // txtCpfResponsavel
            // 
            this.txtCpfResponsavel.Location = new System.Drawing.Point(150, 220);
            this.txtCpfResponsavel.Name = "txtCpfResponsavel";
            this.txtCpfResponsavel.Size = new System.Drawing.Size(200, 23);
            this.txtCpfResponsavel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ApenasNumeros_KeyPress);

            // 
            // txtTelefoneResponsavel
            // 
            this.txtTelefoneResponsavel.Location = new System.Drawing.Point(150, 260);
            this.txtTelefoneResponsavel.Name = "txtTelefoneResponsavel";
            this.txtTelefoneResponsavel.Size = new System.Drawing.Size(200, 23);
            this.txtTelefoneResponsavel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ApenasNumeros_KeyPress);

            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(150, 310);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 30);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(270, 310);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // 
            // Labels
            // 
            this.lblNome.Location = new System.Drawing.Point(30, 20);
            this.lblNome.Text = "Nome:";
            this.lblNome.AutoSize = true;

            this.lblIdade.Location = new System.Drawing.Point(30, 60);
            this.lblIdade.Text = "Idade:";
            this.lblIdade.AutoSize = true;

            this.lblEndereco.Location = new System.Drawing.Point(30, 100);
            this.lblEndereco.Text = "Endereço:";
            this.lblEndereco.AutoSize = true;

            this.lblEscola.Location = new System.Drawing.Point(30, 140);
            this.lblEscola.Text = "Escola:";
            this.lblEscola.AutoSize = true;

            this.lblResponsavel.Location = new System.Drawing.Point(30, 180);
            this.lblResponsavel.Text = "Responsável:";
            this.lblResponsavel.AutoSize = true;

            this.lblCpf.Location = new System.Drawing.Point(30, 220);
            this.lblCpf.Text = "CPF do Responsável:";
            this.lblCpf.AutoSize = true;

            this.lblTelefone.Location = new System.Drawing.Point(30, 260);
            this.lblTelefone.Text = "Telefone do Responsável:";
            this.lblTelefone.AutoSize = true;

            // 
            // TelaAdicionarAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 370);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.numIdade);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtEscola);
            this.Controls.Add(this.txtResponsavel);
            this.Controls.Add(this.txtCpfResponsavel);
            this.Controls.Add(this.txtTelefoneResponsavel);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblIdade);
            this.Controls.Add(this.lblEndereco);
            this.Controls.Add(this.lblEscola);
            this.Controls.Add(this.lblResponsavel);
            this.Controls.Add(this.lblCpf);
            this.Controls.Add(this.lblTelefone);
            this.Name = "TelaAdicionarAluno";
            this.Text = "Adicionar Aluno";

            ((System.ComponentModel.ISupportInitialize)(this.numIdade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.NumericUpDown numIdade;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtEscola;
        private System.Windows.Forms.TextBox txtResponsavel;
        private System.Windows.Forms.TextBox txtCpfResponsavel;
        private System.Windows.Forms.TextBox txtTelefoneResponsavel;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblIdade;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.Label lblEscola;
        private System.Windows.Forms.Label lblResponsavel;
        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.Label lblTelefone;
    }
}
