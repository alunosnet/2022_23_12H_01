<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VerPedido.aspx.cs" Inherits="Projeto.Prestador.VerPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
        
    <asp:GridView ID="gvPedido" EmptyDataText="Prestador não fez nenhum serviço." runat="server" CssClass="table" />

    <%if (Session["perfil"] != null && Session["perfil"].Equals("2")){ %>
    <asp:Button CssClass="btn btn-success" ID="btnAceitar" runat="server" Text="Aceitar" OnClick="btnAceitar_Click" />
    <asp:Label runat="server" ID="lbErro" CssClass="form-control"/>
    <% }%>
    <h6>Tipos: <br />
        1 - Entrega de Comida;<br />
        2 - Taxi;<br />
        3 - Manutenção.
    </h6>
    
</asp:Content>
