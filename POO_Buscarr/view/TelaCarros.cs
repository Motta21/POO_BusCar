using Org.BouncyCastle.Asn1.Cmp;
using POO_Buscarr.controller;
using POO_Buscarr.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POO_Buscarr
{
    public partial class TelaCarros : Form
    {
        private readonly CarroController _carroController;

        public TelaCarros(string connectionString)
        {
            InitializeComponent();
            _carroController = new CarroController(connectionString);
            CarregarCarros();
        }

        private void CarregarCarros()
        {
            dgvCarros.Rows.Clear();
            List<Carro> carros = _carroController.ListarCarros();
            foreach (var carro in carros)
            {
                dgvCarros.Rows.Add(carro.Id, carro.Modelo, carro.Placa, carro.Renavam, carro.Status);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var carro = new Carro
            {
                Modelo = txtModelo.Text,
                Placa = txtPlaca.Text,
                Renavam = txtRenavam.Text,
                Status = cmbStatus.SelectedItem?.ToString()
            };
            _carroController.AdicionarCarro(carro);
            CarregarCarros();
            LimparCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCarros.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvCarros.SelectedRows[0].Cells["Id"].Value);

            var carro = new Carro
            {
                Id = id,
                Modelo = txtModelo.Text,
                Placa = txtPlaca.Text,
                Renavam = txtRenavam.Text,
                Status = cmbStatus.SelectedItem?.ToString()
            };

            _carroController.AtualizarCarro(carro);
            CarregarCarros();
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvCarros.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvCarros.SelectedRows[0].Cells["Id"].Value);
            _carroController.DeletarCarro(id);
            CarregarCarros();
            LimparCampos();
        }

        private void dgvCarros_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCarros.SelectedRows.Count == 0) return;

            var row = dgvCarros.SelectedRows[0];
            txtModelo.Text = row.Cells["Modelo"].Value.ToString();
            txtPlaca.Text = row.Cells["Placa"].Value.ToString();
            txtRenavam.Text = row.Cells["Renavam"].Value.ToString();
            cmbStatus.SelectedItem = row.Cells["Status"].Value.ToString();
        }

        private void LimparCampos()
        {
            txtModelo.Clear();
            txtPlaca.Clear();
            txtRenavam.Clear();
            cmbStatus.SelectedIndex = -1;
        }
    }
}
