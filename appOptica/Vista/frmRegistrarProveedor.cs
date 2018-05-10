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
    public partial class frmRegistrarProveedor : Form
    {
        public frmRegistrarProveedor()
        {
            InitializeComponent();
           
        }
        

       


        clValidaciones V = new clValidaciones();
        clProveedoresL objProveedoresL = new clProveedoresL();

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            clProveedoresE objProveedoresE = new clProveedoresE();
            if (txtNombre.Text == "" || txtDireccion.Text == "" || txtEmail.Text == "" || txtNIT.Text == "" || txtTelefono.Text == "")
            {
                MessageBox.Show("Debe Ingresar Todos Los Campos Obligatorios");
            }
            else
            {
                Boolean validacionCorreo = V.email_bien_escrito(txtEmail.Text);
                if (validacionCorreo == true)
                {
                    objProveedoresE.Nombre = txtNombre.Text.Trim();
                    objProveedoresE.Direccion = txtDireccion.Text.Trim();
                    objProveedoresE.Telefono = txtTelefono.Text.Trim();
                    objProveedoresE.NIT = txtNIT.Text.Trim();
                    objProveedoresE.Email = txtEmail.Text.Trim();

                    int registro = objProveedoresL.mtdValidar(objProveedoresE);

                    
                    if (registro == -2)
                    {
                        MessageBox.Show("Datos nulos");
                    }
                    else if (registro == 1)
                    {
                        MessageBox.Show("Registo completo");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese una dirrección de correo valida");
                }

            }
            }
        
        

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.soloLetras(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.soloNumeros(e);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmRegistrarProveedor_Load(object sender, EventArgs e)
        {

        }
    }
    }

