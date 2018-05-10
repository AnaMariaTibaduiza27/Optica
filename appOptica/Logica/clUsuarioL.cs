using appOptica.Datos;
using appOptica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Logica
{
    class clUsuarioL
    {
        
        clUsuarioD objUsuarioD = new clUsuarioD();

        public clUsuarioE mtdIniciarSesion(clUsuarioE objUsuarioE)
        {

            clUsuarioE objUsuario = new clUsuarioE();
            objUsuario = objUsuarioD.mtdIniciarSesion(objUsuarioE);
                
            
            return objUsuario;
        }

    }
}
