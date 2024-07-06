<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TiposIncidentes.aspx.cs" Inherits="TPC_equipo_20.TiposIncidentes" %>

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

        .btn{
            margin: 5px;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3 border-bottom">
        <div class="col-md-8 d-flex align-items-center">
            <h1>Tipos incidentes</h1>
        </div>
        <div class="col-md-4 d-flex align-items-center justify-content-end">
            <asp:Button ID="btnCrear" Text="Crear Tipo de Incidente" CssClass="btn btn-primary" runat="server" OnClick="btnCrear_Click" />
            <a href="/Administracion.aspx" class="btn btn-warning">Regresar</a>
        </div>
    </div>
    <div class="row">
        <asp:GridView ID="dgvTipos" DataKeyNames="Id" OnSelectedIndexChanged="dgvTipos_SelectedIndexChanged"
            CssClass="table table-hover" AutoGenerateColumns="false" OnPageIndexChanging="dgvTipos_PageIndexChanging"
            AllowPaging="true" PageSize="5" runat="server">
            <PagerStyle CssClass="pagination" />
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-info" SelectText="Ver" HeaderText="Accion" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
