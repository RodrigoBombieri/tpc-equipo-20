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

    <div class="row  mb-3 border-bottom">
        <div class="col-md-8 d-flex align-items-center">
            <h1>Creando incidente</h1>
        </div>
        <div class="col-md-4 d-flex align-items-center justify-content-end">
            <asp:Button ID="btnVolver" Text="Volver" CssClass="btn btn-primary" runat="server" />
        </div>
    </div>
    <div class="row">
        <asp:Button ID="btnSeleccionCliente" Text="Seleccione cliente" CssClass="btn btn-primary" runat="server" OnClick="btnSeleccionCliente_Click" />
    </div>
    <div class="row">
        <div class="col-md-6" style="padding-right: 15px;">
            <div class="row border mb-4">
                <div class="mb-3">
                    <label id="lblPrioridad" class="form-label">Prioridad</label>
                    <asp:DropDownList ID="ddlPrioridad" CssClass="btn btn-secondary dropdown-toggle form-select" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label id="lblTipo" class="form-label">Tipo de incidente</label>
                    <asp:DropDownList ID="ddlTipo" CssClass="btn btn-secondary dropdown-toggle form-select" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label id="lblDetalle" class="form-label">Detalle</label>
                    <asp:TextBox ID="txtDetalle" TextMode="MultiLine" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3 text-end">
                    <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn btn-danger" runat="server" />
                    <asp:Button ID="btnGuardarAccion" Text="Guardar" CssClass="btn btn-primary me-2" runat="server" />
                </div>
            </div>
        </div>
        <div class="col-md-6 border mb-4">
            <div class="mb-3">
                <label id="lblCliente" class="form-label"></label>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblNombreApellido" class="form-label" runat="server"></asp:Label>
                <asp:Label ID="lblDocumento" class="form-label" runat="server"></asp:Label>
            </div>
            <div class="mb-3">
                <label id="lblCliente2" class="form-label">Documento:</label>
            </div>
            <div class="mb-3">
                <label id="lblDetalle1" class="form-label">Detalle</label>
                <asp:TextBox ID="txtDetalleAccion" TextMode="MultiLine" CssClass="form-control" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
