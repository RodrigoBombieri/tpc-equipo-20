<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormularioTipoIncidente.aspx.cs" Inherits="TPC_equipo_20.FormularioTipoIncidente" %>

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
    <h1>Tipos incidentes</h1>
    <div class="row custom-row border-bottom">
        <div class="col-md-12">
            <div class="mb-3">
                <label id="lblNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" MaxLength="80" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="El nombre es requerido" CssClass="validacion" ControlToValidate="txtNombre" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Solo letras permitidas" CssClass="validacion" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtNombre" runat="server" />
            </div>
        </div>
        <div class="row custom-row">
            <div class="col-md-4">
                <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-primary" runat="server" OnClick="btnGuardar_Click" />
                <a href="/TiposIncidentes.aspx" class="btn btn-warning">Regresar</a>
            </div>
        </div>
    </div>
</asp:Content>
