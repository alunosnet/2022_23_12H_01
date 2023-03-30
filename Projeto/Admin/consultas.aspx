<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="consultas.aspx.cs" Inherits="Projeto.Admin.consultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <h2>Consultas</h2>
    <asp:DropDownList ID="ddConsultas" CssClass="form-control" AutoPostBack="true" 
        OnSelectedIndexChanged="ddConsultas_SelectedIndexChanged" runat="server">
        <asp:ListItem Value="0">Mais Pedidos Concluidos</asp:ListItem>
        <asp:ListItem Value="1">Mais Pedidos Feitos</asp:ListItem>
        <asp:ListItem Value="2">Média dos Prestadores</asp:ListItem>
    </asp:DropDownList>
    <asp:GridView CssClass="table" ID="gvConsultas" EmptyDataText="Nenhum valor Encontrado" runat="server"></asp:GridView>
</asp:Content>
