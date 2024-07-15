using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Data
{
    public class Conexion
    {
        
        private readonly string _connectionString;

        public Conexion(string valor)
        {
            _connectionString = valor;
        }

        public SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(_connectionString);
            conexion.Open();
            return conexion;
        }
    }
}
