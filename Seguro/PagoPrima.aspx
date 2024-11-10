<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagoPrima.aspx.cs" Inherits="Seguro.PagoPrima" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registrar Pago de Prima</title>
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
            <h2 class="title is-3">Registrar Pago de Prima</h2>
            
            <form id="form1" runat="server">
                
                <div class="field">
                    <label class="label">Fecha de Pago (No Editable)</label>
                    <div class="control">
                        <asp:TextBox ID="txtFechaPago" runat="server" CssClass="input" ReadOnly="true" />
                    </div>
                </div>

                <div class="columns">
                    
                    <div class="column">
                        <div class="field">
                            <label class="label">Código Paciente</label>
                            <div class="control">
                                <asp:TextBox ID="txtCodigoPaciente" runat="server" CssClass="input" placeholder="Ingrese Código" />
                            </div>
                        </div>
                    </div>
                    
                    <div class="column">
                        <div class="field">
                            <label class="label">Mes de Cobertura Cancelado</label>
                            <div class="control">
                                <asp:DropDownList ID="ddlMesCobertura" runat="server" CssClass="input">
                                    <asp:ListItem Value="1">Enero</asp:ListItem>
                                    <asp:ListItem Value="2">Febrero</asp:ListItem>
                                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                                    <asp:ListItem Value="4">Abril</asp:ListItem>
                                    <asp:ListItem Value="5">Mayo</asp:ListItem>
                                    <asp:ListItem Value="6">Junio</asp:ListItem>
                                    <asp:ListItem Value="7">Julio</asp:ListItem>
                                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                                    <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="column">
                        <div class="field">
                            <label class="label">Año de Cobertura Cancelado</label>
                            <div class="control">
                                <asp:DropDownList ID="ddlAnoCobertura" runat="server" CssClass="input"></asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="column">
                        <div class="field">
                            <label class="label">Monto</label>
                            <div class="control">
                                <asp:TextBox ID="txtMonto" runat="server" CssClass="input" TextMode="Number" placeholder="Ingrese Monto" />
                            </div>
                        </div>
                    </div>

                </div>

                <div class="field is-grouped">
                    <div class="control">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button is-primary" OnClick="btnGuardar_Click" />
                    </div>
                    <div class="control">
                        <asp:Button ID="btnCancelar" runat="server" Text="Regresar" CssClass="button is-light" OnClick="btnCancelar_Click" />
                    </div>
                </div>

                <asp:Label ID="lblMensaje" runat="server" CssClass="notification is-hidden"></asp:Label>

            </form>
        </div>
    </section>
</body>
</html>
