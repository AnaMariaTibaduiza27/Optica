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
    public partial class frmListarFacturas : Form
    {
        public frmListarFacturas()
        {
            InitializeComponent();
        }

        clFacturaL objFacturaL = new clFacturaL();

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
                clFacturaE objFacturaE = new clFacturaE();


                string año = (dtpFecha.Value.Year).ToString();

            string mes = dtpFecha.Value.Month.ToString();
            string dia = dtpFecha.Value.Day.ToString();
            string fecha;
            if (dtpFecha.Value.Month < 10 || dtpFecha.Value.Day < 10)
            {
                if (dtpFecha.Value.Month < 10)
                {
                    fecha = dia + "/0" + mes + "/" + año;
                }
                else if (dtpFecha.Value.Day < 10)
                {
                    fecha = "0" +dia +"/" + mes + "/" + año;
                }
                else
                {
                    fecha = dia + "/0" + mes + "/0" + año;
                }

            }
            else
            {
                fecha = dia + "/" + mes + "/" + año;
            }

                objFacturaE.Fecha = fecha;
                
                dgvFacturas.DataSource = objFacturaL.mtdListarFacturas(objFacturaE: objFacturaE);
            dgvPagos.DataSource = "";

        }

        private void cmbBuscarEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

            clFacturaE objFacturaE = new clFacturaE();
            objFacturaE.Estado = cmbBuscarEstado.SelectedItem.ToString();
            dgvFacturas.DataSource = objFacturaL.mtdListarFacturas(objFacturaE: objFacturaE);
            dgvPagos.DataSource = "";
        }

        private void frmListarFacturas_Load(object sender, EventArgs e)
        {

            dgvFacturas.DataSource = objFacturaL.mtdListarFacturas();
            
            

        }

        private void cmbBuscarPorMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mes;
            if (cmbBuscarPorMes.SelectedItem.ToString() == "Enero")
            {
                mes = "01";
            }
            else if (cmbBuscarPorMes.SelectedItem.ToString() == "Febrero")
            {
                mes = "02";
            }
            else if (cmbBuscarPorMes.SelectedItem.ToString() == "Marzo")
            {
                mes = "03";
            }
            else if (cmbBuscarPorMes.SelectedItem.ToString() == "Abril")
            {
                mes = "04";
            }
            else if (cmbBuscarPorMes.SelectedItem.ToString() == "Mayo")
            {
                mes = "05";
            }
            else if (cmbBuscarPorMes.SelectedItem.ToString() == "Junio")
            {
                mes = "06";
            }
            else if (cmbBuscarPorMes.SelectedItem.ToString() == "Julio")
            {
                mes = "07";
            }
            else if (cmbBuscarPorMes.SelectedItem.ToString() == "Agosto")
            {
                mes = "08";
            }
            else if (cmbBuscarPorMes.SelectedItem.ToString() == "Septiembre")
            {
                mes = "09";
            }
            else if (cmbBuscarPorMes.SelectedItem.ToString() == "Octubre")
            {
                mes = "10";
            }
            else if (cmbBuscarPorMes.SelectedItem.ToString() == "Noviembre")
            {
                mes = "11";
            }
            else
            {
                mes = "12";
            }

            dgvFacturas.DataSource = objFacturaL.mtdListarFacturas(mes:mes);
            dgvPagos.DataSource = "";
        }

        private void btnBuscarDoc_Click(object sender, EventArgs e)
        {
            clFacturaE objFacturaE = new clFacturaE();
            string Documento = txtDocumento.Text;
            dgvFacturas.DataSource = objFacturaL.mtdListarFacturas(Documento: Documento);
            dgvPagos.DataSource = "";
        }

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            dgvFacturas.DataSource = objFacturaL.mtdListarFacturas();
        }

        public static int IdFactura;
        public static string NoFactura;
        public static string TotalaPagar;
        DataGridViewRow dgv;
        clPagoL objPagoD = new clPagoL();
        string tipoPago;
        string longuitudFactura;
        public static string nombreTicket;
       
        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
       
            dgv = dgvFacturas.Rows[e.RowIndex];
            NoFactura = dgv.Cells[0].Value.ToString().Trim();
            TotalaPagar = dgv.Cells[4].Value.ToString().Trim();
            tipoPago = dgv.Cells[6].Value.ToString().Trim();

            if (dgv.Cells[5].Value.ToString().Trim() == "Paga")
            {
                btnPagar.Enabled = false;
                btnVerTicket.Enabled = true;

            }
            else
            {
                btnPagar.Enabled = true;
                btnVerTicket.Enabled = false;
            }
            
            if (tipoPago == "Crédito")
            {
                longuitudFactura = "00000000";
                int noFac = int.Parse(NoFactura); 
                nombreTicket = "CR" + (noFac.ToString(longuitudFactura));
            }
            else
            {
                longuitudFactura = "00000000";
                int noFac = int.Parse(NoFactura);
                nombreTicket = "CN" + (noFac.ToString(longuitudFactura));
            }
               
            
            IdFactura = objFacturaL.mtdObtenerIdFactura(NoFactura, dgv.Cells[5].Value.ToString(), tipoPago);


            lblIdFactura.Visible = false;
            lblIdFactura.Text = IdFactura.ToString();
            lblTotalAPagar.Text = TotalaPagar.ToString();

            dgvPagos.DataSource = objPagoD.mtdListarPagos(IdFactura, dgv.Cells[5].Value.ToString(),tipoPago);



        }

        private void btnVerPagos_Click(object sender, EventArgs e)
        {
            dgvPagos.DataSource = objPagoD.mtdListarPagos(IdFactura, dgv.Cells[5].Value.ToString(),tipoPago);
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {

            TotalaPagar = lblTotalAPagar.Text;
            IdFactura = int.Parse(lblIdFactura.Text);
            frmRegistrarPago objFrmRegistrarPago = new frmRegistrarPago();
            
            objFrmRegistrarPago.MdiParent = this.MdiParent;
            this.Hide();
            objFrmRegistrarPago.Show();
            

        }

        private void btnVerTicket_Click(object sender, EventArgs e)
        {
            frmVistaTicket objTicket = new frmVistaTicket();
           // objTicket.MdiParent = this.MdiParent;

           
            this.MdiParent.Hide();
            objTicket.Show();
        }
        clValidaciones v = new clValidaciones();
        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }
    }
} 
