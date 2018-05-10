using appOptica.Datos;
using appOptica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Logica
{
    class clTipoPacienteL
    {

        public List<clTipoPacienteE> mtdListar()
        {
            clTipoPacienteD objTipoPacienteD = new clTipoPacienteD();
            List<clTipoPacienteE> lista = new List<clTipoPacienteE>();
            lista = objTipoPacienteD.mtdListar();

            return lista;
        }
    }
}
