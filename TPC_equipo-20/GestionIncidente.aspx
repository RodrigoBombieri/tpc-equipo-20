<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GestionIncidente.aspx.cs" Inherits="TPC_equipo_20.GestionIncidente" %>

<%@ Register Src="~/ControlUsuarios.ascx" TagPrefix="uc" TagName="ControlUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .large-badge {
            font-size: 0.8rem; /* Ajusta el tamaño de fuente según lo necesario */
            padding: 0.5em 1em; /* Ajusta el relleno según lo necesario */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row  mb-3 border-bottom">
        <div class="col-md-8 d-flex align-items-center">
            <asp:Label ID="lblNumIncidente" CssClass="h1" Style="margin-right: 10px;" runat="server"></asp:Label>
            <asp:Label ID="lblEstado" CssClass="badge rounded-pill text-bg-info large-badge" Style="margin-right: 10px;" runat="server">Estado</asp:Label>
            <asp:Label ID="lblVigencia" CssClass="badge rounded-pill text-bg-warning large-badge" runat="server">Vigencia</asp:Label>
            <%--<asp:Label ID="lblTipo" CssClass="badge rounded-pill text-bg-info large-badge" runat="server">Tipo</asp:Label>--%>
        </div>
        <div class="col-md-4 d-flex align-items-center justify-content-end">
            <%--<asp:Button ID="btnCerrar" Text="Cerrar" CssClass="btn btn-primary me-2" runat="server" />
            <asp:Button ID="btnResolver" Text="Resolver" CssClass="btn btn-primary me-2" runat="server" />--%>
            <asp:Button ID="btnVolver" Text="Volver" CssClass="btn btn-primary" runat="server" OnClick="btnVolver_Click" />
        </div>
    </div>
    <%--<uc:ControlUsuarios ID="MiControl1" runat="server" />--%>
    <div class="row">
        <div class="col-md-6" style="padding-right: 15px;">
            <div class="row border mb-4">
                <div class="mb-3">
                    <label id="lblTipo" class="form-label">Tipo de incidente</label>
                    <asp:DropDownList ID="ddlTipo" CssClass="btn btn-secondary dropdown-toggle form-select" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label id="lblPrioridad" class="form-label">Prioridad</label>
                    <asp:DropDownList ID="ddlPrioridad" CssClass="btn btn-secondary dropdown-toggle form-select" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3 text-end">
                    <asp:Button ID="Button1" Text="Cancelar" CssClass="btn btn-danger" runat="server" />
                    <asp:Button ID="Button2" Text="Guardar" CssClass="btn btn-primary me-2" runat="server" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblCreado" class="form-label" runat="server"></asp:Label>
                </div>
                <div class="mb-3">
                    <label id="lblDetalle1" class="form-label">Detalle</label>
                    <asp:TextBox ID="txtDetalle" TextMode="MultiLine" CssClass="form-control" Enabled="false" runat="server" />
                </div>
            </div>
            <div class="row border m-6 mb-4">
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
            </div>
        </div>

        <div class="col-md-6 border mb-4">
            <div class="mb-3">
                <label id="lblTipoAccion" class="form-label">Seguimiento:</label>
                <asp:DropDownList ID="ddlTipoAcciones" CssClass="btn btn-secondary dropdown-toggle form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label id="lblDetalle" class="form-label">Detalle</label>
                <asp:TextBox ID="txtDetalleAccion" TextMode="MultiLine" CssClass="form-control" runat="server" />
            </div>
            <div class="row" style="margin-top: 10px">
                <div class="mb-3 text-end">
                    <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn btn-danger" runat="server" />
                    <asp:Button ID="btnGuardarAccion" Text="Guardar" CssClass="btn btn-primary me-2" runat="server" />
                </div>
            </div>
            <div class="mb-3">
                <asp:GridView ID="dgvAcciones" DataKeyNames="Id" OnSelectedIndexChanged="dgvAcciones_SelectedIndexChanged"
                    CssClass="table" AutoGenerateColumns="false" OnPageIndexChanging="dgvAcciones_PageIndexChanging"
                    AllowPaging="true" PageSize="5" runat="server" ShowHeaderWhenEmpty="True">
                    <Columns>
                        <asp:BoundField DataField="Tipo.Nombre" HeaderText="Tipo" />
                        <asp:BoundField DataField="Fecha" HeaderText="Creado" />
                        <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-primary" SelectText="Ver" HeaderText="Accion" />
                    </Columns>
                    <EmptyDataTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="2" style="text-align: center;">No hay datos disponibles.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </div>    
</asp:Content>
