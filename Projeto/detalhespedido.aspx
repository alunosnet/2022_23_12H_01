<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="detalhespedido.aspx.cs" Inherits="Projeto.detalhespedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label runat="server" ID="lblPedido" CssClass="form-control"/>

       <div class="form-group">
           <asp:Image runat="server" ID="ImgSer" />
       </div>

   <div class="form-group" style="width: 25rem; margin-left:2%; float:left;  border: 0;">
        <label for="ContentPlaceHolder1_txtDescricao">Descrição:</label>
        <asp:textbox CssClass="form-control z-depth-1" ID="txtDescricao" runat="server" MaxLength="150" placeholder="Descrição"/><br />
    </div>

    <div class="form-group" style="width: 25rem; margin-left:2%; float:left;  border: 0;">
        <label for="ContentPlaceHolder1_txtPreco">Preco:</label>
        <asp:TextBox CssClass="form-control" ID="txtPreco" runat="server" required MaxLength="3"/><br />
    </div>


    <asp:Button CssClass="btn btn-success" ID="btnPedido" runat="server" Text="Fazer Pedido" OnClick="btnPedido_Click" />
    <asp:Label runat="server" ID="lbErro" CssClass="form-control"/>

   <asp:GridView ID="gvAval" runat="server" CssClass="table" />


</asp:Content>