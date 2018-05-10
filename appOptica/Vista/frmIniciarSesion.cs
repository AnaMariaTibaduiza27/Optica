using appOptica.Datos;
using appOptica.Entidades;
using appOptica.Logica;
using System;
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
    public partial class frmIniciarSesion : Form
    {
        public frmIniciarSesion()
        {
            InitializeComponent();
        }
        clUsuarioL objUsuarioL = new clUsuarioL();
        clUsuarioD objUsuarioD = new clUsuarioD();
        public static string nombre = "";
        public static int IdUsuario = 0;

        clUsuarioE objUsuario = new clUsuarioE();
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            clUsuarioE objUsuarioE = new clUsuarioE();
            if (txtContraseña.Text == "" || txtUsuario.Text == "")
            {
                MessageBox.Show("Debe Llenar Los Campos");
            }
            else

            {
                objUsuarioE.Usuario = txtUsuario.Text;
                objUsuarioE.Contraseña = txtContraseña.Text;
                

                objUsuario = objUsuarioL.mtdIniciarSesion(objUsuarioE);
                

                if (objUsuario != null)
                {
                    IdUsuario = objUsuarioE.IdUsuario;
                    nombre = objUsuario.Nombres;
                    frmContenedor objContenedor = new frmContenedor();
                    objContenedor.Show();
                    
                    this.Hide();
                }

                else 
                {
                    nombre = "";
                    MessageBox.Show("Usuario y/o Contraseña incorrectos");
                }
            }
           

        }
       
        
      
        private void frmIniciarSesion_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmConfiguracionIP ConfiguracionIp = new frmConfiguracionIP();
            ConfiguracionIp.Show();
        }
    }
}
