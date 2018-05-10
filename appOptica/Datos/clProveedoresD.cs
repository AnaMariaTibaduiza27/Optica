using appOptica.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Datos
{
    class clProveedoresD
    {
        clBDSql objconexion = new clBDSql();
        String consulta = "";
        public int mtdRegistrar(clProveedoresE objProveedoresE)
        {
            consulta = "insert into Proveedor(Nombre, Direccion, Telefono," +
               "NIT, Email) Values ('" + objProveedoresE.Nombre + "','" + objProveedoresE.Direccion + "','"
               + objProveedoresE.Telefono + "','" + objProveedoresE.NIT + "','" + objProveedoresE.Email + "')";
            int registrosp = objconexion.mtdIDU(consulta);

            return registrosp;
        }

        public int mtdActualizar(clProveedoresE objProveedore)
        {
            consulta = "Update Proveedor set Nombre = '" + objProveedore.Nombre + "',Direccion = '"
                  + objProveedore.Direccion + "', Telefono = '" + objProveedore.Telefono + "',NIT = '" 
                  + objProveedore.NIT + "',Email = '" + objProveedore.Email + "' where IdProveedor =" + objProveedore.IdProveedor + "";

            int resgistros = objconexion.mtdIDU(consulta);

            return resgistros;  
        }

        public int mtdEliminar (clProveedoresE objProveedores)
        {
            DataTable tblDatos = new DataTable();

            consulta = "Delete Proveedor where IdProveedor =" + objProveedores.IdProveedor + "";

            int registros = objconexion.mtdIDU(consulta);

            return registros;
        }

        public List<clProveedoresE> mtdLista(clProveedoresE objProveedores, string busqueda)
        {
           
            if (objProveedores != null && objProveedores.Nombre != null)
            {
                consulta = "Select * From Proveedor where Nombre ='" + objProveedores.Nombre + "'";
            }
            else if (busqueda != null)
            {
                consulta = "Select * From Proveedor where Nombre Like'" + busqueda + "%' OR NIT LIKE '" + busqueda + "%'";
            }
            else
            {
                consulta = "Select * From Proveedor";
            }

            List<clProveedoresE> Lista = new List<clProveedoresE>();
            DataTable tblDatos = new DataTable();
                tblDatos = objconexion.mtdSelect(consulta);

                for (int i = 0; i < tblDatos.Rows.Count; i++)
                {
                    clProveedoresE objProveedor = new clProveedoresE();
                    objProveedor.IdProveedor = int.Parse(tblDatos.Rows[i][0].ToString());
                    objProveedor.Nombre = tblDatos.Rows[i][1].ToString();
                    objProveedor.Direccion = tblDatos.Rows[i][2].ToString();
                    objProveedor.Telefono = tblDatos.Rows[i][3].ToString();
                    objProveedor.NIT = tblDatos.Rows[i][4].ToString();
                    objProveedor.Email = tblDatos.Rows[i][5].ToString();

                    Lista.Add(objProveedor);
                    
                }
          return Lista;
        }  
    }
}

