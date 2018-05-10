using appOptica.Datos;
using appOptica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Logica
{
    class clTipoCitaL
    {
        List<clTipoCitaE> listaTipoCita = new List<clTipoCitaE>();
        clTipoCitaD objtipoCitaD = new clTipoCitaD();

        public List<clTipoCitaE> mtdTipoCita (string busqueda = null)
        {
            listaTipoCita = objtipoCitaD.mtdTipoCita(busqueda);
            return listaTipoCita;
        }
    }
}
