<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Estados.aspx.cs" Inherits="TPC_equipo_20.Estados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Estados</h1>
    <div class="row">
        <asp:GridView ID="dgvEstados" CssClass="table" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvEstados_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Id" InsertVisible="false" ReadOnly="true" SortExpression="id" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                <asp:CommandField ShowSelectButton="True" HeaderText="Acción" ControlStyle-CssClass="btn btn-info" SelectText="Ver" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="row">
        <div class="mb-3">
            <asp:Button ID="btnCrear" runat="server" CssClass="btn btn-primary" OnClick="btnCrear_Click" Text="Crear" />
            <a href="/Administracion.aspx" class="btn btn-warning">Regresar</a>
        </div>
    </div>
</asp:Content>
