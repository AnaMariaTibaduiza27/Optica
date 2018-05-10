using appOptica.Datos;
using appOptica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Logica
{
    class clProveedoresL
    {
        clProveedoresD objProveedoresD = new clProveedoresD();
        public int mtdValidar(clProveedoresE objProveedoresE)
        {
            int registros = 0;
            if (objProveedoresE.Nombre == "")
            {
                registros = -2;
            }
            else
            {
                registros = objProveedoresD.mtdRegistrar(objProveedoresE);
            }
            return registros;
        }


        public List<clProveedoresE> mtdListar(clProveedoresE objProveedoresE = null, string busqueda = null)
        {
            List<clProveedoresE> objProvedoresE = new List<clProveedoresE>();
            objProvedoresE = objProveedoresD.mtdLista(objProveedoresE , busqueda);
            return objProvedoresE;
        }
        public int mtdAcualizar(clProveedoresE objProveedoresE)
        {
            int Registros = objProveedoresD.mtdActualizar(objProveedoresE);
            return Registros;
        }
        public int mtdEliminar ( clProveedoresE objProveedoresE)
        {
            int Registro = objProveedoresD.mtdEliminar(objProveedoresE);

            return Registro;
         }
    }
}
