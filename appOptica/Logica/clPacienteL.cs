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
    class clPacienteL
    {
        clPacienteD objPacienteD = new clPacienteD();

        public int mtdRegistrar(clPacienteE objPacienteE)
        {
            int registros = objPacienteD.mtdRegistrar(objPacienteE);

            return registros; 
        }


        public DataTable mtdListar(clPacienteE objPaciente = null, string busqueda = null)
        {
            DataTable tblDatos = new DataTable();
            tblDatos= objPacienteD.mtdListar(objPaciente,busqueda);

            return tblDatos;
        }

        public int mtdActualizar(clPacienteE objPacienteE)
        {
            int registros = objPacienteD.mtdActualizar(objPacienteE);
            return registros;
        }

        public int mtdEliminar(int IdPaciente)
        {
            int registros = objPacienteD.mtdEliminar(IdPaciente);
            return registros;
        }
    }
}
