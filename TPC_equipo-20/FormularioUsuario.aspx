<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormularioUsuario.aspx.cs" Inherits="TPC_equipo_20.FormularioUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .mb-3 {
            margin: -10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Formulario Nuevo Usuario </h1>


    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtID" class="form-label">ID: </label>
                <asp:TextBox ID="txtID" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre: </label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un nombre" ControlToValidate="txtNombre" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido: </label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un apellido" ControlToValidate="txtApellido" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label for="txtDNI" class="form-label">DNI: </label>
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un DNI" ControlToValidate="txtDNI" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ErrorMessage="DNI inválido" ControlToValidate="txtDNI" runat="server" CssClass="text-danger" ValidationExpression="^[0-9]{8}$"></asp:RegularExpressionValidator>
            </div>
            <div class="mb-3">
                <label for="txtTelefono" class="form-label">Teléfono: </label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="regexTelefono" runat="server"
                    ControlToValidate="txtTelefono"
                    ErrorMessage="Teléfono inválido. Solo se permiten números."
                    ValidationExpression="^\d+$"
                    CssClass="text-danger">
                </asp:RegularExpressionValidator>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" />
                <a href="Usuarios.aspx" class="btn btn-secondary">Cancelar</a>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <lbl for="txtRol" class="form-label">Rol: </lbl>
                <asp:DropDownList ID="ddlRoles" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtNickname" class="form-label">Nickname: </label>
                <asp:TextBox ID="txtNickname" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un nickname" ControlToValidate="txtNickname" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email: </label>
                <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar un email" ControlToValidate="txtEmail" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ErrorMessage="Email inválido" ControlToValidate="txtEmail" runat="server" CssClass="text-danger" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label">Contraseña: </label>
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar una contraseña" ControlToValidate="txtPassword" runat="server" CssClass="text-danger"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-6">
                <asp:ScriptManager runat="server" />
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" OnClick="btnEliminar_Click" Text="Eliminar" />
                        </div>
                        <% if (confirmaEliminar)
                            { %>
                        <div class="mb-3">
                            <asp:CheckBox ID="chkConfirmaEliminar" runat="server" Text="Confirmar eliminación" />
                            <asp:Button ID="btnConfirmaEliminar" runat="server" CssClass="btn btn-outline-danger" OnClick="btnConfirmaEliminar_Click" Text="Eliminar" />
                        </div>
                        <% } %>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
</asp:Content>
