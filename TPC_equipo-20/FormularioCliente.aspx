<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="TPC_equipo_20.FormularioCliente" %>

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
            background-color: #f8f9fa; /* Color de fondo */
            border: 1px solid #dee2e6; /* Borde delgado */
            border-radius: 0.25rem; /* Bordes redondeados */
            padding: 10px 20px; /* Espaciado interno */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <hr>
    <div class="row custom-row border-bottom">
        <h3>Datos Personales </h3>
        <div class="col-md-6">
            <div class="mb-3">
                <label id="lblNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" TabIndex="1" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un nombre" ControlToValidate="txtNombre" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label id="lblDni" class="form-label">DNI</label>
                <asp:TextBox ID="txtDni" CssClass="form-control" TabIndex="3" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un DNI" ControlToValidate="txtDni" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ErrorMessage="Ingrese sólo números" ControlToValidate="txtDni" runat="server" CssClass="text-danger" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
            </div>
            <div class="mb-3">
                <label id="lblTelefono1" class="form-label">Telefono 1</label>
                <asp:TextBox ID="txtTelefono1" CssClass="form-control" TabIndex="5" runat="server" />
            </div>
            <div class="mb-3">
                <label id="lblFechaNac" class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox ID="txtFechaNac" CssClass="form-control" TabIndex="7" runat="server" TextMode="Date" />
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar una fecha de nacimiento" ControlToValidate="txtFechaNac" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="col-md-6">
            <div class="mb-3">
                <label id="lblApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" TabIndex="2" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un apellido" ControlToValidate="txtApellido" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label id="lblEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" TabIndex="4" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un email" ControlToValidate="txtEmail" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ErrorMessage="Email inválido" ControlToValidate="txtEmail" runat="server" CssClass="text-danger" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
            </div>
            <div class="mb-3">
                <label id="lblTelefono2" class="form-label">Telefono 2</label>
                <asp:TextBox ID="txtTelefono2" CssClass="form-control" TabIndex="6" runat="server" />
            </div>
            <div class="mb-3">
                <label id="lblFechaCreacion" class="form-label">Fecha de Alta</label>
                <asp:TextBox ID="txtFechaCreacion" CssClass="form-control" runat="server" TextMode="Date" />
            </div>
        </div>
    </div>
    <hr>
    <div class="row custom-row">
        <h3>Domicilio </h3>
        <div class="col-md-6">
            <div class="mb-3">
                <label id="lblCalle" class="form-label">Calle</label>
                <asp:TextBox ID="txtCalle" CssClass="form-control" TabIndex="8" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar una calle" ControlToValidate="txtCalle" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label id="lblPiso" class="form-label">Piso</label>
                <asp:TextBox ID="txtPiso" CssClass="form-control" TabIndex="10" runat="server" />
            </div>
            <div class="mb-3">
                <label id="lblLocalidad" class="form-label">Localidad</label>
                <asp:TextBox ID="txtLocalidad" CssClass="form-control" TabIndex="12" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar una localidad" ControlToValidate="txtLocalidad" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label id="lblProvincia" class="form-label">Provincia</label>
                        <asp:DropDownList ID="ddlProvincias" runat="server" CssClass="form-select" TabIndex="14"></asp:DropDownList>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-md-6">
            <div class="mb-3">
                <label id="lblNumero" class="form-label">Número</label>
                <asp:TextBox ID="txtNumero" CssClass="form-control" TabIndex="9" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un número" ControlToValidate="txtNumero" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label id="lblDepartamento" class="form-label">Departamento</label>
                <asp:TextBox ID="txtDepartamento" CssClass="form-control" TabIndex="11" runat="server" />
            </div>
            <div class="mb-3">
                <label id="lblCodigoPostal" class="form-label">Código Postal</label>
                <asp:TextBox ID="txtCodigoPostal" CssClass="form-control" TabIndex="13" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un código postal" ControlToValidate="txtCodigoPostal" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ErrorMessage="Ingrese sólo números" ControlToValidate="txtCodigoPostal" runat="server" CssClass="text-danger" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="row custom-row">
            <div class="mb-3">
                <label id="lblObservaciones" class="form-label">Observaciones</label>
                <asp:TextBox ID="txtObservaciones" TextMode="MultiLine" TabIndex="15" CssClass="form-control" runat="server" />
            </div>
        </div>
    </div>
    <%if (Request.QueryString["id"] != null)
        {%>
    <hr>
    <div class="row custom-row">
        <h3>Incidentes </h3>
        <div class="col">
            <asp:GridView runat="server" ID="dgvIncidentes" CssClass="table" DataKeyNames="Id" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvIncidentes_SelectedIndexChanged" OnPageIndexChanging="dgvIncidentes_PageIndexChanging"
                AllowPaging="true" PageSize="5">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="Id" />
                    <asp:BoundField HeaderText="Fecha de Creación" DataField="FechaCreacion" />
                    <asp:BoundField HeaderText="Tipo" DataField="Tipo.Nombre" />
                    <asp:BoundField HeaderText="Prioridad" DataField="Prioridad.Nombre" />
                    <asp:BoundField HeaderText="Estado" DataField="Estado.Nombre" />
                    <asp:BoundField DataField="UsuarioAsignado.Nombre" />
                    <asp:BoundField DataField="UsuarioAsignado.Apellido" />
                    <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-primary" SelectText="Ver más" />
                </Columns>
                <EmptyDataTemplate>
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="2" style="text-align: center;">No hay incidentes para mostrar.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
    <%  }      %>
    <div class="row custom-row">
        <%if (Request.QueryString["id"] == null)
            {%>
        <div class="col-md-2">
            <asp:Button ID="btnGuardar" Text="Guardar Cliente" CssClass="btn btn-primary" runat="server" OnClick="btnGuardar_Click" />
        </div>
        <%if (Request.QueryString["form"] == null)
            {%>
        <div class="col-md-2">
            <asp:Button ID="btnGuardarCrear" Text="Guardar y Crear incidente" CssClass="btn btn-info" runat="server" OnClick="btnGuardarCrear_Click" />
        </div>
                <%  }    %>
        <div class="col-md-2" style="margin-left: 20px; margin-bottom: 5px;">
            <a href="Clientes.aspx" class="btn btn-warning">Volver al listado</a>
        </div>
        <%  }
            else
            {%>
        <% if (confirmarEditar)
            {
        %>
        <div class="col-md-1">
            <asp:Button ID="btnGuardarEdicion" Text="Guardar" CssClass="btn btn-primary" runat="server" OnClick="btnGuardarEdicion_Click" />
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnGuardarEdicionCrear" Text="Guardar y Crear incidente" CssClass="btn btn-primary" runat="server" OnClick="btnGuardarEdicionCrear_Click" />
        </div>
        <%}
            else
            { %>
        <div class="col-md-1">
            <asp:Button ID="btnEditar" Text="Editar" CssClass="btn btn-primary" runat="server" OnClick="btnEditar_Click" AutoPostBack="false" />
        </div>
        <div class="col-md-2">
            <asp:Button ID="CrearIncidente" Text="Crear incidente" CssClass="btn btn-primary" runat="server" OnClick="CrearIncidente_Click" />
        </div>
        <%    }%>
        <div class="col-md-1">
            <asp:UpdatePanel ID="UpdatePanel" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" OnClick="btnEliminar_Click" Text="Eliminar" />
                    </div>
                    <% if (confirmaEliminar)
                        { %>
                    <div class="col-md-1">
                        <asp:CheckBox ID="chkConfirmaEliminar" runat="server" Text="Confirmar eliminación" />
                        <asp:Button ID="btnConfirmaEliminar" runat="server" CssClass="btn btn-outline-danger" OnClick="btnConfirmaEliminar_Click" Text="Eliminar" />
                    </div>
                    <% } %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-md-2">
            <a href="Clientes.aspx" class="btn btn-warning">Volver al listado</a>
        </div>
        <%    }%>
    </div>
</asp:Content>
