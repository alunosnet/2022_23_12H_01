using Projeto.Classes;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validar
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            if (!IsPostBack)
            {
                divEditar.Visible = false;
                MostrarPerfil();

            }
        }

        private void MostrarPerfil()
        {
            int id = int.Parse(Session["id"].ToString());
            Utilizador utilizador = new Utilizador();
            DataTable dados = utilizador.devolveDadosUtilizador(id);

            if (divPerfil.Visible == true)
            {
                lblNome.Text = dados.Rows[0]["nome"].ToString();
                lblMorada.Text = dados.Rows[0]["morada"].ToString();
                lblNif.Text = dados.Rows[0]["nif"].ToString();
            }
            else
            {
                txtNome.Text = dados.Rows[0]["nome"].ToString();
                txtMorada.Text = dados.Rows[0]["morada"].ToString();
                txtNif.Text = dados.Rows[0]["nif"].ToString();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = false;
            divEditar.Visible = true;
            MostrarPerfil();
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["id"].ToString());
            string nome = txtNome.Text;
            string morada = txtMorada.Text;
            string nif = txtNif.Text;
            //ToDo:Validar Dados
            Utilizador utilizador = new Utilizador();
            utilizador.nome = nome;
            utilizador.morada = morada;
            utilizador.nif = nif;
            utilizador.id = id;
            utilizador.atualizarUtilizador();
            btnCancelar_Click(sender, e);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = true;
            divEditar.Visible = false;
            MostrarPerfil();
        }
    }
}