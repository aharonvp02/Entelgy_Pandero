using EP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Data.Repositorio
{
    public interface IAprobadorRepository
    {
        IEnumerable<Aprobador> ListarAprobador();

        Aprobador ObtenerAprobadorPorCodigo(int codigo);

        Task<int> InsertarAprobador(Aprobador aprobador);
    }
}
