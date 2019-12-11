<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mantenedor_Tareas.aspx.cs" Inherits="Portafolio.Mantenedor_Tareas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="div_crud_tareas" class="container-fluid" style="border-style: none; text-align: center; background-color: #2B7A78; overflow: auto; height: auto;">
        <br>
        <br>
        <div id="inner_div_crud_tarea_elementos" class="container-fluid" style="text-align: center; background-color: #17252A; width: 900px; margin-top: 50px; margin-bottom: 50px; height: auto;">
            <h3 style="color: #9D9D9D">Ingresar Tarea</h3>
            <br>
            <table style="width: 750px; height: auto;">
                <tr>
                    <td align="right">
                        <br>
                        <asp:Label ID="Label5" runat="server" Text="Nombre de Tarea:" Style="color: #9D9D9D;"></asp:Label>
                        <br>
                    </td>
                    <td align="right">
                        <br>
                        <asp:TextBox ID="txtNombre" runat="server" Width="300px"></asp:TextBox>
                        <br>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br>
                        <asp:Label ID="Label4" runat="server" Text="Descripción de Tarea:" Style="color: #9D9D9D;"></asp:Label>
                        <br>
                    </td>
                    <td align="right">
                        <br>
                        <asp:TextBox ID="txtDescripcion" runat="server" Width="300px"></asp:TextBox>
                        <br>
                    </td>
                </tr>

                <tr>
                    <td align="right">
                        <br>
                        <asp:Label ID="Label1" runat="server" Text="Correo de Encargado:" Style="color: #9D9D9D;"></asp:Label>
                        <br>
                    </td>
                    <td align="right">
                        <br>
                        <asp:TextBox ID="txtCorreo" runat="server" Width="300px"></asp:TextBox>
                        <br>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br>
                        <asp:Label ID="Label3" runat="server" Text="Tipo de Tarea:" Style="color: #9D9D9D;"></asp:Label>
                        <br>
                    </td>
                    <td align="right">
                        <br>
                        <asp:DropDownList ID="ddlTipoTarea" runat="server" Height="22px" Width="300px" Style="margin-left: auto"></asp:DropDownList>
                        <br>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br>
                        <asp:Label ID="Label2" runat="server" Text="Asignar flujo de tarea:" Style="color: #9D9D9D;"></asp:Label>
                        <br>
                    </td>
                    <td align="right">
                        <br>
                        <asp:DropDownList ID="ddlFlujo" AutoPostBack="true" runat="server" Width="300px"></asp:DropDownList>
                        <br>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br>
                        <asp:Label ID="Label6" runat="server" Text="Fecha Límite de Tarea:" Style="color: #9D9D9D;"></asp:Label>
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
                        <asp:Button ID="ingresarTarea" runat="server" Text="Ingresar Tarea" OnClick="ingresarTarea_Click" BackColor="#17252A" ForeColor="#E9E9E9" />
                        <br>
                    </td>
                </tr>
            </table>
            <br />

            <h3 style="color: #9D9D9D">Tareas devueltas</h3>
            <div id="inner_div_tareas_pendientes" class="container-fluid" style="text-align: center; vertical-align: top; left: auto; height: 100%; overflow: auto; width: auto;">
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
            </div>
            <br />
            <br />
        </div>
    </div>
    <asp:Label ID="lblidddl" runat="server" Text=""></asp:Label>
</asp:Content>
