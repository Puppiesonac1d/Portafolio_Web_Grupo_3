<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calcular_Carga.aspx.cs" Inherits="Portafolio.Calcular_Carga" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="div_tareas_pendientes" class="container-fluid" style="border-style: none; text-align: center; background-color: #2B7A78; height: auto;">
        <div style="background-color: #17252A; width: 100%; margin-top: 50px;margin-bottom:50px; height: auto;">
            <h3 style="color: #9D9D9D">Tareas pendientes de asignación</h3>
            <asp:Label ID="txtError_asignacion" runat="server" ForeColor="#9D9D9D"></asp:Label>
            <asp:GridView ID="tablaPendientes" AutoPostBack="true" runat="server" CssClass="table table-hover " GridLines="Both" Height="100px" Width="700px" HorizontalAlign="Center" ForeColor="black" AllowPaging="True" BackColor="#E5E5E5" CellPadding="10" Font-Bold="True" PageSize="6">
                <HeaderStyle ForeColor="#9D9D9D" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="Black" />
                <PagerSettings PageButtonCount="4" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <RowStyle BackColor="Orange" />
                <SelectedRowStyle BackColor="#99CCFF" />
            </asp:GridView>
            <asp:Label ID="lblMensaje" runat="server" Text="Felicidades, estás al día." ForeColor="#9D9D9D"></asp:Label>
            <asp:Button ID="btnAsignar" runat="server" Text="Asignar a usuario" OnClick="btnAsignar_Click" BackColor="#17252A" ForeColor="#E9E9E9" />
            <br />
            <br />
            <h3 style="color: #9D9D9D">Tareas subordinadas pendientes de asignación</h3>
            <asp:GridView ID="tablaPendientes2" AutoPostBack="true" runat="server" CssClass="table table-hover " GridLines="Both" Height="100px" Width="700px" HorizontalAlign="Center" ForeColor="black" AllowPaging="True" BackColor="#E5E5E5" CellPadding="10" Font-Bold="True" PageSize="6">
                <HeaderStyle ForeColor="#9D9D9D" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#17252A" />
                <PagerSettings PageButtonCount="4" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <RowStyle BackColor="#FF8040" />
                <SelectedRowStyle BackColor="#99CCFF" />
            </asp:GridView>
            <asp:Label ID="lblMensaje_2" runat="server" Text="Felicidades, estás al día." ForeColor="#9D9D9D"></asp:Label>
            <asp:Button ID="btnAsignar_2" runat="server" Text="Asignar tarea subordinada a usuario" OnClick="btnAsignar_2_Click" BackColor="#17252A" ForeColor="#E9E9E9" />
            <br />
            <br />
        </div>
    </div>
    <br />
    <br />
    <div id="inner_div_crud_tarea_carga" class="container-fluid" style="border-style: none; text-align: center; background-color: #2B7A78; height: auto;">

        <div style="background-color: #17252A; width: 100%; margin-top: 50px;margin-bottom:50px; height: auto;">
            <h3 style="color: #9D9D9D">Tareas asignadas al usuario</h3>
            <div id="inner_div_carga_usuario_tabla" class="container-fluid" style="text-align: center; vertical-align: top; left: auto; height: 100%; overflow: auto; width: auto;">
                <asp:GridView ID="tablaCarga" AutoPostBack="true" runat="server" CssClass="table table-hover " GridLines="Both" Height="100px" Width="700px" HorizontalAlign="Center" ForeColor="black" AllowPaging="True" BackColor="#E5E5E5" CellPadding="10" Font-Bold="True" PageSize="6" OnRowDataBound="GridView1_RowDataBound">
                    <HeaderStyle ForeColor="#9D9D9D" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#17252A" />
                    <PagerSettings PageButtonCount="4" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <SelectedRowStyle BackColor="#99CCFF" />
                </asp:GridView>
            </div>
            <asp:DropDownList ID="ddlCambiarEstado" runat="server" Height="30px" Width="175px">
            </asp:DropDownList>
            &nbsp;
            <asp:Button ID="btnCargarTareas" runat="server" Text="Cambiar estado de tarea" OnClick="btnCargarTareas_Click" BackColor="#17252A" ForeColor="#E9E9E9" />
            <br />
            <br />
            <h3 style="color: #9D9D9D">Tareas subordinadas</h3>
            <div id="inner_div_carga_usuario_tabla_2" class="container-fluid" style="text-align: center; vertical-align: top; left: auto; height: 100%; overflow: auto; width: auto;">
                <asp:GridView ID="tablaCarga2" AutoPostBack="true" runat="server" CssClass="table table-hover " GridLines="Both" Height="100px" Width="700px" HorizontalAlign="Center" ForeColor="black" AllowPaging="True" BackColor="#E5E5E5" CellPadding="10" Font-Bold="True" PageSize="6" OnRowDataBound="GridView1_RowDataBound_2">
                    <HeaderStyle ForeColor="#9D9D9D" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#17252A" />
                    <PagerSettings PageButtonCount="4" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <SelectedRowStyle BackColor="#99CCFF" />
                </asp:GridView>
            </div>
            <asp:DropDownList ID="ddlCambiarEstado2" runat="server" Height="30px" Width="175px">
            </asp:DropDownList>
            &nbsp;
            <asp:Button ID="btnCargarTareas2" runat="server" Text="Cambiar estado de tarea subordinada" OnClick="btnCargarTareas_2_Click" BackColor="#17252A" ForeColor="#E9E9E9" />
            <br />
            <br />
        </div>
    </div>
    <br />
    <br />
    <asp:Label ID="txtCorreo" runat="server" Text="Label"></asp:Label>
</asp:Content>
