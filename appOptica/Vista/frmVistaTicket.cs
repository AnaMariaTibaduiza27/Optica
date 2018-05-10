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
    public partial class frmVistaTicket : Form
    {
        public frmVistaTicket()
        {
            InitializeComponent();
        }

        private void frmVistaTicket_Load(object sender, EventArgs e)
        {
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (frmFactura.nombreFactura == "")
            {
                string carpeta = ruta + "\\TicketsDeVenta\\" + frmListarFacturas.nombreTicket + ".pdf";
                PDFTicket.LoadFile(carpeta);
            }
            else
            {


                string carpeta = ruta + "\\TicketsDeVenta\\" + frmFactura.nombreFactura + ".pdf";
                PDFTicket.LoadFile(carpeta);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmFactura objFactura = new frmFactura();
            frmContenedor objContenedor = new frmContenedor();
            
            objFactura.MdiParent = this.MdiParent;
            objContenedor.Show();
            
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (frmFactura.nombreFactura == "")
            {
                string carpeta = ruta + "\\TicketsDeVenta\\" + frmListarFacturas.nombreTicket + ".pdf";
                PDFTicket.LoadFile(carpeta);
            }
            else
            {


                string carpeta = ruta + "\\TicketsDeVenta\\" + frmFactura.nombreFactura + ".pdf";
                PDFTicket.LoadFile(carpeta);
            }
        }

        private void PDFTicket_OnError(object sender, EventArgs e)
        {
           
        }
    }
}
