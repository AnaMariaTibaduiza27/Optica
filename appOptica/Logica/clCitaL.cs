using appOptica.Datos;
using appOptica.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Logica
{
    class clCitaL
    {
        clCitaD objCitaD = new clCitaD();

        public clPacienteE mtdPaciente(clPacienteE objPacienteE = null)
        {
            clPacienteE paciente = new clPacienteE();
            paciente = objCitaD.mtdPaciente(objPacienteE);
            return paciente;
        }

        /* public clMedicoE mtdMedico(clMedicoE objMedicoE = null)
         {
             clMedicoE medico = new clMedicoE();
             medico = objCitaD.mtdMedico(objMedicoE);
             return medico;
         }*/

        public clPacienteE mtdDatosPaciente(clPacienteE objPaciente)
        {
            return objCitaD.mtdDatosPaciente(objPaciente);
        }

        public clTipoPacienteE mtdTipoPaciente (clPacienteE objPacienteTP)
        {
            clTipoPacienteE objTipoPaceinte = new clTipoPacienteE();
            objTipoPaceinte = objCitaD.mtdTipoPaciente(objPacienteTP);
            return objTipoPaceinte;
        }

        public int mtdCita (clCitaE objCitaE)
        {
            int registros = 0;
            if (objCitaE.IdPaciente == 0 || objCitaE.Hora == null)
            {
                registros = -3;
            }
            else
            {
                registros = objCitaD.mtdCita(objCitaE);
            }

            return registros;
        }

        public List<clCitaE> mtdFechaOcupada (clCitaE objCitaE = null )
        {
            List<clCitaE> listaFechaOcu = new List<clCitaE>();
            listaFechaOcu = objCitaD.mtdFechaOcupada(objCitaE);
            return listaFechaOcu;
        }

        public clBusquedaE mtdBuscarCita (clBusquedaE objBusquedaE)
        {
            clBusquedaE Cita = new clBusquedaE();
            Cita = objCitaD.mtdBuscarCita(objBusquedaE);
            return Cita;
        }

        public int mtdActualizarCita(clCitaE objCitaE)
        {
            int actualizar = objCitaD.mtdActualizarCita(objCitaE);
            return actualizar;
        }

        public int mtdValidacionFechaHora (clCitaE objCitaE)
        {
            int validacion = objCitaD.mtdValidarFechaHora(objCitaE);
            if (validacion == 1)
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
            List<clMedicoE> nombresMedico = new List<clMedicoE>();
            nombresMedico = objCitaD.mtdCompletarMedico();
            return nombresMedico;
        }

        public int mtdEliminarCita (clCitaE objCitaE)
        {
            int eliminar = objCitaD.mtdEliminarCita(objCitaE);
            return eliminar;
        }

  	public List<clCitaE> mtdListaCitasPorPaciente(string busqueda, string Fecha = null)
        {
            return objCitaD.mtdListarCitasPorPaciente(busqueda,Fecha);
        }

        public clCitaE mtdValorCita(string fecha, string hora)
        {
            return objCitaD.mtdValorCita(fecha,hora);
        }
    }
}
