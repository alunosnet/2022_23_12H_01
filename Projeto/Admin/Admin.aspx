<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Projeto.Admin.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Perfil</h1>
    <div runat="server" id="divPerfil">
        Nome:<asp:Label runat="server" ID="lblNome" CssClass="form-control"></asp:Label>
        <br />Morada<asp:Label runat="server" ID="lblMorada" CssClass="form-control"></asp:Label>
        <br />Nif<asp:Label runat="server" ID="lblNif" CssClass="form-control"></asp:Label>
        <br />
            <asp:Button CssClass="btn btn-lg btn-info" runat="server" ID="btnEditar" Text="Editar Perfil" Onclick="btnEditar_Click"/>
    </div>

    <div runat="server" id="divEditar">
        Nome:<asp:TextBox runat="server" ID="txtNome" CssClass="form-control"></asp:TextBox>
        <br />Morada<asp:TextBox runat="server" ID="txtMorada" CssClass="form-control"></asp:TextBox>
        <br />Nif<asp:TextBox runat="server" ID="txtNif" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Button CssClass="btn btn-lg btn-success" runat="server" ID="btnAtualizar" Text="Atualizar Perfil" Onclick="btnAtualizar_Click"/>
        <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="btnCancelar" Text="Cancelar" Onclick="btnCancelar_Click"/>
    </div>
</asp:Content>
