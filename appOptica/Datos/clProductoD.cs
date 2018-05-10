using appOptica.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Datos
{
    class clProductoD
    {
        clBDSql objConexion = new clBDSql();
        String Consulta = "";
        int registros = 0;

        public int mtdRgistrar(clProductoE objProductoE)
        {
            DataTable tblDatos = new DataTable();
            
            Consulta = "Select count(IdProducto) From Producto where Referencia ='"
                + objProductoE.Referecia + "'";

            tblDatos = objConexion.mtdSelect(Consulta);
            registros = int.Parse(tblDatos.Rows[0][0].ToString());

            if (registros != 0)
            {
                registros = -2;
            }
            else
            {

                Consulta = "Insert into Producto (Nombre, Referencia, Cantidad, Marca,Descripcion, Valor, IdProveedor, IdTipoProducto) Values ('" + objProductoE.Nombre + "','" + objProductoE.Referecia + "',"
                + objProductoE.Cantidad + ",'" + objProductoE.Marca + "','" + objProductoE.Descripcion + "'," + objProductoE.Valor + ","
                + objProductoE.idProvedor + "," + objProductoE.IdTipoProducto + " )";
                int Registro = objConexion.mtdIDU(Consulta);
                return Registro;
            }
            return registros;
        }

        public int validarProductoFactura(clProductoE objProductoE)
        {
            DataTable tblDatos = new DataTable();

            Consulta = "Select count(IdProducto) From Producto where Nombre ='"
                + objProductoE.Nombre + "'";

            tblDatos = objConexion.mtdSelect(Consulta);
            registros = int.Parse(tblDatos.Rows[0][0].ToString());

            return registros;

            
        }

        public int mtdActualizar(clProductoE objProducto,int cantidad, int IdProducto)
        {
            if (cantidad != 0 && IdProducto !=0)
            {
                Consulta = "Update Producto set Cantidad= (Cantidad -" + cantidad + ") where  IdProducto ="+IdProducto;
            }
            else
            {
                Consulta = "Update Producto set Nombre = '" + objProducto.Nombre + "', Referencia = '" + objProducto.Referecia + "', Cantidad = '" + objProducto.Cantidad + "', Marca = '"
            + objProducto.Marca + "', Descripcion = '" + objProducto.Descripcion + "', Valor = '" + objProducto.Valor +
            "' where IdProducto =" + objProducto.IdProducto + "";
            }


            

            int registro = objConexion.mtdIDU(Consulta);

            return registro;

        }

        public int mtdEliminar(clProductoE objProductoE)
        {
            DataTable tblDatos = new DataTable();
            Consulta = "Delete Producto where  IdProducto =" + objProductoE.IdProducto + "";

            int registro = objConexion.mtdIDU(Consulta);

            return registro;
        }

        public List<clProductoE> mtdLista(clProductoE objProductoE, string busqueda)
        {
            
            if (objProductoE !=null && objProductoE.Nombre != null)
            {
                Consulta = "Select * from Producto where Nombre  = '" + objProductoE.Nombre + "'";
            }
            else if (busqueda != null)
            {
                Consulta = "Select * From Producto where Nombre Like'" + busqueda + "%' OR Referencia LIKE '" + busqueda + "%'";
            }
            else 
            {
                Consulta = "Select * From producto";
            }
            List<clProductoE> Lista = new List<clProductoE>();
            DataTable tblDatos = new DataTable();
           tblDatos = objConexion.mtdSelect(Consulta);

            for (int i = 0; i < tblDatos.Rows.Count; i++)
            {
                clProductoE objProducto = new clProductoE();
                objProducto.IdProducto = int.Parse(tblDatos.Rows[i][0].ToString());
                objProducto.Nombre = tblDatos.Rows[i][1].ToString();
                objProducto.Referecia = tblDatos.Rows[i][2].ToString();
                objProducto.Cantidad = int.Parse(tblDatos.Rows[i][3].ToString());
                objProducto.Marca = tblDatos.Rows[i][4].ToString();
                objProducto.Descripcion = tblDatos.Rows[i][5].ToString();
                objProducto.Valor = double.Parse(tblDatos.Rows[i][6].ToString());
                objProducto.idProvedor = int.Parse(tblDatos.Rows[i][7].ToString());
                objProducto.IdTipoProducto = int.Parse(tblDatos.Rows[i][8].ToString());
                Lista.Add(objProducto);
              
            }
            return Lista;

        }
         
        public int mtdSumarCantidad(clProductoE objProductoE)
        {
            Consulta = "Update Producto set Cantidad= (Cantidad +" + objProductoE.Cantidad + ") where  Referencia ='" + objProductoE.Referecia+"'";
            int Actualizacion = objConexion.mtdIDU(Consulta);
            return Actualizacion;
        }
        
    }
}

