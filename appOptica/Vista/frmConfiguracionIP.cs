using appOptica.Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appOptica.Vista
{
    public partial class frmConfiguracionIP : Form
    {
        
        public frmConfiguracionIP()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            ArrayList Datos = new ArrayList();
            Datos.Add(txtDireccionIp.Text);
            Datos.Add(txtUsuario.Text);
            Datos.Add(txtContraseña.Text);
            clBDSql objConexion = new clBDSql();

        }
    }
}
