using appOptica.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Datos
{
    class clPagoD
    {
        string consulta;
        clBDSql objBDSql = new clBDSql();

        public int mtdRegistrarPago(clPagoE objPagoE)
        {
            consulta = "insert into Pago(ValorPago,Fecha,IdFactura)values("+objPagoE.ValorPago+",'"+DateTime.Now.ToShortDateString()+"',"+objPagoE.IdFactura+")";
            int registros = objBDSql.mtdIDU(consulta);
            return registros;

        }

        public DataTable mtdListarPagos(int idFactura,string estado,string TipoPago )
        {
            
            consulta = "select Pago.ValorPago,Pago.Fecha,Factura.NoFactura from Pago inner join Factura on Pago.IdFactura = Factura.IdFactura where Pago.IdFactura="+idFactura+" and estado='"+estado+"' and TipoPago='"+TipoPago+"'";
            DataTable tblDatos = new DataTable();
            tblDatos = objBDSql.mtdSelect(consulta);
            return tblDatos;
        }

        public string mtdObtenerSaldoPorPagar(int IdFactura)
        {
            consulta = "select sum(ValorPago)From Pago Where IdFactura ="+IdFactura;
            DataTable tblDatos = new DataTable();
            tblDatos = objBDSql.mtdSelect(consulta);
            string saldo;
            if (tblDatos.Rows[0][0].ToString()=="")
            {
                saldo = "0";
            }
            else
            {


                saldo = tblDatos.Rows[0][0].ToString();
            }
            return saldo;

        }

    }
}
