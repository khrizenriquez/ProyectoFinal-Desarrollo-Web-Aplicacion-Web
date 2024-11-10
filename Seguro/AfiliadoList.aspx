<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfiliadoList.aspx.cs" Inherits="Seguro.AfiliadoList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lista de Afiliados</title>
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
            <h2 class="title is-3">Lista de Afiliados</h2>

            <form id="form1" runat="server">
                
                <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="notification is-hidden"></asp:Label>

                <div class="mb-4">
                    <asp:Button ID="btnCrearNuevo" runat="server" Text="Crear Nuevo Afiliado" CssClass="button is-primary mb-3" OnClick="btnCrearNuevo_Click" />
                </div>

                <asp:GridView ID="gvAfiliados" runat="server" AutoGenerateColumns="False" CssClass="table is-striped is-fullwidth" DataKeyNames="CodigoPaciente"
                              OnRowEditing="gvAfiliados_RowEditing" OnRowDeleting="gvAfiliados_RowDeleting" OnRowCommand="gvAfiliados_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="CodigoPaciente" HeaderText="Código Paciente" />
                        <asp:BoundField DataField="PrimerNombre" HeaderText="Primer Nombre" />
                        <asp:BoundField DataField="SegundoNombre" HeaderText="Segundo Nombre" />
                        <asp:BoundField DataField="PrimerApellido" HeaderText="Primer Apellido" />
                        <asp:BoundField DataField="SegundoApellido" HeaderText="Segundo Apellido" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                        <asp:BoundField DataField="FechaInicioCobertura" HeaderText="Fecha de Inicio de Cobertura" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField DataField="MontoCobertura" HeaderText="Monto de Cobertura" DataFormatString="{0:C}" />
                        
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <%# Convert.ToString(Eval("Status")) == "1" ? "Activo" : "Inactivo" %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField ShowEditButton="True" EditText="Editar" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnActivarDesactivar" runat="server" Text='<%# int.TryParse(Eval("Status").ToString(), out int status) && status == 1 ? "Desactivar" : "Activar" %>' 
                                            CommandName="ActivarDesactivar" CommandArgument='<%# Eval("CodigoPaciente") %>' CssClass="button is-small is-info" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </form>
        </div>
    </section>
</body>
</html>
