using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Entidades
{
    class clCitaE
    {
        public int IdCita { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public float Valor { get; set; }
        public int IdTipoCita { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }

    }
}
