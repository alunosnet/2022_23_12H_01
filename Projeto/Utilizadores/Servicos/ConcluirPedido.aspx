<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ConcluirPedido.aspx.cs" Inherits="Projeto.Utilizadores.Servicos.ConcluirPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <asp:GridView ID="gvPedido" EmptyDataText="Pedido Inexistente" runat="server" CssClass="table" />

    <%if (Session["perfil"] != null && Session["perfil"].Equals("0")){ %>
    <asp:Button CssClass="btn btn-success" ID="btnAceitar" runat="server" Text="Aceitar" OnClick="btnAceitar_Click" />
    <asp:Label runat="server" ID="lbErro" CssClass="form-control"/>
    <% }%>

</asp:Content>
