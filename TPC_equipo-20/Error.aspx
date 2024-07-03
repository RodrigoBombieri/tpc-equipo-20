<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPC_equipo_20.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Aquí puedes incluir el estilo CSS que definimos anteriormente */
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        .error-container {
            width: 80%;
            max-width: 600px;
            margin: 50px auto;
            background-color: #fff;
            border: 1px solid #ccc;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            padding: 20px;
            border-radius: 5px;
        }

        .error-title {
            font-size: 24px;
            color: #333;
            margin-bottom: 15px;
        }

        .error-message {
            font-size: 18px;
            color: #555;
            margin-bottom: 20px;
        }

        .error-source {
            font-size: 14px;
            color: #777;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="error-container">
        <h3 class="error-title">Error</h3>
        <p class="error-message">
            <asp:Label ID="lblError" Text="" runat="server" /></p>
        <p class="error-source">El error ocurrió en la página: <strong><%= Request.UrlReferrer.AbsolutePath %></strong></p>
    </div>
</asp:Content>
