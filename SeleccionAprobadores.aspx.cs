using EP.Data.Repositorio;
using EP.Model;
using EP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;

namespace Entelgy_Pandero
{
    public partial class SeleccionAprobadores : System.Web.UI.Page
    {
        private IAprobadorRepository _aprobadorRepository;
        private INotaCreditoService _notaCreditoService;
        private NotaCredito solicitud;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                var container = (IUnityContainer)Application["UnityContainer"];

              
                _aprobadorRepository = container.Resolve<IAprobadorRepository>();
                _notaCreditoService = container.Resolve<INotaCreditoService>();

                // Recuperar  sesión              
                solicitud = (NotaCredito)Session["Solicitud"];

                if (solicitud != null)
                {
                  
                    litAsociado.Text = solicitud.nombreAsociado;
                    litImporte.Text = solicitud.importe_solicitud.ToString();
                    litCuotas.Text = solicitud.numero_cuotas.ToString();
                    litFecha.Text = solicitud.fecha_solicitud.ToString();
                }
                else
                {
                    string mensaje = "Datos de la Solicitud en blanco";
                    string tipoIcono = "error";
                    string script = $"mostrarAlerta('{mensaje}', '{tipoIcono}');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlertaScript", script, true);
                }

                   
           
                CargarAprobadores();

                // Desactivar la caché 
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
            }
        }

        private void CargarAprobadores()
        {
            IEnumerable<Aprobador> aprobadores = _aprobadorRepository.ListarAprobador();


            List<Aprobador> listaAprobadores = aprobadores.ToList();


            ddlAprobadores.Items.Clear();


            foreach (var aprobador in aprobadores)
            {
                ddlAprobadores.Items.Add(new ListItem(aprobador.NombresApellidosAprobador, aprobador.CodAprobador.ToString()));
            }


            ddlAprobadores.Items.Insert(0, new ListItem("<--Seleccionar-->", ""));
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
          
            int codAprobador= int.Parse(ddlAprobadores.SelectedValue);
            string sustento = txtSustentoAprobador.Text.Trim();

            solicitud = (NotaCredito)Session["Solicitud"];
        
            // Eliminar   sesión 
            Session.Remove("Solicitud");

            NotaCredito nc = new NotaCredito
            {

                ID_asociado = solicitud.ID_asociado,
                CodAprobador = codAprobador,
                importe_solicitud = solicitud.importe_solicitud,
                numero_cuotas = solicitud.numero_cuotas,
                sustento_aprobador = sustento,
                fecha_solicitud = solicitud.fecha_solicitud
            };

            if (_notaCreditoService == null)
            {
                var container = (IUnityContainer)Application["UnityContainer"];
                if (container != null)
                {
                    _notaCreditoService = container.Resolve<INotaCreditoService>();
                }
                else
                {
               
                    throw new Exception("El contenedor de Unity no está configurado correctamente.");
                }
            }

            try
            {
          
                int notaCreditoId =  _notaCreditoService.RegistrarNotaCredito(nc);

              
                string mensaje = $"Nota de crédito registrada con éxito. ID: {notaCreditoId}";
                string tipoIcono = "success";
                string script = $"mostrarAlerta('{mensaje}', '{tipoIcono}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlertaScript", script, true);

                LimpiarControles();
               // Response.Redirect("RegistroSolicitud.aspx");

            }
            catch (Exception ex)
            {
                // Mostrar  error
                string mensaje = ex.Message;
                string tipoIcono = "error"; 
                string script = $"mostrarAlerta('{mensaje}', '{tipoIcono}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarAlertaScript", script, true);              
            }
        }



        protected void LimpiarControles()
        {
            ddlAprobadores.SelectedIndex = 0;
            txtSustentoAprobador.Text = string.Empty; 
            litAsociado.Text = string.Empty;
            litImporte.Text = string.Empty;
            litCuotas.Text = string.Empty;
            litFecha.Text = string.Empty;
        }
    }
}