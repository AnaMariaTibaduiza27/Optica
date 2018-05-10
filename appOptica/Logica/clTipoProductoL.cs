using appOptica.Datos;
using appOptica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Logica
{
    class clTipoProductoL
    {
        clTipoProductoD objTipoPorducto = new clTipoProductoD();
        
        public List<clTipoProductoE> mtdListaTipoProducto()
        {
            List<clTipoProductoE> ListaTipo = new List<clTipoProductoE>();
            ListaTipo = objTipoPorducto.mtdListar();
            return ListaTipo;
        }
    }
}
