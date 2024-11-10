<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Seguro.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Iniciar Sesión</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bulma/0.9.3/css/bulma.min.css" />
    <link rel="stylesheet" href="Styles/login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="card">
                <figure class="image is-128x128">
                    <img class="logo" src="Img/umg-logo.png" alt="Logo UM">
                </figure>
                <h1 class="title is-4 is-centered-text">Inicia sesión</h1>

                <asp:Label ID="lblMensaje" runat="server" CssClass="notification is-hidden"></asp:Label>
                
                <div class="field">
                    <label class="label">Usuario</label>
                    <div class="control">
                        <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="input" type="text" placeholder="toor" required />
                    </div>
                </div>

                <div class="field">
                    <label class="label">Contraseña</label>
                    <div class="control">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="input" TextMode="Password" placeholder="••••" required />
                    </div>
                </div>

                <div class="field">
                    <div class="control">
                        <asp:Button ID="btnLogin" runat="server" CssClass="button is-link is-fullwidth" Text="Iniciar sesión" OnClick="btnLogin_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
