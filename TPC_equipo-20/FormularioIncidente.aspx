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
            <asp:Button ID="btnVolver" Text="Volver" CssClass="btn btn-primary" runat="server" OnClick="btnVolver_Click" />
        </div>
    </div>
    <%--Cliente--%>
    <% if (!banderaCliente)
        { %>
    <div class="row" style="padding: 20px">
        <div class="mb-3">
            <asp:Label runat="server" Text="Buscar por nombre, apellido o documento (para mas filtros <a href='Clientes.aspx'>aqui</a>)."></asp:Label>
        </div>
        <div class="mb-3 d-flex">
            <asp:TextBox ID="txtFiltroCliente" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
            <asp:Button ID="btnBuscarCliente" Text="Buscar" CssClass="btn btn-primary" runat="server" />
        </div>
        <asp:GridView ID="dgvClientes" DataKeyNames="Id" OnSelectedIndexChanged="dgvClientes_SelectedIndexChanged"
            CssClass="table" AutoGenerateColumns="false" OnPageIndexChanging="dgvClientes_PageIndexChanging"
            AllowPaging="true" PageSize="5" runat="server" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Dni" DataField="Dni" />
                <asp:BoundField HeaderText="Teléfono" DataField="Telefono1" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Fecha de Alta" DataField="FechaCreacion" />
                <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-primary" SelectText="Seleccionar" HeaderText="Seleccionar" />
            </Columns>
            <EmptyDataTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td colspan="2" style="text-align: center;">No hay datos disponibles, <a href="FormularioCliente.aspx">crear cliente</a>.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <%}
        else
        { %>
    <div class="row">
        <%--Incidente--%>
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
                    <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn btn-danger" runat="server" OnClick="btnCancelar_Click" />
                    <asp:Button ID="btnGuardarIncidente" Text="Guardar" CssClass="btn btn-primary me-2" runat="server" OnClick="btnGuardarIncidente_Click" />
                </div>
            </div>
        </div>
        <%--Datos cliente--%>
        <div class="col-md-6 border mb-4">
            <div class="mb-3">
                <label id="lblCliente" class="form-label"></label>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblNombreApellido" class="form-label" runat="server"></asp:Label>
                <asp:Label ID="lblDocumento" class="form-label" runat="server"></asp:Label>
            </div>            
            <div class="mb-3 text-end">
                <asp:Button ID="btnModificarUsuario" Text="Modificar" CssClass="btn btn-primary me-2" runat="server" />
            </div>
        </div>
    </div>
    <%} %>
</asp:Content>
