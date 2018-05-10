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
    public partial class ListarProveedor : Form
    {
        public ListarProveedor()
        {
            InitializeComponent();
        }
        clProveedoresE objProveedorE = new clProveedoresE();
        clProveedoresL objProveedorL = new clProveedoresL();
        private void VER_PROVEEDOR_Load(object sender, EventArgs e)
        {
            dgvListarProducto.DataSource = objProveedorL.mtdListar();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvListarProducto.DataSource = objProveedorL.mtdListar();

        }



        DataGridViewRow dgv;
        private void dgvListarProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv = dgvListarProducto.Rows[e.RowIndex];
            txtNombre1.Text = dgv.Cells[1].Value.ToString();
            txtDireccion1.Text = dgv.Cells[2].Value.ToString();
            TxtTelefono.Text = dgv.Cells[3].Value.ToString();
            TxtEmail.Text = dgv.Cells[5].Value.ToString();
            TxtNit.Text = dgv.Cells[4].Value.ToString();
            lblId.Text = dgv.Cells[0].Value.ToString();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            dgvListarProducto.DataSource = objProveedorL.mtdListar(busqueda: txtNombre.Text.Trim());
        }

        private void btnVerTodo_Click(object sender, EventArgs e)
        {
            dgvListarProducto.DataSource = objProveedorL.mtdListar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgvListarProducto.DataSource = objProveedorL.mtdListar(busqueda: textBox1.Text.Trim());
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            clProveedoresE objProveedor = new clProveedoresE();
            objProveedor.Nombre = txtNombre1.Text;
            objProveedor.Direccion = txtDireccion1.Text;
            objProveedor.Telefono = TxtTelefono.Text;
            objProveedor.NIT = TxtNit.Text;
            objProveedor.Email = TxtEmail.Text;
            objProveedor.IdProveedor = int.Parse(lblId.Text);

            int regisros = objProveedorL.mtdAcualizar(objProveedor);
            if (regisros == 0)
            {
                MessageBox.Show("No se pueden actualizar los datos");
            }
            else
            {
                MessageBox.Show("Datos actualizados correctamente");
                List<clProveedoresE> lista = objProveedorL.mtdListar();
                dgvListarProducto.DataSource = lista;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clProveedoresE objProveedor = new clProveedoresE();
            objProveedor.Nombre = txtNombre1.Text;
            objProveedor.Direccion = txtDireccion1.Text;
            objProveedor.Telefono = TxtTelefono.Text;
            objProveedor.NIT = TxtNit.Text;
            objProveedor.Email = TxtEmail.Text;
            objProveedor.IdProveedor = int.Parse(lblId.Text);

            int regisros = objProveedorL.mtdEliminar(objProveedor);
            if (regisros == 0)
            {
                MessageBox.Show("No se pueden Eliminar  los datos");
            }
            else
            {
                MessageBox.Show("Datos Eliminados correctamente");
                List<clProveedoresE> lista = objProveedorL.mtdListar();
                dgvListarProducto.DataSource = lista;
            }
        }
    }
}

