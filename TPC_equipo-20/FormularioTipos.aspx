<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormularioTipos.aspx.cs" Inherits="TPC_equipo_20.FormularioTipos" %>

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
        .validacion{
            color: red;
            font-size:14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Tipos incidentes</h1>
    <div class="row">
        <div class="col-md-12">
            <div class="mb-3">
                <label id="lblNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" MaxLength="80" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="El nombre es requerido"  CssClass="validacion" ControlToValidate="txtNombre" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Solo letras permitidas" CssClass="validacion" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtNombre" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-primary" runat="server" OnClick="btnGuardar_Click" />
                <a href="/TiposIncidentes.aspx">Regresar</a>
            </div>
        </div>
    </div>
</asp:Content>
