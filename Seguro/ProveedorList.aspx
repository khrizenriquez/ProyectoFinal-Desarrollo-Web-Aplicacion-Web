<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProveedorList.aspx.cs" Inherits="Seguro.ProveedorList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lista de Proveedores</title>
    <link rel="stylesheet" href="~/Styles/bulma.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="title">Lista de Proveedores</h1>

            <asp:Label ID="lblMensaje" runat="server" CssClass="notification is-info"></asp:Label>
            
            <asp:TextBox ID="txtBuscar" runat="server" CssClass="input" placeholder="Buscar por NIT o razón social"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="button is-primary" OnClick="btnBuscar_Click" />
            
            <asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="False" CssClass="table is-striped is-hoverable">
                <Columns>
                    <asp:BoundField DataField="NIT" HeaderText="NIT" />
                    <asp:BoundField DataField="RazonSocial" HeaderText="Razón Social" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("NIT") %>' CssClass="button is-link is-small" />
                            <asp:LinkButton ID="lnkEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("NIT") %>' CssClass="button is-danger is-small" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
