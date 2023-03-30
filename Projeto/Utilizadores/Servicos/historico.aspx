<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="historico.aspx.cs" Inherits="Projeto.Utilizadores.Servicos.historico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br /><br /><br /><h1>Historico</h1>
    <asp:GridView ID="gvHistorico" EmptyDataText="Nenhum Pedido Pendente" runat="server" CssClass="table" />
    <br /><h1>Concluidas</h1>
    <asp:GridView ID="gvConcluido" EmptyDataText="Nenhum Pedido Concluido" runat="server" CssClass="table" />
</asp:Content>
