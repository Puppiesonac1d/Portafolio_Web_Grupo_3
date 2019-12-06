<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarFlujo.aspx.cs" Inherits="Portafolio.AgregarFlujo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ParentDiv" class="container-fluid" style="text-align: center; border-style: none; text-align: center; background-color: #2B7A78; height: auto;">
        <br />
        <div id="div_crear" runat="server" class="container-fluid" style="text-align: center; background-color: #17252A; width: 900px; margin-top: 50px; margin-bottom: 50px; height: auto;">
            <br />
            <h3 style="color: #9D9D9D">Ingresar descripción de flujo de tarea</h3>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Descripción de Flujo de Tarea:" ForeColor="#9D9D9D"></asp:Label>
            <asp:TextBox ID="txtNombreFlujo" runat="server"></asp:TextBox>
            <asp:Button ID="btnGuardarFlujo" runat="server" Text="Guardar Flujo" OnClick="btnGuardarFlujo_Click" BackColor="#17252A" ForeColor="#E9E9E9" />
            <br />
            <br />
        </div>
        <div id="inner_div_tabla" runat="server" class="container-fluid" style="text-align: center; background-color: #17252A; width: 900px; margin-top: 50px; margin-bottom: 50px; height: auto;">
            <br />
            <h3 style="color: #9D9D9D">Flujos de Tarea añadidos y aprobados</h3>
            <br />
            <asp:GridView ID="tblFlujo" AutoPostBack="true" runat="server" CssClass="table table-hover " GridLines="Both" Height="100px" Width="700px" HorizontalAlign="Center" ForeColor="black" AllowPaging="False" BackColor="#E5E5E5" CellPadding="10" Font-Bold="True" PageSize="6">
                <HeaderStyle ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                <PagerSettings PageButtonCount="4" />
                <SelectedRowStyle BackColor="#99CCFF" />
            </asp:GridView>
            <br />
            <asp:Label ID="lblError" runat="server" ForeColor="#9D9D9D"></asp:Label>
            <br />
            <br />
        </div>
      
    </div>
    <br />
    <br />
</asp:Content>
