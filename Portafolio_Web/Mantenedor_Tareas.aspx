<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mantenedor_Tareas.aspx.cs" Inherits="Portafolio.Mantenedor_Tareas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="div_crud_tareas" class="container-fluid" style="border-style: none; text-align: center; background-color: #2B7A78; height: auto;">
        <br>
        <br>
        <div id="inner_div_crud_tarea_elementos" class="container-fluid" style="text-align: center; background-color: #17252A; width: 900px; margin-top: 50px; margin-bottom: 50px; height: auto;">
            <h3 style="color: #9D9D9D">Ingresar Tarea</h3>
            <asp:Panel ID="panelCRUDtarea" runat="server">

            </asp:Panel>

                <table style="width: 100%" __designer:mapid="9d">
                    <tr __designer:mapid="9e">
                        <td __designer:mapid="9f">
                            <br __designer:mapid="a0">
                            <asp:Label ID="Label5" runat="server" Text="Nombre de Tarea:" Style="color: #9D9D9D;"></asp:Label>
                            <br __designer:mapid="c0">
                        </td>
                        <td __designer:mapid="a1">
                            <br __designer:mapid="a2">
                            <asp:TextBox ID="txtNombre" runat="server" Width="300px"></asp:TextBox>
                            <br __designer:mapid="c2">
                        </td>
                    </tr>
                    <tr __designer:mapid="a3">
                        <td __designer:mapid="a4">
                            <br __designer:mapid="a5">
                            <asp:Label ID="Label4" runat="server" Text="Descripción de Tarea:" Style="color: #9D9D9D;"></asp:Label>
                            <br __designer:mapid="c4">
                        </td>
                        <td __designer:mapid="a6">
                            <br __designer:mapid="a7">
                            <asp:TextBox ID="txtDescripcion" runat="server" Width="300px"></asp:TextBox>
                            <br __designer:mapid="c6">
                        </td>
                    </tr>

                    <tr __designer:mapid="a8">
                        <td __designer:mapid="a9">
                            <br __designer:mapid="aa">
                            <asp:Label ID="Label1" runat="server" Text="Correo de Encargado:" Style="color: #9D9D9D;"></asp:Label>
                            <br __designer:mapid="c8">
                        </td>
                        <td __designer:mapid="ab">
                            <br __designer:mapid="ac">
                            <asp:TextBox ID="txtCorreo" runat="server" Width="300px"></asp:TextBox>
                            <br __designer:mapid="ca">
                        </td>
                    </tr>
                    <tr __designer:mapid="ad">
                        <td __designer:mapid="ae">
                            <br __designer:mapid="af">
                            <asp:Label ID="Label3" runat="server" Text="Tipo de Tarea:" Style="color: #9D9D9D;"></asp:Label>
                            <br __designer:mapid="cc">
                        </td>
                        <td __designer:mapid="b0">
                            <br __designer:mapid="b1">
                            <asp:DropDownList ID="ddlTipoTarea" runat="server" Height="22px" Width="300px" Style="margin-left: auto"></asp:DropDownList>
                            <br __designer:mapid="ce">
                        </td>
                    </tr>
                    <tr __designer:mapid="b2">
                        <td __designer:mapid="b3">
                            <br __designer:mapid="b4">
                            <asp:Label ID="Label2" runat="server" Text="Asignar flujo de tarea:" Style="color: #9D9D9D;"></asp:Label>
                            <br __designer:mapid="d0">
                        </td>
                        <td __designer:mapid="b5">
                            <br __designer:mapid="b6">
                            <asp:DropDownList ID="ddlFlujo" AutoPostBack="true" runat="server" Width="300px"></asp:DropDownList>
                            <br __designer:mapid="d2">
                        </td>
                    </tr>
                    <tr __designer:mapid="b7">
                        <td __designer:mapid="b8">
                            <br __designer:mapid="b9">
                            <asp:Label ID="Label6" runat="server" Text="Fecha Límite de Tarea:" Style="color: #9D9D9D;"></asp:Label>
                            <br __designer:mapid="d4">
                        </td>
                        <td __designer:mapid="ba">
                            <br __designer:mapid="bb">
                            <div __designer:mapid="d5">
                                <asp:Calendar ID="fecha" runat="server" Width="300px" BackColor="#E5E5E5" style="margin-left: 154px" Format="dd/MM/yyyy"></asp:Calendar>
                            </div>
                            <br __designer:mapid="d7">
                        </td>
                    </tr>
                    <tr __designer:mapid="bc">
                        <td __designer:mapid="bd">
                            <br __designer:mapid="be">
                            <asp:Button ID="ingresarTarea" runat="server" Text="Ingresar Tarea" OnClick="ingresarTarea_Click" />
                            <br __designer:mapid="d9">
                        </td>
                    </tr>
                </table>
            <br />
            <br />
        </div>
    </div>
    <asp:Label ID="lblidddl" runat="server" Text=""></asp:Label>
</asp:Content>
