<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Incidentes.aspx.cs" Inherits="TPC_equipo_20.Incidentes" %>

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
    <h1>Incidencias </h1>
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
            </div>
        </div>
        <div class="col-4" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox ID="chkFiltroAvanzado" Text="Filtro Avanzado" AutoPostBack="true" OnCheckedChanged="chkFiltroAvanzado_CheckedChanged" runat="server" />
            </div>
        </div>
        <div class="col-4">
            <asp:Button ID="btnCrear" Text="Crear" CssClass="btn btn-primary" runat="server" OnClick="btnCrear_Click" />
        </div>
        <%if (chkFiltroAvanzado.Checked)
            //<%if (filtroAvanzado)
            {%>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label ID="lblCampo" Text="Campo" runat="server" />
                    <asp:DropDownList ID="ddlCampo" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                        <asp:ListItem Text="Precio" />
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Descripcion" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label ID="lblCriterio" Text="Criterio" runat="server" />
                    <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="form-control" AutoPostBack="true">
                        <asp:ListItem Text="Igual a" />
                        <asp:ListItem Text="Mayor a" />
                        <asp:ListItem Text="Menor a" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label ID="lblFiltroAvanzado" Text="Filtro" runat="server" />
                    <asp:TextBox ID="txtFiltroAvanzado" CssClass="form-control" runat="server" />
                </div>
                <asp:Label ID="lblValidarFiltro" Text="" runat="server" ForeColor="Red" />
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                    <asp:Button ID="BtnLimpiarFiltros" Text="Limpiar filtros" runat="server" CssClass="btn btn-primary" OnClick="btnLimpiarFiltro_Click" />
                </div>
            </div>
        </div>
        <% } %>
    </div>
    <div class="row">
        <asp:GridView ID="dgvIncidentes" DataKeyNames="Id" OnSelectedIndexChanged="dgvIncidentes_SelectedIndexChanged"
            CssClass="table" AutoGenerateColumns="false" OnPageIndexChanging="dgvIncidentes_PageIndexChanging"
            AllowPaging="true" PageSize="5" runat="server">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Tipo.Nombre" HeaderText="Tipo" />
                <asp:BoundField DataField="Prioridad.Nombre" HeaderText="Prioridad" />
                <asp:BoundField DataField="Estado.Nombre" HeaderText="Estado" />
                <asp:BoundField DataField="Detalle" HeaderText="Detalle" />
                <asp:BoundField DataField="UsuarioAsignado.Nombre" HeaderText="Usuario asignado" />
                <asp:BoundField DataField="FechaCreacion" HeaderText="Creado" />
                <asp:BoundField DataField="FechaCierre" HeaderText="Cierre" />
                <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-primary" SelectText="Ver" HeaderText="Accion" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
