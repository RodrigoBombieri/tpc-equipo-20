<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalleCliente.aspx.cs" Inherits="TPC_equipo_20.DetalleCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <hr>
        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label id="lblNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un nombre" ControlToValidate="txtNombre" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <label id="lblDni" class="form-label">DNI</label>
                    <asp:TextBox ID="txtDni" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un DNI" ControlToValidate="txtDni" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ErrorMessage="Ingrese sólo números" ControlToValidate="txtDni" runat="server" CssClass="text-danger" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                </div>
                <div class="mb-3">
                    <label id="lblTelefono1" class="form-label">Telefono 1</label>
                    <asp:TextBox ID="txtTelefono1" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label id="lblFechaNac" class="form-label">Fecha de Nacimiento</label>
                    <asp:TextBox ID="txtFechaNac" CssClass="form-control" runat="server" TextMode="Date" />
                    <asp:RequiredFieldValidator ErrorMessage="Debe ingresar una fecha de nacimiento" ControlToValidate="txtFechaNac" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-6">
                <div class="mb-3">
                    <label id="lblApellido" class="form-label">Apellido</label>
                    <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un apellido" ControlToValidate="txtApellido" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <label id="lblEmail" class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un email" ControlToValidate="txtEmail" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ErrorMessage="Email inválido" ControlToValidate="txtEmail" runat="server" CssClass="text-danger" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
                </div>
                <div class="mb-3">
                    <label id="lblTelefono2" class="form-label">Telefono 2</label>
                    <asp:TextBox ID="txtTelefono2" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label id="lblFechaCreacion" class="form-label">Fecha de Alta</label>
                    <asp:TextBox ID="txtFechaCreacion" CssClass="form-control" runat="server" TextMode="Date" />
                </div>
            </div>
        </div>
        <div class="row">
            <h3>Domicilio </h3>
            <div class="col-md-6">
                <div class="mb-3">
                    <label id="lblCalle" class="form-label">Calle</label>
                    <asp:TextBox ID="txtCalle" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="Debe ingresar una calle" ControlToValidate="txtCalle" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <label id="lblPiso" class="form-label">Piso</label>
                    <asp:TextBox ID="txtPiso" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label id="lblLocalidad" class="form-label">Localidad</label>
                    <asp:TextBox ID="txtLocalidad" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="Debe ingresar una localidad" ControlToValidate="txtLocalidad" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <label id="lblProvincia" class="form-label">Provincia</label>
                    <asp:DropDownList ID="ddlProvincias" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-6">
                <div class="mb-3">
                    <label id="lblNumero" class="form-label">Número</label>
                    <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un número" ControlToValidate="txtNumero" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <label id="lblDepartamento" class="form-label">Departamento</label>
                    <asp:TextBox ID="txtDepartamento" CssClass="form-control" runat="server" />
                </div>
                <div class="mb-3">
                    <label id="lblCodigoPostal" class="form-label">Código Postal</label>
                    <asp:TextBox ID="txtCodigoPostal" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un código postal" ControlToValidate="txtCodigoPostal" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ErrorMessage="Ingrese sólo números" ControlToValidate="txtCodigoPostal" runat="server" CssClass="text-danger" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <div class="mb-3">
                    <label id="lblObservaciones" class="form-label">Observaciones</label>
                    <asp:TextBox ID="txtObservaciones" TextMode="MultiLine" CssClass="form-control" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <%if (Request.QueryString["id"] == null)
                {%>
            <div class="col-md-1">
                <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-primary" runat="server" OnClick="btnGuardar_Click" />
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
            <%}
            else
            { %>
            <div class="col-md-1">
                <asp:Button ID="btnEditar" Text="Editar" CssClass="btn btn-primary" runat="server" OnClick="btnEditar_Click" AutoPostBack="false" />
            </div>
            <%    }%>
            <div class="col-md-1">
                <asp:ScriptManager runat="server" />
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
            <%    }%>
            <div class="col-md-2">
                <a href="/ListadoClientes.aspx">Volver al listado</a>
            </div>
        </div>
    </div>
</asp:Content>
