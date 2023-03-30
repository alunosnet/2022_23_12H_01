<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ApagarUtilizador.aspx.cs" Inherits="Projeto.Admin.Utilizadores.ApagarUtilizador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <h1>Confirmar apagar Utilizador</h1>
    Id Utilizador :<asp:Label runat="server" id="lblId" CssClass="form-control" />
    <br />Nome:<asp:Label runat="server" id="lblNome" CssClass="form-control" />
    <br />
    <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="btnRemover" Text="Remover" OnClick="btnRemover_Click"/>
    <asp:Button CssClass="btn btn-lg btn-info" runat="server" ID="btnVoltar" Text="Voltar" OnClick="btnVoltar_Click"/>
    <br /><asp:Label runat="server" ID="lblErro" /> 


</asp:Content>
