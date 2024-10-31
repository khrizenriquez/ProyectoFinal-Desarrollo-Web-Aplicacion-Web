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
                
                <div class="field">
                    <label class="label">Correo electrónico</label>
                    <div class="control">
                        <input class="input" type="email" placeholder="toor@miumg.edu.gt" required />
                    </div>
                </div>

                <div class="field">
                    <label class="label">Contraseña</label>
                    <div class="control">
                        <input class="input" type="password" placeholder="••••••••" required />
                    </div>
                </div>

                <div class="field">
                    <div class="control">
                        <button class="button is-link is-fullwidth">Iniciar sesión</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
