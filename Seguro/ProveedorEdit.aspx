<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProveedorEdit.aspx.cs" Inherits="Seguro.ProveedorEdit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro de Proveedor</title>
    <link rel="stylesheet" href="/Styles/login.css" />
</head>
<body>
    <form id="form1" runat="server" class="form-style-9">
        <h2>Registro de Proveedor</h2>

        <asp:Label ID="lblNIT" runat="server" Text="Número de NIT" AssociatedControlID="txtNIT"></asp:Label>
        <asp:TextBox ID="txtNIT" runat="server" CssClass="field-style field-full" Enabled="false"></asp:TextBox>

        <asp:Label ID="lblRazonSocial" runat="server" Text="Razón Social"></asp:Label>
        <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="field-style field-full" Placeholder="Nombre o Razón Social"></asp:TextBox>

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" PostBackUrl="~/ProveedorList.aspx" />
    </form>
</body>
</html>
