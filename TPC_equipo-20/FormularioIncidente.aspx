<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormularioIncidente.aspx.cs" Inherits="TPC_equipo_20.FormularioIncidente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
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
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <div class="row custom-row  mb-3 border-bottom">
        <div class="col-md-8 d-flex align-items-center">
            <h1>Creando incidente</h1>
        </div>
        <div class="col-md-4 d-flex align-items-center justify-content-end">
            <asp:Button ID="btnVolver" Text="Regresar" CssClass="btn btn-warning" runat="server" OnClick="btnVolver_Click" />
        </div>
    </div>
    <%--Cliente--%>
    <% if (!banderaCliente)
        { %>
    <div class="row custom-row" style="padding: 20px">
        <div class="mb-3">
            <asp:Label runat="server" Text="Buscar por nombre, apellido o documento (para mas filtros <a href='Clientes.aspx'>aqui</a>)."></asp:Label>
        </div>
        <div class="mb-3 d-flex">
            <asp:TextBox ID="txtFiltroCliente" CssClass="form-control me-2" runat="server"></asp:TextBox>
            <asp:Button ID="btnBuscarCliente" Text="Buscar" CssClass="btn btn-secondary" runat="server" OnClick="btnBuscarCliente_Click" />
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
                        <td colspan="2" style="text-align: center;">No hay datos disponibles, <a href="FormularioCliente.aspx?form=1">crear cliente</a>.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <%}
        else
        { %>
    <div class="row custom-row">
        <%--Incidente--%>
        <div class="col-md-6" style="padding-right: 15px;">
            <div class="row border mb-4">
                
                        <div class="mb-3">
                            <label id="lblTipo" class="form-label">Tipo de incidente</label>
                            <asp:DropDownList ID="ddlTipo" CssClass="btn btn-secondary dropdown-toggle form-select" 
                                runat="server"></asp:DropDownList>
                            <asp:Label ID="lblErrorDdlTipo" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="mb-3">
                            <label id="lblPrioridad" class="form-label">Prioridad</label>
                            <asp:DropDownList ID="ddlPrioridad" CssClass="btn btn-secondary dropdown-toggle form-select" runat="server"></asp:DropDownList>
                            <asp:Label ID="lblErrorDdlPrioridad" runat="server" Text="" ForeColor="Red"></asp:Label>
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
    <%} %>
</asp:Content>
