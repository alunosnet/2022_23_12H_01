using Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto.Admin
{
    public partial class consultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
                Response.Redirect("~/index.aspx");

            AtualizaGrelhaConsulta();
        }
        protected void ddConsultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaGrelhaConsulta();
        }
        private void AtualizaGrelhaConsulta()
        {
            gvConsultas.Columns.Clear();
            int iconsulta = int.Parse(ddConsultas.SelectedValue);
            DataTable dados;
            string sql = "";
            switch (iconsulta)
            {
                
                case 0:
                    sql = @"SELECT nome,count(*) as [Nº de Servicos] FROM utilizadores 
                            INNER JOIN servicos ON id=idut
                            GROUP BY id,nome
                            ORDER BY count(*) DESC";
                    break;
                case 1:
                    sql = @"SELECT nome,count(*) as [Nº de Pedidos] FROM utilizadores 
                            INNER JOIN pedidos ON id=idut 
                            GROUP BY id,nome
                            ORDER BY count(*) DESC";
                    break;
                case 2:
                    sql = @"SELECT nome,AVG(avaliacao) as [Média] FROM utilizadores 
                            INNER JOIN servicos ON id=idut 
                            GROUP BY id,nome
                            ORDER BY count(*) DESC";
                    break;
            }
            BaseDados bd = new BaseDados();
            dados = bd.devolveSQL(sql);
            gvConsultas.DataSource = dados;
            gvConsultas.DataBind();
        }
    }
}