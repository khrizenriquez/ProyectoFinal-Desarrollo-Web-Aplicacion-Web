<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfiliadoEdit.aspx.cs" Inherits="Seguro.AfiliadoEdit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar Afiliado</title>
    <link href="https://cdn.jsdelivr.net/npm/bulma@0.9.3/css/bulma.min.css" rel="stylesheet" />
    <link href="Styles/estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <nav class="navbar is-primary" role="navigation" aria-label="main navigation">
        <div id="navbarBasicExample" class="navbar-menu">
            <div class="navbar-start">
                <a class="navbar-item" href="AfiliadoList.aspx">
                    Mantenimiento de Afiliados
                </a>

                <a class="navbar-item" href="ProveedorList.aspx">
                    Mantenimiento de Proveedores
                </a>

                <a class="navbar-item" href="PagoPrimaList.aspx">
                    Pago Prima
                </a>
            </div>

            <div class="navbar-end">
                <div class="navbar-item">
                    <a href="Logout.aspx" class="button is-danger">
                        <strong>Cerrar Sesión</strong>
                    </a>
                </div>
            </div>
        </div>
    </nav>
    <section class="section">
        <div class="container">
            <h2 class="title is-3">Editar Afiliado</h2>
            <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="notification"></asp:Label>

            <form id="form1" runat="server" class="box">
                <div class="field">
                    <label class="label">Código Paciente</label>
                    <div class="control">
                        <asp:TextBox ID="txtCodigoPaciente" runat="server" CssClass="input" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <div class="field">
                    <label class="label">Primer Nombre</label>
                    <div class="control">
                        <asp:TextBox ID="txtPrimerNombre" runat="server" CssClass="input"></asp:TextBox>
                    </div>
                </div>

                <div class="field">
                    <label class="label">Segundo Nombre</label>
                    <div class="control">
                        <asp:TextBox ID="txtSegundoNombre" runat="server" CssClass="input"></asp:TextBox>
                    </div>
                </div>

                <div class="field">
                    <label class="label">Primer Apellido</label>
                    <div class="control">
                        <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="input"></asp:TextBox>
                    </div>
                </div>

                <div class="field">
                    <label class="label">Segundo Apellido</label>
                    <div class="control">
                        <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="input"></asp:TextBox>
                    </div>
                </div>

                <div class="field">
                    <label class="label">Fecha de Nacimiento</label>
                    <div class="control">
                        <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="input" TextMode="Date"></asp:TextBox>
                    </div>
                </div>

                <div class="field">
                    <label class="label">Teléfono</label>
                    <div class="control">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="input"></asp:TextBox>
                    </div>
                </div>

                <div class="field">
                    <label class="label">Fecha Inicio Cobertura</label>
                    <div class="control">
                        <asp:TextBox ID="txtFechaInicioCobertura" runat="server" CssClass="input" TextMode="Date"></asp:TextBox>
                    </div>
                </div>

                <div class="field">
                    <label class="label">Monto Cobertura</label>
                    <div class="control">
                        <asp:TextBox ID="txtMontoCobertura" runat="server" CssClass="input" TextMode="Number" Step="0.01"></asp:TextBox>
                    </div>
                </div>

                <div class="buttons">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button is-primary" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Regresar" CssClass="button is-light" OnClick="btnCancelar_Click" />
                </div>
            </form>
        </div>
    </section>
</body>
</html>
