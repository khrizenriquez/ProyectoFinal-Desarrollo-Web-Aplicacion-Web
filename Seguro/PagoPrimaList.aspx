<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagoPrimaList.aspx.cs" Inherits="Seguro.PagoPrimaList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lista de Pagos de Prima</title>
    <link href="https://cdn.jsdelivr.net/npm/bulma@0.9.3/css/bulma.min.css" rel="stylesheet" />
    <link href="Styles/estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <nav class="navbar is-primary" role="navigation" aria-label="main navigation">
        <div id="navbarBasicExample" class="navbar-menu">
            <div class="navbar-start">
                <a class="navbar-item" href="AfiliadoList.aspx">Mantenimiento de Afiliados</a>
                <a class="navbar-item" href="ProveedorList.aspx">Mantenimiento de Proveedores</a>
                <a class="navbar-item" href="PagoPrimaList.aspx">Lista de Pagos de Prima</a>
            </div>
            <div class="navbar-end">
                <div class="navbar-item">
                    <a href="Logout.aspx" class="button is-danger"><strong>Cerrar Sesión</strong></a>
                </div>
            </div>
        </div>
    </nav>

    <section class="section">
        <div class="container">
            <h2 class="title is-3">Lista de Pagos de Prima</h2>

            <form id="form1" runat="server">
                
                <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="notification is-hidden"></asp:Label>

                <asp:Button ID="btnHacerPago" runat="server" Text="Hacer Pago de Prima" CssClass="button is-primary mb-4" OnClick="btnHacerPago_Click" />

                <asp:GridView ID="gvPagosPrima" runat="server" AutoGenerateColumns="False" CssClass="table is-striped is-fullwidth">
                    <Columns>
                        <asp:BoundField DataField="IdPago" HeaderText="ID Pago" />
                        <asp:BoundField DataField="CodigoPaciente" HeaderText="Código Paciente" />
                        <asp:BoundField DataField="NombrePaciente" HeaderText="Nombre del Paciente" />
                        <asp:BoundField DataField="FechaPago" HeaderText="Fecha de Pago" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField DataField="MesCoberturaCancelado" HeaderText="Mes de Cobertura Cancelado" DataFormatString="{0:yyyy-MM}" />
                        <asp:BoundField DataField="Monto" HeaderText="Monto" DataFormatString="Q{0:N2}" />

                        <asp:TemplateField HeaderText="Estado de Prima">
                            <ItemTemplate>
                                <%# Convert.ToDateTime(Eval("MesCoberturaCancelado")) >= DateTime.Now.AddMonths(-1) ? "Activa" : "Inactiva" %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </form>
        </div>
    </section>
</body>
</html>
