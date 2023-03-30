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
    public partial class historico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validar
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            AtualizarGrid();
            AtualizarGridConcluidos();
        }

        private void AtualizarGridConcluidos()
        {
            Models.Servicos serv = new Models.Servicos();
            gvConcluido.Columns.Clear();
            gvConcluido.DataSource = null;
            gvConcluido.DataBind();

            int idutilizador = int.Parse(Session["id"].ToString());
            DataTable dados = serv.listaTodosPedidosClieFiltro(idutilizador);

            gvConcluido.DataSource = dados;
            gvConcluido.AutoGenerateColumns = false;


            //Concluido
            DataColumn dcAvaliar = new DataColumn();
            dcAvaliar.ColumnName = "avaliar";
            dcAvaliar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcAvaliar);

            //Formatação Gridview
            HyperLinkField hlAvaliar = new HyperLinkField();
            hlAvaliar.HeaderText = "Avaliar";
            hlAvaliar.DataTextField = "avaliar";    //columnname do datatable
            hlAvaliar.Text = "Avaliar";
            hlAvaliar.DataNavigateUrlFormatString = "AvaliarPedido.aspx?npedido={0}";
            hlAvaliar.DataNavigateUrlFields = new string[] { "npedido" };
            hlAvaliar.ControlStyle.CssClass = "btn btn-success";
            gvConcluido.Columns.Add(hlAvaliar);


            //id
            BoundField bfId = new BoundField();
            bfId.HeaderText = "id do Pedido";
            bfId.DataField = "npedido";
            bfId.Visible = false;
            gvHistorico.Columns.Add(bfId);
            //nome
            BoundField bfNome = new BoundField();
            bfNome.HeaderText = "Tipo de Pedido";
            bfNome.DataField = "tipo";
            gvConcluido.Columns.Add(bfNome);
            //data
            BoundField bfData = new BoundField();
            bfData.HeaderText = "Data do Pedido Concluido";
            bfData.DataField = "data_serv";
            gvConcluido.Columns.Add(bfData);
            //prestador
            BoundField bdPrestador = new BoundField();
            bdPrestador.HeaderText = "Prestador";
            bdPrestador.DataField = "idut";
            gvConcluido.Columns.Add(bdPrestador);
            //avaliacao
            BoundField bdAvaliacao = new BoundField();
            bdAvaliacao.HeaderText = "Avalicao";
            bdAvaliacao.DataField = "avaliacao";
            gvConcluido.Columns.Add(bdAvaliacao);
            //avaliacao
            BoundField bdDescricao = new BoundField();
            bdDescricao.HeaderText = "Comentarios";
            bdDescricao.DataField = "comentarios";
            gvConcluido.Columns.Add(bdDescricao);

            gvConcluido.DataBind();
        }

        private void AtualizarGrid()
        {
            Pedidos ped = new Pedidos();
            gvHistorico.Columns.Clear();
            gvHistorico.DataSource = null;
            gvHistorico.DataBind();

            int idutilizador = int.Parse(Session["id"].ToString());
            DataTable dados = ped.listaTodosPedidosClie(idutilizador);

            gvHistorico.DataSource = dados;
            gvHistorico.AutoGenerateColumns = false;

            //Concluido
            DataColumn dcConcluir = new DataColumn();
            dcConcluir.ColumnName = "concluido";
            dcConcluir.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcConcluir);

            //Formatação Gridview
            //concluido
            HyperLinkField hlConcluido = new HyperLinkField();
            hlConcluido.HeaderText = "Conluido";
            hlConcluido.DataTextField = "concluido";    //columnname do datatable
            hlConcluido.Text = "Concluido";
            hlConcluido.DataNavigateUrlFormatString = "ConcluirPedido.aspx?npedido={0}";
            hlConcluido.DataNavigateUrlFields = new string[] { "npedido" };
            hlConcluido.ControlStyle.CssClass = "btn btn-success";
            gvHistorico.Columns.Add(hlConcluido);

            //id
            BoundField bfId = new BoundField();
            bfId.HeaderText = "id do Pedido";
            bfId.DataField = "npedido";
            bfId.Visible = false;
            gvHistorico.Columns.Add(bfId);
            //nome
            BoundField bfNome = new BoundField();
            bfNome.HeaderText = "Nome do cliente";
            bfNome.DataField = "nome";
            gvHistorico.Columns.Add(bfNome);
            //data
            BoundField bfData = new BoundField();
            bfData.HeaderText = "Data do Pedido";
            bfData.DataField = "data_ped";
            gvHistorico.Columns.Add(bfData);
            //estdao
            BoundField bdEstado = new BoundField();
            bdEstado.HeaderText = "Estado";
            bdEstado.DataField = "estado";
            gvHistorico.Columns.Add(bdEstado);

            gvHistorico.DataBind();
        }
    }
}