using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appOptica.Vista
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }


        frmRegistrarPaciente objRegistrarPaciente = new frmRegistrarPaciente();
        
        

           

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            frmIniciarSesion objFrmIniciarSesion = new frmIniciarSesion();
            objFrmIniciarSesion.Show();
            this.Hide();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            frmRegistrarPaciente objFrmRegistrarPaciente = new frmRegistrarPaciente();
            objRegistrarPaciente.MdiParent = this.MdiParent;
            this.Hide();
            objRegistrarPaciente.Show();
            
            

        }

        private void pictureBox9_Click_1(object sender, EventArgs e)
        {
            frmListarPacientes objFrmListarPacientes = new frmListarPacientes();
            objFrmListarPacientes.MdiParent = this.MdiParent;
            this.Hide();
            objFrmListarPacientes.Show();
        }     

        

              

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmCita objCita = new frmCita();
            objCita.MdiParent = this.MdiParent;
            this.Hide();
            objCita.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmHistoriaClinica objHistoriaClinica = new frmHistoriaClinica();
            objHistoriaClinica.MdiParent = this.MdiParent;
            this.Hide();
            objHistoriaClinica.Show();


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmProducto objProducto = new frmProducto();
            objProducto.MdiParent = this.MdiParent;
            this.Hide();
            objProducto.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            frmListarProducto objListarProducto = new frmListarProducto();
            objListarProducto.MdiParent = this.MdiParent;
            this.Hide();
            objListarProducto.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            frmFactura objFactura = new frmFactura();
            objFactura.MdiParent = this.MdiParent;
            this.Hide();
            objFactura.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            frmCita objCita = new frmCita();
            objCita.MdiParent = this.MdiParent;
            this.Hide();
            objCita.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            frmHistoriaClinica objHistoriaClinica = new frmHistoriaClinica();
            objHistoriaClinica.MdiParent = this.MdiParent;
            this.Hide();
            objHistoriaClinica.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            frmRegistrarProveedor objHistoriaClinica = new frmRegistrarProveedor();
            objHistoriaClinica.MdiParent = this.MdiParent;
            this.Hide();
            objHistoriaClinica.Show();
        }

        private void pictureBox12_Click_1(object sender, EventArgs e)
        {
            frmListarFacturas objHistoriaClinica = new frmListarFacturas();
            objHistoriaClinica.MdiParent = this.MdiParent;
            this.Hide();
            objHistoriaClinica.Show();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            ListarProveedor objHistoriaClinica = new ListarProveedor();
            objHistoriaClinica.MdiParent = this.MdiParent;
            this.Hide();
            objHistoriaClinica.Show();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            frmListarFacturas objHistoriaClinica = new frmListarFacturas();
            objHistoriaClinica.MdiParent = this.MdiParent;
            this.Hide();
            objHistoriaClinica.Show();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            frmListarFacturas objHistoriaClinica = new frmListarFacturas();
            objHistoriaClinica.MdiParent = this.MdiParent;
            this.Hide();
            objHistoriaClinica.Show();
        }
    }
}
