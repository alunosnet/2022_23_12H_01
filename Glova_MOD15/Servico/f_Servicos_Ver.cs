using Glova_MOD15.Cliente;
using Glova_MOD15.Prestador;
using M15_TrabalhoModelo_2022_23;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glova_MOD15.Servico
{
    public partial class f_Servicos_Ver : Form
    {
        BaseDados bd;
        int nservico_escolhido;
        public f_Servicos_Ver(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            dgvServicos.DataSource = servico.PesquisaTodos(bd);
            AtualizarGrelha();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPedClie_Click(object sender, EventArgs e)
        {
            dgvServicos.DataSource = servico.PesquisaPorCliente(bd);
            btnFinalizar.Enabled = false;
            btnFinalizar.Visible = false;
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            dgvServicos.DataSource = servico.PesquisaTodos(bd);
            btnFinalizar.Enabled = false;
            btnFinalizar.Visible = true;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            int linha = dgvServicos.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int nservico = int.Parse(dgvServicos.Rows[linha].Cells[0].Value.ToString());

            servico serv = new servico();
            serv.nservico = nservico_escolhido;
            serv.ncliente = int.Parse(lblClie.Text);
            serv.nprestador = int.Parse(lblPrest.Text);
            serv.tipo = lblTipo.Text;
            serv.data_prestado = dateTimePicker1.Value;
            serv.estado = true;

            prestador prest = new prestador();
            prest.nprestador = int.Parse(lblPrest.Text);
            prest.AtualizarEstado(bd);
            

            serv.Atualizar(bd);
            AtualizarGrelha();
            btnFinalizar.Enabled = false;
        }

        private void dgvServicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvServicos.RowCount == 0)
            {

            }
            else
            {
                int linha = dgvServicos.CurrentCell.RowIndex;
                if (linha == -1)
                {
                    return;
                }
                int nservico = int.Parse(dgvServicos.Rows[linha].Cells[0].Value.ToString());
                nservico_escolhido = nservico;

                servico serv = new servico();
                serv.ProcurarPorNrServico(bd, nservico);
                lblPrest.Text = serv.nprestador.ToString();
                lblClie.Text = serv.ncliente.ToString();
                dateTimePicker1.Value = serv.data_prestado;
                lblPreco.Text = serv.preco.ToString();
                lblTipo.Text = serv.tipo;

                btnFinalizar.Enabled = true;
            }
        }

        private void f_Servicos_Ver_MouseClick(object sender, MouseEventArgs e)
        {
            btnFinalizar.Enabled = false;
        }

        void AtualizarGrelha()
        {
            dgvServicos.AllowUserToAddRows = false;
            dgvServicos.AllowUserToDeleteRows = false;
            dgvServicos.ReadOnly = true;
            dgvServicos.DataSource = servico.ListarTodos(bd);
        }

        private void btnVerRealizados_Click(object sender, EventArgs e)
        {
            dgvServicos.DataSource = servico.PesquisaRealizados(bd);
            btnFinalizar.Enabled = false;
            btnFinalizar.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvServicos.DataSource = servico.PesquisaRealizadosPrestador(bd);
            btnFinalizar.Enabled = false;
            btnFinalizar.Visible = false;
        }


    }
}
