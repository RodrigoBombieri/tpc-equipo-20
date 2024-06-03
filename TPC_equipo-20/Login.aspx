<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC_equipo_20.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body{
            font-family: Arial, sans-serif;
            background-color: #f8f9fa;
            margin: 0;
            padding: 0;
        }

        .container{
            width: 80vw;
            margin: auto;
            height: 81.6vh;
        }

        .row{
            display: flex;
            justify-content: center;
            align-items: center;
            height: 81.6vh;
        }

        .col-4{
            background: #fff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            text-align: center;
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-4">
                <h1>Login</h1>
                <div class="mb-3">
                    <asp:Label ID="lblEmail" CssClass="form-imput" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="txtEmail" required TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblPassword" CssClass="form-imput" runat="server" Text="Contraseña"></asp:Label>
                    <asp:TextBox ID="txtPassword" required TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="btnLogin" CssClass="btn btn-primary" OnClick="btnLogin_Click" Text="Ingresar" runat="server" />
                <a href="Default.aspx"> Cancelar </a>
            </div>
        </div>
    </div>
</asp:Content>
