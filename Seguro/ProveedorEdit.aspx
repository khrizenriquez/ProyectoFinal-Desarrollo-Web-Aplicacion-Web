<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProveedorEdit.aspx.cs" Inherits="Seguro.ProveedorEdit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar Proveedor</title>
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

                <a class="navbar-item" href="PagoPrima.aspx">
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
            <h2 class="title is-3">Editar Proveedor</h2>
            <form id="form1" runat="server" class="form-style-9">
                <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="notification is-hidden"></asp:Label>

                <div class="columns">
                    <div class="column is-half">
                        <div class="field">
                            <label class="label">Número de NIT</label>
                            <div class="control">
                                <asp:TextBox ID="txtNIT" runat="server" CssClass="input is-info" ReadOnly='<%# Request.QueryString["NIT"] != null %>'></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="column is-half">
                        <div class="field">
                            <label class="label">Razón Social</label>
                            <div class="control">
                                <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="input is-info"></asp:TextBox>
                            </div>
                        </div>
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
