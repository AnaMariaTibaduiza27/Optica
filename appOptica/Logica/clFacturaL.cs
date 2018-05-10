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
    class clFacturaL
    {
        clFacturaD objFacturaD = new clFacturaD();

        public int mtdObtenerNoFactura(int FormaDePago)
        {
            return objFacturaD.mtdObtenerNoFactura(FormaDePago);
        }

        public int mtdObtenerNoFactura1(int FormaDePago)
        {
            return objFacturaD.mtdObtenerNoFactura(FormaDePago);
        }

        public List<clPacienteE> mtdCargarDatos()
        {
            List<clPacienteE> listaDocumentos = new List<clPacienteE>();
            listaDocumentos = objFacturaD.mtdCargarDatos();
            return listaDocumentos;

        }

        public int mtdObtenerIdFactura(string NoFactura,string estado,string TipoPago)
        {
            return objFacturaD.mtdObtenerIdFactura(NoFactura,estado,TipoPago);
        }

        public List<clProductoE> mtdCargarDatosProductos()
        {
            List<clProductoE> listaProductos = new List<clProductoE>();
            listaProductos = objFacturaD.mtdCargarDatosProductos();
            return listaProductos;

        }

        public clPacienteE mtdDatosPaciente(clPacienteE objPaciente)
        {
            return objFacturaD.mtdDatosPaciente(objPaciente);
        }
        public int mtdRegistrarFactura(clFacturaE objFacturaE)
        {
            return objFacturaD.mtdRegistrarFactura(objFacturaE);
        }

        public int mtdEliminarFactura(clFacturaE objFacturaE)
        {
            return objFacturaD.mtdEliminarFactura(objFacturaE);
        }

        public DataTable mtdListarFacturas(clFacturaE objFacturaE = null, String mes = null, String año = null, String Documento = null)
        {
            return objFacturaD.mtdListarFacturas(objFacturaE, mes, año, Documento);
        }

        public int mtdActualizarEstado(int Id)
        {
            return objFacturaD.mtdActualizarEstado(Id);
        }
    }
}

