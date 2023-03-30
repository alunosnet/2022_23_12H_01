using Glova_MOD15.Cliente;
using M15_TrabalhoModelo_2022_23;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Glova_MOD15.Prestador
{
    public partial class f_prestador : Form
    {
        string fotografia;
        BaseDados bd;
        int nprestador_escolhido;

        int NrRegistosPorPagina = 10;

        int nrlinhas, nrpagina;
        public f_prestador(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            cmbTipo.Items.Clear();
            lblNenhumPrest.Visible = false;
            btnApagar.Enabled = false;
            btnCancelar.Visible = false;
            btnEditar.Enabled = false;
            AtualizaNrPaginas();
            AtualizarGrelha();

            cmbTipo.Items.Add("Entrega de Comida");
            cmbTipo.Items.Add("Manutenção");
            cmbTipo.Items.Add("Taxi");
        }
        void AtualizaNrPaginas()
        {
            cmbPag.Items.Clear();
            int nprestadores = prestador.NrRegistos(bd);
            int nrPaginas = (int)Math.Ceiling(nprestadores / (float)NrRegistosPorPagina);
            for (int i = 1; i <= nrPaginas; i++)
                cmbPag.Items.Add(i);
            
            if (cmbPag.Items.Count == 0)
                cmbPag.Items.Add(1);
            cmbPag.SelectedIndex = 0;
        }

        void ApagarRegisto()
        {
            if (nprestador_escolhido < 1)
            {
                MessageBox.Show("Tem de selecionar um prestador primeiro. Clique com o botão esquerdo");
                return;
            }
            // Confirmar
            if (MessageBox.Show("Tem a certeza que pretende apagar o prestador selecionado?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Apagar da bd
                prestador.ApagarCliente(nprestador_escolhido, bd);
                AtualizarGrelha();
            }
        }
        void MostrarBtn()
        {
            btnApagar.Enabled = true;
            btnCancelar.Visible = true;
            btnEditar.Enabled = true;
            btnGuardar.Enabled = false;
        }
        private void LimparForm()
        {
            txtNome.Text = "";
            pbFotografia.Image = null;
            fotografia = "";
            dtpContrato.Value = DateTime.Now;
            txtTel.Text = "";
        }
        void AtualizarGrelha()
        {
            dgvPrestador.AllowUserToAddRows = false;
            dgvPrestador.AllowUserToDeleteRows = false;
            dgvPrestador.ReadOnly = true;
            //dgvPrestador.DataSource = prestador.ListarTodos(bd);

            if (cmbPag.SelectedIndex == -1)
                dgvPrestador.DataSource = prestador.ListarTodos(bd);
            else
            {
                //Paginação
                int nrpagina = cmbPag.SelectedIndex + 1;
                int primeiroregisto = (nrpagina - 1) * NrRegistosPorPagina + 1;
                int ultimoregisto = primeiroregisto + NrRegistosPorPagina - 1;
                dgvPrestador.DataSource = prestador.ListarTodos(bd, primeiroregisto, ultimoregisto);
            }

            if (dgvPrestador.RowCount == 0)
            {
                btnImprimir.Enabled = false;
            }
            else 
            { 
                btnImprimir.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnApagar.Enabled = false;
            btnCancelar.Visible = false;
            btnEditar.Enabled = false;

            LimparForm();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            string nome = txtNome.Text;
            nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
            if (nome == "" || nome.Length < 3 || nome.Length > 40)
            {
                errorProvider1.SetError(txtNome, "O nome está incorreto");
                txtNome.Focus();
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
            else if(cmbTipo.SelectedIndex == 2)
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
            

            DateTime Data_Cont = dtpContrato.Value;
            if (Data_Cont > DateTime.Now)
            {
                errorProvider1.SetError(dtpContrato, "A data está įncorreta");
                dtpContrato.Focus();
                return;
            }

            string telefone = txtTel.Text;
            if (telefone == "" || telefone.Length != 9)
            {
                errorProvider1.SetError(txtTel, "O número de telefone está incorreto");
                txtTel.Focus();
                return;
            }

            if (String.IsNullOrEmpty(fotografia))
            {
                errorProvider1.SetError(pbFotografia, "Tem de selecionar uma fotografia");
                return;
            }

            ///////// FIM DA VALIDAÇÃO //////////

            prestador prest = new prestador(0, nome, tipo_sai, Data_Cont, Utils.ImagemParaVetor(fotografia), telefone, false);


            prest.Guardar(bd);

            LimparForm();

            AtualizarGrelha();
            AtualizaNrPaginas();
        }

        private void btnEscolher_Click(object sender, EventArgs e)
        {
            OpenFileDialog ficheiro = new OpenFileDialog();
            ficheiro.InitialDirectory = "c:\\";
            ficheiro.Filter = "Imagens |*.jpg;*.png | Todos os ficheiros |*.*";
            ficheiro.Multiselect = false;
            if (ficheiro.ShowDialog() == DialogResult.OK)
            {
                string temp = ficheiro.FileName;
                if (System.IO.File.Exists(temp))
                {
                    pbFotografia.Image = Image.FromFile(temp);
                    fotografia = temp;
                }
            }
        }

        private void dgvPrestador_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvPrestador.RowCount == 0)
            {

            }
            else
            {
                int linha = dgvPrestador.CurrentCell.RowIndex;
                if (linha == -1)
                {
                    return;
                }
                int nprestador = int.Parse(dgvPrestador.Rows[linha].Cells[0].Value.ToString());

                prestador prest = new prestador();
                prest.ProcurarPorNrPrestador(bd, nprestador);
                txtNome.Text = prest.nome;
                dtpContrato.Value = prest.data_contratado;
                txtTel.Text = prest.telefone;
                cmbTipo.Text = prest.tipo;

                string ficheiro = System.IO.Path.GetTempPath() + @"\imagem.jpg";
                Utils.VetorParaImagem(prest.fotografia, ficheiro);
                Image img;
                using (var bitmap = new Bitmap(ficheiro))
                {
                    img = new Bitmap(bitmap);
                    pbFotografia.Image = img;
                }

                nprestador_escolhido = nprestador;
                //mostrar os botões para editar, apagar e cancelar
                MostrarBtn();
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

            string tipo = cmbTipo.Text;
            if (tipo == "")
            {
                errorProvider1.SetError(cmbTipo, "O tipo não existe");
                cmbTipo.Focus();
                return;
            }

            DateTime Data_Cont = dtpContrato.Value;
            if (Data_Cont > DateTime.Now)
            {
                errorProvider1.SetError(dtpContrato, "A data está įncorreta");
                dtpContrato.Focus();
                return;
            }

            string telefone = txtTel.Text;
            if (telefone == "" || telefone.Length != 9)
            {
                errorProvider1.SetError(txtTel, "O número de telefone está incorreto");
                txtTel.Focus();
                return;
            }

            if (pbFotografia == null)
            {
                if (String.IsNullOrEmpty(fotografia))
                {
                    errorProvider1.SetError(pbFotografia, "Tem de selecionar uma fotografia");
                    return;
                }
            }
           
            prestador prest = new prestador();
            prest.nprestador = nprestador_escolhido;
            prest.nome = txtNome.Text;
            prest.tipo = cmbTipo.Text;
            prest.telefone = txtTel.Text;
            prest.data_contratado = dtpContrato.Value;

            if (fotografia != null && fotografia != "")
            {
                //verificar se o ficheiro existe
                prest.fotografia = Utils.ImagemParaVetor(fotografia);
            }

            prest.Atualizar(bd);

            LimparForm();
            AtualizarGrelha();
        }

        private void cmbPag_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarGrelha();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            ApagarRegisto();
            AtualizaNrPaginas();
            btnCancelar_Click(sender, e);
        }
        private void txtPesq_TextChanged(object sender, EventArgs e)
        {
            dgvPrestador.DataSource = prestador.PesquisaPorNome(bd, txtPesq.Text);

            if(dgvPrestador.RowCount == 0)
            {
                lblNenhumPrest.Visible = true;
            }
            else
            {
                lblNenhumPrest.Visible = false;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }

        private void imprimeGrelha(System.Drawing.Printing.PrintPageEventArgs e, DataGridView grelha)
        {
            Graphics impressora = e.Graphics;
            Font tipoLetra = new Font("Arial", 10);
            Font tipoLetraMaior = new Font("Arial", 12, FontStyle.Bold);
            Brush cor = Brushes.Black;
            float mesquerda, mdireita, msuperior, minferior, linha, largura;
            Pen caneta = new Pen(cor, 2);

            //margens
            mesquerda = printDocument1.DefaultPageSettings.Margins.Left;
            mdireita = printDocument1.DefaultPageSettings.Bounds.Right - mesquerda;
            msuperior = printDocument1.DefaultPageSettings.Margins.Top;
            minferior = printDocument1.DefaultPageSettings.Bounds.Height - msuperior;
            largura = mdireita - mesquerda;
            //calcular as colunas da grelha
            float[] colunas = new float[grelha.Columns.Count];
            float lgrelha = 0;
            for (int i = 0; i < grelha.Columns.Count; i++)
                lgrelha += grelha.Columns[i].Width;
            colunas[0] = mesquerda;
            float total = mesquerda, larguraColuna;
            for (int i = 0; i < grelha.Columns.Count - 1; i++)
            {
                larguraColuna = grelha.Columns[i].Width / lgrelha;
                colunas[i + 1] = larguraColuna * largura + total;
                total = colunas[i + 1];
            }
            //cabeçalhos
            for (int i = 0; i < grelha.Columns.Count; i++)
            {
                impressora.DrawString(grelha.Columns[i].HeaderText, tipoLetraMaior, cor, colunas[i], msuperior);
            }
            linha = msuperior + tipoLetraMaior.Height;
            //ciclo para percorrer a grelha
            int l;
            for (l = nrlinhas; l < grelha.Rows.Count; l++)
            {
                //desenhar linha
                impressora.DrawLine(caneta, mesquerda, linha, mdireita, linha);
                //escrever uma linha
                for (int c = 0; c < grelha.Columns.Count; c++)
                {
                    impressora.DrawString(grelha.Rows[l].Cells[c].Value.ToString(),
                        tipoLetra, cor, colunas[c], linha);
                }
                //avançar para linha seguinte
                linha = linha + tipoLetra.Height;
                //verificar se o papel acabou
                if (linha + tipoLetra.Height > minferior)
                    break;
            }
            //tem mais páginas?
            if (l < grelha.Rows.Count)
            {
                nrlinhas = l + 1;
                e.HasMorePages = true;
            }
            //rodapé
            impressora.DrawString("12ºH - Página " + nrpagina.ToString(), tipoLetra, cor, mesquerda, minferior);
            //nr página
            nrpagina++;
            //linhas
            //linha superior
            impressora.DrawLine(caneta, mesquerda, msuperior, mdireita, msuperior);
            //linha inferior
            impressora.DrawLine(caneta, mesquerda, linha, mdireita, linha);
            //colunas
            for (int c = 0; c < colunas.Length; c++)
            {
                impressora.DrawLine(caneta, colunas[c], msuperior, colunas[c], linha);
            }
            //linha lado direito
            impressora.DrawLine(caneta, mdireita, msuperior, mdireita, linha);
        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            imprimeGrelha(e, dgvPrestador);
        }
    }
}
