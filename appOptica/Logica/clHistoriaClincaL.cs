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
    class clHistoriaClinicaL
    {
        clPacienteE objPacienteE = new clPacienteE();
        clHistoriaClinicaD objHistoriaClinicaD = new clHistoriaClinicaD();
        clHistoriaClinicaE objHistoriaClinicaE = new clHistoriaClinicaE();

        public clPacienteE mtdListar(clPacienteE objPacienteE)
        {
            clPacienteE objPaci = new clPacienteE();
            objPaci = objHistoriaClinicaD.mtdListar(objPacienteE);
            return objPaci;
        }

        

        public int mtdNoHistoriaCreciente(int IdPaciente)
        {
            int NoHistoriaAsignar = objHistoriaClinicaD.mtdNoHistoriaCreciente(IdPaciente);
            
            return NoHistoriaAsignar;
        }


        public int mtdHistoria(clHistoriaClinicaE objHistoriaClinicaE)
        {
            int registro = 0;
            if (objHistoriaClinicaE.NoHistoriaClinica == "")
            {
                registro = -3;

            }
            else
            {
                registro = objHistoriaClinicaD.mtdHistoria(objHistoriaClinicaE);
            }
            return registro;
        }

        

        public int mtdRegistroValores(clAspectoE.HC[] vecDatos )
        {
            int registroValores = objHistoriaClinicaD.mtdRegistroValores(vecDatos);
            if (registroValores >= 1)
            {
                registroValores = 1;
            }
            else
            {
                registroValores = -2;
            }
            return registroValores;
        }

        public int mtdValidarPaciente(clPacienteE objPacienteE = null)
        {
            int validacion = objHistoriaClinicaD.mtdValidarPaciente(objPacienteE);

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


        public int mtdActualizarHC(clHistoriaClinicaE objHistoriaE)
        {
            int actualizarHC = objHistoriaClinicaD.mtdActualizarHC(objHistoriaE);
            return actualizarHC;
        }

        public int mtdActualizarValores(clAspectoE.HC[] vecDatos = null, clHistoriaClinicaE objHistoriaE = null)
        {
            int actualizarValores = objHistoriaClinicaD.mtdActualizarValores(vecDatos , objHistoriaE );
            return actualizarValores;
        }

        public clHistoriaClinicaE mtdBuscarHC(clHistoriaClinicaE objHistoriaClinicaE)
        {
            clHistoriaClinicaE Historia = new clHistoriaClinicaE();
            Historia = objHistoriaClinicaD.mtdBuscarHC(objHistoriaClinicaE);
            return Historia;
        }

        public int mtdHCExistente(clHistoriaClinicaE objHistoriaClinicaE)
        {
            int validacionHC = objHistoriaClinicaD.mtdHCExistente(objHistoriaClinicaE);
            if (validacionHC == 1)
            {
                validacionHC = 1;
            }
            else
            {
                validacionHC = -2;
            }

            return validacionHC;
        }

        public DataTable mtdBuscarValores(clValoresE objValoresE = null)
        {
            DataTable valores = new DataTable();
            valores = objHistoriaClinicaD.mtdBuscarValores(objValoresE);
            return valores;

        }

        public int mtdEliminarHC(clHistoriaClinicaE objHistoriaClinicaE)
        {
            int eliminarHC = objHistoriaClinicaD.mtdEliminarHC(objHistoriaClinicaE);
            return eliminarHC;
        }

        public int mtdEliminarValores (clAspectoE.HC[] valores , clHistoriaClinicaE objHistoria)
        {
            int eliminarValores = objHistoriaClinicaD.mtdEliminarValores(valores, objHistoria);
            return eliminarValores;
        }

    }

}
