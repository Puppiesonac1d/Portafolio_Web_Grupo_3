<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mantenedor_Tareas_Subordinada.aspx.cs" Inherits="Portafolio.Mantenedor_Tareas_Subordinada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="div_crud_tareas" class="container-fluid" style="border-style: none; text-align: center; background-color: #2B7A78; overflow: auto; height: auto;">
        <br>
        <br>
        <div id="inner_div_crud_tarea_elementos" class="container-fluid" style="text-align: center; background-color: #17252A; width: 900px; margin-top: 50px; margin-bottom: 50px; height: auto;">
            <h3 style="color: #9D9D9D">Ingresar Tarea Subordinada</h3>

            <br>
            <table style="width: auto; height: auto;">
                <tr>
                    <td align="right">
                        <br>
                        <asp:Label ID="Label3" runat="server" Text="Nombre de Tarea:" Style="color: #9D9D9D;"></asp:Label>
                        <br>
                    </td>
                    <td align="right">
                        <br>
                        <asp:GridView ID="tablaTareas" AutoPostBack="true" runat="server" CssClass="table table-hover " GridLines="Both" Height="107px" Width="400px" HorizontalAlign="Center" ForeColor="black" AllowPaging="True" BackColor="#E5E5E5" CellPadding="10" Font-Bold="True" PageSize="6" OnRowDataBound="GridView1_RowDataBound">
                            <HeaderStyle ForeColor="#9D9D9D" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#17252A" />
                            <PagerSettings PageButtonCount="4" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <SelectedRowStyle BackColor="#99CCFF" />
                        </asp:GridView>
                        <br>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br>
                        <asp:Label ID="Label1" runat="server" Text="Nombre de Tarea:" Style="color: #9D9D9D;"></asp:Label>
                        <br>
                    </td>
                    <td align="right">
                        <br>
                        <asp:TextBox ID="txtNombre" runat="server" Width="400px"></asp:TextBox>
                        <br>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br>
                        <asp:Label ID="Label5" runat="server" Text="Descripción de Tarea:" Style="color: #9D9D9D;"></asp:Label>
                        <br>
                    </td>
                    <td align="right">
                        <br>
                        <asp:TextBox ID="txtDescripcionTarea_2" runat="server" Width="400px"></asp:TextBox>
                        <br>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br>
                        <asp:Label ID="Label6" runat="server" Text="Correo de Encargado:" Style="color: #9D9D9D;"></asp:Label>
                        <br>
                    </td>
                    <td align="right">
                        <br>
                        <asp:TextBox ID="txtCorreoEncargado_2" runat="server" Width="400px"></asp:TextBox>
                        <br>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br>
                        <asp:Label ID="Label7" runat="server" Text="Tipo de Tarea:" Style="color: #9D9D9D;"></asp:Label>
                        <br>
                    </td>
                    <td align="right">
                        <br>
                        <asp:DropDownList ID="ddlTipoTarea_2" runat="server" Height="22px" Width="300px" Style="margin-left: auto"></asp:DropDownList>
                        <br>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br>
                        <asp:Label ID="Label2" runat="server" Text="Fecha límite de tarea:" Style="color: #9D9D9D;"></asp:Label>
                        <br>
                    </td>
                    <td align="right">
                        <br>
                        <asp:Calendar ID="fecha" runat="server" Width="400px" BackColor="#E5E5E5" Format="dd/MM/yyyy"></asp:Calendar>
                        <br>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br>
                        <asp:Button ID="btnGuardar_Tarea_2" runat="server" Text="Ingresar Tarea Subordinada" OnClick="IngresarTarea_2_Click" BackColor="#17252A" ForeColor="#E9E9E9" />
                        <br>
                    </td>
                </tr>
            </table>
            <br>
            <br>
            <br>
            <div id="inner_div_tareas_pendientes" class="container-fluid" style="text-align: center; vertical-align: top; left: auto; height: 100%; overflow: auto; width: auto;">

                <h3 style="color: #9D9D9D">Tareas subordinadas devueltas</h3>

                <asp:GridView ID="tablasTareasDevueltas" AutoPostBack="true" runat="server" CssClass="table table-hover " GridLines="Both" Height="100px" Width="700px" HorizontalAlign="Center" ForeColor="black" AllowPaging="True" BackColor="#E5E5E5" CellPadding="10" Font-Bold="True" PageSize="6">
                    <HeaderStyle ForeColor="#9D9D9D" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#17252A" />
                    <PagerSettings PageButtonCount="4" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <SelectedRowStyle BackColor="#99CCFF" />
                </asp:GridView>
                <asp:Label ID="label" runat="server" Text="Correo de reasignación:" Style="color: #9D9D9D;"></asp:Label>
                <asp:TextBox ID="txtCorreoReasignar" runat="server" Width="300px"></asp:TextBox>
                <asp:Button ID="btnReasignar" runat="server" Text="Ingresar Tarea" BackColor="#17252A" ForeColor="#E9E9E9" OnClick="reasignar_Click" />
                <br>
                <br>
            </div>
        </div>
    </div>
</asp:Content>
