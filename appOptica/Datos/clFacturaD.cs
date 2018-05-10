using appOptica.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Datos
{
    class clFacturaD
    {
        string consulta="";
        clBDSql objBDSql = new clBDSql();

        public int mtdObtenerNoFactura(int formaDePago)
        {
            int NoFactura;
            if (formaDePago == 0)
            {
                consulta = "SELECT MAX(NoFactura) from Factura where TipoPago = 'Crédito'";


            }
            else
            {
                consulta = "Select NoFactura from Factura where NoFactura = (SELECT MAX(NoFactura) from Factura) and TipoPago = 'Contado'";
            }
            
            DataTable tblDatos = new DataTable();
            tblDatos = objBDSql.mtdSelect(consulta);
            if (tblDatos.Rows.Count==0 ||tblDatos.Rows[0][0].ToString()=="")
            {
                NoFactura = 0;
            }
            else
            {
                NoFactura = int.Parse(tblDatos.Rows[0][0].ToString());
            }
            
            return NoFactura;
        }
        
        public int mtdObtenerNoFactura1(int formaDePago)
        {
            int NoFactura;
            if (formaDePago == 0)
            {
                consulta = "Select NoFactura from Factura where NoFactura = (SELECT MAX(NoFactura) from Factura) and TipoPago = 'Crédito'";
            }
            else
            {
                consulta = "Select NoFactura from Factura where NoFactura = (SELECT MAX(NoFactura) from Factura) and TipoPago = 'Contado'";
            }
            
            DataTable tblDatos = new DataTable();
            tblDatos = objBDSql.mtdSelect(consulta);
            if (tblDatos.Rows.Count==0 || tblDatos.Rows[0][0].ToString() == "")
            {
                NoFactura = 0;
            }
            else
            {
                NoFactura = int.Parse(tblDatos.Rows[0][0].ToString());
            }
            
            return NoFactura;
        }





        public int mtdObtenerIdFactura(string NoFactura,string estado,string TipoPago)
        {
            int IdFactura;
            
                consulta = "Select IdFactura from Factura where NoFactura = '"+NoFactura+"' and estado ='"+estado+"' and tipoPago = '"+TipoPago+"'";
           

            DataTable tblDatos = new DataTable();
            tblDatos = objBDSql.mtdSelect(consulta);
            if (tblDatos.Rows.Count == 0)
            {
                IdFactura = 0;
            }
            else
            {
                IdFactura = int.Parse(tblDatos.Rows[0][0].ToString());
            }

            return IdFactura;
        }
        
        public List<clPacienteE> mtdCargarDatos()
        {
            consulta = "select Documento From Paciente";

            List<clPacienteE> listaDocumentos = new List<clPacienteE>();

            DataTable tblDatos = new DataTable();
            tblDatos = objBDSql.mtdSelect(consulta);

            for (int i = 0; i < tblDatos.Rows.Count; i++)
            {
                clPacienteE objPacienteE = new clPacienteE();
                objPacienteE.Documento = tblDatos.Rows[i][0].ToString();

                listaDocumentos.Add(objPacienteE);

            }

            return listaDocumentos;
        }

        public List<clProductoE> mtdCargarDatosProductos()
        {
            consulta = "select Nombre From Producto";

            List<clProductoE> listaProductos = new List<clProductoE>();

            DataTable tblDatos = new DataTable();
            tblDatos = objBDSql.mtdSelect(consulta);

            for (int i = 0; i < tblDatos.Rows.Count; i++)
            {
                clProductoE objProductoE = new clProductoE();
                objProductoE.Nombre = tblDatos.Rows[i][0].ToString();

                listaProductos.Add(objProductoE);

            }

            return listaProductos;
        }

        public clPacienteE mtdDatosPaciente(clPacienteE objPacienteE)
        {
            consulta = "Select IdPaciente,Documento,Nombres,Apellidos,Celular,Direccion From Paciente where Documento ='" + objPacienteE.Documento + "'";
            DataTable tblDatos = new DataTable();
            tblDatos = objBDSql.mtdSelect(consulta);

            clPacienteE objPaciente = new clPacienteE();
            if (tblDatos.Rows.Count == 0)
            {
                objPaciente = null;
            }
            else
            {
                objPaciente.IdPaciente = int.Parse(tblDatos.Rows[0][0].ToString());
                objPaciente.Documento = tblDatos.Rows[0][1].ToString();
                objPaciente.Nombres = tblDatos.Rows[0][2].ToString();
                objPaciente.Apellidos = tblDatos.Rows[0][3].ToString();
                objPaciente.Celular = tblDatos.Rows[0][4].ToString();
                objPaciente.Direccion = tblDatos.Rows[0][5].ToString();
            }
            

            return objPaciente;
        }

        public int mtdEliminarFactura(clFacturaE objFacturaE)
        {
            consulta = "Delete Factura where  IdFactura =" + objFacturaE.IdFactura + "";

            int registro = objBDSql.mtdIDU(consulta);

            return registro;
        }

        public int mtdRegistrarFactura(clFacturaE objFacturaE)
        {
            consulta = "Insert into Factura(NoFactura,Fecha,Subtotal,IVA,Total,IdPaciente,Estado,IdUsuario,TipoPago,Descuento)" +
                "values('" + objFacturaE.NoFactura + "','" + objFacturaE.Fecha + "'," + objFacturaE.SubTotal +
                "," + objFacturaE.IVA + "," + objFacturaE.Total + "," + objFacturaE.IdPaciente +
                ",'" + objFacturaE.Estado + "'," + objFacturaE.IdUsuario + ",'" + objFacturaE.TipoPago + "'," +
                objFacturaE.Descuento + ")";
            int registros = objBDSql.mtdIDU(consulta);
            return registros;
    
        }
        public DataTable mtdListarFacturas(clFacturaE objFacturaE, String mes, String año, String Documento)
        {
            DataTable tblDatos = new DataTable();

            if (objFacturaE != null && objFacturaE.Fecha != null)
            {
                consulta = "Select NoFactura,Fecha,Subtotal,IVA,Total,Estado,TipoPago,Descuento From Factura where Fecha='" + objFacturaE.Fecha + "'";

            }
            else if ( Documento != null)
            {
                consulta = "Select NoFactura,Fecha,Subtotal,IVA,Total,Estado,TipoPago,Descuento,Paciente.Nombres From Factura inner join Paciente on Factura.IdPaciente = Paciente.IdPaciente where Paciente.Documento='" + Documento + "'";
            }
            else if (mes != null)
            {
                consulta = "Select NoFactura,Fecha,Subtotal,IVA,Total,Estado,TipoPago,Descuento From Factura where SUBSTRING (Fecha, 4,2)="+mes+"";
            }
            else if (objFacturaE != null && objFacturaE.Estado != null)
            {
                consulta = "Select NoFactura,Fecha,Subtotal,IVA,Total,Estado,TipoPago,Descuento From Factura where Estado='" + objFacturaE.Estado+"'";
            }
            else
            {
                
                consulta = "Select NoFactura,Fecha,Subtotal,IVA,Total,Estado,TipoPago,Descuento From Factura";
            }

            tblDatos = objBDSql.mtdSelect(consulta);

            return tblDatos;
        }


        public int mtdActualizarEstado(int Id)
        {
            consulta = "Update Factura set Estado='Paga' where IdFactura=" + Id;
            int update = objBDSql.mtdIDU(consulta);
            return update;
        }

    }
}
