<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="registo.aspx.cs" Inherits="M17ABTrabalhoModelo.registo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://www.google.com/recaptcha/api.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="card" style="width: 26rem; height: 40rem; margin-left:32%;">

            <h2 class="h3 mb-3 fw-normal" align="center">Bem-Vindo</h2>

            <div class="form-floating" style="width: 25rem; margin-left:2%; float:left;  border: 0;">
<div class="form-group">
        <label for="ContentPlaceHolder1_txtEmail">Email:</label>
        <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" MaxLength="100" placeholder="Email"/><br />
    </div>
                </div>

                        <div class="form-floating" style="width: 25rem; margin-left:2%; float:left;  border: 0;">
    <div class="form-group">
        <label for="ContentPlaceHolder1_txtNome">Nome:</label>
        <asp:TextBox CssClass="form-control" ID="txtNome" runat="server" MaxLength="100"  placeholder="Nome do Utilizador"/><br />
    </div>
                            </div>

            <div class="form-floating" style="width: 25rem; margin-left:2%; float:left;  border: 0;">
    <div class="form-group">
        <label for="ContentPlaceHolder1_txtMorada">Morada:</label>
        <asp:TextBox CssClass="form-control" ID="txtMorada" runat="server" MaxLength="100"  placeholder="Morada"/><br />
    </div>
                </div>

            <div class="form-floating" style="width: 25rem; margin-left:2%; float:left;  border: 0;">
    <div class="form-group">
        <label for="ContentPlaceHolder1_txtNif">Nif:</label>
        <asp:TextBox CssClass="form-control" ID="txtNif" runat="server" MaxLength="9" placeholder="Nif"/><br />
    </div>
                </div>

            <div class="form-floating" style="width: 25rem; margin-left:2%; float:left;  border: 0;">
    <div class="form-group">
        <label for="ContentPlaceHolder1_txtPassword">Password:</label>
        <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" TextMode="Password" MaxLength="64"  placeholder="Password"/><br />
    </div>
                </div>
    

            <div class="g-recaptcha" data-sitekey="6LceZUckAAAAAEAWW1ImZJwe8tFdxf1hX5nMFn9_"></div> 

        <asp:Button CssClass="btn btn-lg btn-success" style="width: 10rem; margin-left:28%; margin-top:2%; float:left;  border: 0;" runat="server" ID="btnAdicionar" Text="Registar" OnClick="btnAdicionar_Click"/>
    <asp:Label runat="server" ID="lblErro" />
    <br />


</div>

</asp:Content>
