<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AreaPrestador.aspx.cs" Inherits="Projeto.Prestador.AreaPrestador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <asp:GridView ID="gvPedidos" EmptyDataText="Não existe nenhum pedido." runat="server" CssClass="table" />
</asp:Content>
