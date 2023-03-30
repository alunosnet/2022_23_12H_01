<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="recuperarpassword.aspx.cs" Inherits="Projeto.recuperarpassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h1>Recuperar Password</h1>

    <div class="form-group">
        <label for="ContentPlaceHolder1_txtPassword">Nova Palavra Passe:</label>
        <asp:TextBox CssClass="form-control" runat="server" ID="txtPassword" TextMode="Password" placeholder="Password"/>
    </div>
        
    <asp:Button CssClass="btn btn-lg btn-info" runat="server" ID="btnRecuperar" Text="Definir nova palavra passe" onClick="btnRecuperar_Click"/><br />
    <asp:Label runat="server" ID="lblErro" /><br />

</asp:Content>
