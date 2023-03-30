using Projeto.Admin.Utilizadores;
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
    public partial class Tipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNome.Text == null || txtNome.Text == "")
                {
                    throw new Exception("Não introduziu o nome");
                }
                string nome = txtNome.Text;

                Tipo tp = new Tipo();
                tp.nome = nome;

                tp.Adicionar(nome);
                DataTable nTipo = tp.VerNtipo();    

                if (ImgTipo.HasFile)
                {
                    string ficheiro = Server.MapPath(@"~\Public\Imagens\");
                    ficheiro = ficheiro + nTipo.Rows[0]["nTipo"].ToString() + ".png";
                    ImgTipo.SaveAs(ficheiro);
                }

                //limpar form
                txtNome.Text = "";

            }
            catch (Exception erro)
            {
                lblErro.Text = erro.Message;
            }
        }
    }
}