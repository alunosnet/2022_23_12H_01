<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Utilizadores.aspx.cs" Inherits="Projeto.Admin.Utilizadores.Utilizadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Gestão de Utilizadores</h2>

    <h4>Pesquisa por nome ou email</h4>
        <div class="col-sm-8 float-start">
            <div class=" col-sm-8 input-group">
                <asp:TextBox CssClass="form-control" ID="txtPesquisa" runat="server"></asp:TextBox>

                        <asp:Button CssClass="btn btn-info" runat="server" ID="btnPesquisa" Text="Pesquisar" OnClick="btnPesquisa_Click" />
                  
            </div>
        </div>

    <asp:GridView ID="gvUtilizador" EmptyDataText="Nenhum Cliente Encontrado" runat="server" CssClass="table" />


        <h2>Adicionar Utilizador</h2>

        <div class="form-group">
        <label for="ContentPlaceHolder1_txtEmail">Email:</label>
        <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" MaxLength="100" placeholder="Email"/><br />
    </div>

    <div class="form-group">
        <label for="ContentPlaceHolder1_txtNome">Nome:</label>
        <asp:TextBox CssClass="form-control" ID="txtNome" runat="server" MaxLength="100" placeholder="Nome do Utilizador"/><br />
    </div>

    <div class="form-group">
        <label for="ContentPlaceHolder1_txtMorada">Morada:</label>
        <asp:TextBox CssClass="form-control" ID="txtMorada" runat="server" MaxLength="100" placeholder="Morada"/><br />
    </div>

    <div class="form-group">
        <label for="ContentPlaceHolder1_txtNif">Nif:</label>
        <asp:TextBox CssClass="form-control" ID="txtNif" runat="server" MaxLength="9" placeholder="Nif"/><br />
    </div>

    <div class="form-group">
        <label for="ContentPlaceHolder1_txtPassword">Password:</label>
        <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" TextMode="Password" MaxLength="64" placeholder="Password"/><br />
    </div>

    <div class="form-group">
        <label for="ContentPlaceHolder1_dpPerfil">Perfil:</label>
        <asp:DropDownList CssClass="form-select" ID="dpPerfil" OnSelectedIndexChanged="dpPerfil_SelectedIndexChanged" AutoPostBack="True" runat="server">
            <asp:ListItem Text="Cliente" Value="0" />
            <asp:ListItem Text="Administrador" Value="1" />
            <asp:ListItem Text="Prestador" Value="2" />
         </asp:DropDownList><br />
    </div>

    <div class="form-group" id="divTipo" runat="server"></div>
    <label for='ContentPlaceHolder1_dpTipo'>Tipo:</label>
    <asp:DropDownList CssClass='form-select' ID='dpTipo' runat='server'>
    </asp:DropDownList>

    <asp:Button CssClass="btn btn-lg btn-success" runat="server" ID="btnAdicionar" Text="Adicionar" Onclick="btnAdicionar_Click"/>
    <asp:Label runat="server" ID="lblErro" />
</asp:Content>
