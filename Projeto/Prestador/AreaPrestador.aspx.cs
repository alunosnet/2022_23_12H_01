using Projeto.Classes;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto.Prestador
{
    public partial class AreaPrestador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] != null || UserLogin.ValidarSessao(Session, Request, "2") != false)
            {
                gvPedidos.Visible = true;
            }
            else
            {
                gvPedidos.Visible = false;
                Response.Redirect("~/index.aspx");
            }
            if(!IsPostBack)
                atualizarPedidos();
        }

        private void atualizarPedidos()
        {
            gvPedidos.Columns.Clear();
            gvPedidos.DataSource = null;
            gvPedidos.DataBind();
            Utilizador utilizador = new Utilizador();
            int id = int.Parse(Session["id"].ToString());
            DataTable numTipo = utilizador.VerTipo(id);
            int tipo = 0;
            int.TryParse(numTipo.Rows[0][0].ToString(), out tipo);
            Pedidos ped = new Pedidos();
            DataTable dados;
            if (tipo != null)
            {
                dados = ped.ListaTodosPedidosPorTipo(tipo);
            }
            else
            {
                dados = ped.ListaTodosPedidos();
            }


            gvPedidos.DataSource = dados;
            gvPedidos.AutoGenerateColumns = false;

            //Aceitar
            DataColumn dcAceitar = new DataColumn();
            dcAceitar.ColumnName = "Aceitar";
            dcAceitar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcAceitar);

            //Formatação Gridview
            //Aceitar

            HyperLinkField hlAceitar = new HyperLinkField();
            hlAceitar.HeaderText = "Aceitar";
            hlAceitar.DataTextField = "Aceitar";    //columnname do datatable
            hlAceitar.Text = "Aceitar";
            hlAceitar.DataNavigateUrlFormatString = "VerPedido.aspx?npedido={0}";
            hlAceitar.DataNavigateUrlFields = new string[] { "npedido" };
            hlAceitar.ControlStyle.CssClass = "btn btn-success";
            gvPedidos.Columns.Add(hlAceitar);

            //tipo
            BoundField bfTipo = new BoundField();
            bfTipo.HeaderText = "Tipo";
            bfTipo.DataField = "tipo";
            gvPedidos.Columns.Add(bfTipo);
            //descricao
            BoundField bfDescricao = new BoundField();
            bfDescricao.HeaderText = "Descricao";
            bfDescricao.DataField = "descricao";
            gvPedidos.Columns.Add(bfDescricao);
            //Data
            BoundField bfData = new BoundField();
            bfData.HeaderText = "Data";
            bfData.DataField = "data_ped";
            gvPedidos.Columns.Add(bfData);
            //Preco
            BoundField bfPreco = new BoundField();
            bfPreco.HeaderText = "Preco";
            bfPreco.DataField = "Preco";
            gvPedidos.Columns.Add(bfPreco);
            gvPedidos.DataBind();
        }
    }
}