<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TPC_equipo_20.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Usuarios</h1>
    <asp:GridView ID="dgvUsuarios" DataKeyNames="Id" OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged"
       CssClass="table" AutoGenerateColumns="false" OnPageIndexChanging="dgvUsuarios_PageIndexChanging"
        AllowPaging="true" PageSize="5" runat="server">
        <Columns>
            <asp:BoundField DataField="Rol" HeaderText="Rol" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="DNI" HeaderText="DNI" />
            <asp:ImageField DataImageUrlField="ImagenPerfil" HeaderText="Foto de Perfil" />
            <asp:BoundField DataField="Nick" HeaderText="Nickname" />
            <asp:BoundField DataField="Password" HeaderText="Contraseña" />
        </Columns>
    </asp:GridView>
    <a href="FormularioUsuario.aspx" class="btn btn-primary">Agregar Usuario</a>
</asp:Content>
