using EP.Data.Repositorio;
using EP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Services
{


    public class AprobadorService : IAprobadorService
    {

        private readonly IAprobadorRepository _aprobadorRepository;

        public AprobadorService(IAprobadorRepository aprobadorRepository)
        {
            _aprobadorRepository = aprobadorRepository;
        }

        public async Task<int> InsertarAprobador(Aprobador aprobador)
        {
            if (!ValidarAprobador(aprobador))
            {
                throw new ArgumentException("El aprobador no cumple con los criterios de validación.");
            }

            return await _aprobadorRepository.InsertarAprobador(aprobador);
        }

        public bool ValidarAprobador(Aprobador aprobador)
        {
            // Implementa tus reglas de validación aquí
            if (string.IsNullOrEmpty(aprobador.NombresApellidosAprobador))
            {
                return false;
            }

            return true;
        }
    }
}
