﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormularioPrioridades.aspx.cs" Inherits="TPC_equipo_20.FormularioPrioridades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Prioridades de incidentes</h1>
    <div class="row">
        <div class="col-md-12">
            <div class="mb-3">
                <label id="lblNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-primary" runat="server" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" OnClick="btnEliminar_Click" Text="Eliminar" />
                <a href="/Prioridades.aspx">Regresar</a>
            </div>
            <% if (confirmaEliminar) { %> 
            <div class="mb-3">
                <asp:CheckBox ID="chkConfirmaEliminar" runat="server" Text="Confirma eliminación?" /></asp:CheckBox>
                <asp:Button ID="btnConfirmaEliminar" runat="server" CssClass="btn btn-outline-danger" OnClick="btnConfirmaEliminar_Click" Text="Eliminar" />
            </div>
            
            <% } %>
        </div>
    </div>
</asp:Content>