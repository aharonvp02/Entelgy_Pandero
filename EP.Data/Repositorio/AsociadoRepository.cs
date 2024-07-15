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
    public class AsociadoRepository : IAsociadoRepository
    {
        private readonly Conexion _conexion;

        public AsociadoRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public  Asociado ObtenerAsociadoPorCodigo(string codigo)
        {
            try
            {
                using (var conexion = _conexion.ObtenerConexion())
                {

                    return  conexion.QueryFirstOrDefault<Asociado>("sp_ObtenerAsociadoByCodigo", new { codAsociado = codigo }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en sp_ObtenerAsociadoByCodigo: " + ex.Message + ", StackTrace: " + ex.StackTrace);
                return null;
            }
        }

        public Asociado ObtenerAsociadoPorId(int id)
        {
            try
            {
                using (var conexion = _conexion.ObtenerConexion())
                {

                    return conexion.QueryFirstOrDefault<Asociado>("sp_ObtenerAsociadoById", new { idAsociado = id }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en sp_ObtenerAsociadoById: " + ex.Message + ", StackTrace: " + ex.StackTrace);
                return null;
            }
        }
    }
}
