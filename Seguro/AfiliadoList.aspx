<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfiliadoList.aspx.cs" Inherits="Seguro.AfiliadoList" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lista de Afiliados</title>
    <link rel="stylesheet" href="/Styles/login.css" />
</head>
<body>
    <form id="form1" runat="server" class="form-style-9">
        <h2>Gestión de Afiliados</h2>

        <!-- Formulario de búsqueda -->
        <asp:TextBox ID="txtBuscar" runat="server" Width="400px" placeholder="Buscar por Código o Nombre..."></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="CodigoPaciente" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="CodigoPaciente" HeaderText="Código" />
                <asp:BoundField DataField="PrimerNombre" HeaderText="Primer Nombre" />
                <asp:BoundField DataField="SegundoNombre" HeaderText="Segundo Nombre" />
                <asp:BoundField DataField="PrimerApellido" HeaderText="Primer Apellido" />
                <asp:BoundField DataField="SegundoApellido" HeaderText="Segundo Apellido" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="FechaInicioCobertura" HeaderText="Fecha Inicio Cobertura" />
                <asp:BoundField DataField="MontoCobertura" HeaderText="Monto de Cobertura" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

        <asp:Button ID="btnNuevoAfiliado" runat="server" Text="Nuevo Afiliado" PostBackUrl="~/Afiliados/AfiliadoEdit.aspx" />
    </form>
</body>
</html>
