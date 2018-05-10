using appOptica.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Datos
{
    class clUsuarioD
    {
        string consulta;
        clBDSql objBDSql = new clBDSql();
        

        public clUsuarioE mtdIniciarSesion(clUsuarioE objUsuarioE)
        {
            DataTable tblDatos = new DataTable();

            consulta = "select * From Usuario where Usuario ='" +
                objUsuarioE.Usuario + "' and Contraseña = '" + objUsuarioE.Contraseña + "'";
            tblDatos = objBDSql.mtdSelect(consulta);

            clUsuarioE objUsuario = new clUsuarioE();

            if (tblDatos.Rows.Count != 0)
            {
                objUsuario.IdUsuario = int.Parse(tblDatos.Rows[0][0].ToString());
                objUsuario.Nombres = tblDatos.Rows[0][3].ToString();
            }
            else
            {
                objUsuario = null;
            }
            
            

            return objUsuario;
        }

    }
}
