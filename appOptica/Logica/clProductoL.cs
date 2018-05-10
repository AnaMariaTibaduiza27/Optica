using appOptica.Datos;
using appOptica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Logica
{
    class clProductoL
    {
        clProductoD objProductoD = new clProductoD();
        public int mtdValidar(clProductoE objProductoE)
        {
            int registros = 0;
            if (objProductoE.Nombre == "")
            {
                registros = -5;
            }
            else
            {
                registros = objProductoD.mtdRgistrar(objProductoE);
            }
            return registros;
        }

        public int validarProductoFactura(clProductoE objProductoE)
        {
            return objProductoD.validarProductoFactura(objProductoE);
        }

        public List<clProductoE> mtdListar(clProductoE objProductoE = null, string busqueda = null)
        {
            List<clProductoE> objProductosE = new List<clProductoE>();
            objProductosE = objProductoD.mtdLista(objProductoE, busqueda);
            return objProductosE;
        }

        public int mtdActualizar (clProductoE objProductoE= null,int cantidad = 0, int IdProducto = 0)
        {
            int registro = objProductoD.mtdActualizar(objProductoE,cantidad,IdProducto);
            return registro;
        }

        public int mtdEliminar (clProductoE objProductoE)
        {
            int registro = objProductoD.mtdEliminar(objProductoE);
            return registro;
        }
        public int mtdRecibirSuma(clProductoE objProductoE)
        {
            return objProductoD.mtdSumarCantidad(objProductoE);
        }
    }
}

