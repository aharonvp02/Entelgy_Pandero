using EP.Data;
using EP.Data.Repositorio;
using EP.Services;
using System;
using System.Configuration;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.Injection;

namespace Entelgy_Pandero
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {

            // Crear el contenedor Unity
            var container = new UnityContainer();

            // Obtener la cadena de conexión desde web.config
            var connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            // Registrar la clase Conexion 
            container.RegisterType<Conexion>(new InjectionConstructor(connectionString));
           

            container.RegisterType<IAprobadorRepository, AprobadorRepository>();
            container.RegisterType<IAsociadoRepository, AsociadoRepository>();
            container.RegisterType<INotaCreditoRepository, NotaCreditoRepository>();
            container.RegisterType<INotaCreditoService, NotaCreditoService>();
            
            Application["UnityContainer"] = container;

            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}