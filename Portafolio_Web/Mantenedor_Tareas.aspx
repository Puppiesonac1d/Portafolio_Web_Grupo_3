<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mantenedor_Tareas.aspx.cs" Inherits="Portafolio.Mantenedor_Tareas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="inner_div_crud_tarea" class="container-fluid" style="text-align: center; border: 3px black; background-color: #222222;">
        <br>
        <br>
        <div id="inner_div_crud_tarea_elementos" class="container-fluid" style="text-align: center; border: 3px black; background-color: #222222;">
            <asp:Panel ID="panelCRUDtarea" runat="server" Height="198px">

                <table style="width: 100%">
                    <tr>
                        <td>
                            <br>
                            <asp:Label ID="Label4" runat="server" Text="Descripción de Tarea:" Style="color: #9D9D9D;"></asp:Label>
                            <br>
                        </td>
                        <td>
                            <br>
                            <asp:TextBox ID="txtDescripcion" runat="server" Width="300px"></asp:TextBox>
                            <br>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br>
                            <asp:Label ID="Label1" runat="server" Text="Correo de Encargado:" Style="color: #9D9D9D;"></asp:Label>
                            <br>
                        </td>
                        <td>
                            <br>
                            <asp:TextBox ID="txtCorreo" runat="server" Width="300px"></asp:TextBox>
                            <br>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br>
                            <asp:Label ID="Label3" runat="server" Text="Tipo de Tarea:" Style="color: #9D9D9D;"></asp:Label>
                            <br>
                        </td>
                        <td>
                            <br>
                            <asp:DropDownList ID="ddlTipoTarea" runat="server" Height="22px" Width="300px" Style="margin-left: auto"></asp:DropDownList>
                            <br>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br>
                            <asp:Label ID="Label2" runat="server" Text="Asignar flujo de tarea:" Style="color: #9D9D9D;"></asp:Label>
                            <br>
                        </td>
                        <td>
                            <br>
                            <asp:DropDownList ID="ddlFlujo" AutoPostBack="true" runat="server" Width="300px"></asp:DropDownList>
                            <br>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br>
                            <asp:Button ID="ingresarTarea" runat="server" Text="Ingresar Tarea" OnClick="ingresarTarea_Click" />
                            <br>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            <br />
        </div>
    </div>
    <br />
    <br />
    <asp:Label ID="lblidddl" runat="server" Text=""></asp:Label>
</asp:Content>
