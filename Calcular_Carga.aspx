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
        <div id="inner_div_pendiente_usuario_tabla_2" class="container-fluid" style="text-align: center; vertical-align: top; left: auto; height: 100%; overflow: auto; width: auto;">
            <asp:GridView ID="tablaPendientes2" AutoPostBack="true" runat="server" CssClass="table table-hover " GridLines="Both" Height="100px" Width="1429px" HorizontalAlign="Center" ForeColor="black" AllowPaging="True" BackColor="White" CellPadding="10" Font-Bold="True" PageSize="6">
                <HeaderStyle ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                <PagerSettings PageButtonCount="4" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <SelectedRowStyle BackColor="#3399FF" />
            </asp:GridView>
        </div>
        <asp:Button ID="btnAsignar_2" runat="server" Text="Asignar a usuario" OnClick="btnAsignar_2_Click" />
        <br />
        <br />
    </div>
    <br />
    <br />
    <div id="inner_div_crud_tarea_carga" class="container-fluid" style="text-align: center; border: 3px black; background-color: #222222;">
        <h3 style="color: #9D9D9D">Tareas asignadas al usuario</h3>
        <div id="inner_div_carga_usuario_tabla" class="container-fluid" style="text-align: center; vertical-align: top; left: auto; height: 100%; overflow: auto; width: auto;">
            <asp:GridView ID="tablaCarga" AutoPostBack="true" runat="server" CssClass="table table-hover " GridLines="Both" Height="100px" Width="1429px" HorizontalAlign="Center" ForeColor="black" AllowPaging="True" BackColor="White" CellPadding="10" Font-Bold="True" PageSize="6">
                <HeaderStyle ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                <PagerSettings PageButtonCount="4" />
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
        <h3 style="color: #9D9D9D">Tareas subordinadas</h3>
        <div id="inner_div_carga_usuario_tabla_2" class="container-fluid" style="text-align: center; vertical-align: top; left: auto; height: 100%; overflow: auto; width: auto;">
            <asp:GridView ID="tablaCarga2" AutoPostBack="true" runat="server" CssClass="table table-hover " GridLines="Both" Height="100px" Width="1429px" HorizontalAlign="Center" ForeColor="black" AllowPaging="True" BackColor="White" CellPadding="10" Font-Bold="True" PageSize="6">
                <HeaderStyle ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                <PagerSettings PageButtonCount="4" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <SelectedRowStyle BackColor="#3399FF" />
            </asp:GridView>
        </div>
        <asp:DropDownList ID="ddlCambiarEstado2" runat="server" Height="30px" Width="175px">
        </asp:DropDownList>
        &nbsp;
            <asp:Button ID="btnCargarTareas2" runat="server" Text="Cambiar estado de tarea" OnClick="btnCargarTareas_2_Click" />
        <br />
        <br />
    </div>
</asp:Content>
