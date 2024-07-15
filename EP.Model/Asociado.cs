using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Model
{
    public class Asociado
    {
        public int ID_asociado { get; set; }
        public string codigo_asociado { get; set; }
        public string nombre_asociado { get; set; }
        public string apellidos_asociado { get; set; }
        public string email_asociado { get; set; }
        public long telefono_asociado { get; set; }
        public bool activo { get; set; }
    }
}
