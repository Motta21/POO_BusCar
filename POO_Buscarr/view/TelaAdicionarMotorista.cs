using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POO_Buscarr.controller;
using POO_Buscarr.database;
using POO_Buscarr.model;

namespace POO_Buscarr.view
{
    public partial class TelaAdicionarMotorista : Form
    {
        private readonly Database _database;
        private readonly Action _callbackAtualizar;
        private readonly Motorista _motorista;

        public TelaAdicionarMotorista(Database database, Action callbackAtualizar, Motorista motorista = null)
        {
            InitializeComponent();
            _database = database;
            _callbackAtualizar = callbackAtualizar;
            _motorista = motorista;

            if (_motorista != null)
            {
                Text = "Editar Motorista";
                btnSalvar.Text = "Salvar Alterações";
                txtSenha.Visible = false;
                lblSenha.Visible = false;
                PreencherCampos();
            }
            else
            {
                txtSenha.Visible = true;
                lblSenha.Visible = true;
            }
        }

        private void PreencherCampos()
        {
            try
            {
                var motoristaAtualizado = ObterMotoristaDoBanco(_motorista.Id);
                if (motoristaAtualizado != null)
                {
                    txtNome.Text = motoristaAtualizado.Nome;
                    txtEmail.Text = motoristaAtualizado.Email;
                    txtCPF.Text = motoristaAtualizado.CPF;
                    txtCNH.Text = motoristaAtualizado.CNH;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar dados atualizados: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Motorista ObterMotoristaDoBanco(int id)
        {
            try
            {
                _database.OpenConnection();
                string query = @"SELECT u.id, u.nome, u.email, u.cpf, m.cnh 
                               FROM usuarios u 
                               JOIN motorista m ON u.id = m.id 
                               WHERE u.id = @id";

                using (var cmd = new MySqlCommand(query, _database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Motorista
                            {
                                Id = reader.GetInt32("id"),
                                Nome = reader.GetString("nome"),
                                Email = reader.GetString("email"),
                                CPF = reader.GetString("cpf"),
                                CNH = reader.GetString("cnh")
                            };
                        }
                    }
                }
            }
            finally
            {
                _database.CloseConnection();
            }
            return null;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            var userController = new UserController(_database);

            try
            {
                if (_motorista == null)
                {
                    // Adicionar novo motorista com tipoUser = 2
                    int userId = userController.AddUser(
                        txtNome.Text,
                        txtEmail.Text,
                        txtSenha.Text,
                        txtCPF.Text,
                        2 // Definindo explicitamente tipoUser como 2 (motorista)
                    );

                    if (userId > 0)
                    {
                        bool success = userController.AddDriverUser(userId, txtCNH.Text);
                        if (success)
                        {
                            MessageBox.Show("Motorista cadastrado com sucesso!", "Sucesso",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _callbackAtualizar?.Invoke();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Motorista criado, mas houve um erro ao associar a CNH.", "Aviso",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falha ao criar usuário motorista.", "Erro",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Editar motorista existente
                    bool userUpdated = AtualizarUsuario(_motorista.Id, txtNome.Text, txtEmail.Text);
                    bool cnhUpdated = AtualizarCNH(_motorista.Id, txtCNH.Text);

                    if (userUpdated || cnhUpdated)
                    {
                        MessageBox.Show("Motorista atualizado com sucesso!", "Sucesso",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _callbackAtualizar?.Invoke();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Nenhum dado foi alterado.", "Aviso",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                string mensagem = ex.Message.Contains("cpf") ? "Já existe um motorista com este CPF." :
                                  ex.Message.Contains("cnh") ? "Já existe um motorista com esta CNH." :
                                  "Já existe um motorista com estes dados.";

                MessageBox.Show(mensagem, "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar motorista: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AtualizarUsuario(int id, string nome, string email)
        {
            try
            {
                _database.OpenConnection();
                string query = "UPDATE usuarios SET nome = @nome, email = @email WHERE id = @id";

                using (var cmd = new MySqlCommand(query, _database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@id", id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar usuário: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                _database.CloseConnection();
            }
        }

        private bool AtualizarCNH(int id, string cnh)
        {
            try
            {
                _database.OpenConnection();
                string query = "UPDATE motorista SET cnh = @cnh WHERE id = @id";

                using (var cmd = new MySqlCommand(query, _database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@cnh", cnh);
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar CNH: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                _database.CloseConnection();
            }
        }

        private bool ValidarCampos()
        {
            // Validação do Nome
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome do motorista.", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validação do Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Informe o e-mail do motorista.", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Email_controller.IsValid(txtEmail.Text))
            {
                MessageBox.Show("Informe um e-mail válido.", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validação da Senha (apenas para novo cadastro)
            if (_motorista == null)
            {
                if (string.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    MessageBox.Show("Informe a senha do motorista.", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!Password_controller.Verify(txtSenha.Text))
                {
                    MessageBox.Show("A senha deve conter:\n- Mínimo 8 caracteres\n- Pelo menos 1 letra maiúscula\n- Pelo menos 1 letra minúscula\n- Pelo menos 1 número",
                                  "Senha Inválida",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return false;
                }
            }

            // Validação do CPF
            if (string.IsNullOrWhiteSpace(txtCPF.Text))
            {
                MessageBox.Show("Informe o CPF do motorista.", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!CPFController.ValidateCpf(txtCPF.Text))
            {
                MessageBox.Show("CPF inválido.", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validação da CNH
            if (string.IsNullOrWhiteSpace(txtCNH.Text))
            {
                MessageBox.Show("Informe a CNH do motorista.", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!CNHController.ValidateCnh(txtCNH.Text))
            {
                MessageBox.Show("CNH inválida.", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            if (_motorista == null) // Apenas para novos cadastros
            {
                if (!string.IsNullOrEmpty(txtSenha.Text) && !Password_controller.Verify(txtSenha.Text))
                {
                    txtSenha.BackColor = Color.LightPink;
                    lblSenha.Text = "Senha (Requisitos não atendidos)";
                    lblSenha.ForeColor = Color.Red;
                }
                else
                {
                    txtSenha.BackColor = Color.White;
                    lblSenha.Text = "Senha";
                    lblSenha.ForeColor = SystemColors.ControlText;
                }
            }
        }
    }
}