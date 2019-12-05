<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mantenedor_Tareas_Subordinada.aspx.cs" Inherits="Portafolio.Mantenedor_Tareas_Subordinada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="inner_div_crud_tarea_2" class="container-fluid" style="text-align: center; border: 3px black; background-color: #222222;">
        <asp:Panel ID="panel1" runat="server">
            <h3 style="color: #9D9D9D">Tarea Subordinada</h3>

            <asp:GridView ID="tablaTareas" AutoPostBack="true" runat="server" CssClass="table table-hover " GridLines="Both" Height="100px" Width="1429px" HorizontalAlign="Center" ForeColor="black" AllowPaging="True" BackColor="White" CellPadding="10" Font-Bold="True" PageSize="6">
                <HeaderStyle ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                <PagerSettings PageButtonCount="4" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <SelectedRowStyle BackColor="#3399FF" />
            </asp:GridView>

            <table style="width: 100%">
                <tr>
                    <td>
                        <br>
                        <asp:Label ID="Label1" runat="server" Text="Nombre de Tarea:" Style="color: #9D9D9D;"></asp:Label>
                        <br>
                    </td>
                    <td>
                        <br>
                        <asp:TextBox ID="txtNombre" runat="server" Width="300px"></asp:TextBox>
                        <br>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br>
                        <asp:Label ID="Label5" runat="server" Text="Descripción de Tarea:" Style="color: #9D9D9D;"></asp:Label>
                        <br>
                    </td>
                    <td>
                        <br>
                        <asp:TextBox ID="txtDescripcionTarea_2" runat="server" Width="300px"></asp:TextBox>
                        <br>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br>
                        <asp:Label ID="Label6" runat="server" Text="Correo de Encargado:" Style="color: #9D9D9D;"></asp:Label>
                        <br>
                    </td>
                    <td>
                        <br>
                        <asp:TextBox ID="txtCorreoEncargado_2" runat="server" Width="300px"></asp:TextBox>
                        <br>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br>
                        <asp:Label ID="Label7" runat="server" Text="Tipo de Tarea:" Style="color: #9D9D9D;"></asp:Label>
                        <br>
                    </td>
                    <td>
                        <br>
                        <asp:DropDownList ID="ddlTipoTarea_2" runat="server" Height="22px" Width="300px" Style="margin-left: auto"></asp:DropDownList>
                        <br>
                    </td>
                </tr>

                <tr>
                    <td>
                        <br>
                        <asp:Button ID="btnGuardar_Tarea_2" runat="server" Text="Ingresar Tarea Subordinada" OnClick="IngresarTarea_2_Click" />
                        <br>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
