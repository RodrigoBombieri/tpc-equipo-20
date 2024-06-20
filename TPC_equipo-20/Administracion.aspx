<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="TPC_equipo_20.Administracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .custom-card {
            height: 100%;
        }

            .custom-card .card-img-top {
                object-fit: cover;
                height: 200px;
            }
        .custom-card:hover{
            /*Poner algún efecto cuando se posiciona el mouse sobre la card*/
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Administración</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-6">
                <div class="card custom-card">
                    <img src="../Images/prioridades.jpg" class="card-img-top" alt="...">
                    <div class="card-body d-flex flex-column">
                        <h5 class="card-title">ABM Prioridades</h5>
                        <p class="card-text">Administración de Altas, Bajas y Modificación de Prioridades para los incidentes.</p>
                        <asp:Button ID="btnPrioridades" Text="Prioridades" runat="server" CssClass="btn btn-primary mt-auto" OnClick="btnPrioridades_Click" />
                    </div>
                </div>
                <div class="card custom-card">
                    <img src="../Images/Estado.jpg" class="card-img-top" alt="...">
                    <div class="card-body d-flex flex-column">
                        <h5 class="card-title">ABM Estados</h5>
                        <p class="card-text">Administración de Altas, Bajas y Modificación de Estados para los incidentes.</p>
                        <asp:Button ID="btnEstados" Text="Estados" runat="server" CssClass="btn btn-primary mt-auto" OnClick="btnEstados_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-6">
                <div class="card custom-card">
                    <img src="../Images/tiposIncidente.png" class="card-img-top" alt="...">
                    <div class="card-body d-flex flex-column">
                        <h5 class="card-title">ABM Tipos de Incidentes</h5>
                        <p class="card-text">Administración de Altas, Bajas y Modificación de Tipos de incidentes.</p>
                        <asp:Button ID="btnTipos" Text="Tipos incidentes" runat="server" CssClass="btn btn-primary mt-auto" OnClick="btnTipos_Click" />
                    </div>
                </div>
                <div class="card custom-card">
                    <img src="../Images/roles.jpg" class="card-img-top" alt="...">
                    <div class="card-body d-flex flex-column">
                        <h5 class="card-title">ABM Roles de Usuarios</h5>
                        <p class="card-text">Administración de Altas, Bajas y Modificación de Roles de Usuarios.</p>
                        <asp:Button ID="btnRoles" Text="Roles" runat="server" CssClass="btn btn-primary mt-auto" OnClick="btnRoles_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
