using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using appOptica.Entidades;

namespace appOptica.Datos
{
    class clTipoCitaD
    {
        clBDSql objBDSql = new clBDSql();
        List<clTipoCitaE> listaTipoCita = new List<clTipoCitaE>();
        string consulta = "";

        public List<clTipoCitaE> mtdTipoCita (string busqueda)
        {

            if (busqueda != null)
            {
                consulta = "select TipoCita from Cita inner join TipoCita where IdCita = "+busqueda+"";

            }
            else
            {
                consulta = "select * from TipoCita";
            }
            
            DataTable tblTipoCita = new DataTable();
            tblTipoCita = objBDSql.mtdSelect(consulta);

            for (int i = 0; i < tblTipoCita.Rows.Count; i++)
            {
                clTipoCitaE TipoCitaE = new clTipoCitaE();
                TipoCitaE.IdTipoCita = int.Parse( tblTipoCita.Rows[i][0].ToString());
                TipoCitaE.TipoCita = tblTipoCita.Rows[i][1].ToString();

                listaTipoCita.Add(TipoCitaE);

            }
            return listaTipoCita;
        }
    }
}
