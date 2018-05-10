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
    public partial class frmListarProducto : Form
    {
        public frmListarProducto()
        {
            InitializeComponent();
        }
        clBDSql objConexion = new clBDSql();
        clProductoD objProductoD = new clProductoD();
        clProductoE objProductoE = new clProductoE();
        clProductoL objProductoL = new clProductoL();

        private void frmListarProducto_Load(object sender, EventArgs e)
        {
            dgvListarProducto.DataSource = objProductoL.mtdListar();
        }

        DataGridViewRow dgv;
        private void dgvListarProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv = dgvListarProducto.Rows[e.RowIndex];
            txtNombre1.Text = dgv.Cells[1].Value.ToString();
            txtReferencia1.Text = dgv.Cells[2].Value.ToString();
            txtCantidad.Text = dgv.Cells[3].Value.ToString();
            txtMarca.Text = dgv.Cells[4].Value.ToString();
            txtDescripcion.Text = dgv.Cells[5].Value.ToString();
            txtValor.Text = dgv.Cells[6].Value.ToString();
           
            lblId.Text = dgv.Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvListarProducto.DataSource = objProductoL.mtdListar();

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            dgvListarProducto.DataSource = objProductoL.mtdListar(busqueda: txtNombre.Text.Trim());
        }

        private void txtReferencia_TextChanged(object sender, EventArgs e)
        {
            dgvListarProducto.DataSource = objProductoL.mtdListar(busqueda: txtReferencia.Text.Trim());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clProductoE objProducto = new clProductoE();
            objProducto.Nombre = txtNombre1.Text;
            objProducto.Referecia = txtReferencia1.Text;
            objProducto.Cantidad = int.Parse(txtCantidad.Text);
            objProducto.Marca = txtMarca.Text;
            objProducto.Descripcion = txtDescripcion.Text;
            objProducto.Valor = int.Parse(txtValor.Text);
            objProducto.IdProducto = int.Parse(lblId.Text);

            int registros = objProductoL.mtdActualizar(objProducto);
            if (registros == 0 )
            {
                MessageBox.Show("Error al Actualizar Datos");
            }
            else
            {
                MessageBox.Show("Datos actualizados correctamente");
                List<clProductoE> Lista = objProductoL.mtdListar();
                dgvListarProducto.DataSource = Lista;
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            clProductoE objProducto = new clProductoE();

            objProducto.Nombre = txtNombre1.Text;
            objProducto.Referecia = txtReferencia1.Text;
            objProducto.Cantidad = int.Parse(txtCantidad.Text);
            objProducto.Marca = txtMarca.Text;
            objProducto.Descripcion = txtDescripcion.Text;
            objProducto.Valor = int.Parse(txtValor.Text);
            objProducto.IdProducto = int.Parse(lblId.Text);

            int registros = objProductoL.mtdEliminar(objProducto);
            
            if (registros == 0)
            {
                MessageBox.Show("Error al Eliminar Datos");
            }
            else
            {
                MessageBox.Show("Datos Eliminados correctamente");
                List<clProductoE> Lista = objProductoL.mtdListar();
                dgvListarProducto.DataSource = Lista;
            }
        }
    }
}
