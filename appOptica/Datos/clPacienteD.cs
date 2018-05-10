using appOptica.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Datos
{
    class clPacienteD
    {
        clBDSql objBDSql = new clBDSql();
        String consulta="";
        int registros = 0;
        

        public int mtdRegistrar(clPacienteE objPacienteE)
        {
            DataTable tblDatos = new DataTable();

            consulta = "Select count(IdPaciente) From Paciente where Documento ='"
                +objPacienteE.Documento+"'";

            tblDatos = objBDSql.mtdSelect(consulta);
            registros = int.Parse(tblDatos.Rows[0][0].ToString());

            if (registros !=0)
            {
                registros = -2;
            }
            else
            {

                DateTime fechaActual = DateTime.Today;
                DateTime fechaNacimiento = objPacienteE.FechaNacimiento;
                int edad = fechaActual.Year - fechaNacimiento.Year;
                
                if (fechaNacimiento.Month > fechaActual.Month)
                {
                    --edad;
                }

                consulta = "Insert into Paciente(TipoDocumento,Documento,Nombres,Apellidos,"
                    + "Edad,Celular,Email,Genero,Direccion,Ocupacion,NombreAcudiente,CelularAcudiente,"
                    +"Aseguradora,TipoVinculacion,FechaNacimiento,IdTipoPaciente,Ciudad)Values('"
                    +objPacienteE.TipoDocumento+"','"+objPacienteE.Documento+"','"+objPacienteE.Nombres+"','"+objPacienteE.Apellidos
                    +"',"+edad+",'"+objPacienteE.Celular+"','"+objPacienteE.Email+"','"
                    +objPacienteE.Genero+"','"+objPacienteE.Direccion+"','"+objPacienteE.Ocupacion+"','"+objPacienteE.NombreAcudiente
                    +"','"+objPacienteE.CelularAcudiente+"','"+objPacienteE.Aseguradora+"','"
                    +objPacienteE.TipoVinculacion+"','"+fechaNacimiento.ToShortDateString()+"',"+objPacienteE.IdTipoPaciente+",'"+objPacienteE.Ciudad+"')";
                registros = objBDSql.mtdIDU(consulta);
                
            }

            return registros;
            
        }

        public int mtdActualizar(clPacienteE objPacienteE)
        {
            DataTable tblDatos = new DataTable();
            consulta = "Update Paciente set Direccion ='"+objPacienteE.Direccion+"',Email ='"+objPacienteE.Email
                +"',Celular = '"+objPacienteE.Celular + "',CelularAcudiente = '"+objPacienteE.CelularAcudiente
                +"',Aseguradora = '"+objPacienteE.Aseguradora+"' where IdPaciente ="+objPacienteE.IdPaciente+"";

            registros = objBDSql.mtdIDU(consulta);
            return registros;

        }

        public DataTable mtdListar(clPacienteE objPaciente,string busqueda)
        {
                       
            if (objPaciente != null && objPaciente.IdTipoPaciente != 0)
            {
                consulta = "Select TipoPaciente.Tipo From Paciente where IdTipoPaciente =" + objPaciente.IdTipoPaciente + "";
            }
            else if (busqueda != null)
            {
                consulta = "Select Paciente.TipoDocumento,Paciente.Documento,Paciente.Edad,Paciente.Nombres," +
                    "Paciente.Apellidos,Paciente.Celular,Paciente.Email,Paciente.FechaNacimiento,Paciente.Direccion,"+
                    "Paciente.NombreAcudiente,Paciente.CelularAcudiente,TipoPaciente.Tipo,Paciente.Aseguradora,Paciente.TipoVinculacion,"+
                    "Paciente.Ocupacion,Paciente.Ciudad,Paciente.Genero, Paciente.IdPaciente From Paciente inner join TipoPaciente " +
                    "on Paciente.IdTipoPaciente = TipoPaciente.IdTipoPaciente  where Documento LIKE '" + busqueda + "%' OR Nombres LIKE '"+busqueda+ "%'";
            }
            else
            {
                consulta = "Select Paciente.TipoDocumento,Paciente.Documento,Paciente.Edad,Paciente.Nombres," +
                    "Paciente.Apellidos,Paciente.Celular,Paciente.Email,Paciente.FechaNacimiento,Paciente.Direccion," +
                    "Paciente.NombreAcudiente,Paciente.CelularAcudiente,TipoPaciente.Tipo,Paciente.Aseguradora,Paciente.TipoVinculacion," +
                    "Paciente.Ocupacion,Paciente.Ciudad,Paciente.Genero, Paciente.IdPaciente From Paciente inner join TipoPaciente " +
                    "on Paciente.IdTipoPaciente = TipoPaciente.IdTipoPaciente";
            }

            
            DataTable tblDatos = new DataTable();
            tblDatos = objBDSql.mtdSelect(consulta);
            //List<clPacienteE> lista = new List<clPacienteE>();

            //for (int i = 0; i < tblDatos.Rows.Count; i++)
            //{
            //    clPacienteE objPacienteE = new clPacienteE();
            //    objPacienteE.IdPaciente = int.Parse(tblDatos.Rows[i][0].ToString());
            //    objPacienteE.TipoDocumento = tblDatos.Rows[i][1].ToString();
            //    objPacienteE.Documento = tblDatos.Rows[i][2].ToString();
            //    objPacienteE.Edad = int.Parse(tblDatos.Rows[i][3].ToString());
            //    objPacienteE.Nombres = tblDatos.Rows[i][4].ToString();
            //    objPacienteE.Apellidos = tblDatos.Rows[i][5].ToString();
            //    objPacienteE.Celular = tblDatos.Rows[i][6].ToString();
            //    objPacienteE.Email = tblDatos.Rows[i][7].ToString();
            //    objPacienteE.FechaNacimiento = Convert.ToDateTime(tblDatos.Rows[i][8].ToString());
            //    objPacienteE.Direccion = tblDatos.Rows[i][9].ToString();
            //    objPacienteE.NombreAcudiente = tblDatos.Rows[i][10].ToString();
            //    objPacienteE.CelularAcudiente = tblDatos.Rows[i][11].ToString();
            //    objPacienteE.IdTipoPaciente = tblDatos.Rows[i][12].ToString();
            //    objPacienteE.Aseguradora = tblDatos.Rows[i][13].ToString();
            //    objPacienteE.TipoVinculacion = tblDatos.Rows[i][14].ToString();
            //    objPacienteE.Ocupacion = tblDatos.Rows[i][15].ToString();
            //    objPacienteE.Genero = tblDatos.Rows[i][17].ToString();
            //    objPacienteE.Ciudad = tblDatos.Rows[i][16].ToString();

            //    lista.Add(objPacienteE);
                
            //}

            return tblDatos;     

        }


        public int mtdEliminar(int IdPaciente)
        {
            consulta = "Delete From Paciente where IdPaciente = " + IdPaciente + "";
            registros = objBDSql.mtdIDU(consulta);

            return registros;
        }

        
        }
}
