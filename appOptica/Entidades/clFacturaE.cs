using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Entidades
{
    class clFacturaE
    {
        public int IdFactura { get; set; }
        public int NoFactura { get; set; }
        public String Fecha { get; set; }
        public double SubTotal { get; set; }
        public double IVA { get; set; }
        public double Total { get; set; }
        public int IdPaciente { get; set; }
        public string Estado{ get; set; }
        public int IdUsuario { get; set; }
        public double Descuento { get; set; }
        public string TipoPago { get; set; }

    }
}
