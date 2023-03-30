using Projeto.Admin.Utilizadores;
using Projeto.Classes;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto.Prestador
{
    public partial class VerPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "2") == false)
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

        protected void btnAceitar_Click(object sender, EventArgs e)
        {

                int npedido = int.Parse(Request["npedido"].ToString());
                int idutilizador = int.Parse(Session["id"].ToString());
                Servicos serv = new Servicos();
                Utilizador utilizador = new Utilizador();
                serv.adicionarServico(npedido, idutilizador);
                serv.atualizarPedido(npedido);
                lbErro.Text = "Pedido aceite com sucesso";

            Pedidos ped = new Pedidos();
            DataTable info = ped.InfoPed(npedido);
            string email = info.Rows[0][1].ToString();
            string descricao = info.Rows[0][5].ToString();

            string mensagem = "O pedido com a descrição '" + descricao + "' foi aceite por um prestador.<br />";

            string meuemail = ConfigurationManager.AppSettings["MeuEmail"];
            string minhapassword = ConfigurationManager.AppSettings["MinhaPassword"];
            Helper.enviarMail(meuemail, minhapassword, email, "Pedido Aceite", mensagem);            

            ScriptManager.RegisterStartupScript(this, typeof(Page),
            "Redirecionar", "returnMain('/index.aspx')", true);
        }

    }
}
