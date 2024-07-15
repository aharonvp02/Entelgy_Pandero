using EP.Data.Repositorio;
using EP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;

namespace Entelgy_Pandero
{
    public partial class RegistroSolicitud : System.Web.UI.Page
    {

        private  IAsociadoRepository _asociadoRepository;
    
        protected void Page_Load(object sender, EventArgs e)
        {


            var container = (IUnityContainer)Application["UnityContainer"];

   
            _asociadoRepository = container.Resolve<IAsociadoRepository>();
        }

        protected  void txtCodigoAsociado_TextChanged(object sender, EventArgs e)
        {
            string codigoAsociado = txtCodigoAsociado.Text.Trim();

            Asociado asociado =  _asociadoRepository.ObtenerAsociadoPorCodigo(codigoAsociado);

            if (asociado == null)
            {
            
                string mensaje = "No se encontró ningún asociado con ese código.";
                string tipoIcono = "error"; 
                string script = $"mostrarAlerta('{mensaje}', '{tipoIcono}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlertaScript", script, true);


                LimpiarCamposAsociado();
            }
            else {

                ViewState["idAsociado"] = asociado.ID_asociado;
                txtNombreAsociado.Text = asociado.nombre_asociado;
                txtApellidosAsociado.Text = asociado.apellidos_asociado;
                txtEmailAsociado.Text = asociado.email_asociado;
                txtTelefonoAsociado.Text = asociado.telefono_asociado.ToString();
                chkActivo.Checked = asociado.activo;
                
            }
            


        }

        private void LimpiarCamposAsociado()
        {
            txtNombreAsociado.Text = string.Empty;
            txtApellidosAsociado.Text = string.Empty;
            txtEmailAsociado.Text = string.Empty;
            txtTelefonoAsociado.Text = string.Empty;
            chkActivo.Checked = false;
          
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
         
         
            Session.Clear();
            Session.Abandon();


            Response.Redirect("Fin.aspx");

        }

        protected void btnRegistrarSolicitud_Click(object sender, EventArgs e)
        {

            // Recuperar idAsociado 
            int idAsociado = Convert.ToInt32(ViewState["idAsociado"]);

            string codigoAsociado = txtCodigoAsociado.Text.Trim();
            string nombreApellidosAsociado = txtNombreAsociado.Text.Trim()+" "+txtApellidosAsociado.Text.Trim();
            string importeSolicitud = txtImporteSolicitud.Text.Trim();
            string numeroCuotas= txtNumeroCuotas.Text.Trim();
            string fecha = txtFechaSolicitud.Text.Trim();

    

            var solicitud = new NotaCredito
            {
                
                nombreAsociado = nombreApellidosAsociado,
                importe_solicitud = Convert.ToDecimal(importeSolicitud),
                numero_cuotas = int.Parse(numeroCuotas),
                fecha_solicitud = DateTime.Parse(fecha),
                ID_asociado = idAsociado
            };

            Session["Solicitud"] = solicitud;

            Response.Redirect("~/SeleccionAprobadores.aspx");
        }
    }
}