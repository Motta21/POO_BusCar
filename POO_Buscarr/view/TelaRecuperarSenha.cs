using POO_Buscarr.controller;
using POO_Buscarr.database;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_Buscarr.view
{
    public partial class TelaRecuperarSenha : Form
    {
        private readonly Database _database;
        private readonly PasswordRecoveryController _recoveryController;
        private string _userEmail;
        private bool _codeValidated = false;

        public TelaRecuperarSenha(Database database)
        {
            InitializeComponent();
            _database = database;
            _recoveryController = new PasswordRecoveryController(database);
        }

        private async void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            _userEmail = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(_userEmail) || !Email_controller.IsValid(_userEmail))
            {
                MessageBox.Show("Por favor, digite um email válido.", "Atenção",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool enviado = await _recoveryController.RequestPasswordRecovery(_userEmail);

                if (enviado)
                {
                    MessageBox.Show("Um código de 6 dígitos foi enviado para seu email.",
                                  "Código Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mostra os controles para inserir o código
                    lblCodigo.Visible = true;
                    txtCodigo.Visible = true;
                    btnValidarCodigo.Visible = true;

                    // Oculta os controles iniciais
                    lblEmail.Visible = false;
                    txtEmail.Visible = false;
                    btnEnviarCodigo.Visible = false;
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao enviar o código. Tente novamente.",
                                  "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnValidarCodigo_Click(object sender, EventArgs e)
        {
            string code = txtCodigo.Text.Trim();

            if (string.IsNullOrEmpty(code) || code.Length != 6)
            {
                MessageBox.Show("Por favor, digite o código de 6 dígitos recebido.",
                              "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_recoveryController.ValidateRecoveryCode(_userEmail, code))
            {
                _codeValidated = true;
                _recoveryController.MarkCodeAsUsed(_userEmail, code);

                MessageBox.Show("Código validado com sucesso! Agora você pode criar uma nova senha.",
                              "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Exibe campos para redefinir a senha
                lblNovaSenha.Visible = true;
                txtNovaSenha.Visible = true;
                lblConfirmarSenha.Visible = true;
                txtConfirmarSenha.Visible = true;
                btnAlterarSenha.Visible = true;

                // Oculta campos de código
                lblCodigo.Visible = false;
                txtCodigo.Visible = false;
                btnValidarCodigo.Visible = false;
            }
            else
            {
                MessageBox.Show("Código inválido ou expirado. Solicite um novo código.",
                              "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlterarSenha_Click(object sender, EventArgs e)
        {
            string newPassword = txtNovaSenha.Text;
            string confirmPassword = txtConfirmarSenha.Text;

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("As senhas não coincidem. Por favor, digite novamente.",
                              "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Password_controller.Verify(newPassword))
            {
                MessageBox.Show("A senha deve conter pelo menos 8 caracteres, incluindo letras maiúsculas, minúsculas e números.",
                              "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool atualizou = _recoveryController.UpdatePasswordWithRecovery(_userEmail, newPassword);

                if (atualizou)
                {
                    MessageBox.Show("Senha alterada com sucesso! Você já pode fazer login com a nova senha.",
                                  "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao alterar a senha. Tente novamente.",
                                  "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}",
                              "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
