<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Projeto.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card" style="width: 26rem; height: 30rem; margin-left:32%;">

        <h2 class="h3 mb-3 fw-normal" align="center">Bem-Vindo</h2>

    <div runat="server" id="divLogin">
        <div class="form-floating" style="width: 25rem; margin-left:2%; float:left;  border: 0;">
        <div class="form-group">
            <label for="ContentPlaceHolder1_txtEmail">Email:</label>
            <asp:TextBox CssClass="form-control" runat="server" ID="txtEmail" textMode="Email" placeholder="Email"/>
        </div>
        </div>

        <div class="form-floating" style="width: 25rem; margin-left:2%; float:left;  border: 0;">
        <div class="form-group">
            <label for="ContentPlaceHolder1_txtPassword">Password:</label>
            <asp:TextBox CssClass="form-control" runat="server" ID="txtPassword" TextMode="Password" placeholder="Password"/>
        </div>
        </div>

        <asp:Label runat="server" ID="lblErro" /><br />
        <asp:Button CssClass="btn btn-lg btn-success" style="width: 10rem; margin-left:28%; margin-top:2%; float:left;  border: 0;" runat="server" ID="btnLogin" Text="Login" OnClick="btnLogin_Click"/><br /><br />
        <asp:Button CssClass="btn btn-lg btn-danger" style="width: 10rem; margin-left:28%; margin-top:2%; float:left;  border: 0;" runat="server" ID="btnRecuperar" Text="Recuperar" onClick="btnRecuperar_Click"/><br /><br />

        <label style="width: 11rem; margin-left:28%; margin-top:2%; float:left;  border: 0;">Não tem conta? Crie já!</label>
        <asp:Button CssClass="btn btn-lg btn-info" style="width: 10rem; margin-left:28%; float:left;  border: 0;" runat="server" ID="btnRegistar" Text="Registar" onClick="btnRegistar_Click"/>    
    </div>
    </div>
</asp:Content>
