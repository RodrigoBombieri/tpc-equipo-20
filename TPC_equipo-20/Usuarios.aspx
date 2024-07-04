<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TPC_equipo_20.Usuarios" %>

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
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="row  mb-3 border-bottom">
        <div class="col-md-8 d-flex align-items-center">
            <h1>Usuarios</h1>
        </div>
        <div class="col-md-4 d-flex align-items-center justify-content-end">
            <a href="FormularioUsuario.aspx" class="btn btn-primary">Crear Nuevo Usuario</a>
        </div>
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <asp:Label runat="server" Text="Filtrar: "></asp:Label>
                    <asp:TextBox ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
                <div class="mb-3">
                    <asp:CheckBox ID="chkFiltroAvanzado" Text="Filtro Avanzado" AutoPostBack="true" OnCheckedChanged="chkFiltroAvanzado_CheckedChanged" runat="server" />
                </div>
            </div>

            <%if (chkFiltroAvanzado.Checked)
                { %>

                    <div class="row">
                        <div class="col-3">
                            <div class="mb-3">
                                <asp:Label ID="lblCampo" runat="server" Text="Campo"></asp:Label>
                                <asp:DropDownList ID="ddlCampo" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" runat="server">
                                    <asp:ListItem Text="Nombre"></asp:ListItem>
                                    <asp:ListItem Text="Apellido"></asp:ListItem>
                                    <asp:ListItem Text="Email"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-3">
                            <div class="mb-3">
                                <asp:Label ID="lblCriterio" runat="server" Text="Criterio"></asp:Label>
                                <asp:DropDownList ID="ddlCriterio" CssClass="form-control" AutoPostBack="true" runat="server">
                                    <asp:ListItem Text="Contiene"></asp:ListItem>
                                    <asp:ListItem Text="Igual"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                                    <div class="col-3">
                            <div class="mb-3">
                                <asp:Label ID="lblFiltroAvanzado" runat="server" Text="Filtro"></asp:Label>
                                <asp:TextBox ID="txtFiltroAvanzado" OnTextChanged="txtFiltroAvanzado_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
            <% } %>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-secondary" OnClick="btnBuscar_Click" Text="Buscar" />
                        <asp:Button ID="BtnLimpiarFiltros" Text="Limpiar filtros" runat="server" CssClass="btn btn-outline-secondary" OnClick="BtnLimpiarFiltros_Click" />
                    </div>
                </div>
            </div>
        </div>


        <asp:GridView ID="dgvUsuarios" DataKeyNames="Id" OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged"
            CssClass="table table-hover" AutoGenerateColumns="false" OnPageIndexChanging="dgvUsuarios_PageIndexChanging"
            AllowPaging="true" PageSize="5" runat="server">
            <PagerStyle CssClass="pagination" />
            <Columns>
                <asp:BoundField DataField="Rol" HeaderText="Rol" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                <asp:BoundField DataField="DNI" HeaderText="DNI" />
                <asp:ImageField DataImageUrlField="ImagenPerfil" HeaderText="Foto de Perfil" />
                <asp:BoundField DataField="Nick" HeaderText="Nickname" />
                <asp:BoundField DataField="Password" HeaderText="Contraseña" />
                <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-outline-primary" SelectText="Editar" HeaderText="Accion" />
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
</asp:Content>
