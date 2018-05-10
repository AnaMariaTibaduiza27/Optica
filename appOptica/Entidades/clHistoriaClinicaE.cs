using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Entidades
{
    class clHistoriaClinicaE
    {
        public int IdHistoriaClinica { get; set; }
        public String NoHistoriaClinica { get; set; }
        public DateTime Fecha { get; set; }
        public String Hora { get; set; }
        public int IdPaciente { get; set; }
        public String UltimoControl { get; set; }
        public String  RX { get; set; }
        public string MotivoCOnsulta { get; set; }
        public String Antecedentes { get; set; }
        public String ExamenEsterno { get; set; }
        public String ReflejosPupilares { get; set; }
        public String BioMicroscopia { get; set; }
        public String Diagnostico { get; set; }
        public String Tratamiento { get; set; }
        public String Observaciones { get; set; }
    }
}
