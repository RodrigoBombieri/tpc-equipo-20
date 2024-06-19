<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormularioEstado.aspx.cs" Inherits="TPC_equipo_20.FormularioEstado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> Estados </h1>
    <div class="row">
        <div class="col-md-12">
            <div class="mb-3">
                <label for="estado" class="form-label">Estado</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-primary" runat="server" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnEliminar" Text="Eliminar" CssClass="btn btn-danger" runat="server" OnClick="btnEliminar_Click" />
                <a href="Estados.aspx">Regresar</a>
            </div>
            <% if (confirmaEliminar) { %>
                <div class="mb-3">
                    <asp:CheckBox ID="chkConfirmaEliminar" runat="server" Text="Confirma eliminar Rol?" />
                    <asp:Button ID="btnConfirmaEliminar" runat="server" CssClass="btn btn-outline-danger" OnClick="btnConfirmaEliminar_Click" Text="Eliminar" /> 
                </div>           
            <% }%>
        </div>
    </div>
</asp:Content>
