using Projeto.Classes;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projeto
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            atualizaListarTipos();
        }

        private void atualizaListarTipos()
        {
            Tipo tipo = new Tipo();
            DataTable dados;
            dados = tipo.listaTipo();
            gerarIndex(dados);
        }

        private void gerarIndex(DataTable dados)
        {
            if (dados == null || dados.Rows.Count == 0)
            {
                divTipo.InnerHtml = "";
                return;
            }
            string grelha = @"<div class='row mt-3 clearfix'>";
            foreach (DataRow tipos in dados.Rows)
            {
                if (tipos["nome"].ToString() != "Nenhum")
                {

                    string algoNTipo = tipos["nTipo"].ToString();
                    string algoNome = tipos["nome"].ToString();
                    grelha += @"
                              <div class='col-6 col-sm-3 mt-10'>
                                <div class='card' style='width: 17rem; height: 23rem;'>
                                   <img src='/Public/imagens/" + algoNTipo + @".png' class='card-img-top' style='height: 23rem'>
                                    <div class='card-body'>
                                    <h5 class='card-title'>" + algoNome + "</h5>";
                    if (Session["perfil"] == null)
                    {
                        grelha += "<a href='login.aspx'class='btn btn-primary'>Detalhes</a>";
                    }
                    else
                    {
                        grelha += "<a href='detalhespedido.aspx?nTipo=" + algoNTipo + "'class='btn btn-primary'>Detalhes</a>";
                    }
                    grelha += "</div>";
                    grelha += "</div>";
                    grelha += "</div>";
                }
            }
            divTipo.InnerHtml = grelha;
        }
    }
}