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
    public class AprobadorRepository : IAprobadorRepository
    {
        private readonly Conexion _conexion;

        public AprobadorRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<int> InsertarAprobador(Aprobador aprobador)
        {
            try
            {
                using (var conexion = _conexion.ObtenerConexion())
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@Nombre", aprobador.NombresApellidosAprobador, DbType.String);
                    parametros.Add("@IdAprobador", DbType.Int32, direction: ParameterDirection.Output);

                    await conexion.ExecuteAsync("sp_InsertarAprobador", parametros, commandType: CommandType.StoredProcedure);
                    int numeroAprobador = parametros.Get<int>("@IdAprobador");
                    return numeroAprobador;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en sp_InsertarAprobador: " + ex.Message + ", StackTrace: " + ex.StackTrace);
                return 0;
            }
        }

        public  IEnumerable<Aprobador> ListarAprobador()
        {
            try
            {
                using (var conexion = _conexion.ObtenerConexion())
                {

                    return  conexion.Query<Aprobador>("sp_ObtenerAprobadores", commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en sp_ObtenerAprobadores: " + ex.Message + ", StackTrace: " + ex.StackTrace);
                return null;
            }
        }

        public Aprobador ObtenerAprobadorPorCodigo(int codigo)
        {
            try
            {
                using (var conexion = _conexion.ObtenerConexion())
                {

                    return conexion.QueryFirstOrDefault<Aprobador>("sp_ObtenerAprobadorByCodigo", new { codAprobador = codigo }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en sp_ObtenerAprobadorByCodigo: " + ex.Message + ", StackTrace: " + ex.StackTrace);
                return null;
            }
        }
    }
}
