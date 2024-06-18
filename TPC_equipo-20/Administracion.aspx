<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="TPC_equipo_20.Administracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Administración</h1>
    <div class="row">
    <div class="col-3">
        <div class="mb-3">
            <asp:Button ID="btnPrioridades" Text="Prioridades" runat="server" CssClass="btn btn-primary" OnClick="btnPrioridades_Click" />
            <asp:Button ID="btnEstados" Text="Estados" runat="server" CssClass="btn btn-primary" OnClick="btnEstados_Click" />
            <asp:Button ID="btnTipos" Text="Tipos incidentes" runat="server" CssClass="btn btn-primary" OnClick="btnTipos_Click" />

        </div>
    </div>
</div>
</asp:Content>
