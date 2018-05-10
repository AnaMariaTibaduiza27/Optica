using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Entidades
{
    class clPagoE
    {
        public int IdPago { get; set; }
        public double ValorPago { get; set; }
        public DateTime Fecha { get; set; }
        public int IdFactura { get; set; }

    }
}
