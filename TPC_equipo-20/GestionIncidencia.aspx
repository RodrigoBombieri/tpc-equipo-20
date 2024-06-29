<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GestionIncidencia.aspx.cs" Inherits="TPC_equipo_20.GestionIncidencia" %>

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
    <div class="row">
        <div class="col-md-8">


            <asp:Label ID="lblNumIncidencia" class="h1" runat="server"></asp:Label>
            <asp:Label ID="lblEstado" CssClass="badge rounded-pill text-bg-primary" runat="server">Estado</asp:Label>
            <asp:Label ID="lblTipo" CssClass="badge rounded-pill text-bg-info" runat="server">Tipo</asp:Label>
            <asp:Label ID="lblPrioridad" CssClass="badge rounded-pill text-bg-warning" runat="server">Prioridad</asp:Label>
        </div>
        <div class="col-md-4">
            <asp:Button ID="btnCerrar" Text="Cerrar" CssClass="btn btn-primary" runat="server" />
            <asp:Button ID="btnResolver" Text="Resolver" CssClass="btn btn-primary" runat="server" />
            <asp:Button ID="btnVolver" Text="Volver" CssClass="btn btn-primary" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="mb-3">
                <label id="lblCliente" class="form-label">Cliente:</label>
            </div>
            <div class="mb-3">
                <label id="lblCreado" class="form-label">Creado:</label>
            </div>
            <div class="mb-3">
                <label id="lblDetalle" class="form-label">Detalle</label>
                <asp:TextBox ID="txtDetalle" TextMode="MultiLine" CssClass="form-control" runat="server" />
            </div>
        </div>
        <div class="col-md-6">
            <div class="mb-3">
                <label id="lblAcciones" class="form-label">Acciones:</label>
                <asp:GridView ID="dgvAcciones" DataKeyNames="Id" OnSelectedIndexChanged="dgvAcciones_SelectedIndexChanged"
                    CssClass="table" AutoGenerateColumns="false" OnPageIndexChanging="dgvAcciones_PageIndexChanging"
                    AllowPaging="true" PageSize="5" runat="server" ShowHeaderWhenEmpty="True">
                    <Columns>
                        <asp:BoundField DataField="Tipo.Nombre" HeaderText="Tipo" />
                        <asp:BoundField DataField="Fecha" HeaderText="Creado" />
                        <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-primary" SelectText="Ver" HeaderText="Accion" />
                    </Columns>
                        <EmptyDataTemplate>
        <table style="width:100%;">
            <tr>
                <td colspan="2" style="text-align:center;">No hay datos disponibles.</td>
            </tr>
        </table>
    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
