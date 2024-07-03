<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Prioridades.aspx.cs" Inherits="TPC_equipo_20.Prioridades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Prioridades</h1>
    <div class="row">
        <asp:GridView ID="dgvPrioridades" CssClass="table" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnSelectedIndexChanged="dgvPrioridades_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-info" HeaderText="Acción" SelectText="Ver" />
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
