<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProveedorList.aspx.cs" Inherits="Seguro.ProveedorList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lista de Proveedores</title>
    <link rel="stylesheet" href="/Styles/login.css" />
</head>
<body>
    <form id="form1" runat="server" class="form-style-9">
        <h2>Gestión de Proveedores</h2>

        <asp:TextBox ID="txtBuscar" runat="server" Width="400px" placeholder="Buscar por NIT o Razón Social..."></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="NIT" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="NIT" HeaderText="NIT" />
                <asp:BoundField DataField="RazonSocial" HeaderText="Razón Social" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

        <asp:Button ID="btnNuevoProveedor" runat="server" Text="Nuevo Proveedor" PostBackUrl="~/ProveedorEdit.aspx" OnClick="btnNuevoProveedor_Click" />
    </form>
</body>
</html>
