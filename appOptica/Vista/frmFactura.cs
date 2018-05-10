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
using iTextSharp.text;

using iTextSharp.text.pdf;

using System.IO;


namespace appOptica.Vista
{
    public partial class frmFactura : Form
    {
        public frmFactura()
        {
            InitializeComponent();
        }
        string longuitudFactura;
        public static String nombreFactura="";
        public static int NoFactura = 0;
        public static string Totall;
        public static int IdF;
        clValidaciones c = new clValidaciones();

        private void frmFactura_Load(object sender, EventArgs e)
        {

            gbPagoDeContado.Visible = false;
            dgvCitas.Visible = false;
            dgvProductos.Visible = false;
            grBCita.Visible = false;
            grBProducto.Visible = false;


            txtBusqueda.AutoCompleteCustomSource = mtdCargarDatos();
            txtBusqueda.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBusqueda.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtNombreProducto.AutoCompleteCustomSource = mtdCargarDatosProducto();
            txtNombreProducto.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtNombreProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtFecha.Text = DateTime.Now.ToShortDateString();
            txtVendedor.Text = frmIniciarSesion.nombre;
        

        }
        clFacturaL objFacturaL = new clFacturaL();
        public AutoCompleteStringCollection mtdCargarDatos()
        {
            AutoCompleteStringCollection documentos = new AutoCompleteStringCollection();

            List<clPacienteE> listaDocumentos = new List<clPacienteE>();


            listaDocumentos = objFacturaL.mtdCargarDatos();

            foreach (clPacienteE item in listaDocumentos)
            {
                documentos.Add(item.Documento.Trim());
            }

            return documentos;
        }

        public AutoCompleteStringCollection mtdCargarDatosProducto()
        {
            AutoCompleteStringCollection productos = new AutoCompleteStringCollection();

            List<clProductoE> listaProductos = new List<clProductoE>();


            listaProductos = objFacturaL.mtdCargarDatosProductos();

            foreach (clProductoE item in listaProductos)
            {
                productos.Add(item.Nombre.Trim());
            }

            return productos;
        }
        int idPaciente;

        private void button1_Click(object sender, EventArgs e)
        {
            clPacienteE objPacienteE = new clPacienteE();
            clPacienteE objPaciente = new clPacienteE();
            clCitaL objCitaL = new clCitaL();

            if (txtBusqueda.Text == "")
            {
                MessageBox.Show("Debe ingresar un número de documento");
            }
            else
            {
                objPacienteE.Documento = txtBusqueda.Text;

                objPaciente = objFacturaL.mtdDatosPaciente(objPacienteE);

                idPaciente = objPaciente.IdPaciente;
                txtDocumento.Text = objPaciente.Documento.Trim();
                txtNombres.Text = objPaciente.Nombres.Trim() + " " + objPaciente.Apellidos.Trim();
                txtTelefono.Text = objPaciente.Celular.Trim();
                txtDireccion.Text = objPaciente.Direccion.Trim();

                cmbCitasPaciente.DataSource = objCitaL.mtdListaCitasPorPaciente(txtBusqueda.Text);
                cmbCitasPaciente.DisplayMember = "Fecha";
                cmbCitasPaciente.ValueMember = "Fecha";
            }



        }

        private void cmbFormaDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormaDePago.SelectedIndex == 0)
            {
                longuitudFactura = "00000000";
                NoFactura = objFacturaL.mtdObtenerNoFactura(0) + 1;
                txtNoFactura.Text = "CR"+(NoFactura.ToString(longuitudFactura));
                gbPagoDeContado.Visible = false;
            }
            else
            {
                longuitudFactura = "00000000";
                NoFactura = objFacturaL.mtdObtenerNoFactura1(1) + 1;
                txtNoFactura.Text = "CN"+(NoFactura.ToString(longuitudFactura));
                gbPagoDeContado.Visible = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void rbCita_CheckedChanged(object sender, EventArgs e)
        {
            dgvCitas.Visible = true;
            grBCita.Visible = true;
            dgvProductos.Visible = false;
            grBProducto.Visible = false;
            cmbFormaDePago.Text = "Contado";
            cmbFormaDePago.Enabled = false;
        }

        private void rbAccesorios_CheckedChanged(object sender, EventArgs e)
        {
            dgvProductos.Visible = true;
            grBProducto.Visible = true;
            dgvCitas.Visible = false;
            grBCita.Visible = false;
            cmbFormaDePago.Enabled = true;

        }
        int idCita ;
        int citas;
        private void btnAgregarCita_Click(object sender, EventArgs e)
        {
            if (cmbCitasPaciente.SelectedItem == null || cmbCitaPorFecha.SelectedItem == null )
            {
                MessageBox.Show("Por favor seleccione alguna opción");
            }
            else
            {
                clCitaL objCitaL = new clCitaL();
                clCitaE objCitaE = new clCitaE();

                objCitaE = objCitaL.mtdValorCita(cmbCitasPaciente.SelectedValue.ToString(), cmbCitaPorFecha.SelectedValue.ToString());
                dgvCitas.Rows[0].Cells[0].Value = cmbCitasPaciente.SelectedValue.ToString();
                dgvCitas.Rows[0].Cells[1].Value = cmbCitaPorFecha.SelectedValue.ToString();
                dgvCitas.Rows[0].Cells[3].Value = objCitaE.Valor;
                idCita = objCitaE.IdCita;
                if (objCitaE.IdTipoCita == 1)
                {
                    dgvCitas.Rows[0].Cells[2].Value = "Valoración";
                }
                else
                {
                    dgvCitas.Rows[0].Cells[2].Value = "Tratamiento";
                }

                txtSubTotal.Text = objCitaE.Valor.ToString();

                float IVA = (objCitaE.Valor * 19 / 100);
                txtIVA.Text = IVA.ToString();
                txtTotal.Text = (objCitaE.Valor + IVA).ToString();
                txtDescuento.Text = "0";
                citas++;
            }
           



        }

        private void cmbCitasPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clCitaL objCitaL = new clCitaL();
                cmbCitaPorFecha.DataSource = objCitaL.mtdListaCitasPorPaciente(txtBusqueda.Text, cmbCitasPaciente.SelectedValue.ToString());
                cmbCitaPorFecha.DisplayMember = "Hora";
                cmbCitaPorFecha.ValueMember = "Hora";
            }
            catch (Exception)
            {


            }

        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            frmFactura obj = new frmFactura();
            obj.Show();
            this.Hide();


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            mtdLimpiarFormulario();
        }

        double suma;
        int productos=0;
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (txtNombreProducto.Text == "" || txtCantidad.Text == "")
            {
                MessageBox.Show("Campos Obligatorios");

            }
            else
            {
                List<clProductoE> lista = new List<clProductoE>();
                clProductoE objProductoE = new clProductoE();
                clProductoL objProductoL = new clProductoL();

                objProductoE.Nombre = txtNombreProducto.Text;
                int productoExistente = objProductoL.validarProductoFactura(objProductoE);
                if (productoExistente == 1)
                {
                    lista = objProductoL.mtdListar(objProductoE: objProductoE);
                    objProductoE.Cantidad = lista[0].Cantidad;
                    objProductoE.Descripcion = lista[0].Descripcion.Trim();
                    objProductoE.Valor = lista[0].Valor;
                    objProductoE.IdProducto = lista[0].IdProducto;

                    double cantidadAComprar = float.Parse(txtCantidad.Text);

                    if (cantidadAComprar > objProductoE.Cantidad)
                    {
                        MessageBox.Show("La cantidad que desea comprar es mayor a la cantidad existente");
                    }
                    else
                    {

                        double valorTotal = cantidadAComprar * objProductoE.Valor;

                        dgvProductos.Rows.Insert((dgvProductos.Rows.Count - 1), objProductoE.IdProducto, objProductoE.Nombre, objProductoE.Descripcion, txtCantidad.Text, objProductoE.Valor, valorTotal);

                        txtNombreProducto.Text = "";
                        txtCantidad.Text = "";
                        suma += valorTotal;
                        txtSubTotal.Text = suma.ToString();
                        txtIVA.Text = (suma * 19 / 100).ToString();


                        txtTotal.Text = ((suma + (suma * 19 / 100)) - double.Parse(txtDescuento.Text)).ToString();

                        productos++;
                    }
                }
                else
                {
                    MessageBox.Show("El Producto ingresado no existe");
                }

                

                
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtDescuentoProductos.Text == "")
            {
                MessageBox.Show("Primero Ingrese un valor");
            }
            else
            {
                if (dgvCitas.Visible ==true )
                {
                    double valor = double.Parse(dgvCitas.Rows[0].Cells[3].Value.ToString());
                    double total = double.Parse(txtTotal.Text);
                    int desc = int.Parse(txtDescuentoProductos.Text);
                    double descuento = total * desc / 100;
                    txtDescuento.Text = descuento.ToString();
                    double totalDes = total - descuento;
                    txtTotalConDes.Text = totalDes.ToString();
                }
                else
                {
                    txtDescuento.Text = ((suma + (suma * 19 / 100)) * double.Parse(txtDescuentoProductos.Text) / 100).ToString();
                    txtTotalConDes.Text = ((suma + (suma * 19 / 100)) - double.Parse(txtDescuento.Text)).ToString();
                }
                
            }
           
        }

        int btGuardar;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            

            if (rbCita.Checked == true && txtNombres.Text == "")
            {
                MessageBox.Show("Para Guardar Una Factura De Cita Es Necesario Un Paciente");
            }
            else
            {
                if ((rbAccesorios.Checked == true && productos ==0)||(rbCita.Checked == true && citas == 0)||cmbFormaDePago.SelectedItem == null || (rbCita.Checked == false && rbAccesorios.Checked == false) ||(cmbFormaDePago.SelectedItem.ToString()=="Contado" && txtEfectivo.Text == ""))
                {
                    MessageBox.Show("Complete Todos Los Campos, Por Favor.");
                }
                else
                {
                    clFacturaE objFacturaE = new clFacturaE();
                    objFacturaE.NoFactura = NoFactura;

                    

                    
                    objFacturaE.Fecha = txtFecha.Text;
                    objFacturaE.SubTotal = Math.Truncate(double.Parse(txtSubTotal.Text));
                    objFacturaE.IVA = Math.Truncate(double.Parse(txtIVA.Text));
                    objFacturaE.Total = Math.Truncate(double.Parse(txtTotal.Text));
                    Totall = txtTotal.Text;
                    objFacturaE.Descuento = Math.Truncate(double.Parse(txtDescuento.Text));
                    objFacturaE.TipoPago = cmbFormaDePago.SelectedItem.ToString();
                    if (objFacturaE.TipoPago == "Contado")
                    {
                        
                        objFacturaE.Estado = "Paga";
                    }
                    else
                    {
                        objFacturaE.Estado = "Pendiente";
                    }
                    
                    objFacturaE.IdUsuario = frmIniciarSesion.IdUsuario;
                    objFacturaE.IdPaciente = idPaciente;

                    int registros = objFacturaL.mtdRegistrarFactura(objFacturaE);
                    int registroDetalle = 0;
                    int totalRegistros = 0;
                    if (registros == 1)
                    {
                        clDetallesL objDetallesL = new clDetallesL();
                        objFacturaE = objDetallesL.mtdObtenerIdFactura(objFacturaE);
                        IdF = objFacturaE.IdFactura;
                        if (cmbFormaDePago.Text == "Contado")
                        {
                            clPagoL objPagoL = new clPagoL();
                            clPagoE objPagoE = new clPagoE();
                            objPagoE.ValorPago = Math.Truncate(Double.Parse(txtTotal.Text));
                            objPagoE.Fecha = Convert.ToDateTime(txtFecha.Text);
                            objPagoE.IdFactura = objFacturaE.IdFactura;

                            int registro = objPagoL.mtdRegistrarPago(objPagoE);
                            
                        }
                        
                        if (rbCita.Checked == true)
                        {

                            clDetallesE objDetallesE = new clDetallesE();
                            objDetallesE.IdFactura = objFacturaE.IdFactura;
                            objDetallesE.IdCita = idCita;
                            objDetallesE.Valor = Math.Truncate(double.Parse(dgvCitas.Rows[0].Cells[3].Value.ToString()));
                            registroDetalle = objDetallesL.mtdRegistrarDetalles(objDetallesE,1);
                            if (registroDetalle == 1)
                            {
                                totalRegistros++;
                            }
                            else if (registroDetalle == 5)
                            {
                                MessageBox.Show("La cita que desea cancelar ya está paga");
                                objFacturaL.mtdEliminarFactura(objFacturaE);

                            }

                            if (totalRegistros != dgvCitas.Rows.Count)
                            {
                                MessageBox.Show("Error Al Guardar");
                                objFacturaL.mtdEliminarFactura(objFacturaE);


                            }
                            else
                            {
                                efectivo = double.Parse(txtEfectivo.Text);
                                total = double.Parse(txtTotal.Text);

                                cambio = efectivo - total;
                                btGuardar = 0;
                                MessageBox.Show("Factura Guardada con éxito \n Cambio: "+cambio);

                                btGuardar++;
                                if (cmbFormaDePago.Text == "Contado")
                                {
                                    mtdTicket();
                                    frmVistaTicket objTicket = new frmVistaTicket();
                                    //objTicket.MdiParent = this.MdiParent;
                                    objTicket.Show();
                                    this.Hide();
                                    this.MdiParent.Hide();
                                    
                                }
                                else
                                {
                                    mtdTicket();
                                    frmListarFacturas objListarFacturas = new frmListarFacturas();
                                    objListarFacturas.MdiParent = this.MdiParent;
                                    objListarFacturas.Show();

                                    this.Hide();
                                 
                                }

                                
                                
                                

                            }
                        }
                        else
                        {
                            for (int i = 0; i < productos; i++)
                            {
                                clDetallesE objDetallesE = new clDetallesE();
                                objDetallesE.IdProducto = int.Parse(dgvProductos.Rows[i].Cells[0].Value.ToString());
                                objDetallesE.IdFactura = objFacturaE.IdFactura;
                                objDetallesE.Cantidad = int.Parse(dgvProductos.Rows[i].Cells[3].Value.ToString());
                                objDetallesE.Valor = Math.Truncate(double.Parse(dgvProductos.Rows[i].Cells[5].Value.ToString()));
                                registroDetalle = objDetallesL.mtdRegistrarDetalles(objDetallesE,2);
                                if (registroDetalle == 1)
                                {
                                    totalRegistros++;
                                }


                            }
                            if (totalRegistros != productos)
                            {
                                MessageBox.Show("Error Al Guardar");
                                objFacturaL.mtdEliminarFactura(objFacturaE);
                            }
                            else
                            {
                                
                                for (int i = 0; i < productos; i++)
                                {
                                    clProductoL objProductoL = new clProductoL();
                                    int cantidad = int.Parse(dgvProductos.Rows[i].Cells[3].Value.ToString());
                                    int IdProducto = int.Parse(dgvProductos.Rows[i].Cells[0].Value.ToString());
                                    objProductoL.mtdActualizar(cantidad: cantidad, IdProducto: IdProducto);


                                }
                                btGuardar++;
                                if (cmbFormaDePago.Text == "Contado")
                                {

                                    efectivo = double.Parse(txtEfectivo.Text);
                                    total = double.Parse(txtTotal.Text);

                                    cambio = efectivo - total;
                                    MessageBox.Show("La Factura se ha Guardado con éxito \n Cambio: " + cambio);
                                    mtdTicket();
                                    frmVistaTicket objTicket = new frmVistaTicket();
                                    //objTicket.MdiParent = this.MdiParent;

                                    this.Hide();
                                    this.MdiParent.Hide();
                                    objTicket.Show();

                                }
                                else
                                {
                                    MessageBox.Show("La Factura se ha Guardado con éxito");

                                  
                                        mtdTicket();
                                        frmListarFacturas objListarFacturas = new frmListarFacturas();
                                        objListarFacturas.MdiParent = this.MdiParent;
                                        objListarFacturas.Show();

                                        this.Hide();

                                    
                                }
                                
                                
                            }
                        }



                    }
                    else
                    {
                        MessageBox.Show("Error Al Guardar");
                    }
                }
               
            }
           


            

        }

        


        public void mtdTicket()
        {
            if (btGuardar == 0)
            {
                MessageBox.Show("Asegurese de guardar la factura antes de generar la factura");
            }
            else if (btGuardar == 1)
            {
                //string tipo = txtNoFactura.Text.Substring(0,2);
                //string resto = txtNoFactura.Text.Substring(3,8);
                string nombre = txtNoFactura.Text;
                //Creamos una instancia d ela clase CrearTicket
                clCrearTicketDeVenta ticket = new clCrearTicketDeVenta(nombre);
                //Ya podemos usar todos sus metodos

                //Ya podemos usar todos sus metodos
                //ticket.AbreCajon();//Para abrir el cajon de dinero.

                //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

                //Datos de la cabecera del Ticket.
                if (dgvCitas.Visible == true)
                {
                    ticket.TextoCentro("OPTISOF");
                    ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
                    ticket.TextoIzquierda("DIREC: SOGAMOSO");
                    ticket.TextoIzquierda("TELEF: 4530000");
                    ticket.TextoIzquierda("R.F.C: XXXXXXXXX-XX");
                    ticket.TextoIzquierda("EMAIL: optisof@gmail.com");//Es el mio por si me quieren contactar ...
                    ticket.TextoIzquierda("");
                    ticket.TextoExtremos("Caja # 1", "Ticket # " + txtNoFactura.Text);
                    ticket.lineasAsteriscos();

                    //Sub cabecera.
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierda("ATENDIÓ: " + txtVendedor.Text);
                    ticket.TextoIzquierda("CLIENTE: PUBLICO EN GENERAL");
                    ticket.TextoIzquierda("");
                    ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
                    ticket.lineasAsteriscos();
                    ticket.TextoCentro("DATOS DE LA CITA");
                    ticket.TextoIzquierda("PACIENTE: " + txtNombres.Text);

                    string fecha = dgvCitas.Rows[0].Cells[0].Value.ToString();
                    string fechaA = fecha.Remove(11);
                    ticket.TextoIzquierda("FECHA :" + fechaA);
                    ticket.TextoIzquierda("HORA  :" + dgvCitas.Rows[0].Cells[1].Value.ToString());
                    ticket.TextoIzquierda("TIPO  :" + dgvCitas.Rows[0].Cells[2].Value.ToString());
                    ticket.TextoIzquierda("VALOR :" + dgvCitas.Rows[0].Cells[3].Value.ToString());

                    ticket.AgregarTotales("         SUBTOTAL......$", decimal.Parse(txtSubTotal.Text));
                    ticket.AgregarTotales("         IVA...........$", decimal.Parse(txtIVA.Text));//La M indica que es un decimal en C#
                    ticket.AgregarTotales("         DESCUENTO.....$", decimal.Parse(txtDescuento.Text));
                    ticket.AgregarTotales("         TOTAL.........$", decimal.Parse(txtTotal.Text));
                    ticket.TextoIzquierda("");
                    if (cmbFormaDePago.SelectedIndex == 1)
                    {
                        ticket.AgregarTotales("         EFECTIVO......$", decimal.Parse(txtEfectivo.Text));
                        ticket.AgregarTotales("         CAMBIO........$", decimal.Parse(cambio.ToString()));

                    }


                    //Texto final del Ticket.
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: " + productos);
                    ticket.TextoIzquierda("");
                    ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");

                    ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera

                }
                else
                {
                    ticket.TextoCentro("OPTISOF");
                    ticket.TextoIzquierda("EXPEDIDO EN: LOCAL PRINCIPAL");
                    ticket.TextoIzquierda("DIREC: SOGAMOSO");
                    ticket.TextoIzquierda("TELEF: 4530000");
                    ticket.TextoIzquierda("R.F.C: XXXXXXXXX-XX");
                    ticket.TextoIzquierda("EMAIL: optisof@gmail.com");//Es el mio por si me quieren contactar ...
                    ticket.TextoIzquierda("");
                    ticket.TextoExtremos("Caja # 1", "Ticket # " + txtNoFactura.Text);
                    ticket.lineasAsteriscos();

                    //Sub cabecera.
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierda("ATENDIÓ: " + txtVendedor.Text);
                    ticket.TextoIzquierda("CLIENTE: PUBLICO EN GENERAL");
                    ticket.TextoIzquierda("");
                    ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
                    ticket.lineasAsteriscos();

                    //Articulos a vender.
                    ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
                    ticket.lineasAsteriscos();
                    //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
                    for (int i = 0; i < productos; i++)//dgvLista es el nombre del datagridview
                    {
                        ticket.AgregaArticulo(dgvProductos.Rows[i].Cells[2].Value.ToString(), int.Parse(dgvProductos.Rows[i].Cells[3].Value.ToString()),
                        decimal.Parse(dgvProductos.Rows[i].Cells[4].Value.ToString()), decimal.Parse(dgvProductos.Rows[i].Cells[5].Value.ToString()));
                    }
                    //ticket.AgregaArticulo("Articulo A", 2, 20, 40);
                    //ticket.AgregaArticulo("Articulo B", 1, 10, 10);
                    //ticket.AgregaArticulo("Este es un nombre largo del articulo, para mostrar como se bajan las lineas", 1, 30, 30);
                    //ticket.lineasIgual();

                    //Resumen de la venta. Sólo son ejemplos
                    ticket.AgregarTotales("         SUBTOTAL......$", decimal.Parse(txtSubTotal.Text));
                    ticket.AgregarTotales("         IVA...........$", decimal.Parse(txtIVA.Text));//La M indica que es un decimal en C#
                    ticket.AgregarTotales("         DESCUENTO.....$", decimal.Parse(txtDescuento.Text));
                    ticket.AgregarTotales("         TOTAL.........$", decimal.Parse(txtTotal.Text));
                    ticket.TextoIzquierda("");



                    //Texto final del Ticket.
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: " + productos);
                    ticket.TextoIzquierda("");
                    ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
                    ticket.CortaTicket();
                    ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera    
                }


                nombreFactura = txtNoFactura.Text.Trim();
                
            }
            else
            {
                MessageBox.Show("Error Al Generar Ticket");
            }
        }

        public void mtdLimpiarFormulario()
        {
            foreach (Control c in groupBox2.Controls)
            {
                if (c is TextBox)
                {
                    TextBox text = c as TextBox;
                    text.Clear();


                    //Enfoco en el primer TextBox

                    this.txtBusqueda.Focus();
                }

            }

            

            foreach (Control c in groupBox5.Controls)
            {
                if (c is TextBox)
                {
                    TextBox text = c as TextBox;
                    text.Clear();


                    //Enfoco en el primer TextBox

                    this.txtBusqueda.Focus();
                }

            }


            foreach (Control c in grBProducto.Controls)
            {
                if (c is TextBox)
                {
                    TextBox text = c as TextBox;
                    text.Clear();


                    //Enfoco en el primer TextBox

                    this.txtBusqueda.Focus();
                }

            }

            txtNoFactura.Text = "";
            cmbCitaPorFecha.DataSource = null;
            cmbCitaPorFecha.Items.Clear();

            cmbCitasPaciente.DataSource = null;
            cmbCitasPaciente.Items.Clear();


            gbPagoDeContado.Visible = false;

            rbAccesorios.Checked = false;
            rbCita.Checked = false;

            dgvCitas.DataSource = null;
            dgvCitas.Rows.Clear();
            txtTotal.Text = "";

            dgvProductos.DataSource = null;
            dgvProductos.Rows.Clear();
            txtDescuento.Text = "0";
            txtDescuentoProductos.Text = "0";

            grBCita.Visible = false;
            grBProducto.Visible = false;

        }



        double efectivo, cambio, total;

        private void txtNombreProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void txtDescuentoProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.soloNumeros(e);
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            frmPrincipal objPrincipal = new frmPrincipal();
            this.Hide();
            objPrincipal.Show();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
    }

