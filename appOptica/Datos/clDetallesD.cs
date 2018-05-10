using appOptica.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Datos
{
    class clDetallesD
    {

        clBDSql objBDSql = new clBDSql();
        String consulta;

        public clFacturaE mtdObtenerIdFactura(clFacturaE objFacturaE)
        {
            consulta = "Select IdFactura from Factura where NoFactura ="+objFacturaE.NoFactura+"and TipoPago='"+objFacturaE.TipoPago+"'";
            DataTable tblDatos = new DataTable();
            tblDatos = objBDSql.mtdSelect(consulta);

            clFacturaE objFactura = new clFacturaE();
            objFactura.IdFactura = int.Parse(tblDatos.Rows[0][0].ToString());
            return objFactura;


        }



        public int mtdRegistrarDetalle(clDetallesE objDetallesE,int tipo)
        {
            int registros=0;

            if (tipo == 1)
            {
                consulta = "Select count(IdDetalles) From Detalles where IdCita = " + objDetallesE.IdCita;
                DataTable registrosC = new DataTable();
                registrosC = objBDSql.mtdSelect(consulta);
                int registrosee = int.Parse(registrosC.Rows[0][0].ToString());

                if (registrosee != 0)
                {
                    registros = 5;
                }

                if (registros == 5)
                {
                    registros = 5;
                }
                else
                {
                    consulta = "Insert into Detalles(IdProducto,IdFactura,Valor,IdCita,Cantidad)Values" +
                    "(" + objDetallesE.IdProducto + "," + objDetallesE.IdFactura + "," + objDetallesE.Valor +
                    "," + objDetallesE.IdCita + "," + objDetallesE.Cantidad + ")";
                    registros = objBDSql.mtdIDU(consulta);
                }

            }
            else if (tipo == 2)
            {
                consulta = "Insert into Detalles(IdProducto,IdFactura,Valor,IdCita,Cantidad)Values" +
                    "(" + objDetallesE.IdProducto + "," + objDetallesE.IdFactura + "," + objDetallesE.Valor +
                    "," + objDetallesE.IdCita + "," + objDetallesE.Cantidad + ")";
                registros = objBDSql.mtdIDU(consulta);
            }
            
            return registros;
        }
    }
}
