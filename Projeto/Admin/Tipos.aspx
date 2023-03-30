<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Tipos.aspx.cs" Inherits="Projeto.Admin.Tipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h2>Novo Tipo de Serviço</h2>

    <div class="form-group">
        <label for="ContentPlaceHolder1_txtNome">Nome:</label>
        <asp:TextBox CssClass="form-control" ID="txtNome" runat="server" MaxLength="100" placeholder="Nome do Serviço"/><br />
    </div>

    <div class="form-group">
        <label for="ContentPlaceHolder1_ImgTipo">Imagem:</label>
        <asp:FileUpload ID="ImgTipo" runat="server" CssClass="form-control" /><br />
    </div>
    <asp:Label runat="server" ID="lblTipo" ></asp:Label>

    <asp:Button CssClass="btn btn-lg btn-info" runat="server" ID="btnAdicionar" Text="Adicionar" Onclick="btnAdicionar_Click"/>
    <asp:Label runat="server" ID="lblErro" />

</asp:Content>
