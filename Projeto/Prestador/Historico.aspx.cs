using Projeto.Classes;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto.Prestador
{
    public partial class Historico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "2") == false)
                Response.Redirect("~/index.aspx");
            try
            {
                ConfigurarGrid();
                atualizarGrid();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Redirecionar",
                "returnMain('~/index.aspx');", true);
            }
        }

        private void ConfigurarGrid()
        {
            
                gvHistorico.AllowPaging = true;
            gvHistorico.PageSize = 5;
            gvHistorico.PageIndexChanging += GvHistorico_PageIndexChanging; ;
            
        }

        private void GvHistorico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHistorico.PageIndex = e.NewPageIndex;
            atualizarGrid();
        }

        private void atualizarGrid()
        {
            gvHistorico.Columns.Clear();
            gvHistorico.DataSource = null;
            gvHistorico.DataBind();

            int id = int.Parse(Session["id"].ToString());
            Servicos serv = new Servicos();
            gvHistorico.DataSource = serv.listaServicosID(id);
            gvHistorico.DataBind();
        }
    }
}