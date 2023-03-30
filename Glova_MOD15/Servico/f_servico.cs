using Glova_MOD15.Cliente;
using Glova_MOD15.Prestador;
using M15_TrabalhoModelo_2022_23;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Glova_MOD15.Servico
{
    public partial class f_servico : Form
    {
        BaseDados bd;
        string valor_man;
        string valor_entrega;
        public f_servico(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;

            Random rd = new Random();
            int rand_num = rd.Next(100, 200);
            valor_man = rand_num.ToString();

            rand_num = rd.Next(100, 200);
            valor_entrega = rand_num.ToString();

            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Entrega de Comida");
            cmbTipo.Items.Add("Manutenção");
            cmbTipo.Items.Add("Taxi");
            cmbTipo.SelectedIndex = 0;

            lblEmail.Visible = false;
            lblEmail.Text = Form1.SetValueForText1;

            AtualizaCBCliente();
            cmbCliente.SelectedIndex = 0;

            AtualizaCBPrestadores();
            int combobox = cmbPrestador.Items.Count;
            if (combobox == 0)
            {
                cmbPrestador.Enabled = false;
                btnPrestar.Enabled = false;
            }
            else
            {
                cmbPrestador.Enabled = true;
                btnPrestar.Enabled = true;
                cmbPrestador.SelectedIndex = 0;
                txtPreco.Text = valor_entrega;
            }
        }

        private void AtualizaCBPrestadores()
        {
            
            errorProvider1.Clear();

            string tipo_sai = "";
                if (cmbTipo.SelectedIndex == 0)
                {
                    string tipo = "Entrega de Comida";
                    tipo_sai = tipo;
                }
                else if (cmbTipo.SelectedIndex == 1)
                {
                    string tipo = "Manutenção";
                    tipo_sai = tipo;
                }
                else if (cmbTipo.SelectedIndex == 2)
                {
                    string tipo = "Taxi";
                    tipo_sai = tipo;
                }
                else
                {

                    errorProvider1.SetError(cmbTipo, "O tipo Não existe");
                    cmbTipo.Focus();
                    return;

                }

                cmbPrestador.Items.Clear();
                DataTable dados = prestador.PesquisaPorTipo(bd, tipo_sai);
                foreach (DataRow dr in dados.Rows)
                {
                    prestador prest = new prestador();
                    prest.nprestador = int.Parse(dr["nprestador"].ToString());
                    prest.nome = dr["nome"].ToString();
                    txtPrestTel.Text = (prest.telefone = dr["telefone"].ToString());
                    cmbPrestador.Items.Add(prest);
                }
            
               
        }

        private void AtualizaCBCliente()
        {
            string email = lblEmail.Text;
            cmbCliente.Items.Clear();

            DataTable dados = cliente.PesquisaPorEmail(bd, email);
            foreach (DataRow dr in dados.Rows)
            {
                cliente clie = new cliente();
                clie.ncliente = int.Parse(dr["ncliente"].ToString());
                clie.nome = dr["nome"].ToString();
                cmbCliente.Items.Add(clie);
            }
        }
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaCBPrestadores();

            int combobox = cmbPrestador.Items.Count;
            if (combobox == 0)
            {
                cmbPrestador.Enabled = false;
                btnPrestar.Enabled = false;
                txtPrestTel.Text = "";
                txtPreco.Text = "";
            }
            else
            {
                cmbPrestador.Enabled = true;
                btnPrestar.Enabled = true;
                cmbPrestador.SelectedIndex = 0;

                if(cmbTipo.SelectedIndex == 2)
                {
                    txtPreco.Text = "50";
                }
                else if(cmbTipo.SelectedIndex == 1)
                {
                    txtPreco.Text = valor_entrega;
                }
                else
                {
                    txtPreco.Text = valor_man;
                }

            }
            
        }

        private void btnPrestar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            //validar o form
            if (cmbCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um cliente");
                return;
            }
            if (cmbPrestador.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um prestador");
                return;
            }
            if(cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um Tipo");
                return;
            }

            DateTime Data_Prest = dtpPrestado.Value;
            if (Data_Prest < DateTime.Now)
            {
                errorProvider1.SetError(dtpPrestado, "A data está įncorreta");
                dtpPrestado.Focus();
                return;
            }

            string tipo_sai = "";
            if (cmbTipo.SelectedIndex == 0)
            {
                string tipo = "Entrega de Comida";
                tipo_sai = tipo;
            }
            else if (cmbTipo.SelectedIndex == 1)
            {
                string tipo = "Manutenção";
                tipo_sai = tipo;
            }
            else if (cmbTipo.SelectedIndex == 2)
            {
                string tipo = "Taxi";
                tipo_sai = tipo;
            }

            cliente clie = cmbCliente.SelectedItem as cliente;
            prestador prest = cmbPrestador.SelectedItem as prestador;

            decimal preco = decimal.Parse(txtPreco.Text);

            servico serv = new servico(clie.ncliente, prest.nprestador, dtpPrestado.Value, tipo_sai, preco);


            serv.Adicionar(bd);

            AtualizaCBPrestadores();

            int combobox = cmbPrestador.Items.Count;
            if (combobox == 0)
            {
                cmbPrestador.Enabled = false;
                btnPrestar.Enabled = false;
                txtPreco.Text = "";
            }
            else
            {
                cmbPrestador.Enabled = true;
                btnPrestar.Enabled = true;
                cmbPrestador.SelectedIndex = 0;
                txtPreco.Text = valor_entrega;
            }
        }
    }
}
