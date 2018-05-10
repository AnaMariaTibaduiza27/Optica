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
    public partial class frmRegistrarPaciente : Form
    {
        public frmRegistrarPaciente()
        {
            InitializeComponent();
        }
        clValidaciones v = new clValidaciones();

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void txtCelularAcudiente_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void txtOcupacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        private void txtNombreAcudiente_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        private void txtAseguradora_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        private void txtTipoVinculacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        clPacienteL objPacienteL = new clPacienteL();
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            clPacienteE objPacienteE = new clPacienteE();
            if (cmbTipoDocumento.Text == ""||txtDocumento.Text==""||txtNombres.Text == ""||txtApellidos.Text == ""||txtCelular.Text==""||txtEmail.Text==""||txtDireccion.Text==""||cmbGenero.Text =="")
            {
                MessageBox.Show("Debe Ingresar Todos Los Campos Obligatorios");
            }
            else
            {
                Boolean validacionCorreo = v.email_bien_escrito(txtEmail.Text);
                if (validacionCorreo == true)
                {
                    objPacienteE.TipoDocumento = cmbTipoDocumento.SelectedItem.ToString();
                    objPacienteE.Documento = txtDocumento.Text;
                    objPacienteE.Nombres = txtNombres.Text;
                    objPacienteE.Apellidos = txtApellidos.Text;
                    objPacienteE.Celular = txtCelular.Text;
                    objPacienteE.Email = txtEmail.Text;
                    objPacienteE.Direccion = txtDireccion.Text;
                    objPacienteE.Genero = cmbGenero.SelectedItem.ToString();
                    objPacienteE.Aseguradora = txtAseguradora.Text;
                    objPacienteE.TipoVinculacion = txtTipoVinculacion.Text;
                    objPacienteE.NombreAcudiente = txtNombreAcudiente.Text;
                    objPacienteE.CelularAcudiente = txtCelularAcudiente.Text;
                    objPacienteE.Ocupacion = txtOcupacion.Text;
                    objPacienteE.IdTipoPaciente = int.Parse(cmbTipoPaciente.SelectedValue.ToString());
                    objPacienteE.FechaNacimiento = Convert.ToDateTime(mcFechaNacimiento.SelectionStart.Date);
                    objPacienteE.Ciudad = txtCiudad.Text;

                    int registros = objPacienteL.mtdRegistrar(objPacienteE);
                    if (registros == 1)
                    {
                        MessageBox.Show("Paciente registrado con éxito");
                        txtNombreAcudiente.Text = "";
                        txtNombres.Text = "";
                        txtApellidos.Text = "";
                        txtCelular.Text = "";
                        txtCelularAcudiente.Text = "";
                        txtCiudad.Text = "";
                        txtDireccion.Text = "";
                        txtDocumento.Text = "";
                        txtEmail.Text = "";
                        txtOcupacion.Text = "";
                        txtTipoVinculacion.Text = "";
                        txtAseguradora.Text = "";
                        
                    }
                    else if (registros == -2)
                    {
                        MessageBox.Show("Paciente ya registrado");
                    }
                    else
                    {
                        MessageBox.Show("Error Al Registrar");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese una dirrección de correo valida");
                }
            }
            

            
        }

        private void frmRegistrarPaciente_Load(object sender, EventArgs e)
        {

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            clTipoPacienteL objTipoPacienteL = new clTipoPacienteL();
            cmbTipoPaciente.DataSource = objTipoPacienteL.mtdListar();
            cmbTipoPaciente.DisplayMember = "TipoPaciente";
            cmbTipoPaciente.ValueMember = "IdTipoPaciente";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            frmPrincipal objFrmPrincipal = new frmPrincipal();
            objFrmPrincipal.MdiParent = this.MdiParent;
            this.Hide();
            objFrmPrincipal.Show();
            
        }

       
    }
}
