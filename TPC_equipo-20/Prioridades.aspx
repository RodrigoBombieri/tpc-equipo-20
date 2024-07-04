<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Prioridades.aspx.cs" Inherits="TPC_equipo_20.Prioridades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
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
            <h1>Prioridades</h1>
        </div>
        <div class="col-md-4 d-flex align-items-center justify-content-end">
            <asp:Button ID="btnCrear" runat="server" CssClass="btn btn-primary" OnClick="btnCrear_Click" Text="Crear Prioridad" />
            <a href="/Administracion.aspx" class="btn btn-warning">Regresar</a>
        </div>
    </div>
    <div class="row">
        <asp:GridView ID="dgvPrioridades" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnSelectedIndexChanged="dgvPrioridades_SelectedIndexChanged">
            <PagerStyle CssClass="pagination" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-info" HeaderText="Acción" SelectText="Ver" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
