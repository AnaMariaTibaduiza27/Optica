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
    public partial class frmReporte : Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bDOpticaDataSet.Producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter.mtdVerTodos(this.bDOpticaDataSet.Producto);

            this.reportViewer1.RefreshReport();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.productoTableAdapter.mtdVerParametros(this.bDOpticaDataSet.Producto, txtProveedor.Text);

            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.productoTableAdapter.mtdVerTodos(this.bDOpticaDataSet.Producto);

            this.reportViewer1.RefreshReport();
        }
    }
}
