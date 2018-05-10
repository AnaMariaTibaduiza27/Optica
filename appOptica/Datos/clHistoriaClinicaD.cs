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
    class clHistoriaClinicaD
    {
        clPacienteE objPacienteE = new clPacienteE();
        clBDSql objBDSql = new clBDSql();

        String consulta = "";
        public clPacienteE mtdListar(clPacienteE objPacienteE)
        {
            DataTable DatosPaciente = new DataTable();
            consulta = "select * from Paciente where Documento = '" + objPacienteE.Documento + "'";
            DatosPaciente = objBDSql.mtdSelect(consulta);
            clPacienteE paciente = new clPacienteE();

            paciente.IdPaciente = int.Parse(DatosPaciente.Rows[0][0].ToString());
            paciente.TipoDocumento = DatosPaciente.Rows[0][1].ToString();
            paciente.Documento = DatosPaciente.Rows[0][2].ToString();
            paciente.Edad = int.Parse(DatosPaciente.Rows[0][3].ToString());
            paciente.Nombres = DatosPaciente.Rows[0][4].ToString();
            paciente.Apellidos = DatosPaciente.Rows[0][5].ToString();
            paciente.Celular = DatosPaciente.Rows[0][6].ToString();
            paciente.Email = DatosPaciente.Rows[0][7].ToString();
            paciente.FechaNacimiento = DateTime.Parse(DatosPaciente.Rows[0][8].ToString());
            paciente.Direccion = DatosPaciente.Rows[0][9].ToString();
            paciente.NombreAcudiente = DatosPaciente.Rows[0][10].ToString();
            paciente.CelularAcudiente = DatosPaciente.Rows[0][11].ToString();
            paciente.IdTipoPaciente = int.Parse(DatosPaciente.Rows[0][12].ToString());
            paciente.Genero = DatosPaciente.Rows[0][17].ToString();
            paciente.Aseguradora = DatosPaciente.Rows[0][13].ToString();
            paciente.TipoVinculacion = DatosPaciente.Rows[0][14].ToString();
            paciente.Ocupacion = DatosPaciente.Rows[0][15].ToString();
            paciente.Ciudad = DatosPaciente.Rows[0][16].ToString();

            return paciente;
        }


        public int mtdValidarPaciente(clPacienteE objPacienteE)
        {
            DataTable tblPaciente = new DataTable();
            consulta = "select count (IdPaciente) from paciente where Documento = '" + objPacienteE.Documento + "'";
            tblPaciente = objBDSql.mtdSelect(consulta);

            int validacion = int.Parse(tblPaciente.Rows[0][0].ToString());

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


        public int mtdHistoria(clHistoriaClinicaE objHistoriaClinicaE)
        {
            consulta = "insert into HistoriaClinica (NoHistoriaClinica,Fecha,Hora,IdPaciente," +
                       "UltimoControl,RX,MotivoConsulta,Antecedentes,ExamenExterno,ReflejosPupilares," +
                       "BioMicroscopia,Diagnostico,Tratamiento,Observaciones)" +
                       "values ('" + objHistoriaClinicaE.NoHistoriaClinica + "','" + objHistoriaClinicaE.Fecha.ToShortDateString() + "','"
                       + objHistoriaClinicaE.Hora + "'," + objHistoriaClinicaE.IdPaciente + ",'" + objHistoriaClinicaE.UltimoControl + "','"
                       + objHistoriaClinicaE.RX + "','" + objHistoriaClinicaE.MotivoCOnsulta + "','" + objHistoriaClinicaE.Antecedentes + "','"
                       + objHistoriaClinicaE.ExamenEsterno + "','" + objHistoriaClinicaE.ReflejosPupilares + "','"
                       + objHistoriaClinicaE.BioMicroscopia + "','" + objHistoriaClinicaE.Diagnostico + "','" + objHistoriaClinicaE.Tratamiento + "','"
                       + objHistoriaClinicaE.Observaciones + "')";

            int registro = objBDSql.mtdIDU(consulta);
            return registro;
        }

        public clHistoriaClinicaE mtdNoHistoria(clHistoriaClinicaE objHistoriaE = null)
        {
            DataTable tblNoHistoria = new DataTable();
            String consulta = "select max (IdHistoriaClinica) from HistoriaClinica";
            tblNoHistoria = objBDSql.mtdSelect(consulta);
            clHistoriaClinicaE historiaClinica = new clHistoriaClinicaE();
            historiaClinica.IdHistoriaClinica = int.Parse(tblNoHistoria.Rows[0][0].ToString());
            return historiaClinica;

        }

        public int mtdRegistroValores(clAspectoE.HC[] vecDatos = null)
        {
            clHistoriaClinicaE HistoriaClinica = new clHistoriaClinicaE();
            HistoriaClinica = mtdNoHistoria();
            int IdHistoria = HistoriaClinica.IdHistoriaClinica;
            int registroValores = 0;
            int suma = 0;
            for (int i = 0; i < 46; i++)
            {
                if (vecDatos[i].valor == "")
                {
                    vecDatos[i].valor = "----";
                }
                string consulta = "insert into Valores(IdAspecto,IdItem,Valor,IdHistoriaClinica)values("
                                  + vecDatos[i].aspecto + "," + vecDatos[i].item + ",'"
                                  + vecDatos[i].valor + "'," + IdHistoria + ")";
                registroValores = objBDSql.mtdIDU(consulta);
            }
            suma = suma + registroValores;

            return suma;
        }


        public int mtdActualizarHC(clHistoriaClinicaE objHistoriaClinicaE)
        {
            string consulta = "update HistoriaClinica set NoHistoriaClinica = '" + objHistoriaClinicaE.NoHistoriaClinica
                       + "',Fecha = '" + objHistoriaClinicaE.Fecha.ToShortDateString()
                       + "',Hora = '" + objHistoriaClinicaE.Hora + "',IdPaciente = " + objHistoriaClinicaE.IdPaciente
                       + ",UltimoControl = '" + objHistoriaClinicaE.UltimoControl + "', RX = '"
                       + objHistoriaClinicaE.RX + "',MotivoConsulta = '" + objHistoriaClinicaE.MotivoCOnsulta
                       + "',Antecedentes = '" + objHistoriaClinicaE.Antecedentes + "',ExamenExterno = '"
                       + objHistoriaClinicaE.ExamenEsterno + "',ReflejosPupilares = '" + objHistoriaClinicaE.ReflejosPupilares
                       + "',BioMicroscopia = '" + objHistoriaClinicaE.BioMicroscopia + "',Diagnostico = '"
                       + objHistoriaClinicaE.Diagnostico + "',Tratamiento = '" + objHistoriaClinicaE.Tratamiento
                       + "',Observaciones = '" + objHistoriaClinicaE.Observaciones + "' where NoHistoriaClinica = '" + objHistoriaClinicaE.NoHistoriaClinica + "'";
            int actualizarHC = objBDSql.mtdIDU(consulta);
            return actualizarHC;
        }

        // id de historia
        public clHistoriaClinicaE mtdIdHC(clHistoriaClinicaE objHistoriaClinicaE = null)
        {
            DataTable tblNoHistoria = new DataTable();
            String consulta = "select IdHistoriaClinica from HistoriaClinica where NoHistoriaClinica = '" + objHistoriaClinicaE.NoHistoriaClinica + "'";
            tblNoHistoria = objBDSql.mtdSelect(consulta);
            clHistoriaClinicaE historiaClinica = new clHistoriaClinicaE();
            historiaClinica.IdHistoriaClinica = int.Parse(tblNoHistoria.Rows[0][0].ToString());
            return historiaClinica;

        }

        public List<clHistoriaClinicaE> mtdNoHC()
        {
            string consulta = "select NoHistoriaClinica from HistoriaClinica";
            DataTable tblHistorias = new DataTable();
            tblHistorias = objBDSql.mtdSelect(consulta);

            List<clHistoriaClinicaE> listaNoHC = new List<clHistoriaClinicaE>();

            for (int i = 0; i < tblHistorias.Rows.Count; i++)
            {
                clHistoriaClinicaE objHistoria = new clHistoriaClinicaE();
                objHistoria.NoHistoriaClinica = tblHistorias.Rows[i][0].ToString();

                listaNoHC.Add(objHistoria);

            }
            return listaNoHC;
        }

        public int mtdActualizarValores(clAspectoE.HC[] vecDatos = null, clHistoriaClinicaE objHistoriaE = null)
        {
            //clHistoriaClinicaE HistoriaClinica = mtdIdHC();
            int IdHistoria = objHistoriaE.IdHistoriaClinica;
            int actualizarValores = 0;
            int suma = 0;
            for (int i = 0; i < vecDatos.Count(); i++)
            {

                consulta = "update Valores set IdAspecto = " + vecDatos[i].aspecto
                           + ",IdItem = " + vecDatos[i].item + ", Valor = '" + vecDatos[i].valor
                           + "' where IdHistoriaClinica = " + IdHistoria + " and IdAspecto = " + vecDatos[i].aspecto + " and IdItem = " + vecDatos[i].item + "";

                actualizarValores = objBDSql.mtdIDU(consulta);

                suma = suma + actualizarValores;
            }

            return suma;

        }

        public clHistoriaClinicaE mtdBuscarHC(clHistoriaClinicaE objHistoriaE)
        {
            DataTable tbldatosHC = new DataTable();
            consulta = "select * from HistoriaClinica where NoHistoriaClinica = '" + objHistoriaE.NoHistoriaClinica + "'";
            tbldatosHC = objBDSql.mtdSelect(consulta);

            clHistoriaClinicaE Historia = new clHistoriaClinicaE();

            if (tbldatosHC.Rows.Count == 0)
            {
                Historia = null;
            }
            else
            {
                Historia.IdHistoriaClinica = int.Parse(tbldatosHC.Rows[0][0].ToString());
                Historia.NoHistoriaClinica = tbldatosHC.Rows[0][1].ToString();
                Historia.Fecha = DateTime.Parse(tbldatosHC.Rows[0][2].ToString());
                Historia.Hora = tbldatosHC.Rows[0][3].ToString();
                Historia.IdPaciente = int.Parse(tbldatosHC.Rows[0][4].ToString());
                Historia.UltimoControl = tbldatosHC.Rows[0][5].ToString();
                Historia.RX = tbldatosHC.Rows[0][6].ToString();
                Historia.MotivoCOnsulta = tbldatosHC.Rows[0][7].ToString();
                Historia.Antecedentes = tbldatosHC.Rows[0][8].ToString();
                Historia.ExamenEsterno = tbldatosHC.Rows[0][9].ToString();
                Historia.ReflejosPupilares = tbldatosHC.Rows[0][10].ToString();
                Historia.BioMicroscopia = tbldatosHC.Rows[0][11].ToString();
                Historia.Diagnostico = tbldatosHC.Rows[0][12].ToString();
                Historia.Tratamiento = tbldatosHC.Rows[0][13].ToString();
                Historia.Observaciones = tbldatosHC.Rows[0][14].ToString();

            }

            return Historia;

        }

        /// <summary>
        /// Método para saber que incremento se le realizara a la nueva historia clinica que se registre a un mismo paciente
        /// </summary>
        /// <param name="objPacienteE"></param>
        /// <returns></returns>
        public int mtdNoHistoriaCreciente(int IdPaciente)
        {
            consulta = "select count (IdPaciente) from HistoriaClinica where IdPaciente = " + IdPaciente + "";
            DataTable tblNoHistoria = new DataTable();
            tblNoHistoria = objBDSql.mtdSelect(consulta);
            int NoHistoriaAsignar;

            if (tblNoHistoria.Rows.Count == 0)
            {
                NoHistoriaAsignar = -2;
            }
            else
            {
                NoHistoriaAsignar = int.Parse(tblNoHistoria.Rows[0][0].ToString());
            }

            return NoHistoriaAsignar;
        }

        public int mtdHCExistente(clHistoriaClinicaE objHistoriaClinicaE)
        {
            DataTable tblHCExistente = new DataTable();
            consulta = "select count (IdHistoriaClinica) from HistoriaClinica where NoHistoriaClinica = '" +
                        objHistoriaClinicaE.NoHistoriaClinica + "'";
            tblHCExistente = objBDSql.mtdSelect(consulta);

            int validacionHC = int.Parse(tblHCExistente.Rows[0][0].ToString());

            if (validacionHC != 0)
            {
                validacionHC = 1;
            }
            else
            {
                validacionHC = -2;
            }

            return validacionHC;
        }

        public DataTable mtdBuscarValores(clValoresE objValoresE)
        {
            DataTable tblValores = new DataTable();
            consulta = "select * from Valores where IdHistoriaClinica = " + objValoresE.IdHistoriaClinica + "";
            tblValores = objBDSql.mtdSelect(consulta);


            return tblValores;
        }

        public int mtdEliminarHC(clHistoriaClinicaE objHistoriaClincaE)
        {
            consulta = "delete from HistoriaClinica where IdHistoriaClinica = " + objHistoriaClincaE.IdHistoriaClinica + "";
            int eliminar = objBDSql.mtdIDU(consulta);
            return eliminar;
        }

        public int mtdEliminarValores(clAspectoE.HC[] valores, clHistoriaClinicaE objHistoria)
        {

            int eliminarValores = 0;
            
            consulta = "delete from Valores where IdHistoriaClinica = " + objHistoria.IdHistoriaClinica + "";
            eliminarValores = objBDSql.mtdIDU(consulta);


            return eliminarValores;
        }

    }
}