using appOptica.Entidades;
using appOptica.Logica;
using System;
using System.Collections;
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
    public partial class frmCita : Form
    {
        public frmCita()
        {
            InitializeComponent();
        }

        clTipoCitaL objTipoCitaL = new clTipoCitaL();
        clPacienteE objPacienteE = new clPacienteE();
        clCitaL objCitaL = new clCitaL();
        clCitaE objCitaE = new clCitaE();
        clMedicoE objMedicoE = new clMedicoE();
        clHistoriaClinicaL objHistoriaClinicaL = new clHistoriaClinicaL();
        clValidaciones objValidaciones = new clValidaciones();

        private void frmCita_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = "09:00 a,m";
            dataGridView1.Rows[0].Cells[1].Value = "09:30 a,m";
            dataGridView1.Rows[0].Cells[2].Value = "10:00 a,m";
            dataGridView1.Rows[0].Cells[3].Value = "10:30 a,m";
            dataGridView1.Rows[0].Cells[4].Value = "11:00 a,m";
            dataGridView1.Rows[0].Cells[5].Value = "11:30 a,m";
            dataGridView1.Rows[0].Cells[6].Value = "02:00 p,m";
            dataGridView1.Rows[0].Cells[7].Value = "02:30 p,m";
            dataGridView1.Rows[0].Cells[8].Value = "03:00 p,m";
            dataGridView1.Rows[0].Cells[9].Value = "03:30 p,m";
            dataGridView1.Rows[0].Cells[10].Value = "04:00 p,m";
            dataGridView1.Rows[0].Cells[11].Value = "04:30 p,m";
            dataGridView1.Rows[0].Cells[12].Value = "05:00 p,m";
            dataGridView1.Rows[0].Cells[13].Value = "05:30 p,m";

            cbTipoCita.DataSource = objTipoCitaL.mtdTipoCita();
            cbTipoCita.DisplayMember = "TipoCita";
            cbTipoCita.ValueMember = "IdTipoCita";
            

            txtBusqueda.AutoCompleteCustomSource = mtdCargarDatos();
            txtBusqueda.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBusqueda.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        public AutoCompleteStringCollection mtdCompletarMedico()
        {
            AutoCompleteStringCollection nombres = new AutoCompleteStringCollection();
            List<clMedicoE> nombresMedico = new List<clMedicoE>();
            nombresMedico = objCitaL.mtdCompletarMedico();
            foreach (clMedicoE item in nombresMedico)
            {
                nombres.Add(item.Nombres.Trim());
            }

            return nombres;
        }

        //int IdMedico = 0;
        int IdPaciente = 0;
        private void btnCita_Click(object sender, EventArgs e)
        {
            objPacienteE.Documento = txtPaciente.Text;
            int validacion = objHistoriaClinicaL.mtdValidarPaciente(objPacienteE);

            objCitaE.Fecha = DateTime.Parse(dtpFechaCita.Text);
            objCitaE.Hora = mtHora.Text;
            int validacionFH = objCitaL.mtdValidacionFechaHora(objCitaE);
            

            if ( txtPaciente.Text == "" || string.IsNullOrEmpty(mtHora.Text))
            {
                MessageBox.Show("¡Ups! al parecer no has llenado todos los campos.");
            }
            else if (validacion == 1)
            {
                float VCParticularVal = 30000, VCParticularTra = 25000, VCEpsVal = 4000, VCEpsTra = 3000;
                

                if (validacionFH != 1)
                {
                    objPacienteE.Documento = txtPaciente.Text;
                    clPacienteE objPaciE = new clPacienteE();
                    objPaciE = objCitaL.mtdPaciente(objPacienteE: objPacienteE);

                    IdPaciente = objPaciE.IdPaciente;

                    clTipoPacienteE objPacienteTP = new clTipoPacienteE();
                    objPacienteE.Documento = txtBusqueda.Text;
                    objPacienteTP = objCitaL.mtdTipoPaciente(objPacienteTP: objPacienteE);
                    
                    objCitaE.IdTipoCita = int.Parse(cbTipoCita.SelectedValue.ToString());

                    if (objCitaE.IdTipoCita == 1 && objPacienteTP.IdTipoPaciente == 1 )
                    {
                        
                        objCitaE.Valor = VCParticularVal;
                        MessageBox.Show("La cita tiene un costo de: $" + VCParticularVal); 
                        
                    }
                    else if (objCitaE.IdTipoCita == 1 && objPacienteTP.IdTipoPaciente ==2)
                    {
                        objCitaE.Valor = VCEpsVal;
                        MessageBox.Show("La cita tiene un costo de: $" + VCEpsVal);
                    }
                    else if (objCitaE.IdTipoCita == 2 && objPacienteTP.IdTipoPaciente == 1)
                    {
                        objCitaE.Valor = VCParticularTra;
                        MessageBox.Show("La cita tiene un costo de: $" + VCParticularTra);
                    }
                    else if (objCitaE.IdTipoCita == 2 && objPacienteTP.IdTipoPaciente ==2)
                    {
                        objCitaE.Valor = VCEpsTra;
                        MessageBox.Show("La cita tiene un costo de: $" + VCEpsTra);
                    }
                    objCitaE.Fecha = DateTime.Parse(dtpFechaCita.Text);
                    objCitaE.Hora = mtHora.Text;
                    objCitaE.IdPaciente = int.Parse(IdPaciente.ToString());
                    int registro = objCitaL.mtdCita(objCitaE);

                    if (registro == -3)
                    {
                        MessageBox.Show("Problemas al registrar la cita.");
                    }
                    else
                    {
                        MessageBox.Show("Cita registrada con exito.");
                        
                        mtHora.Text = "";
                        dtpFechaCita.Text = "";
                        //txtValor.Text = "";
                        txtPaciente.Text = "";
                        cbTipoCita.Text = "";
                        txtBusqueda.Text = "";
                        txtNombres.Text = "";
                        txtTelefono.Text = "";
                        txtTipoPaciente.Text = "";
                        txtDireccion.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("La fecha y hora asignadas ya estan ocupadas.");
                }
               
            }
            else
            {
                MessageBox.Show("El paciente no esta registrado.");
                DialogResult result = MessageBox.Show("¿Deseas registrar al paciente?", "Registrar Paciente", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    frmRegistrarPaciente frmRegistrarPaciente = new frmRegistrarPaciente();
                    frmRegistrarPaciente.Show();
                    this.Hide();
                }
            }
        }

       

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            clBusquedaE objBusquedaE = new clBusquedaE();
            if (txtTipoPaciente.Text == "")
            {
                MessageBox.Show("Verifica los datos del Paciente (Buscalo)");
            }
            else
            {
                objBusquedaE.Fecha = DateTime.Parse(dtpFechaCita.Text);
                objBusquedaE.Hora = mtHora.Text;
                //Comprobar si la cita existe
                objCitaE.Fecha = DateTime.Parse(dtpFechaCita.Text);
                objCitaE.Hora = mtHora.Text;
                int validacion = objCitaL.mtdValidacionFechaHora(objCitaE);


                if (validacion == 1)
                {
                    clBusquedaE Cita = new clBusquedaE();
                    Cita = objCitaL.mtdBuscarCita(objBusquedaE);

                    dtpFechaCita.Text = Cita.Fecha.ToString();
                    mtHora.Text = Cita.Hora.ToString();
                    //txtValor.Text = Cita.Valor.ToString();
                    cbTipoCita.Text = Cita.TipoCita.ToString();
                    txtPaciente.Text = Cita.Paciente.ToString();
                    MessageBox.Show("Cita encontrada.");

                    IdCita = Cita.IdCita;
                }
                else
                {
                    MessageBox.Show("Cita no existente.");
                }
            }

            
           
        }


        int IdCita = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            objPacienteE.Documento = txtPaciente.Text;
            clPacienteE objPaciE = new clPacienteE();
            objPaciE = objCitaL.mtdPaciente(objPacienteE: objPacienteE);

            IdPaciente = objPaciE.IdPaciente;

            clTipoPacienteE objPacienteTP = new clTipoPacienteE();
            objPacienteE.Documento = txtBusqueda.Text;
            objPacienteTP = objCitaL.mtdTipoPaciente(objPacienteTP: objPacienteE);

            objCitaE.IdTipoCita = int.Parse(cbTipoCita.SelectedValue.ToString());

            float VCParticularVal = 30000, VCParticularTra = 25000, VCEpsVal = 4000, VCEpsTra = 3000;
            if (objCitaE.IdTipoCita == 1 && objPacienteTP.IdTipoPaciente == 1)
            {

                objCitaE.Valor = VCParticularVal;
                MessageBox.Show("La cita tiene un costo de: $" + VCParticularVal);

            }
            else if (objCitaE.IdTipoCita == 1 && objPacienteTP.IdTipoPaciente == 2)
            {
                objCitaE.Valor = VCEpsVal;
                MessageBox.Show("La cita tiene un costo de: $" + VCEpsVal);
            }
            else if (objCitaE.IdTipoCita == 2 && objPacienteTP.IdTipoPaciente == 1)
            {
                objCitaE.Valor = VCParticularTra;
                MessageBox.Show("La cita tiene un costo de: $" + VCParticularTra);
            }
            else if (objCitaE.IdTipoCita == 2 && objPacienteTP.IdTipoPaciente == 2)
            {
                objCitaE.Valor = VCEpsTra;
                MessageBox.Show("La cita tiene un costo de: $" + VCEpsTra);
            }

            objCitaE.Fecha = DateTime.Parse(dtpFechaCita.Text);
            objCitaE.Hora = mtHora.Text;
            objCitaE.IdPaciente = int.Parse(IdPaciente.ToString());
            objCitaE.IdTipoCita = int.Parse(cbTipoCita.SelectedValue.ToString());
            objCitaE.IdMedico = 3;
            objCitaE.IdCita = int.Parse(IdCita.ToString());

            int actualizar = objCitaL.mtdActualizarCita(objCitaE);
            if (actualizar == 0)
            {
                MessageBox.Show("Error al actualizar cita.");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Deseas actualizar esta cita?", "Actualizar", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Cita actualizada exitosamente.");

                    mtHora.Text = "";
                    dtpFechaCita.Text = "";
                    //txtValor.Text = "";
                    txtPaciente.Text = "";
                    cbTipoCita.Text = "";
                    txtBusqueda.Text = "";
                    txtNombres.Text = "";
                    txtTelefono.Text = "";
                    txtTipoPaciente.Text = "";
                    txtDireccion.Text = "";
                }
                else if (result == DialogResult.No)
                {
                }
                else if (result == DialogResult.Cancel)
                {
                }
                
            }
        }

        
        public AutoCompleteStringCollection mtdCargarDatos()
        {
            clFacturaL objFacturaL = new clFacturaL();
            AutoCompleteStringCollection documentos = new AutoCompleteStringCollection();

            List<clPacienteE> listaDocumentos = new List<clPacienteE>();


            listaDocumentos = objFacturaL.mtdCargarDatos();

            foreach (clPacienteE item in listaDocumentos)
            {
                documentos.Add(item.Documento.Trim());
            }

            return documentos;
        }


        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidaciones.soloNumeros(e);
        }

        private void txtPaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidaciones.soloNumeros(e);
        }

        private void txtMedico_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidaciones.soloLetras(e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //for (int j = 0; j < dataGridView1.ColumnCount; j++)
            //{
            //    dataGridView1.Rows[0].Cells[j].Style.BackColor = Color.LightSteelBlue;
            //}


            //objCitaE.Fecha = DateTime.Parse(dtpFecha.Text);
            //List<clCitaE> listaFechaOcu = new List<clCitaE>();
            //listaFechaOcu = objCitaL.mtdFechaOcupada(objCitaE);
            
            //for (int i = 0; i < listaFechaOcu.Count; i++)
            //{
            //    for (int j = 0; j < dataGridView1.ColumnCount; j++)
            //    {
            //        string valor = dataGridView1.Rows[0].Cells[j].Value.ToString();
                  
            //       if (listaFechaOcu[i].Hora == dataGridView1.Rows[0].Cells[j].Value.ToString())
            //        {
            //           dataGridView1.Rows[0].Cells[j].Style.BackColor = Color.DodgerBlue;
            //        }
            //    }
            //}
        }

       
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objPacienteE.Documento = txtPaciente.Text;
            clPacienteE objPaciE = new clPacienteE();
            objPaciE = objCitaL.mtdPaciente(objPacienteE: objPacienteE);

            IdPaciente = objPaciE.IdPaciente;

            clTipoPacienteE objPacienteTP = new clTipoPacienteE();
            objPacienteE.Documento = txtBusqueda.Text;

            objPacienteTP = objCitaL.mtdTipoPaciente(objPacienteTP: objPacienteE);

            objCitaE.IdTipoCita = int.Parse(cbTipoCita.SelectedValue.ToString());

            float VCParticularVal = 30000, VCParticularTra = 25000, VCEpsVal = 4000, VCEpsTra = 3000;

            if (objCitaE.IdTipoCita == 1 && objPacienteTP.IdTipoPaciente == 1)
            {

                objCitaE.Valor = VCParticularVal;
                //MessageBox.Show("La cita tiene un costo de: $" + VCParticularVal);

            }
            else if (objCitaE.IdTipoCita == 1 && objPacienteTP.IdTipoPaciente == 2)
            {
                objCitaE.Valor = VCEpsVal;
                //MessageBox.Show("La cita tiene un costo de: $" + VCEpsVal);
            }
            else if (objCitaE.IdTipoCita == 2 && objPacienteTP.IdTipoPaciente == 1)
            {
                objCitaE.Valor = VCParticularTra;
                ///MessageBox.Show("La cita tiene un costo de: $" + VCParticularTra);
            }
            else if (objCitaE.IdTipoCita == 2 && objPacienteTP.IdTipoPaciente == 2)
            {
                objCitaE.Valor = VCEpsTra;
                //MessageBox.Show("La cita tiene un costo de: $" + VCEpsTra);
            }

            objCitaE.Fecha = DateTime.Parse(dtpFechaCita.Text);
            objCitaE.Hora = mtHora.Text;
            //objCitaE.Valor = float.Parse(txtValor.Text);
            objCitaE.IdPaciente = int.Parse(IdPaciente.ToString());
            objCitaE.IdTipoCita = int.Parse(cbTipoCita.SelectedValue.ToString());
            objCitaE.IdCita = int.Parse(IdCita.ToString());

            int eliminar = objCitaL.mtdEliminarCita(objCitaE);

            if (eliminar == 0)
            {
                MessageBox.Show("Error al eliminar.");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Deseas eliminar la cita?", "Eliminar", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Cita eliminada exitosamente.");

                    mtHora.Text = "";
                    dtpFechaCita.Text = "";
                    //txtValor.Text = "";
                    txtPaciente.Text = "";
                    cbTipoCita.Text = "";
                    txtBusqueda.Text = "";
                    txtNombres.Text = "";
                    txtTelefono.Text = "";
                    txtTipoPaciente.Text = "";
                    txtDireccion.Text = "";
                }
                else if (result == DialogResult.No)
                {
                }
                else if (result == DialogResult.Cancel)
                {
                }

                
            }
        }

        private void dtpFechaCita_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Today;
            DateTime fechaCita = DateTime.Parse(dtpFechaCita.Text);
            if (fechaCita < fechaActual)
            {
                MessageBox.Show("La fecha de la cita no puede ser anterior a la fecha actual.");
            }
            else
            {

            }

            for (int j = 0; j < dataGridView1.ColumnCount; j++)
            {
                dataGridView1.Rows[0].Cells[j].Style.BackColor = Color.LightSteelBlue;
            }


            objCitaE.Fecha = DateTime.Parse(dtpFechaCita.Text);
            List<clCitaE> listaFechaOcu = new List<clCitaE>();
            listaFechaOcu = objCitaL.mtdFechaOcupada(objCitaE);

            for (int i = 0; i < listaFechaOcu.Count; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    string valor = dataGridView1.Rows[0].Cells[j].Value.ToString();

                    if (listaFechaOcu[i].Hora == dataGridView1.Rows[0].Cells[j].Value.ToString())
                    {
                        dataGridView1.Rows[0].Cells[j].Style.BackColor = Color.DodgerBlue;
                    }
                }
            }


        }

        private void mtHora_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            //string dateString = "00/00/0000 09:00:00 AM";
            //MaskedTextBox comparacion = '09:00:00 A,M';
            //if (mtHora < comparacion)
            //{
                
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clPacienteE objPacienteE = new clPacienteE();
            clPacienteE objPaciente = new clPacienteE();
            clTipoPacienteE objPacienteTP = new clTipoPacienteE();
            clCitaL objCitaL = new clCitaL();

            int idPaciente;
            if (txtBusqueda.Text == "")
            {
                MessageBox.Show("Debe ingresar un número de documento");
            }
            else
            {
                objPacienteE.Documento = txtBusqueda.Text;

                objPaciente = objCitaL.mtdDatosPaciente(objPacienteE);
                objPacienteTP = objCitaL.mtdTipoPaciente(objPacienteTP:objPacienteE);

                if (objPaciente == null || objPacienteTP == null)
                {
                    MessageBox.Show("El Paciente no existente");
                    DialogResult result = MessageBox.Show("¿Deseas registrar al paciente? ","Registro", MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Yes)
                    {
                        frmRegistrarPaciente frmRegistrarPaciente = new frmRegistrarPaciente();
                        frmRegistrarPaciente.Show();
                        this.Hide();
                    }
                }
                else
                {
                    idPaciente = objPaciente.IdPaciente;
                    txtNombres.Text = objPaciente.Nombres.Trim() + " " + objPaciente.Apellidos.Trim();
                    txtTelefono.Text = objPaciente.Celular.Trim();
                    txtDireccion.Text = objPaciente.Direccion.Trim();
                    txtTipoPaciente.Text = objPacienteTP.TipoPaciente;
                    txtPaciente.Text = txtBusqueda.Text;
                }
                
            } 
        }

        private void txtPaciente_TextChanged(object sender, EventArgs e)
        {
        //    clPacienteE objPacienteE = new clPacienteE();
        //    clPacienteE objPaciente = new clPacienteE();
        //    clFacturaL objFacturaL = new clFacturaL();
        //    clCitaL objCitaL = new clCitaL();

        //    int idPaciente;
        //    //if (txtBusqueda.Text == "")
        //    //{
        //    //    MessageBox.Show("Debe ingresar un número de documento");
        //    //}
        //    //else
        //    //{
        //        objPacienteE.Documento = txtBusqueda.Text;

        //        objPaciente = objFacturaL.mtdDatosPaciente(objPacienteE);

        //        if (objPaciente == null)
        //        {
        //            MessageBox.Show("El Paciente no existente");
        //        }
        //        else
        //        {
        //            idPaciente = objPaciente.IdPaciente;
        //            txtNombres.Text = objPaciente.Nombres.Trim() + " " + objPaciente.Apellidos.Trim();
        //            txtTelefono.Text = objPaciente.Celular.Trim();
        //            txtDireccion.Text = objPaciente.Direccion.Trim();
        //        }

        //    //}
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbTipoCita_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
