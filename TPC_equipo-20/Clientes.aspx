<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPC_equipo_20.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .pagination a {
            display: inline-block;
            padding: 8px 12px;
            margin: 0 4px;
            border: 1px solid #007bff;
            border-radius: 4px;
            color: #007bff;
            text-decoration: none;
            transition: background-color 0.3s, color 0.3s, border-color 0.3s;
        }

            .pagination a.active,
            .pagination a:hover {
                background-color: #007bff;
                color: #fff;
                border-color: #007bff;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row  mb-3 border-bottom">
        <div class="col-md-8 d-flex align-items-center">
            <h1>Clientes</h1>
        </div>
        <div class="col-md-4 d-flex align-items-center justify-content-end">
            <asp:Button ID="btnCrear" Text="Crear Nuevo Cliente" CssClass="btn btn-primary" runat="server" OnClick="btnCrear_Click"></asp:Button>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label runat="server" Text="Filtrar: "></asp:Label>
                <asp:TextBox ID="txtFiltroCliente" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltroCliente_TextChanged" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox ID="chkFiltroAvanzadoCliente" Text="Filtro Avanzado" AutoPostBack="true" OnCheckedChanged="chkFiltroAvanzadoCliente_CheckedChanged" runat="server" />
            </div>
        </div>

        <%if (chkFiltroAvanzadoCliente.Checked)
            { %>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label ID="lblCampo" runat="server" Text="Campo"></asp:Label>
                            <asp:DropDownList ID="ddlCampo" CssClass="form-control" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                <asp:ListItem Text="Nombre"></asp:ListItem>
                                <asp:ListItem Text="Apellido"></asp:ListItem>
                                <asp:ListItem Text="Email"></asp:ListItem>
                                <asp:ListItem Text="DNI"></asp:ListItem>
                                <asp:ListItem Text="Cantidad de incidentes"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label ID="lblCriterio" runat="server" Text="Criterio"></asp:Label>
                            <asp:DropDownList ID="ddlCriterio" CssClass="form-control" runat="server">
                                <asp:ListItem Text="Contiene"></asp:ListItem>
                                <asp:ListItem Text="Empieza con"></asp:ListItem>
                                <asp:ListItem Text="Termina con"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label ID="lblFiltroAvanzado" runat="server" Text="Filtro"></asp:Label>
                            <asp:TextBox ID="txtFiltroAvanzadoCliente" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label ID="lblBtnBuscar" runat="server"></asp:Label>
                    <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-secondary" OnClick="btnBuscar_Click" Text="Buscar" />
                </div>
            </div>
        </div>

        <% } %>
    </div>
    <div class="row">
        <div class="col">
            <asp:GridView runat="server" ID="dgvClientes" CssClass="table table-hover" DataKeyNames="Id" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvClientes_SelectedIndexChanged" OnRowCommand="dgvClientes_RowCommand" OnPageIndexChanging="dgvClientes_PageIndexChanging"
                AllowPaging="true" PageSize="20">
                <PagerStyle CssClass="pagination" />
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="Dni" DataField="Dni" />
                    <asp:BoundField HeaderText="Teléfono" DataField="Telefono1" />
                    <asp:BoundField HeaderText="Email" DataField="Email" />
                    <asp:BoundField ItemStyle-Wrap="true" HeaderText="Fecha de Alta" DataField="FechaCreacion" />
                    <asp:BoundField HeaderText="Cantidad de incidentes" DataField="Incidentes.Count" />
                    <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-info" SelectText="Ver más" />
                    <asp:ButtonField CommandName="nuevoIncidente" ControlStyle-CssClass="btn btn-primary" Text="Crear incidente" />
                </Columns>
                <EmptyDataTemplate>
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="2" style="text-align: center;">No hay clientes para mostrar.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
