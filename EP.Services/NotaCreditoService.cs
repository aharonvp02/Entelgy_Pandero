using EP.Data.Repositorio;
using EP.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Services
{
    public class NotaCreditoService : INotaCreditoService
    {
        private readonly INotaCreditoRepository _notaCreditoRepository;
        private readonly IAsociadoRepository _asociadoRepository;
        private readonly IAprobadorRepository _aprobadorRepository;

        public NotaCreditoService(INotaCreditoRepository notaCreditoRepository,
                              IAsociadoRepository asociadoRepository,
                              IAprobadorRepository aprobadorRepository)
        {
            _notaCreditoRepository = notaCreditoRepository;
            _asociadoRepository = asociadoRepository;
            _aprobadorRepository = aprobadorRepository;
        }

        public int RegistrarNotaCredito(NotaCredito notaCredito)
        {
            var asociado =  _asociadoRepository.ObtenerAsociadoPorId(notaCredito.ID_asociado);
            if (asociado == null)
            {
                throw new ArgumentException("El asociado no existe.");
            }

            // Validar el aprobador
            var aprobador = _aprobadorRepository.ObtenerAprobadorPorCodigo(notaCredito.CodAprobador);
            if (aprobador == null)
            {
                throw new ArgumentException("El aprobador no existe.");
            }

            // Validar el sustento
            if (string.IsNullOrWhiteSpace(notaCredito.sustento_aprobador) || notaCredito.sustento_aprobador.Length > 50)
            {
                throw new ArgumentException("El sustento es obligatorio y no debe exceder los 50 caracteres.");
            }

            // Validar el importe
            if (notaCredito.importe_solicitud <= 0)
            {
                throw new ArgumentException("El importe debe ser mayor a 0.");
            }
            // Validar el número de cuotas
            if (notaCredito.numero_cuotas <= 0)
            {
                throw new ArgumentException("El número de cuotas debe ser mayor a 0.");
            }

            // Registrar la nota de crédito
                 return  _notaCreditoRepository.InsertarNotaCredito(notaCredito);

        }
    }
}
