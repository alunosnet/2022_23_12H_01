using Glova_MOD15.Prestador;
using M15_TrabalhoModelo_2022_23;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Glova_MOD15.Cliente
{
    public partial class f_cliente : Form
    {
        BaseDados bd;
        int ncliente_escolhido;
        string[] localidades = new string[] { "Armamar", "Carregal Do Sal", "Castro Daire", "Cinfães", "Cinfaes", "Lamego", "Mangualde", "Moimenta Da Beira", "Mortágua", "Mortagua", "Nelas", "Oliveira De Frades", "Penalva Do Castelo", "Penedono", "Resende", "Santa Comba Dão", "Santa Comba Dao", "São João Da Pesqueira", "Sao Joao Da Pesqueira", "São Pedro Do Sul", "Sao Pedro Do Sul", "Sátão", "Satao", "Sernancelhe", "Tabuaço", "Tabuaco", "Tarouca", "Tondela", "Vila Nova De Paiva", "Viseu", "Vouzela" };
        int NrRegistosPorPagina = 5;
        public f_cliente(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;

            lblNenhumPrest.Visible = false;
            btnApagar.Enabled = false;
            btnCancelar.Visible = false;
            btnEditar.Enabled = false;
            AtualizaNrPaginas();
            AtualizarGrelha();
        }
        void AtualizaNrPaginas()
        {
            cmbPag.Items.Clear();
            int nclientes = cliente.NrRegistos(bd);
            int nrPaginas = (int)Math.Ceiling(nclientes / (float)NrRegistosPorPagina);
            for (int i = 1; i <= nrPaginas; i++)
                cmbPag.Items.Add(i);

            // se não existirem livros
            if (cmbPag.Items.Count == 0)
                cmbPag.Items.Add(1);
            cmbPag.SelectedIndex = 0;
        }

        void AtualizarGrelha()
        {
            dgvCliente.AllowUserToAddRows = false;
            dgvCliente.AllowUserToDeleteRows = false;
            dgvCliente.ReadOnly = true;
            //dgvCliente.DataSource = cliente.ListarTodos(bd);

            if (cmbPag.SelectedIndex == -1)
                dgvCliente.DataSource = cliente.ListarTodos(bd);
            else
            {
                //Paginação
                int nrpagina = cmbPag.SelectedIndex + 1;
                int primeiroregisto = (nrpagina - 1) * NrRegistosPorPagina + 1;
                int ultimoregisto = primeiroregisto + NrRegistosPorPagina - 1;
                dgvCliente.DataSource = cliente.ListarTodos(bd, primeiroregisto, ultimoregisto);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            
            string nome = txtNome.Text;
            if (nome == "" || nome.Length < 3 || nome.Length > 40)
            {
                errorProvider1.SetError(txtNome, "O nome está incorreto");
                txtNome.Focus();
                return;
            }

            string localidade= txtLocalidade.Text;
            localidade = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(localidade.ToLower()); // Meter a primeira letra maiuscula e o resto minusculo
            if (Array.Exists(localidades, element => element == localidade) == false)
            {
                errorProvider1.SetError(txtLocalidade, "A localidade está incorreto");
                txtLocalidade.Focus();
                return;
            }

            string cod_postal = txtCodPostal.Text;
            if (cod_postal == "" || cod_postal.Length != 8 /*|| cod_postal != ""*/)
            {
                errorProvider1.SetError(txtCodPostal, "O codigo postal está incorreto");
                txtCodPostal.Focus();
                return;
            }


            string telefone = txtTel.Text;
            if (telefone == "" || telefone.Length != 9)
            {
                errorProvider1.SetError(txtTel, "O número de telefone está incorreto");
                txtTel.Focus();
                return;
            }

            string email = txtEmail.Text;
            if (email == "" || email.Contains("@") == false || email.Contains(".") == false)
            {
                errorProvider1.SetError(txtEmail, "O email está incorreto");
                txtEmail.Focus();
                return;
            }

            ///////// FIM DA VALIDAÇÃO //////////

            cliente clie = new cliente();

            clie.nome = nome;
            clie.localidade = localidade;
            clie.cod_postal = cod_postal;
            clie.telefone = telefone;
            clie.email = email;

            clie.Guardar(bd);

            LimparForm();

            AtualizarGrelha();
            AtualizaNrPaginas();
        }

        private void LimparForm()
        {
            txtNome.Text = "";
            txtCodPostal.Text = "";
            txtLocalidade.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnApagar.Enabled = false;
            btnCancelar.Visible = false;
            btnEditar.Enabled = false;

            LimparForm();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            ApagarRegisto();
            btnCancelar_Click(sender, e);
        }

        void MostrarBtn()
        {
            btnApagar.Enabled = true;
            btnCancelar.Visible = true;
            btnEditar.Enabled = true;
            btnGuardar.Enabled = false;
        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //selecionar e mostrar os dados do leitor
            if(dgvCliente.RowCount == 0)
            {

            }
            else
            {
                int linha = dgvCliente.CurrentCell.RowIndex;
                if (linha == -1)
                {
                    return;
                }
                int ncliente = int.Parse(dgvCliente.Rows[linha].Cells[0].Value.ToString());

                cliente clie = new cliente();
                clie.ProcurarPorNrCliente(bd, ncliente);
                txtNome.Text = clie.nome;
                txtCodPostal.Text = clie.cod_postal;
                txtLocalidade.Text = clie.localidade;
                txtTel.Text = clie.telefone;
                txtEmail.Text = clie.email;


                //Guardar o nleitor
                ncliente_escolhido = ncliente;
                //mostrar os botões para editar, apagar e cancelar
                MostrarBtn();
            }
            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ApagarRegisto()
        {
            if (ncliente_escolhido < 1)
            {
                MessageBox.Show("Tem de selecionar um cliente primeiro. Clique com o botão esquerdo");
                return;
            }
            // Confirmar
            if (MessageBox.Show("Tem a certeza que pretende apagar o cliente selecionado?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Apagar da bd
                cliente.ApagarCliente(ncliente_escolhido, bd);
                AtualizarGrelha();
                AtualizaNrPaginas();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            string nome = txtNome.Text;
            if (nome == "" || nome.Length < 3 || nome.Length > 40)
            {
                errorProvider1.SetError(txtNome, "O nome está incorreto");
                txtNome.Focus();
                return;
            }

            string localidade = txtLocalidade.Text;
            localidade = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(localidade.ToLower()); // Meter a primeira letra maiuscula e o resto minusculo
            if (Array.Exists(localidades, element => element == localidade) == false)
            {
                errorProvider1.SetError(txtLocalidade, "A localidade está incorreto");
                txtLocalidade.Focus();
                return;
            }

            string cod_postal = txtCodPostal.Text;
            if (cod_postal == "" || cod_postal.Length != 8 /*|| cod_postal != ""*/)
            {
                errorProvider1.SetError(txtCodPostal, "O codigo postal está incorreto");
                txtCodPostal.Focus();
                return;
            }


            string telefone = txtTel.Text;
            if (telefone == "" || telefone.Length != 9)
            {
                errorProvider1.SetError(txtTel, "O número de telefone está incorreto");
                txtTel.Focus();
                return;
            }

            string email = txtEmail.Text;
            if (email == "" || email.Contains("@") == false || email.Contains(".") == false)
            {
                errorProvider1.SetError(txtEmail, "O email está incorreto");
                txtEmail.Focus();
                return;
            }

            cliente clie = new cliente();

            clie.ncliente = ncliente_escolhido;
            clie.nome = nome;
            clie.localidade = localidade;
            clie.cod_postal = cod_postal;
            clie.telefone = telefone;
            clie.email = email;

            clie.Atualizar(bd);

            AtualizarGrelha();
            btnCancelar_Click(sender, e);
            
        }

        private void cmbPag_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarGrelha();
        }

        private void txtPesq_TextChanged(object sender, EventArgs e)
        {
            dgvCliente.DataSource = cliente.PesquisaPorNome(bd, txtPesq.Text);

            if (dgvCliente.RowCount == 0)
            {
                lblNenhumPrest.Visible = true;
            }
            else
            {
                lblNenhumPrest.Visible = false;
            }
        }
    }
}
