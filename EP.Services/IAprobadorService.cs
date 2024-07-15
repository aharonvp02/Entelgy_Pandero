using EP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Services
{
    public interface IAprobadorService
    {
        bool ValidarAprobador(Aprobador aprobador);
        Task<int> InsertarAprobador(Aprobador aprobador);
    }
}
