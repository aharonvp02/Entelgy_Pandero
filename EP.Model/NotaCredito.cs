using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Model
{
    public class NotaCredito
    {
        public int ID_notaCredito { get; set; }
        public int ID_asociado { get; set; }
        public int CodAprobador { get; set; }
        public string sustento_aprobador { get; set; }
        public decimal importe_solicitud { get; set; }
        public int numero_cuotas { get; set; }
        public DateTime fecha_solicitud { get; set; }


        public string nombreAsociado { get; set; }
    }
}
