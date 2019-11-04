<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Portafolio.Login" %>

<!DOCTYPE html>
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>Iniciar Sesión</title>
    <!--Made with love by Mutiullah Samim -->

    <!--Bootsrap 4 CDN-->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">

    <!--Fontawesome CDN-->
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">

    <!--Custom styles-->
    <link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <div id="ParentDiv" class="container-fluid" style="text-align: center; border: 3px black; background-color: #222222; height: 100%; position: absolute; top: 0; bottom: 0; left: 0; right: 0; margin: auto;">
        
        <div class="container" style="position: center; top: 0; bottom: 0; left: 0; right: 0; margin: auto;">
            <div class="card">
                <div class="card-header">
                    <h3>Ingresar al sistema</h3>
                </div>
                <div class="card-body">
                    <form id="form1" runat="server">
                        <div class="input-group form-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text"><i class="fas fa-user"></i></span>
                            </div>
                            <input id="correo" type="text" class="form-control" placeholder="Correo" runat="server">
                        </div>
                        <div class="input-group form-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text"><i class="fas fa-key"></i></span>
                            </div>
                            <input id="contrasena" type="password" class="form-control" placeholder="Contraseña" runat="server">
                        </div>
                        <div class="form-group">
                            <asp:Button ID="Button1" runat="server" Text="Iniciar Sesión" OnClick="Button1_Click" />
                            <br />
                            <asp:Label ID="lblError" runat="server" Text="Usuario o contraseña incorrectos, intente nuevamente"></asp:Label>
                        </div>
                    </form>
                </div>
            </div>
        </div>
        <br />
    </div>
</body>
</html>
