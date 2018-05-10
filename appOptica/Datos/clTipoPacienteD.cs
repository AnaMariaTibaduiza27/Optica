using appOptica.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Datos
{
    class clTipoPacienteD
    {
        clBDSql objBDSql = new clBDSql();

        public List<clTipoPacienteE> mtdListar()
        {
            string consulta = "Select * From TipoPaciente";
            DataTable tblDatos = new DataTable();
            tblDatos = objBDSql.mtdSelect(consulta);

            List<clTipoPacienteE> lista = new List<clTipoPacienteE>();

            for (int i  = 0; i  <tblDatos.Rows.Count; i ++)
            {
                clTipoPacienteE objTipoPaciente = new clTipoPacienteE();
                objTipoPaciente.IdTipoPaciente = int.Parse(tblDatos.Rows[i][0].ToString());
                objTipoPaciente.TipoPaciente = tblDatos.Rows[i][1].ToString();

                lista.Add(objTipoPaciente);

            }

            return lista;
        }

    }
}
