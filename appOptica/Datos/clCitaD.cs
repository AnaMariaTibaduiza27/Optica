using appOptica.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Datos
{
    class clCitaD
    {
        clBDSql objBBSql = new clBDSql();

        String consulta = "";
        public clPacienteE mtdPaciente(clPacienteE objPacienteE)
        {
            DataTable tblPaciente = new DataTable();
            consulta = "select IdPaciente from Paciente where Documento = '" + objPacienteE.Documento + "'";
            tblPaciente = objBBSql.mtdSelect(consulta);

            clPacienteE paciente = new clPacienteE();

            paciente.IdPaciente = int.Parse(tblPaciente.Rows[0][0].ToString());

            return paciente;

        }

        public clPacienteE mtdDatosPaciente(clPacienteE objPacienteE)
        {
            consulta = "Select IdPaciente,Documento,Nombres,Apellidos,Celular,Direccion From Paciente where Documento ='" + objPacienteE.Documento + "'";
            DataTable tblDatos = new DataTable();
            tblDatos = objBBSql.mtdSelect(consulta);

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

        public clTipoPacienteE mtdTipoPaciente (clPacienteE objPacienteTP)
        {
            consulta = "select TipoPaciente.Tipo,TipoPaciente.IdTipoPaciente from TipoPaciente inner join Paciente on TipoPaciente.IdTipoPaciente = " +
                        " Paciente.IdTipoPaciente where Paciente.Documento = '"+objPacienteTP.Documento+"'";
            DataTable tblTipoPaciente = new DataTable();
            tblTipoPaciente = objBBSql.mtdSelect(consulta);

            clTipoPacienteE objTipoPaciente = new clTipoPacienteE();
            if (tblTipoPaciente.Rows.Count == 0)
            {
                objTipoPaciente = null;
            }
            else
            {
                objTipoPaciente.IdTipoPaciente = int.Parse(tblTipoPaciente.Rows[0][1].ToString());
                objTipoPaciente.TipoPaciente = tblTipoPaciente.Rows[0][0].ToString();
            }
            
            return objTipoPaciente;
        }

        /* public clMedicoE mtdMedico(clMedicoE objMedicoE)
         {
             DataTable tblMedico = new DataTable();
             consulta = "select IdMedico from Medico where Nombres = '" + objMedicoE.Nombres + "'";
             tblMedico = objBBSql.mtdSelect(consulta);

             clMedicoE medico = new clMedicoE();

             medico.IdMedico = int.Parse(tblMedico.Rows[0][0].ToString());

             return medico;
         }*/

        public int mtdCita(clCitaE objCitaE)
        {
            consulta = "insert into Cita (Fecha,Hora,Valor,IdTipoCita,IdPaciente,IdMedico)"
                      + "values ('" + objCitaE.Fecha.ToShortDateString() + "','"
                      + objCitaE.Hora + "'," + objCitaE.Valor + ","
                      + objCitaE.IdTipoCita + "," + objCitaE.IdPaciente + "," + 3 + ")";
            int registro = objBBSql.mtdIDU(consulta);
            return registro;

        }

        public List<clCitaE> mtdListarCitas(clCitaE objCitaE)
        {
            List<clCitaE> listaCitas = new List<clCitaE>();
            consulta = "select Fecha,Hora from Cita";
            DataTable tblcitas = new DataTable();
            tblcitas = objBBSql.mtdSelect(consulta);

            for (int i = 0; i < tblcitas.Rows.Count; i++)
            {
                clCitaE objCitaRegE = new clCitaE();
                objCitaRegE.Fecha = DateTime.Parse(tblcitas.Rows[i][0].ToString());
                objCitaRegE.Hora = tblcitas.Rows[i][1].ToString();
                listaCitas.Add(objCitaRegE);
            }
            return listaCitas;
        }

        public List<clCitaE> mtdFechaOcupada(clCitaE objCitaE = null)
        {
            DataTable tblFechaOcupada = new DataTable();
            consulta = "select Hora from Cita where Fecha = '" + objCitaE.Fecha.ToShortDateString() + "'";
            tblFechaOcupada = objBBSql.mtdSelect(consulta);
            List<clCitaE> listaFechaOcu = new List<clCitaE>();
            for (int i = 0; i < tblFechaOcupada.Rows.Count; i++)
            {
                clCitaE objCita = new clCitaE();

                objCita.Hora = tblFechaOcupada.Rows[i][0].ToString();
                listaFechaOcu.Add(objCita);
            }

            return listaFechaOcu;
        }

        public clBusquedaE mtdBuscarCita(clBusquedaE objBusquedaE)
        {
            DataTable tblBusquedaCita = new DataTable();
            consulta = "select Paciente.Documento, TipoCita.TipoCita,Cita.Fecha,Cita.Hora,"+
                "Cita.Valor,Cita.IdCita from (Cita "+
                "inner join Paciente on Cita.IdPaciente = Paciente.IdPaciente) inner join "+
                "TipoCita on TipoCita.IdTipoCita = Cita.IdTipoCita  where Fecha = '" + objBusquedaE.Fecha.ToShortDateString() +
                "'and Hora = '" + objBusquedaE.Hora + "'";

            tblBusquedaCita = objBBSql.mtdSelect(consulta);

            clBusquedaE Cita = new clBusquedaE();

            Cita.Fecha = DateTime.Parse(tblBusquedaCita.Rows[0][2].ToString());
            Cita.Hora = tblBusquedaCita.Rows[0][3].ToString();
            Cita.Valor = float.Parse(tblBusquedaCita.Rows[0][4].ToString());
            Cita.TipoCita = (tblBusquedaCita.Rows[0][1].ToString());
            Cita.Paciente = (tblBusquedaCita.Rows[0][0].ToString());
            Cita.IdCita = int.Parse(tblBusquedaCita.Rows[0][5].ToString());

            return Cita;

        }

        public int mtdActualizarCita(clCitaE objCitaE)
        {
            consulta = "update Cita set Fecha = '" + objCitaE.Fecha.ToShortDateString()
                      + "',Hora = '" + objCitaE.Hora + "', Valor = " + objCitaE.Valor
                      + ", IdTipoCita = " + objCitaE.IdTipoCita + ",IdPaciente = " + objCitaE.IdPaciente
                      + ",IdMedico = " + objCitaE.IdMedico + " where IdCita = " + objCitaE.IdCita + "";

            int actualizar = objBBSql.mtdIDU(consulta);
            return actualizar;
        }


        public int mtdValidarFechaHora(clCitaE objCitaE)
        {
            DataTable tblValidacion = new DataTable();
            consulta = "select count (IdCita) from Cita where Fecha = '" + objCitaE.Fecha.ToShortDateString() + "' and Hora = '" + objCitaE.Hora + "'";
            tblValidacion = objBBSql.mtdSelect(consulta);

            int validacion = int.Parse(tblValidacion.Rows[0][0].ToString());
            if (validacion != 0)//si existe
            {
                validacion = 1;
            }
            else
            {
                validacion = -2;
            }

            return validacion;
        }

        public List<clMedicoE> mtdCompletarMedico()
        {
            consulta = "select Nombres from Medico ";
            List<clMedicoE> nombresMedico = new List<clMedicoE>();
            DataTable tblNombres = new DataTable();
            tblNombres = objBBSql.mtdSelect(consulta);
            for (int i = 0; i < tblNombres.Rows.Count; i++)
            {
                clMedicoE Medico = new clMedicoE();
                Medico.Nombres = tblNombres.Rows[i][0].ToString();
                nombresMedico.Add(Medico);

            }

            return nombresMedico;
        }

        public int mtdEliminarCita(clCitaE objCitaE)
        {
            consulta = "delete from Cita where IdCita = "+objCitaE.IdCita+"";
            int eliminar = objBBSql.mtdIDU(consulta);
            return eliminar;
        }

        public clCitaE mtdValorCita(string fecha, string hora)
        {
            consulta = "Select Valor,IdTipoCita,IdCita from Cita where Fecha = '" + DateTime.Parse(fecha).ToShortDateString() + "' and Hora = '" + hora + "'";
            DataTable tblDatos = new DataTable();
            tblDatos = objBBSql.mtdSelect(consulta);
            clCitaE objCitaE = new clCitaE();

            
            objCitaE.Valor = float.Parse(tblDatos.Rows[0][0].ToString());
            objCitaE.IdTipoCita = int.Parse(tblDatos.Rows[0][1].ToString());
            objCitaE.IdCita = int.Parse(tblDatos.Rows[0][2].ToString());

            return objCitaE;
        }


        public List<clCitaE> mtdListarCitasPorPaciente(string busqueda, string fecha)
        {
            List<clCitaE> lista = new List<clCitaE>();
            if (fecha != null)
            {
                consulta = "Select Hora,Valor,IdTipoCita from Cita where Fecha='" + DateTime.Parse(fecha).ToShortDateString()+ "'";
                DataTable tblDatos = new DataTable();
                tblDatos = objBBSql.mtdSelect(consulta);
                

                for (int i = 0; i < tblDatos.Rows.Count; i++)
                {
                    clCitaE objCitaE = new clCitaE();
                   
                    objCitaE.Hora = tblDatos.Rows[i][0].ToString();
                    objCitaE.Valor = float.Parse(tblDatos.Rows[i][1].ToString());
                    objCitaE.IdTipoCita = int.Parse(tblDatos.Rows[i][2].ToString());

                    lista.Add(objCitaE);
                }
              

            }
            else if (busqueda != null && fecha == null)
            
            {
                consulta = "Select Fecha,Hora,Valor from Paciente inner join Cita on Paciente.IdPaciente = Cita.IdPaciente where Documento ='" + busqueda + "'";
                DataTable tblDatos = new DataTable();
                tblDatos = objBBSql.mtdSelect(consulta);
                

                for (int i = 0; i < tblDatos.Rows.Count; i++)
                {
                    clCitaE objCitaE = new clCitaE();
                    DateTime Fecha = Convert.ToDateTime(tblDatos.Rows[i][0]);
                    Fecha.ToShortDateString();
                    objCitaE.Fecha = Fecha;
                    objCitaE.Hora = tblDatos.Rows[i][1].ToString();
                    objCitaE.Valor = float.Parse(tblDatos.Rows[i][2].ToString());

                    lista.Add(objCitaE);
                }
                

            }

            return lista;
        }
    }
}
