<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfiliadoEdit.aspx.cs" Inherits="Seguro.AfiliadoEdit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar Afiliado</title>
    <style>
        .form-container {
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 8px;
            background-color: #f9f9f9;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
        }
        .form-title {
            font-size: 24px;
            margin-bottom: 20px;
            text-align: center;
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-group label {
            display: block;
            margin-bottom: 5px;
        }
        .form-group input {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        .button-group {
            text-align: center;
            margin-top: 20px;
        }
        .button-group input {
            margin: 0 10px;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            color: #fff;
            cursor: pointer;
        }
        .button-group .btn-save {
            background-color: #28a745;
        }
        .button-group .btn-cancel {
            background-color: #dc3545;
        }
        .message {
            text-align: center;
            margin-top: 15px;
            color: #d9534f;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="form-container">
        <h2 class="form-title">Editar Afiliado</h2>

        <div class="form-group">
            <label for="txtCodigoPaciente">Código Paciente</label>
            <asp:TextBox ID="txtCodigoPaciente" runat="server" CssClass="form-control" />
        </div>
        
        <div class="form-group">
            <label for="txtPrimerNombre">Primer Nombre</label>
            <asp:TextBox ID="txtPrimerNombre" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtSegundoNombre">Segundo Nombre</label>
            <asp:TextBox ID="txtSegundoNombre" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtPrimerApellido">Primer Apellido</label>
            <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtSegundoApellido">Segundo Apellido</label>
            <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtFechaNacimiento">Fecha de Nacimiento</label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date" />
        </div>

        <div class="form-group">
            <label for="txtTelefono">Teléfono</label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtFechaInicioCobertura">Fecha de Inicio de Cobertura</label>
            <asp:TextBox ID="txtFechaInicioCobertura" runat="server" CssClass="form-control" TextMode="Date" />
        </div>

        <div class="form-group">
            <label for="txtMontoCobertura">Monto de Cobertura</label>
            <asp:TextBox ID="txtMontoCobertura" runat="server" CssClass="form-control" TextMode="Number" />
        </div>

        <asp:Label ID="lblMensaje" runat="server" CssClass="message" />

        <div class="button-group">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn-save" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn-cancel" OnClick="btnCancelar_Click" />
        </div>
    </form>
</body>
</html>
