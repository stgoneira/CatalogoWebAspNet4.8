<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="CategoriasPage.aspx.cs" Inherits="CatalogoWeb.CategoriasPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Categorías</h1>

    ID <br />
    <asp:TextBox ID="TextBoxId" runat="server"></asp:TextBox>
    <br /><br />

    Nombre<br />
    <asp:TextBox ID="TextBoxNombre" runat="server"></asp:TextBox>
    <br /><br />

    <asp:Button ID="ButtonGuardar" runat="server" Text="Crear" OnClick="ButtonGuardar_Click" />
    <br /><br />
    <br /><br />


    <asp:TextBox ID="TextBoxBusqueda" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />
    <br /><br />

    <asp:Button ID="ButtonNuevo" runat="server" Text="Nuevo" OnClick="ButtonNuevo_Click" />
    <br />
    <asp:GridView 
        ID="GridView1" 
        runat="server" 
        DataSourceID="ObjectDataSource1" 
        AutoGenerateColumns="False"
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
    >
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="NOMBRE" />
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" CausesValidation="False" SelectText="Seleccionar" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource 
        ID="ObjectDataSource1" 
        runat="server" 
        SelectMethod="GetCategorias" 
        TypeName="CatalogoWeb.CategoriasPage"
    />
</asp:Content>
