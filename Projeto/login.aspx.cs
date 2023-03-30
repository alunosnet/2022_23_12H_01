using Projeto.Classes;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                UserLogin user = new UserLogin();
                DataTable dados = user.VerificaLogin(email, password);
                if (dados == null)
                {
                    throw new Exception("Login Falhou");
                }

                //login
                Session["nome"] = dados.Rows[0]["nome"].ToString();
                Session["id"] = dados.Rows[0]["id"].ToString();

                //autorização
                Session["perfil"] = dados.Rows[0]["perfil"].ToString();
                Session["ip"] = Request.UserHostAddress;
                Session["useragent"] = Request.UserAgent;

                //redirecionar
                if (Session["perfil"].ToString() == "1")
                    Response.Redirect("~/Admin/Admin.aspx");
                if (Session["perfil"].ToString() == "0")
                    Response.Redirect("~/Utilizadores/User.aspx");
                if (Session["perfil"].ToString() == "2")
                    Response.Redirect("~/Prestador/Prestador.aspx");
            }
            catch
            {
                lblErro.Text = "Login falhou. Tente novamente";
            }
        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txtEmail.Text.Trim().Length == 0)
                {
                    throw new Exception("Indique um email");
                }
                string email = txtEmail.Text.Trim();

                Utilizador utilizador = new Utilizador();
                DataTable dados = utilizador.devolveDadosUtilizadorRecuperar(email);
                if (dados == null || dados.Rows.Count != 1)
                {
                    throw new Exception("Foi enviado um email para recuperação da palavra-passe");
                }
                Guid guid = Guid.NewGuid();
                utilizador.recuperarPassword(email, guid.ToString());

                string mensagem = "Clique no link para recuperar a sua password.<br />";
                mensagem += "<a href='http://" + Request.Url.Authority + "/recuperarpassword.aspx?";
                mensagem += "id=" + Server.UrlEncode(guid.ToString()) + "'>Clique Aqui</a>";

                string meuemail = ConfigurationManager.AppSettings["MeuEmail"];
                string minhapassword = ConfigurationManager.AppSettings["MinhaPassword"];
                Helper.enviarMail(meuemail, minhapassword, email, "Recuperação de Password", mensagem);

                lblErro.Text = "Foi enviado um email para recuperação da palavra passe";

            }
            catch (Exception ex)
            {
                lblErro.Text = ex.Message;
            }
            
        }

        protected void btnRegistar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/registo.aspx");
        }
    }
}