using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Model
{
    public class Log
    {
        public int ID_log { get; set; }
        public int ID_notaCredito { get; set; }
        public int CodAprobador { get; set; }
        public DateTime fecha_hora_registro { get; set; } = DateTime.Now;
    }
}
