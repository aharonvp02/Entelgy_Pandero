<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroSolicitud.aspx.cs" Inherits="Entelgy_Pandero.RegistroSolicitud" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <main>
    <section class="row" aria-labelledby="aspnetTitle">
     <h1 id="titulo">Registro de Solicitud</h1>
     <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" HeaderText="Por favor, corrige los siguientes errores:" />
        
          <div class="form-group ">
            <label for="codigoAsociado" class="col-sm-4">Código del Asociado</label>
           <asp:TextBox ID="txtCodigoAsociado" runat="server" CssClass="form-control col-sm-4"  AutoPostBack="true"  OnTextChanged="txtCodigoAsociado_TextChanged"  />
              

          <asp:RequiredFieldValidator ID="rfvCodigoAsociado" runat="server" ControlToValidate="txtCodigoAsociado" ErrorMessage="Código del Asociado es obligatorio." CssClass="text-danger" />
            <asp:RegularExpressionValidator ID="revCodigoAsociado" runat="server" ControlToValidate="txtCodigoAsociado" ValidationExpression="^\S*$" ErrorMessage="El código del asociado no debe contener espacios en blanco." CssClass="text-danger" />
        </div>
         <div class="form-group">
                <label for="nombreAsociado">Nombre del Asociado</label>
                <asp:TextBox ID="txtNombreAsociado" runat="server" CssClass="form-control" Enabled="false" />
                <asp:RequiredFieldValidator ID="rfvNombreAsociado" runat="server" ControlToValidate="txtNombreAsociado" ErrorMessage="Nombre del Asociado es obligatorio." CssClass="text-danger" />
                <asp:RegularExpressionValidator ID="revNombreAsociado" runat="server" ControlToValidate="txtNombreAsociado" ValidationExpression="^\S*$" ErrorMessage="El nombre del asociado no debe contener espacios en blanco." CssClass="text-danger" />
            </div>
            <div class="form-group">
                <label for="apellidosAsociado">Apellidos del Asociado</label>
                <asp:TextBox ID="txtApellidosAsociado" runat="server" CssClass="form-control" Enabled="false" />
                <asp:RequiredFieldValidator ID="rfvApellidosAsociado" runat="server" ControlToValidate="txtApellidosAsociado" ErrorMessage="Apellidos del Asociado son obligatorios." CssClass="text-danger" />
                <asp:RegularExpressionValidator ID="revApellidosAsociado" runat="server" ControlToValidate="txtApellidosAsociado" ValidationExpression="^\S*$" ErrorMessage="Los apellidos del asociado no deben contener espacios en blanco." CssClass="text-danger" />
            </div>
            <div class="form-group">
                <label for="emailAsociado">Email del Asociado</label>
                <asp:TextBox ID="txtEmailAsociado" runat="server" CssClass="form-control" Enabled="false" />
                <asp:RequiredFieldValidator ID="rfvEmailAsociado" runat="server" ControlToValidate="txtEmailAsociado" ErrorMessage="Email del Asociado es obligatorio." CssClass="text-danger" />
                <asp:RegularExpressionValidator ID="revEmailAsociado" runat="server" ControlToValidate="txtEmailAsociado" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ErrorMessage="Email inválido." CssClass="text-danger" />
            </div>
            <div class="form-group">
                <label for="telefonoAsociado">Teléfono del Asociado</label>
                <asp:TextBox ID="txtTelefonoAsociado" runat="server" CssClass="form-control" Enabled="false" />
                <asp:RequiredFieldValidator ID="rfvTelefonoAsociado" runat="server" ControlToValidate="txtTelefonoAsociado" ErrorMessage="Teléfono del Asociado es obligatorio." CssClass="text-danger" />
                <asp:RegularExpressionValidator ID="revTelefonoAsociado" runat="server" ControlToValidate="txtTelefonoAsociado" ValidationExpression="^\d+$" ErrorMessage="Teléfono inválido. Solo se permiten números." CssClass="text-danger" />
            </div>
            <div class="form-group">
                <label for="activo">Activo</label>
                <asp:CheckBox ID="chkActivo" runat="server" CssClass="form-check-input" Enabled="false" />
            </div>
            <div class="form-group">
                <label for="importeSolicitud">Importe en Soles de la Solicitud</label>
                <asp:TextBox ID="txtImporteSolicitud" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvImporteSolicitud" runat="server" ControlToValidate="txtImporteSolicitud" ErrorMessage="Importe en soles de la solicitud es obligatorio." CssClass="text-danger" />
                <asp:RegularExpressionValidator ID="revImporteSolicitud" runat="server" ControlToValidate="txtImporteSolicitud" ValidationExpression="^\d+(\.\d{1,2})?$" ErrorMessage="Importe inválido. Solo se permiten números." CssClass="text-danger" />

            </div>
            <div class="form-group">
                <label for="numeroCuotas">Número de Cuotas a Afectar</label>
                <asp:TextBox ID="txtNumeroCuotas" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvNumeroCuotas" runat="server" ControlToValidate="txtNumeroCuotas" ErrorMessage="Número de cuotas es obligatorio." CssClass="text-danger" />
                <asp:RegularExpressionValidator ID="revNumeroCuotas" runat="server" ControlToValidate="txtNumeroCuotas" ValidationExpression="^\d+$" ErrorMessage="Número de cuotas inválido. Solo se permiten números." CssClass="text-danger" />
            </div>
            <div class="form-group">
                <label for="fechaSolicitud">Fecha de la Solicitud</label>
                <asp:TextBox ID="txtFechaSolicitud" TextMode="Date" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvFechaSolicitud" runat="server" ControlToValidate="txtFechaSolicitud" ErrorMessage="Fecha de la solicitud es obligatoria." CssClass="text-danger" />
                <asp:CompareValidator ID="cvFechaSolicitud" runat="server" ControlToValidate="txtFechaSolicitud" Operator="DataTypeCheck" Type="Date" ErrorMessage="Fecha inválida." CssClass="text-danger" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnRegistrarSolicitud" runat="server" Text="Registrar Solicitud" CssClass="btn btn-primary" OnClick="btnRegistrarSolicitud_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" CausesValidation="false" OnClick="btnCancelar_Click"  />
             <%--   <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" CausesValidation="false" OnClientClick="return cerrarVentana();" />--%>

            </div>

     </section>
</main>

</asp:Content>
