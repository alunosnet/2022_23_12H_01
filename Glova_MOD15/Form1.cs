using Glova_MOD15.Cliente;
using Glova_MOD15.Prestador;
using Glova_MOD15.Servico;
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

namespace Glova_MOD15
{
    public partial class Form1 : Form
    {
        BaseDados bd = new BaseDados("Glova_BD");
        public Form1()
        {
            InitializeComponent();
        }

        public static string SetValueForText1 = "";

        private void btnServico_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (String.IsNullOrEmpty(txtEmailPesq.Text))
            {
                errorProvider1.SetError(txtEmailPesq, "Tem de colocar um email");
                txtEmailPesq.Focus();
                return;
            }
            else
            {
                dgvEmailPesq.DataSource = cliente.PesquisaPorEmail(bd, txtEmailPesq.Text);
                if (dgvEmailPesq.RowCount == 2)
                {
                    SetValueForText1 = txtEmailPesq.Text;

                    f_servico fservico = new f_servico(bd);
                    Email_Receber();
                    errorProvider1.Clear();
                    fservico.Show();
                    
                }
                else
                {
                    errorProvider1.SetError(txtEmailPesq, "Email Incorreto");
                    txtEmailPesq.Focus();
                    return;
                }
            }
                
        }

        public string Email_Receber()
        {
            return txtEmailPesq.Text;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void verServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_Servicos_Ver fver = new f_Servicos_Ver(bd);
            fver.Show();
        }

        private void novoAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_prestador fprestador = new f_prestador(bd);
            fprestador.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            f_cliente fcliente = new f_cliente(bd);
            fcliente.Show();
        }

        private void txtEmailPesq_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtEmailPesq.Text == "Email")
            {
                txtEmailPesq.Text = "";
            }
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtEmailPesq.Text == "")
            {
                txtEmailPesq.Text = "Email";
            }
        }
    }
}
