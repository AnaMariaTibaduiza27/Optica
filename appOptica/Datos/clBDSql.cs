using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace appOptica.Datos
{
    class clBDSql
    {
        SqlConnection conexion;
        SqlDataAdapter adaptador;
        SqlCommand cmdRegistrar;
        DataTable tblDatos;
        SqlCommandBuilder scb;
        
        public clBDSql()
        { //Data Source=DESKTOP-5LP0CUF;Initial Catalog=BDOptica;Integrated Security=True

            //conexion = new SqlConnection("Data Source=172.17.1.163;Initial Catalog=BDOptica;Persist Security Info=True;User ID=usuario;Password=1234");
            conexion = new SqlConnection("Data Source=DESKTOP-5LP0CUF;Initial Catalog=BDOptica;Integrated Security=True");
        }


        public DataTable mtdSelect(String Consulta)
        {
            conexion.Open();
            adaptador = new SqlDataAdapter(Consulta,conexion);
            tblDatos = new DataTable();
            adaptador.Fill(tblDatos);
            conexion.Close();

            return tblDatos;
        }

        public int mtdIDU(String consulta)
        {
            conexion.Open();
            cmdRegistrar = new SqlCommand(consulta, conexion);
            int cantidad = cmdRegistrar.ExecuteNonQuery();
            conexion.Close();
            return cantidad;
        }

        public DataTable mtdUpdate()
        {
            conexion.Open();
            scb = new SqlCommandBuilder(adaptador);
            adaptador.Update(tblDatos);
            conexion.Close();
            return tblDatos;

        }

        public DataTable mtdValidarRegistros(string validacion)
        {
            conexion.Open();
            cmdRegistrar = new SqlCommand(validacion, conexion);
            SqlDataReader dr = cmdRegistrar.ExecuteReader();
            tblDatos = new DataTable();
            tblDatos.Load(dr);

            conexion.Close();

            return tblDatos;
        }

    }
}
