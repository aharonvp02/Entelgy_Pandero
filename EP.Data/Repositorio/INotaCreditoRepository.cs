using EP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Data.Repositorio
{
    public interface INotaCreditoRepository
    {
        int InsertarNotaCredito(NotaCredito notaCredito);
    }
}
