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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Tipos incidentes</h1>
    <div class="row">
        <asp:GridView ID="dgvTipos" DataKeyNames="Id" OnSelectedIndexChanged="dgvTipos_SelectedIndexChanged"
            CssClass="table" AutoGenerateColumns="false" OnPageIndexChanging="dgvTipos_PageIndexChanging"
            AllowPaging="true" PageSize="5" runat="server">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-info" SelectText="Ver" HeaderText="Accion" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="row">
        <div class="col-4">
            <asp:Button ID="btnCrear" Text="Crear" CssClass="btn btn-primary" runat="server" OnClick="btnCrear_Click" />
            <a href="/Administracion.aspx" class="btn btn-warning">Regresar</a>
        </div>
    </div>
</asp:Content>
