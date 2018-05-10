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
    public partial class frmContenedor : Form
    {

        public frmContenedor()
        {
            InitializeComponent();
            timer1.Enabled = true;


        }
        frmPrincipal objFrmPrincipal = new frmPrincipal();
        frmCita objCita = new frmCita();
        frmFactura objFactura = new frmFactura();
        frmListarPacientes objListarPaciente = new frmListarPacientes();
        frmListarProducto objListarProducto = new frmListarProducto();
        ListarProveedor objListarProveedor = new ListarProveedor();
        frmPrincipal objPrincipal = new frmPrincipal();
        frmProducto objProducto = new frmProducto();
        frmRegistrarPaciente objRegistrarPaciente = new frmRegistrarPaciente();
        frmRegistrarProveedor objRegistrarProveedor = new frmRegistrarProveedor();
        frmVistaTicket objVistaTicket = new frmVistaTicket();
        frmHistoriaClinica objHistoriaClinica = new frmHistoriaClinica();



        private void frmContenedor_Load(object sender, EventArgs e)
        {


            objFrmPrincipal.MdiParent = this;
            objFrmPrincipal.Show();
            // colorDeFondo();
            lblEspacion.Text = "                              " +
                "                                             " +
                "                                             " +
                "                                             " +
                "Usuario: " + frmIniciarSesion.nombre;



        }



        public void colorDeFondo()
        {

            foreach (Control control in this.Controls)
            {

                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    client.BackColor = Color.SlateGray;

                    break;
                }

            }


        }

        private void pictureBox12_Click_1(object sender, EventArgs e)
        {
            frmIniciarSesion objFrmIniciarSesion = new frmIniciarSesion();

            objFrmIniciarSesion.Show();
            this.Hide();
        }

        

        private void citaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario == objCita)
                {
                    formulario.Show();
                }
                else
                {
                    formulario.Hide();
                }

            }

            objCita.MdiParent = this;
            objCita.Show();
        }

        private void pacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //objRegistrarPaciente.MdiParent = this;
            //objRegistrarPaciente.Show();


            ////objRegistrarPaciente.Show();
            //objCita.Hide();
            //objFactura.Hide();
            //objListarPaciente.Hide();
            //objListarProducto.Hide();
            //objPrincipal.Hide();
            //objProducto.Hide();
            ////objRegistrarPaciente.Hide();
            //objRegistrarProveedor.Hide();
            //objVistaTicket.Hide();


            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario == objRegistrarPaciente)
                {
                    formulario.Show();
                }
                else
                {
                    formulario.Hide();
                }

            }

            objRegistrarPaciente.MdiParent = this;
            objRegistrarPaciente.Show();


        }



        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario == objProducto)
                {
                    formulario.Show();
                }
                else
                {
                    formulario.Hide();
                }

            }

            objProducto.MdiParent = this;
            objProducto.Show();


        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario == objListarProducto)
                {
                    formulario.Show();
                }
                else
                {
                    formulario.Hide();
                }

            }

            objListarProducto.MdiParent = this;
            objListarProducto.Show();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario == objRegistrarProveedor)
                {
                    formulario.Show();
                }
                else
                {
                    formulario.Hide();
                }

            }

            objRegistrarProveedor.MdiParent = this;
            objRegistrarProveedor.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario == objListarProveedor)
                {
                    formulario.Show();
                }
                else
                {
                    formulario.Hide();
                }

            }

            objListarProveedor.MdiParent = this;
            objListarProveedor.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tslFechaHora.Text = DateTime.Now.ToString();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void mtdCerrarFormularios()
        {


            objCita.Hide();
            objFactura.Hide();
            objListarPaciente.Hide();
            objListarProducto.Hide();
            objPrincipal.Hide();
            objProducto.Hide();
            objRegistrarPaciente.Hide();
            objRegistrarProveedor.Hide();
            objVistaTicket.Hide();

        }

        private void historiaClinicaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario == objHistoriaClinica)
                {
                    formulario.Show();
                }
                else
                {
                    formulario.Hide();
                }

            }

            objHistoriaClinica.MdiParent = this;
            objHistoriaClinica.Show();
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario == objFactura)
                {
                    formulario.Show();
                }
                else
                {
                    formulario.Hide();
                }

            }

            objFactura.MdiParent = this;
            objFactura.Show();
        }

        private void principalToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario == objPrincipal)
                {
                    formulario.Show();
                }
                else
                {
                    formulario.Hide();
                }

            }

            objPrincipal.MdiParent = this;
            objPrincipal.Show();
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario == objListarPaciente)
                {
                    formulario.Show();
                }
                else
                {
                    formulario.Hide();
                }

            }

            objListarPaciente.MdiParent = this;
            objListarPaciente.Show();
        }

        private void citasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario == objCita)
                {
                    formulario.Show();
                }
                else
                {
                    formulario.Hide();
                }

            }

            objCita.MdiParent = this;
            objCita.Show();
        }

        private void historiasClínicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario == objHistoriaClinica)
                {
                    formulario.Show();
                }
                else
                {
                    formulario.Hide();
                }

            }

            objHistoriaClinica.MdiParent = this;
            objHistoriaClinica.Show();
        }

        private void pacienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario == objListarPaciente)
                {
                    formulario.Show();
                }
                else
                {
                    formulario.Hide();
                }

            }

            objListarPaciente.MdiParent = this;
            objListarPaciente.Show();
        }

        private void historiaClinicaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario == objHistoriaClinica)
                {
                    formulario.Show();
                }
                else
                {
                    formulario.Hide();
                }

            }

            objHistoriaClinica.MdiParent = this;
            objHistoriaClinica.Show();
        }

        private void productoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario == objListarProducto)
                {
                    formulario.Show();
                }
                else
                {
                    formulario.Hide();
                }

            }

            objListarProducto.MdiParent = this;
            objListarProducto.Show();
        }

        private void proveedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario == objListarProveedor)
                {
                    formulario.Show();
                }
                else
                {
                    formulario.Hide();
                }

            }

            objListarProveedor.MdiParent = this;
            objListarProveedor.Show();
        }

        private void citaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario == objCita)
                {
                    formulario.Show();
                }
                else
                {
                    formulario.Hide();
                }

            }

            objCita.MdiParent = this;
            objCita.Show();
        }

        private void reporteProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporte objReporte = new frmReporte();
            foreach (Form formulario in this.MdiChildren)
            {
                if (formulario == objReporte)
                {
                    formulario.Show();
                }
                else
                {
                    formulario.Hide();
                }

                

                objReporte.MdiParent = this;
                objReporte.Show();
            }
        }
    }
}
