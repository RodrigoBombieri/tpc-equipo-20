<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_equipo_20.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: bisque;
        }

        .imagen, .botonInicioSesion {
            display: flex;
            justify-content: center;
            align-items: center;
            animation: movimientoImagen 5s infinite alternate;
        }

        .imagen-fondo {
            width: 300px;
            height: 300px;
            border-radius: 50%;
            transition: box-shadow 0.3s ease;
        }

            .imagen-fondo:hover {
                box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
                background-color: white;
            }

        .btnInicio {
            width: 350px;
            height: 90px;
            font-size: 50px;
        }

            .btnInicio:hover {
                background-color: white;
                color: blue;
            }

        @keyframes movimientoImagen {
            0% {
                transform: translateX(0);
            }

            100% {
                transform: translateX(20px);
            }
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>CALL CENTER </h1>
    </div>
    <h2>Bienvenido al sistema de gestión de llamadas </h2>
    <div class="imagen">
        <img class="imagen-fondo" src="/Images/fondo-default.png" alt="fondo" />
    </div>
    <div class="botonInicioSesion">
        <% if (!negocio.Seguridad.SesionActiva(Session["usuario"]))
            { %>
        <asp:Button ID="btnInicioSesion" CssClass="btn btn-primary btnInicio" runat="server" Text="Inicia Sesión" OnClick="btnInicioSesion_Click" />
        <% } else { 
            // Obtiene la instancia de Usuario desde Session["usuario"]
            // para mostrar el nombre y el apellido del usuario logueado en el inicio.
            dominio.Usuario usuario = Session["usuario"] as dominio.Usuario;
            if (usuario != null)
            {
        %>
            <h2> Bienvenido, <%: usuario.ToString() %> </h2>
        <% 
            }
        } %>
    </div>
</asp:Content>
