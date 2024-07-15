<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Fin.aspx.cs" Inherits="Entelgy_Pandero.Fin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div>
            <h2>La sesión ha terminado</h2>
            <p>Puede cerrar esta ventana.</p>
            <button onclick="window.open('', '_self', '');window.close();">Cerrar Ventana</button>
        </div>



</asp:Content>
