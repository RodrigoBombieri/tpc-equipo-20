<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Estados.aspx.cs" Inherits="TPC_equipo_20.Estados" %>

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
            <h1>Estados</h1>
        </div>
        <div class="col-md-4 d-flex align-items-center justify-content-end">
            <asp:Button ID="btnCrear" runat="server" CssClass="btn btn-primary" OnClick="btnCrear_Click" Text="Crear Estado" />
            <a href="/Administracion.aspx" class="btn btn-warning">Regresar</a>
        </div>
    </div>
    <div class="row">
            <asp:GridView ID="dgvEstados" CssClass="table table-hover" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvEstados_SelectedIndexChanged">
                <PagerStyle CssClass="pagination" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Id" InsertVisible="false" ReadOnly="true" SortExpression="id" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                    <asp:CommandField ShowSelectButton="True" HeaderText="Acción" ControlStyle-CssClass="btn btn-info" SelectText="Ver" />
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
