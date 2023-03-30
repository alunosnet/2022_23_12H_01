<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AvaliarPedido.aspx.cs" Inherits="Projeto.Utilizadores.Servicos.AvaliarPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
        <asp:GridView ID="gvPedido" EmptyDataText="Pedido Inexistente" runat="server" CssClass="table" />

    <%if (Session["perfil"] != null && Session["perfil"].Equals("0")){ %>

        <div class="form-group">
        <label for="ContentPlaceHolder1_dpAvaliar">Avaliar:</label>
        <asp:DropDownList CssClass="form-select" ID="dpAvaliar" runat="server">
            <asp:ListItem Text="0" Value="0" />
            <asp:ListItem Text="1" Value="1" />
            <asp:ListItem Text="2" Value="2" />
            <asp:ListItem Text="3" Value="3" />
            <asp:ListItem Text="4" Value="4" />
            <asp:ListItem Text="5" Value="5" />
         </asp:DropDownList><br />

                <h4>Faça um comentário !</h4>
        <div class="col-sm-8 float-start">
            <div class=" col-sm-8 input-group">
                <asp:TextBox CssClass="form-control" ID="txtComentario" MaxLength="100" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <asp:Button CssClass="btn btn-success" ID="btnAvaliar" runat="server" Text="Avaliar" OnClick="btnAvaliar_Click" />
    <asp:Label runat="server" ID="lbErro" CssClass="form-control"/>
    <% }%>

</asp:Content>
