using POO_Buscarr.controller;
using POO_Buscarr.model;
using System;
using System.Windows.Forms;

namespace POO_Buscarr.view
{
    public partial class TelaAdicionarAluno : Form
    {
        private readonly AlunoController _alunoController;
        private Aluno _alunoEdicao;
        private readonly Action _callbackAtualizacao;

        public TelaAdicionarAluno(string connectionString, Action callbackAtualizacao = null, Aluno alunoEdicao = null)
        {
            InitializeComponent();
            _alunoController = new AlunoController(connectionString);
            _callbackAtualizacao = callbackAtualizacao;
            _alunoEdicao = alunoEdicao;

            if (alunoEdicao != null)
            {
                Text = "Editar Aluno";
                btnSalvar.Text = "Atualizar";
                PreencherCamposEdicao();
            }
        }

        private void PreencherCamposEdicao()
        {
            txtNome.Text = _alunoEdicao.Nome;
            numIdade.Value = _alunoEdicao.Idade;
            txtEndereco.Text = _alunoEdicao.Endereco;
            txtEscola.Text = _alunoEdicao.Escola;
            txtResponsavel.Text = _alunoEdicao.NomeResponsavel;
            txtCpfResponsavel.Text = _alunoEdicao.CpfResponsavel;
            txtTelefoneResponsavel.Text = _alunoEdicao.TelefoneResponsavel;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                Aluno aluno = new Aluno(
                    txtNome.Text.Trim(),
                    (int)numIdade.Value,
                    txtEndereco.Text.Trim(),
                    txtEscola.Text.Trim(),
                    txtResponsavel.Text.Trim(),
                    txtCpfResponsavel.Text.Trim(),
                    txtTelefoneResponsavel.Text.Trim()
                );

                bool sucesso;

                if (_alunoEdicao == null)
                {
                    sucesso = _alunoController.AdicionarAluno(aluno);
                }
                else
                {
                    aluno.Id = _alunoEdicao.Id;
                    sucesso = _alunoController.AtualizarAluno(aluno);
                }

                if (sucesso)
                {
                    MessageBox.Show("Aluno salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _callbackAtualizacao?.Invoke();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Não foi possível salvar o aluno.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar aluno: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O nome do aluno é obrigatório.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numIdade.Value <= 0)
            {
                MessageBox.Show("A idade deve ser maior que zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtResponsavel.Text))
            {
                MessageBox.Show("O nome do responsável é obrigatório.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCpfResponsavel.Text))
            {
                MessageBox.Show("O CPF do responsável é obrigatório.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApenasNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}