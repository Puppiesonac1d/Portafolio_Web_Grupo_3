<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarFlujo.aspx.cs" Inherits="Portafolio.AgregarFlujo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ParentDiv" class="container-fluid" style="text-align: center; border: 3px black; background-color: #222222;">
        <br />
        <div id="inner_div_crear" class="container-fluid" style="text-align: center; border: 3px black; background-color: #222222;">
            <br />
            <h3 style="color: #9D9D9D">Ingresar descripción de flujo de tarea</h3>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Descripción de Flujo de Tarea:" ForeColor="#9D9D9D"></asp:Label>
            <asp:TextBox ID="txtNombreFlujo" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Button ID="btnGuardarFlujo" runat="server" Text="Guardar Flujo" OnClick="btnGuardarFlujo_Click" />
            <br />
            <br />
        </div>
        <br />
        <br />
    </div>
    <br />
    <br />
    <div id="inner_div_tabla" class="container-fluid" style="text-align: center; border: 3px grey; background-color: #222222;">
        <br />
        <h3 style="color: #9D9D9D">Flujos de Tarea Añadidos</h3>
        <br />
        <br />
        <div id="inner_div_tabla_contenido" class="container-fluid" style="text-align: center; border: 3px black; background-color: #222222;">
            <br />
            <asp:GridView ID="tblFlujo" runat="server" AutoPostBack="true" CssClass="table table-hover " GridLines="Both" Height="100px" Width="1429px" HorizontalAlign="Center" ForeColor="#9D9D9D">
            </asp:GridView>
            <br />
        </div>
        <br />
        <br />
        <asp:Label ID="lblError" runat="server" ForeColor="#9D9D9D"></asp:Label>
        <br />
        <br />
    </div>
    <br />
    <br />
</asp:Content>
