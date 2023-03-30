using Projeto.Classes;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto.Admin.Utilizadores
{
    public partial class ApagarUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validar
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            try
            {
                
                int id = int.Parse(Request["id"].ToString());


                Utilizador utilizador = new Utilizador();
                DataTable dados = utilizador.devolveDadosUtilizador(id);
                if (dados == null || dados.Rows.Count == 0)
                {
                    throw new Exception("Utilizador não existe");
                }
                else
                {
                    //mostra os dados do utilizador
                    lblId.Text = dados.Rows[0]["id"].ToString();
                    lblNome.Text = dados.Rows[0]["nome"].ToString();
                }

            }
            catch
            {
                Response.Redirect("~/Admin/Utilizadores/Utilizadores.aspx");
            }
        }

        protected void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"].ToString());
                Utilizador utilizador = new Utilizador();
                utilizador.removerUtilizador(id);

                lblErro.Text = "O utilizador foi removido com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Redirecionar", "returnMain('Utilizadores.aspx')", true);
            }
            catch
            {
                Response.Redirect("~/Admin/Utilizadores/Utilizadores.aspx");
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Utilizadores/Utilizadores.aspx");
        }
    }
}