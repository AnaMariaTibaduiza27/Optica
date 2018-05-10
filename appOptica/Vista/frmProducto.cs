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
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }
        clProductoE objProductoE = new clProductoE();
        clProductoL objProductoL = new clProductoL();
        clValidaciones V = new clValidaciones();

        private void frmProducto_Load(object sender, EventArgs e)
        {
            clProveedoresL objProveedoresL = new clProveedoresL();
            cmbProveedor.DataSource = objProveedoresL.mtdListar();
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "IdProveedor";

            clTipoProductoL objTipoProductoL = new clTipoProductoL();
            cmbTipoProducto.DataSource = objTipoProductoL.mtdListaTipoProducto();
            cmbTipoProducto.DisplayMember = "TipoProducto";
            cmbTipoProducto.ValueMember = "IdTipoProducto";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtReferencia.Text == "" || txtMarca.Text == "" || txtDescripcion.Text == "" || txtCantidad.Text == "" || txtValor.Text == "")
            {
                MessageBox.Show("Debe Ingresar Todos Los Campos Obligatorios");
            }
            else
            {
                objProductoE.Nombre = txtNombre.Text;
                objProductoE.Referecia = txtReferencia.Text;
                objProductoE.Marca = txtMarca.Text;
                objProductoE.Descripcion = txtDescripcion.Text;
                objProductoE.Cantidad = int.Parse(txtCantidad.Text);
                objProductoE.Valor = int.Parse(txtValor.Text);
                objProductoE.idProvedor = int.Parse(cmbProveedor.SelectedValue.ToString());
                objProductoE.IdTipoProducto = int.Parse(cmbTipoProducto.SelectedValue.ToString());

                int registro = objProductoL.mtdValidar(objProductoE);

                if (registro == -5)
                {
                    MessageBox.Show("Datos nulos");
                }
                else if (registro == 1)
                {
                    MessageBox.Show("Registo completo");

                    foreach (Control c in groupBox1.Controls)
                    {
                        if (c is TextBox)
                        {
                            ((TextBox)c).Clear();
                        }
                        else if (c is ComboBox)
                        {
                            ((ComboBox)c).SelectedIndex = 0;
                        }
                    }
                }
                else if (registro == -2)
                {
                    if (MessageBox.Show("El producto que desea ingresar ya existe, ¿Desea añadir esta cantidad a la ya existente?","Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        clProductoE objProductoE = new clProductoE();
                        objProductoE.Cantidad = int.Parse(txtCantidad.Text);
                        objProductoE.Referecia = txtReferencia.Text;

                        int cantidadAñadida = objProductoL.mtdRecibirSuma(objProductoE);
                        if (cantidadAñadida == 1)
                        {
                            MessageBox.Show("Cantidad añadida correctamente");

                            foreach (Control c in groupBox1.Controls)
                            {
                                if (c is TextBox)
                                {
                                    ((TextBox)c).Clear();
                                }
                                else if (c is ComboBox)
                                {
                                    ((ComboBox)c).SelectedIndex = 0;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error al añadir la cantidad");
                        }
                    
                    }
                }

            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.soloLetras(e);
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.soloLetras(e);
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.soloNumeros(e);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            V.soloNumeros(e);
        }
    }
}
