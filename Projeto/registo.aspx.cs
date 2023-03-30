using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17ABTrabalhoModelo
{
    public partial class registo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] != null)
            {
                Response.Redirect("~/index.aspx");
            }

        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                var respostaRecaptcha = Request.Form["g-Recaptcha-Response"];
                var valido = ReCaptcha.Validate(respostaRecaptcha);
                if (valido == false)
                {
                    throw new Exception("Tem de provar que nao e um robo");
                }
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
                string palavra_passe = txtPassword.Text;

                Utilizador utilizador = new Utilizador();
                utilizador.nif = nif;
                utilizador.nome = nome;
                utilizador.morada = morada;
                utilizador.email = email;
                utilizador.password = palavra_passe;
                utilizador.perfil = 0;
                int tipo = 4;
                Random rnd = new Random();
                utilizador.sal = rnd.Next(9999);
                utilizador.Adicionar(tipo);
                lblErro.Text = "Registado com sucesso";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "Redirecionar", "returnMain('/index.aspx')", true);

            }
            catch (Exception erro)
            {
                lblErro.Text = erro.Message;
            }
        }
    }
}