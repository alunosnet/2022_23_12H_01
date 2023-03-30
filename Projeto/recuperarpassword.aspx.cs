using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto
{
    public partial class recuperarpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string password = txtPassword.Text.Trim();
                if (password.Length == 0)
                {
                    throw new Exception("Tem de indicar uma password");
                }
                string guid = Server.UrlDecode(Request["id"].ToString());
                Utilizador utilizador = new Utilizador();
                utilizador.atualizarPassword(guid, password);
                lblErro.Text = "Password atualizada com sucesso";

                // mandar para o index
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Redirecionar", "returnMain('/index.aspx')", true);

            }
            catch (Exception erro)
            {
                lblErro.Text = erro.Message;
            }
        }
    }
}