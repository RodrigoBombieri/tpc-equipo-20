<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormularioIncidente.aspx.cs" Inherits="TPC_equipo_20.FormularioIncidente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f9fa;
            margin: 0;
            padding: 0;
        }

        .container {
            height: 81.6vh;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Incidentes </h1>
    <div class="row">
        <h2>Aca hay que replicar clientes para buscar y asignarle la incidencia......</h2>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="mb-3">
                <label id="lblDetalle" class="form-label">Detalle</label>
                <asp:TextBox ID="txtDetalle" TextMode="MultiLine" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label id="lblPrioridad" class="form-label">Prioridad</label>
                <asp:DropDownList ID="ddlPrioridad" CssClass="btn btn-secondary dropdown-toggle form-select" runat="server"></asp:DropDownList>
            </div>
          <%--  <div class="mb-3">
                <label id="lblEstado" class="form-label">Estado</label>
                <asp:DropDownList ID="ddlEstado" CssClass="btn btn-secondary dropdown-toggle form-select" runat="server"></asp:DropDownList>
            </div>--%>
            <div class="mb-3">
                <label id="lblTipo" class="form-label">Tipo de incidente</label>
                <asp:DropDownList ID="ddlTipo" CssClass="btn btn-secondary dropdown-toggle form-select" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-primary" runat="server" OnClick="btnGuardar_Click" />
                <a href="/Incidentes.aspx">Regresar</a>
            </div>
        </div>
    </div>
</asp:Content>
