using Projeto.Classes;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17ABTrabalhoModelo.Admin.Utilizadores
{
    public partial class historicoutilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
                Response.Redirect("~/index.aspx");
            try
            {
                atualizarGrid();
            }
            catch
            {
                lbErro.Text = "O utilizador indicado não existe";
                lbErro.CssClass = "alert alert-danger";
                
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Redirecionar",
                "returnMain('/Admin/Utilizadores/Utilizadores.aspx');", true);
            }
        }

        private void atualizarGrid()
        {
            gvHistorico.Columns.Clear();
            gvHistorico.DataSource = null;
            gvHistorico.DataBind();

            int id = int.Parse(Request["id"].ToString());
            Pedidos pedido = new Pedidos();
            gvHistorico.DataSource = pedido.listaTodosPedidos(id);
            gvHistorico.DataBind();
        }
    }
}