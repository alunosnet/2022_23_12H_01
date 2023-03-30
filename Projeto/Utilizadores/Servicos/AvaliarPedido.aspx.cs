using Projeto.Classes;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto.Utilizadores.Servicos
{
    public partial class AvaliarPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            else
            {
                if (!IsPostBack)
                    atualizarInfo();
            }
        }
        private void atualizarInfo()
        {
            gvPedido.Columns.Clear();
            gvPedido.DataSource = null;
            gvPedido.DataBind();

            int npedido = int.Parse(Request["npedido"].ToString());
            Pedidos ped = new Pedidos();
            DataTable dados = ped.InfoPed(npedido);

            gvPedido.DataSource = dados;
            gvPedido.AutoGenerateColumns = false;

            //Formatação Gridview
            //nome

            BoundField bfNome = new BoundField();
            bfNome.HeaderText = "Nome";
            bfNome.DataField = "nome";
            gvPedido.Columns.Add(bfNome);

            //morada
            BoundField bfMorada = new BoundField();
            bfMorada.HeaderText = "Morada";
            bfMorada.DataField = "morada";
            gvPedido.Columns.Add(bfMorada);


            //tipo
            BoundField bfTipo = new BoundField();
            bfTipo.HeaderText = "Tipo";
            bfTipo.DataField = "tipo";
            gvPedido.Columns.Add(bfTipo);
            //descricao
            BoundField bfDescricao = new BoundField();
            bfDescricao.HeaderText = "Descricao";
            bfDescricao.DataField = "descricao";
            gvPedido.Columns.Add(bfDescricao);
            //Data
            BoundField bfData = new BoundField();
            bfData.HeaderText = "Data";
            bfData.DataField = "data_ped";
            gvPedido.Columns.Add(bfData);
            //Preco
            BoundField bfPreco = new BoundField();
            bfPreco.HeaderText = "Preco";
            bfPreco.DataField = "Preco";
            gvPedido.Columns.Add(bfPreco);
            gvPedido.DataBind();
        }

        protected void btnAvaliar_Click(object sender, EventArgs e)
        {
            try
            {
                int npedido = int.Parse(Request["npedido"].ToString());
                int avaliacao = int.Parse(dpAvaliar.SelectedValue);
                string comentario = txtComentario.Text;
                Models.Servicos serv = new Models.Servicos();
                serv.AvaliarPedido(npedido, avaliacao, comentario);
                lbErro.Text = "Pedido Avaliado com sucesso";
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