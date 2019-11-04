<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calcular_Carga.aspx.cs" Inherits="Portafolio.Calcular_Carga" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="div_calcular_carga_correo" class="container-fluid" style="text-align: center; border: 3px black; background-color: #222222;" runat="server">
        <div id="inner_div_correo" class="container-fluid" style="text-align: center; border: 3px black">
            <h3 style="color: #9D9D9D">Usuario</h3>
            <asp:TextBox ID="txtCorreo" runat="server" Width="300px"></asp:TextBox>
        </div>
        <br />
        <br />
    </div>
    <br />
    <br />
    <div id="inner_div_crud_tarea_pendiente" class="container-fluid" style="text-align: center; border: 3px black; background-color: #222222;">
        <h3 style="color: #9D9D9D">Tareas pendientes de asignación</h3>
        <asp:Label ID="txtError_asignacion" runat="server" ForeColor="#9D9D9D"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="tablaPendientes" AutoPostBack="true" runat="server" Width="100%" CssClass="table table-hover" GridLines="Both" ForeColor="#9D9D9D">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="#3399FF" />
        </asp:GridView>
        <asp:Button ID="btnAsignar" runat="server" Text="Asignar a usuario" OnClick="btnAsignar_Click" />
        <br />
        <br />
    </div>
    <br />
    <br />
    <div id="inner_div_crud_tarea_carga" class="container-fluid" style="text-align: center; border: 3px black; background-color: #222222;">
        <h3 style="color: #9D9D9D">Carga de Usuario</h3>
        <br />
        <br />
        <asp:Button ID="btnCalcularCarga" runat="server" Text="Calcular carga de usuario" OnClick="btnCalcularCarga_Click" />
        <br />
        <br />
        <div id="inner_div_carga_usuario_tabla" class="container-fluid" style="text-align: center;">
            <asp:GridView ID="tablaCarga" AutoPostBack="true" runat="server" Width="100%" CssClass="table table-hover" GridLines="Both" BackColor="#222222" ForeColor="#9D9D9D">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <SelectedRowStyle BackColor="#3399FF" />
            </asp:GridView>
        </div>
        <asp:DropDownList ID="ddlCambiarEstado" runat="server" Height="30px" Width="175px">
        </asp:DropDownList>
        &nbsp;
            <asp:Button ID="btnCargarTareas" runat="server" Text="Cambiar estado de tarea" OnClick="btnCargarTareas_Click" />
        <br />
        <br />
    </div>
    <asp:Label ID="lblError" runat="server" ForeColor="#9D9D9D"></asp:Label>

</asp:Content>
