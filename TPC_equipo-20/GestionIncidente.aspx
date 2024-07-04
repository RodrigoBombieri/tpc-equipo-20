<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GestionIncidente.aspx.cs" Inherits="TPC_equipo_20.GestionIncidente" %>

<%@ Register Src="~/ControlUsuarios.ascx" TagPrefix="uc" TagName="ControlUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .large-badge {
            font-size: 0.8rem; /* Ajusta el tamaño de fuente según lo necesario */
            padding: 0.5em 1em; /* Ajusta el relleno según lo necesario */
        }

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

        .estado-color {
        }

        .form-control {
            border: 1px solid #ced4da; /* gris claro */
            border-radius: 0.5rem;
            font-size: 1rem;
            transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
        }

            .form-control:focus {
                border-color: #007bff;
                box-shadow: 0 0 0 0.2rem rgba(0, 123, 255, 0.25);
            }

        .form-label {
            font-weight: bold;
            color: #495057;
        }

        .text-danger {
            color: #dc3545; /* rojo para mensajes de error */
        }

        .form-group {
            margin-bottom: 2rem;
        }

            .form-group label {
                margin-bottom: 0.5rem;
            }

        .container {
            margin-top: 2rem;
            padding: 2rem;
            background-color: #fff;
            box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.15);
            border-radius: 0.5rem;
        }

        .custom-row {
            background-color: #f8f9fa;
            border: 1px solid #dee2e6;
            border-radius: 0.25rem;
            padding: 10px 20px;
        }

        .card {
            background-color: #fff;
            border: 1px solid #dee2e6;
            border-radius: 0.25rem;
            box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.15);
            padding: 0.5rem;
            margin-bottom: 1rem;
        }

            .card:hover {
                box-shadow: 0 0 0 0.2rem rgba(0, 123, 255, 0.25);
            }

        .card-title {
            font-size: 1.25rem;
            font-weight: bold;
            color: #007bff; /* Color azul */
            margin-bottom: 0.75rem;
        }

        .card-body {
            padding: 1rem;
            display: flex;
            flex-direction: column;
            justify-content: center;
        }

            .card-body div {
                margin-bottom: 0.5rem;
            }

            .card-body .form-label {
                font-weight: bold;
                color: #495057;
            }

            .card-body .btn {
                margin-top: 0.5rem;
                align-self: center;
            }

        .info-value {
            font-weight: normal;
            color: #6c757d;
        }

        .btn-outline-primary {
            display: inline-block;
            justify-content: center;
            align-items: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        // Función para manejar el clic del botón y cancelar el postback
        function handleClick() {
            var textBoxValue = document.getElementById('<%= txtDetalleAccion.ClientID %>').value.trim();
            //alert(textBoxValue);
            if (textBoxValue === '') {
                showModal();
                return false;
            }
            return true;
        }
        // Función para mostrar el modal
        function showModal() {
            var modal = new bootstrap.Modal(document.getElementById('detalleRequerido'));
            modal.show();
        }
    </script>
    <!-- Modal -->
    <div class="modal fade" id="detalleRequerido" tabindex="-1" aria-labelledby="ModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="ModalLabel">Campo requerido</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
                </div>
                <div class="modal-body">
                    Ingrese el detalle para continuar.
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <div class="row custom-row mb-3 border-bottom">
        <div class="col-md-8 d-flex align-items-center">
            <asp:Label ID="lblNumIncidente" CssClass="h1" Style="margin-right: 10px;" runat="server"></asp:Label>
            <asp:Label ID="lblEstado" CssClass="badge rounded-pill text-bg-info large-badge estado-color" Style="margin-right: 10px;" runat="server">Estado</asp:Label>
            <asp:Label ID="lblVigencia" CssClass="badge rounded-pill text-bg-warning large-badge" runat="server">Vigencia</asp:Label>
        </div>
        <div class="col-md-4 d-flex align-items-center justify-content-end">
            <asp:Button ID="btnVolver" Text="Regresar" CssClass="btn btn-warning" runat="server" OnClick="btnVolver_Click" />
        </div>
    </div>
    <div class="row custom-row">
        <div class="col-md-6" style="padding-right: 15px;">
            <%--Incidente--%>
            <div class="row custom-row border mb-4">
                <div class="mb-3">
                    <label id="lblTipo" class="form-label">Tipo de incidente</label>
                    <asp:DropDownList ID="ddlTipo" CssClass="btn btn-secondary dropdown-toggle form-select" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label id="lblPrioridad" class="form-label">Prioridad</label>
                    <asp:DropDownList ID="ddlPrioridad" CssClass="btn btn-secondary dropdown-toggle form-select" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3 text-end">
                    <%--<asp:Button ID="Button1" Text="Cancelar" CssClass="btn btn-danger" runat="server" />--%>
                    <asp:Button ID="btnModificarIncidente" Text="Modificar" CssClass="btn btn-secondary me-2" runat="server" OnClick="btnModificarIncidente_Click" />
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblCreado" class="form-label" runat="server"></asp:Label>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblUsuarioAsignado" class="form-label" runat="server"></asp:Label>
                </div>
                <div class="mb-3">
                    <label id="lblDetalle1" class="form-label">Detalle</label>
                    <asp:TextBox ID="txtDetalle" TextMode="MultiLine" CssClass="form-control" Enabled="false" runat="server" />
                </div>
            </div>
        </div>

        <div class="col-md-6" style="padding-right: 15px;">
            <%--Cliente--%>
            <div class="col-md-6 mb-4">


                <div class="card" style="width: 18rem;">
                    <div class="card-body">
                        <h5 class="card-title">Cliente:</h5>
                        <div>
                            <asp:Label ID="lblNombreApellido" class="form-label" runat="server"></asp:Label>
                        </div>
                        <div>
                            <span class="info-value">D.N.I:</span>
                            <asp:Label ID="lblDocumento" class="info-value" runat="server"></asp:Label>
                        </div>
                        <div>
                            <span class="info-value">Tel.:</span>
                            <asp:Label ID="lblTelefono1" class="info-value" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblEmail" class="info-value" runat="server"></asp:Label>
                        </div>

                        <asp:Button ID="btnModificarUsuario" Text="Modificar Cliente" CssClass="btn btn-outline-primary me-2" runat="server" />
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <%--Acciones--%>
            <div class="col-md-12 border mb-4">

                <div class="row custom-row" style="padding-bottom: 10px">
                    <div class="col-md-8 d-flex align-items-center">
                        <label id="lblTipoAccion" class="form-label">Seguimiento:</label>
                    </div>
                    <div class="col-md-4 d-flex align-items-center justify-content-end">

                        <% if (banderaReabrirCaso)
                            {
                        %>
                        <asp:Button ID="btnReabrir" Text="Re-abrir" CssClass="btn btn-primary me-2" runat="server"
                            OnClick="btnReabrir_Click" OnClientClick="return handleClick();" />
                        <%}
                            else
                            {
                                if (!negocio.Seguridad.EsTelefonista(Session["usuario"]))
                                {%>
                        <asp:Button ID="btnReasignar" Text="Reasignar" CssClass="btn btn-primary me-2" runat="server" OnClick="btnReasignar_Click" />
                        <%}%>
                        <asp:Button ID="btnCerrar" Text="Cerrar incidente" CssClass="btn btn-primary me-2" runat="server"
                            OnClick="btnCerrar_Click" OnClientClick="return handleClick();" />
                        <asp:Button ID="btnResolver" Text="Resolver incidente" CssClass="btn btn-primary me-2" runat="server"
                            OnClick="btnResolver_Click" OnClientClick="return handleClick();" />
                        <%} %>
                        <%--<asp:Button ID="Button4" Text="Volver" CssClass="btn btn-primary" runat="server" OnClick="btnVolver_Click" />--%>
                    </div>
                </div>

                <%--Usuario--%>
                <% if (banderaUsuario)
                    { %>
                <div class="row custom-row" style="padding: 20px">
                    <div class="mb-3">
                        <asp:Label runat="server" Text="Buscar por nombre, apellido o documento."></asp:Label>
                    </div>
                    <div class="mb-3 d-flex">
                        <asp:TextBox ID="txtFiltroUsuario" AutoPostBack="false" CssClass="form-control me-2" runat="server"></asp:TextBox>
                        <asp:Button ID="btnBuscarUsuario" Text="Buscar" CssClass="btn btn-secondary" runat="server" OnClick="btnBuscarUsuario_Click" />
                    </div>
                    <asp:GridView ID="dgvUsuarios" DataKeyNames="Id" OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged"
                        CssClass="table table-hover" AutoGenerateColumns="false" OnPageIndexChanging="dgvUsuarios_PageIndexChanging"
                        AllowPaging="true" PageSize="5" runat="server" ShowHeaderWhenEmpty="True">
                        <PagerStyle CssClass="pagination" />
                        <Columns>
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                            <asp:BoundField HeaderText="Dni" DataField="Dni" />
                            <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-primary" SelectText="Seleccionar" HeaderText="Seleccionar" />
                        </Columns>
                        <EmptyDataTemplate>
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="2" style="text-align: center;">No se encontraron usuarios.</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
                <%}
                    else
                    { %>
                <div class="row custom-row" style="padding: 20px">
                    <div class="mb-3">
                        <asp:DropDownList ID="ddlTipoAccion" CssClass="btn btn-secondary dropdown-toggle form-select" runat="server"></asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label id="lblDetalle" class="form-label">Detalle</label>
                        <asp:TextBox ID="txtDetalleAccion" TextMode="MultiLine" CssClass="form-control" runat="server" />
                    </div>
                    <div class="row" style="margin-top: 10px">
                        <div class="mb-3 text-end">
                            <%--<asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn btn-danger" runat="server" />--%>
                            <asp:Button ID="btnGuardarAccion" Text="Guardar" CssClass="btn btn-success me-2" runat="server" OnClick="btnGuardarAccion_Click" />
                        </div>
                    </div>
                    <div class="mb-3">
                        <asp:GridView ID="dgvAcciones" DataKeyNames="Id" OnSelectedIndexChanged="dgvAcciones_SelectedIndexChanged"
                            CssClass="table table-hover" AutoGenerateColumns="false" OnPageIndexChanging="dgvAcciones_PageIndexChanging"
                            AllowPaging="true" PageSize="5" runat="server" ShowHeaderWhenEmpty="True">
                            <PagerStyle CssClass="pagination" />
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
                <%}%>
            </div>
        </div>
    </div>
</asp:Content>
