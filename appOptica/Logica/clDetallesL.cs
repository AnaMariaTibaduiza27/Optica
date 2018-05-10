using appOptica.Datos;
using appOptica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Logica
{
    class clDetallesL
    {
        clDetallesD objDetallesD = new clDetallesD();

        public clFacturaE mtdObtenerIdFactura(clFacturaE objFacturaE)
        {
            return objDetallesD.mtdObtenerIdFactura(objFacturaE);
        }

        public int mtdRegistrarDetalles(clDetallesE objDetallesE,int tipo)
        {
            return objDetallesD.mtdRegistrarDetalle(objDetallesE,tipo);
        }

    }
}
