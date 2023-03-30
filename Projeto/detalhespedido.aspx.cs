using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto
{
    public partial class detalhespedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["perfil"] == null)
            {
                Response.Redirect("~/index.aspx");
            }
            if (IsPostBack == false)
            {
                txtPreco.Enabled = false;
                Random rnd = new Random();
                txtPreco.Text = rnd.Next(100).ToString();
                AtualizarGrid();
            }

            try
            {
                string tipo = Request["nTipo"].ToString();
                Tipo tipos = new Tipo();
                DataTable dadosTipo = tipos.devolveNome(int.Parse(tipo));
                ImgSer.ImageUrl = @"~\Public\imagens\" + tipo + ".png";
                ImgSer.Width = 300;
                lblPedido.Text = dadosTipo.Rows[0]["nome"].ToString();
            }
            catch
            {
                Response.Redirect("~/index.aspx");
            }
        }

        private void AtualizarGrid()
        {
            gvAval.Columns.Clear();
            gvAval.DataSource = null;
            gvAval.DataBind();

            Servicos serv = new Servicos();
            string tipo = Request["nTipo"].ToString();
            DataTable dados;

                dados = serv.ListaAval(tipo);
            
            

            gvAval.DataSource = dados;
            gvAval.AutoGenerateColumns = false;

            //Formatação Gridview

            //id
            BoundField bfId = new BoundField();
            bfId.HeaderText = "Id";
            bfId.DataField = "npedido";
            bfId.Visible = false;
            gvAval.Columns.Add(bfId);
            //nome
            BoundField bfNome = new BoundField();
            bfNome.HeaderText = "Nome";
            bfNome.DataField = "nome";
            gvAval.Columns.Add(bfNome);
            //Avaliacao
            BoundField bfAval = new BoundField();
            bfAval.HeaderText = "Avaliação";
            bfAval.DataField = "avaliacao";
            gvAval.Columns.Add(bfAval);
            //comentarios
            BoundField bfCom = new BoundField();
            bfCom.HeaderText = "Comentarios";
            bfCom.DataField = "comentarios";
            gvAval.Columns.Add(bfCom);

            gvAval.DataBind();
        }

        protected void btnPedido_Click(object sender, EventArgs e)
        {
            try
            {
                int tipo = int.Parse(Request["nTipo"].ToString());
                int idutilizador = int.Parse(Session["id"].ToString());
                string descricao = txtDescricao.Text;
                Decimal preco = Decimal.Parse(txtPreco.Text);
                Pedidos ped = new Pedidos();
                ped.adicionarReserva(tipo, idutilizador, descricao, preco);
                lbErro.Text = "Pedido feito com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/index.aspx')", true);
            }
            catch
            {
                Response.Redirect("/index.aspx");
            }
        }
    }
}