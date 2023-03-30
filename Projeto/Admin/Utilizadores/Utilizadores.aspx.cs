using Projeto.Classes;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Projeto.Admin.Utilizadores
{
    public partial class Utilizadores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            if(!IsPostBack)
            {
                dpTipo.Enabled = false;
            }
            ConfigurarGrid();
           
            AtualizarGrid();
            AtualizarDDTipo();
            
        }

        private void ConfigurarGrid()
        {
            gvUtilizador.AllowPaging = true;
            gvUtilizador.PageSize = 5;
            gvUtilizador.PageIndexChanging += GvUtilizador_PageIndexChanging;
        }

        private void GvUtilizador_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUtilizador.PageIndex = e.NewPageIndex;
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
                gvUtilizador.Columns.Clear();
                gvUtilizador.DataSource = null;
                gvUtilizador.DataBind();

                Utilizador utilizador = new Utilizador();
                DataTable dados;
                string nomepesq = txtPesquisa.Text;
                if (txtPesquisa.Text == "" || txtPesquisa.Text == null)
                {
                    dados = utilizador.ListaTodosUtilizadores();
                }
                else
                {
                    dados = utilizador.ListaTodosUtilizadoresNome(nomepesq);
                }

                gvUtilizador.DataSource = dados;
                gvUtilizador.AutoGenerateColumns = false;

                //remover
                DataColumn dcRemover = new DataColumn();
                dcRemover.ColumnName = "Remover";
                dcRemover.DataType = Type.GetType("System.String");
                dados.Columns.Add(dcRemover);
                //histórico
                DataColumn dcHistorico = new DataColumn();
                dcHistorico.ColumnName = "Historico";
                dcHistorico.DataType = Type.GetType("System.String");
                dados.Columns.Add(dcHistorico);

                //Formatação Gridview
                //remover
                HyperLinkField hlRemover = new HyperLinkField();
                hlRemover.HeaderText = "Remover";
                hlRemover.DataTextField = "Remover";    //columnname do datatable
                hlRemover.Text = "Remover";
                //RemoverUtilizador.aspx?id={0}
                hlRemover.DataNavigateUrlFormatString = "ApagarUtilizador.aspx?id={0}";
                hlRemover.DataNavigateUrlFields = new string[] { "id" };
                hlRemover.ControlStyle.CssClass = "btn btn-danger";
                gvUtilizador.Columns.Add(hlRemover);
                //histórico
                HyperLinkField hlHistorico = new HyperLinkField();
                hlHistorico.HeaderText = "Histórico";
                hlHistorico.DataTextField = "Historico";    //columnname do datatable
                hlHistorico.Text = "Histórico";
                hlHistorico.DataNavigateUrlFormatString = "HistoricoUtilizador.aspx?id={0}";
                hlHistorico.DataNavigateUrlFields = new string[] { "id" };
                hlHistorico.ControlStyle.CssClass = "btn btn-success";
                gvUtilizador.Columns.Add(hlHistorico);

                //id
                BoundField bfId = new BoundField();
                bfId.HeaderText = "Id";
                bfId.DataField = "id";
                bfId.Visible = false;
                gvUtilizador.Columns.Add(bfId);
                //email
                BoundField bfEmail = new BoundField();
                bfEmail.HeaderText = "Email";
                bfEmail.DataField = "email";
                gvUtilizador.Columns.Add(bfEmail);
                //nome
                BoundField bfNome = new BoundField();
                bfNome.HeaderText = "Nome";
                bfNome.DataField = "nome";
                gvUtilizador.Columns.Add(bfNome);
                //Morada
                BoundField bfMorada = new BoundField();
                bfMorada.HeaderText = "Morada";
                bfMorada.DataField = "morada";
                gvUtilizador.Columns.Add(bfMorada);
                //nif
                BoundField bfNif = new BoundField();
                bfNif.HeaderText = "Nif";
                bfNif.DataField = "nif";
                gvUtilizador.Columns.Add(bfNif);
                //perfil
                BoundField bfPerfil = new BoundField();
                bfPerfil.HeaderText = "Perfil";
                bfPerfil.DataField = "perfil";
                gvUtilizador.Columns.Add(bfPerfil);
                //tipo
                BoundField bfTipo = new BoundField();
                bfTipo.HeaderText = "Tipo";
                bfTipo.DataField = "tipo";
                gvUtilizador.Columns.Add(bfTipo);
                //Como fazer para aparecer a palavra Admin ou utilizador em vez 0 e 1?
                gvUtilizador.DataBind();
            
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtEmail.Text == null || txtEmail.Text == "")
                {
                    throw new Exception("Não introduziu o email");
                }
                if (txtNome.Text == null || txtNome.Text == "")
                {
                    throw new Exception("Não introduziu o nome");
                }
                if (txtMorada.Text == null || txtMorada.Text == "")
                {
                    throw new Exception("Não introduziu a morada");
                }
                if (txtNif.Text == null || txtNif.Text == "" || txtNif.Text.Length != 9)
                {
                    throw new Exception("Nif incorreto");
                }
                if (txtPassword.Text == null || txtPassword.Text == "")
                {
                    throw new Exception("Não introduziu a password");
                }

                string nome = txtNome.Text;
                string email = txtEmail.Text;
                string morada = txtMorada.Text;
                string nif = txtNif.Text;
                string password = txtPassword.Text;
                int perfil = int.Parse(dpPerfil.SelectedValue);
                int tipo = int.Parse(dpTipo.SelectedValue);

                Random rnd = new Random();
                int sal = rnd.Next(1000);

                Utilizador utilizador = new Utilizador();
                utilizador.nome = nome;
                utilizador.morada = morada;
                utilizador.nif = nif;
                utilizador.password = password;
                utilizador.perfil = perfil;
                utilizador.email = email;
                utilizador.sal = sal;

                utilizador.Adicionar(tipo);

                //limpar form
                txtNome.Text = "";
                txtMorada.Text = "";
                txtNif.Text = "";
                txtEmail.Text = "";

                //atualizar a grid
                AtualizarGrid();
            }
                        
            catch (Exception erro)
            {
                lblErro.Text = erro.Message;
            }
}

        protected void btnPesquisa_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        protected void dpPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpPerfil.SelectedValue != "2")
            {
                dpTipo.Enabled = false;
            }
            else
            {
                dpTipo.Enabled = true;
            }
            AtualizarDDTipo();

        }

        private void AtualizarDDTipo()
        {

            Tipo tp = new Tipo();
            dpTipo.Items.Clear();
            DataTable dados = tp.devolveTipo();
            if (dpPerfil.SelectedValue != "2")
            {
                foreach (DataRow linha in dados.Rows)
                {
                    if (linha["nome"].ToString() == "Nenhum")
                    {
                        dpTipo.Items.Add(new ListItem(linha["nome"].ToString(), linha["nTipo"].ToString()));
                    }
                }
            }
            else
            {
                foreach (DataRow linha in dados.Rows)
                {
                    if (linha["nome"].ToString() != "Nenhum")
                    {
                        dpTipo.Items.Add(new ListItem(linha["nome"].ToString(), linha["nTipo"].ToString()));
                    }
                }
            }
        }
    }
}