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
    public partial class frmListarPacientes : Form
    {
        public frmListarPacientes()
        {
            InitializeComponent();
        }


        clPacienteL objPacienteL = new clPacienteL();
        clTipoPacienteL objTipoPacienteL = new clTipoPacienteL();

        private void frmListarPacientes_Load(object sender, EventArgs e)
        {
            // QUITAR BOTON DE MINIMIZAR AL FRM
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            DataTable lista = objPacienteL.mtdListar();
            dgvListaPacientes.DataSource = lista;
            cmbBuscarPorTipo.DataSource = objTipoPacienteL.mtdListar();
            cmbBuscarPorTipo.DisplayMember = "TipoPaciente";
            cmbBuscarPorTipo.ValueMember = "IdTipoPaciente";
        }
             
                

        private void cmbBuscarPorTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clPacienteE objPaciente = new clPacienteE();
                objPaciente.IdTipoPaciente = int.Parse(cmbBuscarPorTipo.SelectedValue.ToString());
                dgvListaPacientes.DataSource = objPacienteL.mtdListar(objPaciente: objPaciente);
            }
            catch (Exception )
            {


            }
        }

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            dgvListaPacientes.DataSource = objPacienteL.mtdListar();
        }


        DataGridViewRow dgv;
        // Revisar!
        private void dgvListaPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv = dgvListaPacientes.Rows[e.RowIndex];
            txtCelular.Text = dgv.Cells[6].Value.ToString();
            txtDireccion.Text = dgv.Cells[9].Value.ToString();
            txtEmail.Text = dgv.Cells[7].Value.ToString();
            txtCelularAcudiente.Text = dgv.Cells[12].Value.ToString();
            txtAseguradora.Text = dgv.Cells[13].Value.ToString();
            label10.Text = dgv.Cells[0].Value.ToString();
        }
        clValidaciones v = new clValidaciones();

        private void button2_Click(object sender, EventArgs e)
        {         
            
            
                clPacienteE objPacienteE = new clPacienteE();

                objPacienteE.Direccion = txtDireccion.Text;
                objPacienteE.Email = txtEmail.Text;              
                objPacienteE.Celular = txtCelular.Text;
                objPacienteE.CelularAcudiente = txtCelularAcudiente.Text;
                objPacienteE.Aseguradora = txtAseguradora.Text;
                objPacienteE.IdPaciente = int.Parse(label10.Text);

                
                int registros = objPacienteL.mtdActualizar(objPacienteE);
                if (registros == 0)
                {
                    MessageBox.Show("Error Al Actualizar");

                }
                else
                {
                    MessageBox.Show("Datos Actualizados");
                    DataTable lista = objPacienteL.mtdListar();
                    dgvListaPacientes.DataSource = lista;
                }
          
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            dgvListaPacientes.DataSource = objPacienteL.mtdListar(busqueda: txtNombre.Text);
        }

        string email = "";

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            email = txtEmail.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar el paciente?", "Eliminar Registros",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                clPacienteE objPacienteE = new clPacienteE();

                int registroEliminado = objPacienteL.mtdEliminar(objPacienteE.IdPaciente = int.Parse(label10.Text));
                if (registroEliminado == 1)
                {
                    MessageBox.Show("Paciente eliminado con éxito");
                    DataTable lista = objPacienteL.mtdListar();
                    dgvListaPacientes.DataSource = lista;
                }
                else
                {
                    MessageBox.Show("Error Al eliminar");
                }
            }

            
        }
    }
}