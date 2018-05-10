using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Entidades
{
    class clBusquedaE
    {
        public DateTime Fecha { get; set; }
        public String Hora { get; set; }
        public int  IdCita { get; set; }
        public float Valor { get; set; }
        public string Paciente { get; set; }
        public String TipoCita { get; set; }
        public String  Medico { get; set; }
    }
}
