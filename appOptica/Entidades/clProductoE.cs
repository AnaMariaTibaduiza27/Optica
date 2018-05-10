using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appOptica.Entidades
{
    class clProductoE
    {
        public int IdProducto { get; set; }
        public String Nombre { get; set; }
        public String Referecia { get; set; }
        public int Cantidad { get; set; }
        public String Marca { get; set; }
        public String Descripcion { get; set; }
        public double Valor { get; set; }
        public int idProvedor { get; set; }
        public int IdTipoProducto { get; set; }
    }
}
