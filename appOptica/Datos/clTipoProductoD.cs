using appOptica.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Datos
{
    class clTipoProductoD
    {
        clBDSql objBDSql = new clBDSql();
        List<clTipoProductoE> ListaTipo = new List<clTipoProductoE>();

        public List<clTipoProductoE> mtdListar()
        {
            String consulta = "Select * from TipoProducto";
            DataTable tblTipo = new DataTable();
            tblTipo = objBDSql.mtdSelect(consulta);
            for (int i = 0; i < tblTipo.Rows.Count; i++)
            {
                clTipoProductoE objTipoProducto = new clTipoProductoE();
                objTipoProducto.IdTipoProducto = int.Parse(tblTipo.Rows[i][0].ToString());
                objTipoProducto.TipoProducto = tblTipo.Rows[i][1].ToString();
                ListaTipo.Add(objTipoProducto);
            }
            return ListaTipo;
        }
    }
}
