<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeleccionAprobadores.aspx.cs" Inherits="Entelgy_Pandero.SeleccionAprobadores" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section>
                 <h3 id="titulo">Selecciona Aprobador</h3>


            <div class="card col-sm-5">
                <div class="card-header">
                    Resumen Solicitud 
                </div>
                <div class="card-body">
                    <h5 class="card-title">Asociado:</h5>
                    <p class="card-text"><asp:Literal ID="litAsociado" runat="server"></asp:Literal></p>
                
                  <h5 class="card-title">Importe:</h5>
                    <p class="card-text"><asp:Literal ID="litImporte" runat="server"></asp:Literal></p>
   

                     <h5 class="card-title">Numero de Cuotas:</h5>
                    <p class="card-text"><asp:Literal ID="litCuotas" runat="server"></asp:Literal></p>
   

                     <h5 class="card-title">Fecha:</h5>
                    <p class="card-text"><asp:Literal ID="litFecha" runat="server"></asp:Literal></p>  
                </div>
            </div>

           <hr />


             <div class="form-group">
            <label for="nombreAsociado">Seleccionar Aprobador</label>

             <asp:DropDownList ID="ddlAprobadores" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                 <asp:ListItem Text="Selecciona un aprobador" Value="" />
             </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvAprobadores" runat="server" ControlToValidate="ddlAprobadores" InitialValue="" ErrorMessage="Selecciona un aprobador." CssClass="text-danger" />

             </div>

             <div class="form-group">
                <label for="txtSustentoAprobador">Sustento del Aprobador:</label>
                <asp:TextBox ID="txtSustentoAprobador" TextMode="MultiLine" Rows="4" Columns="50" runat="server" CssClass="form-control" MaxLength="50" />
                <asp:RequiredFieldValidator ID="rfvSustentoAprobador" runat="server" ControlToValidate="txtSustentoAprobador" ErrorMessage="El sustento es obligatorio." CssClass="text-danger" />
                <asp:RegularExpressionValidator ID="revSustentoAprobador" runat="server" ControlToValidate="txtSustentoAprobador" ValidationExpression="^.{1,50}$" ErrorMessage="El sustento debe tener un máximo de 50 caracteres." CssClass="text-danger" />
            </div>
           

            
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar"  CssClass="btn btn-primary mt-2" OnClick="btnRegistrar_Click" />
     
        </section>




    </main>

</asp:Content>
