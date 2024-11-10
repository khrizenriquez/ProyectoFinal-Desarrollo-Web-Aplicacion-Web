<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagoPrima.aspx.cs" Inherits="Seguro.PagoPrima" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registrar Pago de Prima</title>
    <link href="https://cdn.jsdelivr.net/npm/bulma@0.9.3/css/bulma.min.css" rel="stylesheet" />
    <link href="Styles/estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <section class="section">
        <div class="container">
            <h2 class="title is-3">Registrar Pago de Prima</h2>

            <form id="form1" runat="server" class="box">
                
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
                                <asp:TextBox ID="txtCodigoPaciente" runat="server" CssClass="input" placeholder="Ingrese" />
                            </div>
                        </div>
                    </div>

                    <div class="column">
                        <div class="field">
                            <label class="label">Mes de Cobertura Cancelado</label>
                            <div class="control">
                                <asp:TextBox ID="txtMesCoberturaCancelado" runat="server" CssClass="input" type="date" />
                            </div>
                        </div>
                    </div>

                    <div class="column">
                        <div class="field">
                            <label class="label">Monto</label>
                            <div class="control">
                                <asp:TextBox ID="txtMonto" runat="server" CssClass="input" type="number" step="0.01" placeholder="Ingrese" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="field is-grouped">
                    <div class="control">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button is-primary" OnClick="btnGuardar_Click" />
                    </div>
                    <div class="control">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="button is-light" OnClick="btnCancelar_Click" />
                    </div>
                </div>

                <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="notification is-hidden"></asp:Label>
                
            </form>
        </div>
    </section>
</body>
</html>
