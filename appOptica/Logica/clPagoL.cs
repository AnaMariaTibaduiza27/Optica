using appOptica.Datos;
using appOptica.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Logica
{
    class clPagoL
    {
        clPagoD objPagoD = new clPagoD();


        public int mtdRegistrarPago(clPagoE objPagoE)
        {
            return objPagoD.mtdRegistrarPago(objPagoE);
        }

        public string mtdObtenerSaldoPorPagar(int IdFactura)
        {
            return objPagoD.mtdObtenerSaldoPorPagar(IdFactura);
        }

        public DataTable mtdListarPagos(int IdFactura,string estado,string TipoPago)
        {
            return objPagoD.mtdListarPagos(IdFactura,estado,TipoPago);
        }
    }
}
