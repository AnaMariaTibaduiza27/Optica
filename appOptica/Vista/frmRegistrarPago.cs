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
    public partial class frmRegistrarPago : Form
    {
        public frmRegistrarPago()
        {
            InitializeComponent();
        }

        clFacturaL objFacturaL = new clFacturaL();
        clPagoL objPagoL = new clPagoL();
        int IdFactura;
        double saldo;
        double TotalPagado;
        double Total;
        private void frmRegistrarPago_Load(object sender, EventArgs e)
        {
            lblTotalAPagar.Text = frmListarFacturas.TotalaPagar;
            IdFactura = frmListarFacturas.IdFactura;
            label1.Text = frmListarFacturas.NoFactura;
            lblTotalPagado.Text = objPagoL.mtdObtenerSaldoPorPagar(IdFactura);
            Total = Math.Truncate(Double.Parse(lblTotalAPagar.Text));
             TotalPagado = Math.Truncate(Double.Parse(lblTotalPagado.Text));
             saldo = Total - TotalPagado;
            lblSaldo.Text = saldo.ToString();

        }

        private void btnGuardarCr_Click(object sender, EventArgs e)
        {
            

           
            if (txtAbono.Text == "" || txtEfectivo.Text == "" )
            {
                MessageBox.Show("Por favor complete todos los campos");
            }
            else
            {
                if (Double.Parse(txtEfectivo.Text)<Double.Parse(txtAbono.Text))
                {
                    MessageBox.Show("El valor en efectivo no puede ser menor que el abono");
                }
                else
                {
                    double abono = Double.Parse(txtAbono.Text);
                    if (abono > saldo)
                    {
                        MessageBox.Show("El Abono no puede ser mayor al saldo pendiente, por favor verifique el valor ingresado");
                    }
                    else
                    {


                        clPagoE objPagoE = new clPagoE();
                        objPagoE.Fecha = DateTime.Now;
                        objPagoE.IdFactura = IdFactura;
                        objPagoE.ValorPago = Math.Truncate(Double.Parse(txtAbono.Text));
                        if (objPagoE.ValorPago > Double.Parse(lblSaldo.Text))
                        {
                            objPagoE.ValorPago = Double.Parse(lblSaldo.Text);
                        }
                        int registro = objPagoL.mtdRegistrarPago(objPagoE);

                        if (registro == 1)
                        {
                            double cambio = Double.Parse(txtEfectivo.Text) - Double.Parse(txtAbono.Text);
                            MessageBox.Show("Pago registrado con éxito \n Cambio:$" + cambio);
                            double Total = Double.Parse(lblTotalAPagar.Text);
                            TotalPagado = Double.Parse(objPagoL.mtdObtenerSaldoPorPagar(IdFactura));
                            if (TotalPagado >= Total)
                            {
                                objFacturaL.mtdActualizarEstado(objPagoE.IdFactura);
                            }
                            this.Hide();
                            frmListarFacturas objListarFacturas = new frmListarFacturas();
                            objListarFacturas.Show();

                        }
                        else
                        {
                            MessageBox.Show("Error al registrar ");
                        }
                    }
                }
                
            }

        }
        clValidaciones v = new clValidaciones();
        private void txtAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }
    }
}
