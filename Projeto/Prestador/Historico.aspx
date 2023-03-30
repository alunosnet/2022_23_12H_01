<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Historico.aspx.cs" Inherits="Projeto.Prestador.Historico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <h2>Histórico</h2>
    <asp:GridView EmptyDataText="Prestador não fez nenhum serviço." CssClass="table" ID="gvHistorico" runat="server"></asp:GridView>
    <br /><asp:Label ID="lbErro" runat="server" Text=""></asp:Label>

</asp:Content>
