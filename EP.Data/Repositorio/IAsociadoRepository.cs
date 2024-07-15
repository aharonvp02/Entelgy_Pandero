using EP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Data.Repositorio
{
    public interface IAsociadoRepository
    {
        Asociado ObtenerAsociadoPorCodigo(string codigo);
        Asociado ObtenerAsociadoPorId(int id);
    }
}
