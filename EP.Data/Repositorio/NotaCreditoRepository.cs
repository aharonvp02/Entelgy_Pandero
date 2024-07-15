using Dapper;
using EP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Data.Repositorio
{
    public class NotaCreditoRepository : INotaCreditoRepository
    {
        private readonly Conexion _conexion;

        public NotaCreditoRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public int InsertarNotaCredito(NotaCredito notaCredito)
        {
            try
            {
                using (var conexion = _conexion.ObtenerConexion())
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@AsociadoId", notaCredito.ID_asociado, DbType.Int32);
                    parametros.Add("@CodAprobador", notaCredito.CodAprobador, DbType.Int32);
                    parametros.Add("@Sustento", notaCredito.sustento_aprobador, DbType.String);
                    parametros.Add("@Importe", notaCredito.importe_solicitud, DbType.Currency);
                    parametros.Add("@NumeroCuotas", notaCredito.numero_cuotas, DbType.Int32);
                    parametros.Add("@Fecha", notaCredito.fecha_solicitud, DbType.DateTime);
                    parametros.Add("@NotaCreditoId", DbType.Int32, direction: ParameterDirection.Output);

                     conexion.Execute("sp_InsertarNotaCredito", parametros, commandType: CommandType.StoredProcedure);
                    int numeroNotaCredito = parametros.Get<int>("@NotaCreditoId");
                    return numeroNotaCredito;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en sp_InsertarNotaCredito: " + ex.Message + ", StackTrace: " + ex.StackTrace);
                return 0;
            }
        }

       
    }
}
