<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProveedorEdit.aspx.cs" Inherits="Seguro.ProveedorEdit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar Proveedor</title>
    <link href="Styles/estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="form-style-9">
        <h2>Editar Proveedor</h2>
        <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="notification"></asp:Label>
        
        <div>
            <label>NIT:</label>
            <asp:TextBox ID="txtNIT" runat="server" CssClass="input is-info" ReadOnly="true"></asp:TextBox>
        </div>
        <div>
            <label>Razón Social:</label>
            <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="input is-info"></asp:TextBox>
        </div>
        
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button is-primary" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="button is-light" OnClick="btnCancelar_Click" />
    </form>
</body>
</html>
