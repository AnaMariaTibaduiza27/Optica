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
    public partial class frmHistoriaClinica : Form
    {
        public frmHistoriaClinica()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        clPacienteE objPacienteE;
        clPacienteE objPaciE;
        clHistoriaClinicaL objHistoriaClinicaL; 
        clHistoriaClinicaE objHistoriaClinicaE;
        clHistoriaClinicaD objHistoriaClinicaD;
        clValidaciones  validacion = new clValidaciones(); 
        clValoresE objValoresE = new clValoresE();

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

        public AutoCompleteStringCollection mtdNoHC()
        {
            clHistoriaClinicaD objHistoriaD = new clHistoriaClinicaD();
            AutoCompleteStringCollection NoHistorias = new AutoCompleteStringCollection();
            List<clHistoriaClinicaE> listaNoHC = new List<clHistoriaClinicaE>();

            listaNoHC = objHistoriaD.mtdNoHC();

            foreach(clHistoriaClinicaE item in listaNoHC)
            {
                NoHistorias.Add(item.NoHistoriaClinica.Trim());
            }

            return NoHistorias;
        }

        int IdPaciente = 0;
        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            objPacienteE = new clPacienteE();
            objHistoriaClinicaL = new clHistoriaClinicaL();
            objPacienteE.Documento = txtNoHistoriaClinica.Text;

            int validacion = objHistoriaClinicaL.mtdValidarPaciente(objPacienteE);

            objPaciE = new clPacienteE();

            if (validacion == 1)
            {
                objHistoriaClinicaL.mtdListar(objPacienteE);

                objPaciE = objHistoriaClinicaL.mtdListar(objPacienteE);
                IdPaciente = objPaciE.IdPaciente;

                lbDocumento.Text = objPaciE.Documento;
                lbNombres.Text = objPaciE.Nombres;
                lbApellidos.Text = objPaciE.Apellidos;
                lbTipoDocumento.Text = objPaciE.TipoDocumento;
                lbFechaNacimiento.Text = objPaciE.FechaNacimiento.ToString();
                lbCiudad.Text = objPaciE.Ciudad;
                lbEdad.Text = objPaciE.Edad.ToString();
                lbGenero.Text = objPaciE.Genero;
                lbDireccion.Text = objPaciE.Direccion;
                lbCelular.Text = objPaciE.Celular;
                lbAseguradora.Text = objPaciE.Aseguradora;
                lbTipoVinculacion.Text = objPaciE.TipoVinculacion;
                lbOcupacion.Text = objPaciE.Ocupacion;
                lbNombreAcompañante.Text = objPaciE.NombreAcudiente;
                lbCelularAcudiente.Text = objPaciE.CelularAcudiente;
            }
            else
            {
                MessageBox.Show("El paciente no ha sido registrado.");
            }
        }


        clAspectoE.HC[] vecDatos = new clAspectoE.HC[46];

        private void mtdCargar()
        {
            vecDatos[0].aspecto = "1";
            vecDatos[0].item = "1";
            vecDatos[0].valor = txtLensometriaOD.Text;

            vecDatos[1].aspecto = "1";
            vecDatos[1].item = "2";
            vecDatos[1].valor = txtLensometriaOI.Text;

            vecDatos[2].aspecto = "4";
            vecDatos[2].item = "1";
            vecDatos[2].valor = txtPHOD.Text;

            vecDatos[3].aspecto = "4";
            vecDatos[3].item = "2";
            vecDatos[3].valor = txtPHOI.Text;

            vecDatos[4].aspecto = "2";
            vecDatos[4].item = "1";
            vecDatos[4].valor = txtAVSCVLOD.Text;

            vecDatos[5].aspecto = "2";
            vecDatos[5].item = "2";
            vecDatos[5].valor = txtAVSCVLOI.Text;

            vecDatos[6].aspecto = "3";
            vecDatos[6].item = "1";
            vecDatos[6].valor = txtAVSCVPOD.Text;

            vecDatos[7].aspecto = "3";
            vecDatos[7].item = "2";
            vecDatos[7].valor = txtAVSCVPOI.Text;

            vecDatos[8].aspecto = "2";
            vecDatos[8].item = "3";
            vecDatos[8].valor = txtAVSCVLAO.Text;

            vecDatos[9].aspecto = "3";
            vecDatos[9].item = "3";
            vecDatos[9].valor = txtAVSCVPAO.Text;

            vecDatos[10].aspecto = "5";
            vecDatos[10].item = "1";
            vecDatos[10].valor = txtAVCCVLOD.Text;

            vecDatos[11].aspecto = "5";
            vecDatos[11].item = "2";
            vecDatos[11].valor = txtAVCCVLOI.Text;

            vecDatos[12].aspecto = "5";
            vecDatos[12].item = "3";
            vecDatos[12].valor = txtAVCCVLAO.Text;

            vecDatos[13].aspecto = "6";
            vecDatos[13].item = "1";
            vecDatos[13].valor = txtAVCCVPOD.Text;

            vecDatos[14].aspecto = "6";
            vecDatos[14].item = "2";
            vecDatos[14].valor = txtAVCCVPOI.Text;

            vecDatos[15].aspecto = "6";
            vecDatos[15].item = "3";
            vecDatos[15].valor = txtAVCCVPAO.Text;

            vecDatos[16].aspecto = "7";
            vecDatos[16].item = "4";
            vecDatos[16].valor = txtCovertTestVL.Text;

            vecDatos[17].aspecto = "7";
            vecDatos[17].item = "5";
            vecDatos[17].valor = txtCovertTestVP.Text;

            vecDatos[18].aspecto = "7";
            vecDatos[18].item = "6";
            vecDatos[18].valor = txtCovertTestPPC.Text;

            vecDatos[19].aspecto = "8";
            vecDatos[19].item = "1";
            vecDatos[19].valor = txtDuccionesOD.Text;

            vecDatos[20].aspecto = "8";
            vecDatos[20].item = "2";
            vecDatos[20].valor = txtDuccionesOI.Text;

            vecDatos[21].aspecto = "9";
            vecDatos[21].item = "1";
            vecDatos[21].valor = txtVersionesOD.Text;

            vecDatos[22].aspecto = "9";
            vecDatos[22].item = "2";
            vecDatos[22].valor = txtVersionesOI.Text;

            vecDatos[23].aspecto = "10";
            vecDatos[23].item = "1";
            vecDatos[23].valor = txtOftalmoscopiaOD.Text;

            vecDatos[24].aspecto = "10";
            vecDatos[24].item = "2";
            vecDatos[24].valor = txtOftalmoscopiaOI.Text;

            vecDatos[25].aspecto = "11";
            vecDatos[25].item = "1";
            vecDatos[25].valor = txtQueratometriaOD.Text;

            vecDatos[26].aspecto = "11";
            vecDatos[26].item = "7";
            vecDatos[26].valor = txtQueratometriaMirasOD.Text;

            vecDatos[27].aspecto = "11";
            vecDatos[27].item = "11";
            vecDatos[27].valor = txtQueratometriaMirasOI.Text;

            vecDatos[28].aspecto = "11";
            vecDatos[28].item = "2";
            vecDatos[28].valor = txtQueratometriaOI.Text;

            vecDatos[29].aspecto = "12";
            vecDatos[29].item = "1";
            vecDatos[29].valor = txtRetinoscopiaOD.Text;

            vecDatos[30].aspecto = "12";
            vecDatos[30].item = "8";
            vecDatos[30].valor = txtRetinoscopiaAVOD.Text;

            vecDatos[31].aspecto = "12";
            vecDatos[31].item = "2";
            vecDatos[31].valor = txtRetinoscopiaOI.Text;

            vecDatos[32].aspecto = "12";
            vecDatos[32].item = "13";
            vecDatos[32].valor = txtRetinoscopiaAVOI.Text;

            vecDatos[33].aspecto = "13";
            vecDatos[33].item = "1";
            vecDatos[33].valor = txtSubjetivoOD.Text;

            vecDatos[34].aspecto = "13";
            vecDatos[34].item = "2";
            vecDatos[34].valor = txtSubjetivoOI.Text;

            vecDatos[35].aspecto = "13";
            vecDatos[35].item = "8";
            vecDatos[35].valor = txtSubjetivoAVOD.Text;

            vecDatos[36].aspecto = "13";
            vecDatos[36].item = "13";
            vecDatos[36].valor = txtSubjetivoAVOI.Text;

            vecDatos[37].aspecto = "14";
            vecDatos[37].item = "1";
            vecDatos[37].valor = txtRXFinalOD.Text;

            vecDatos[38].aspecto = "14";
            vecDatos[38].item = "8";
            vecDatos[38].valor = txtRXFinalAVOD.Text;

            vecDatos[39].aspecto = "14";
            vecDatos[39].item = "9";
            vecDatos[39].valor = txtRXFinalDPOD.Text;

            vecDatos[40].aspecto = "14";
            vecDatos[40].item = "2";
            vecDatos[40].valor = txtRXFinalOI.Text;

            vecDatos[41].aspecto = "14";
            vecDatos[41].item = "13";
            vecDatos[41].valor = txtRXFinalAVOI.Text;

            vecDatos[42].aspecto = "14";
            vecDatos[42].item = "10";
            vecDatos[42].valor = txtRXFinalADDOI.Text;

            vecDatos[43].aspecto = "15";
            vecDatos[43].item = "12";
            vecDatos[43].valor = txtTonometriaInstrumento.Text;

            vecDatos[44].aspecto = "15";
            vecDatos[44].item = "1";
            vecDatos[44].valor = txtTonometriaOD.Text;

            vecDatos[45].aspecto = "15";
            vecDatos[45].item = "2";
            vecDatos[45].valor = txtTonometriaOI.Text;

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            objHistoriaClinicaL = new clHistoriaClinicaL();
            objHistoriaClinicaE = new clHistoriaClinicaE();
            objHistoriaClinicaD = new clHistoriaClinicaD();
            clPacienteE objPacienteE = new clPacienteE();
            clPacienteE PacienteId = new clPacienteE();
            validacion = new clValidaciones();
            String lim = "";
            String incremento1 = "-1";
            String incrementoMas = "-";

            objPacienteE.Documento = txtNoHistoriaClinica.Text;
            PacienteId = objHistoriaClinicaL.mtdListar(objPacienteE);

            int IdPaciente = PacienteId.IdPaciente;

            int NoHistoriaAsignar = objHistoriaClinicaL.mtdNoHistoriaCreciente(IdPaciente);

            if (NoHistoriaAsignar == -2)
            {
                objHistoriaClinicaE.NoHistoriaClinica = txtNoHistoriaClinica.Text + incremento1;
            }
            else
            {
                int x = NoHistoriaAsignar + 1;
                string t = x.ToString();
                objHistoriaClinicaE.NoHistoriaClinica = txtNoHistoriaClinica.Text + incrementoMas + t;
            } 

            
            objHistoriaClinicaE.Fecha = DateTime.Parse(dtpFecha.Text);
            objHistoriaClinicaE.Hora = txtHora.Text;
            objHistoriaClinicaE.IdPaciente = int.Parse(IdPaciente.ToString());
            objHistoriaClinicaE.UltimoControl = txtUltimoControl.Text;
            objHistoriaClinicaE.RX = txtRX.Text;
            objHistoriaClinicaE.MotivoCOnsulta = txtMotivoConsulta.Text;
            objHistoriaClinicaE.Antecedentes = txtAntecedentes.Text;
            objHistoriaClinicaE.ExamenEsterno = txtExamenExterno.Text;
            objHistoriaClinicaE.ReflejosPupilares = txtReflejosPupilares.Text;
            objHistoriaClinicaE.BioMicroscopia = txtBiomicroscopia.Text;
            objHistoriaClinicaE.Diagnostico = txtDiagnostico.Text;
            objHistoriaClinicaE.Tratamiento = txtTratamiento.Text;
            objHistoriaClinicaE.Observaciones = txtObservaciones.Text;



            int registros = objHistoriaClinicaL.mtdHistoria(objHistoriaClinicaE);

            if (registros == -3)
            {
                MessageBox.Show("El No.Historia Clinica no se ha ingresado es imposible registrar.");
            }
            else
            {
                MessageBox.Show("Registro de Historia Clinica Exitoso.");
                
            }

            //consultar ultima historia
            objHistoriaClinicaE.NoHistoriaClinica = txtNoHistoriaClinica.Text;
            clHistoriaClinicaE objHistoriaE = new clHistoriaClinicaE();
            objHistoriaE = objHistoriaClinicaD.mtdNoHistoria(objHistoriaClinicaE);

            mtdCargar();
            // objHistoriaClinicaD.mtdRegistroValores(vecDatos);

            int registroValores = objHistoriaClinicaL.mtdRegistroValores(vecDatos);

            if (registroValores == -2)
            {
                MessageBox.Show("No se han registrado los valores correctamente.");
            }
            else
            {
                MessageBox.Show("Se han registrado los valores con exito.");
                validacion = new clValidaciones();
                validacion.BorrarCampos(groupBox2,groupBox3,groupBox4,groupBox5,groupBox6,groupBox7,groupBox8
                    ,groupBox9,groupBox10,groupBox11,groupBox12,groupBox13,groupBox14,groupBox15,groupBox16,groupBox17,groupBox18);
                txtLensometriaOD.Text = lim; txtLensometriaOI.Text = lim;
                txtPHOD.Text = lim; txtPHOI.Text = lim; txtReflejosPupilares.Text = lim;
                txtCovertTestVL.Text = lim; txtCovertTestVP.Text = lim; txtCovertTestPPC.Text = lim;
                txtDuccionesOD.Text = lim; txtDuccionesOI.Text = lim;
            }

        }


        private void frmHistoriaClinica_Load(object sender, EventArgs e)
        {
            this.txtHora.Text = DateTime.Now.ToLongTimeString();

            txtNoHistoriaClinica.AutoCompleteCustomSource = mtdNoHC();
            txtNoHistoriaClinica.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtNoHistoriaClinica.AutoCompleteSource = AutoCompleteSource.CustomSource;

            //txtNoHistoriaClinica.AutoCompleteCustomSource = mtdCargarDatos();
            //txtNoHistoriaClinica.AutoCompleteMode = AutoCompleteMode.Suggest;
            //txtNoHistoriaClinica.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            objHistoriaClinicaL = new clHistoriaClinicaL();
            objHistoriaClinicaE = new clHistoriaClinicaE();
            objHistoriaClinicaD = new clHistoriaClinicaD();
            validacion = new clValidaciones();
            string lim = "";

            objHistoriaClinicaE.NoHistoriaClinica = txtNoHistoriaClinica.Text;
            objHistoriaClinicaE.Fecha = DateTime.Parse(dtpFecha.Text);
            objHistoriaClinicaE.Hora = txtHora.Text;
            objHistoriaClinicaE.IdPaciente = int.Parse(IdPaciente.ToString());
            objHistoriaClinicaE.UltimoControl = txtUltimoControl.Text;
            objHistoriaClinicaE.RX = txtRX.Text;
            objHistoriaClinicaE.MotivoCOnsulta = txtMotivoConsulta.Text;
            objHistoriaClinicaE.Antecedentes = txtAntecedentes.Text;
            objHistoriaClinicaE.ExamenEsterno = txtExamenExterno.Text;
            objHistoriaClinicaE.ReflejosPupilares = txtReflejosPupilares.Text;
            objHistoriaClinicaE.BioMicroscopia = txtBiomicroscopia.Text;
            objHistoriaClinicaE.Diagnostico = txtDiagnostico.Text;
            objHistoriaClinicaE.Tratamiento = txtTratamiento.Text;
            objHistoriaClinicaE.Observaciones = txtObservaciones.Text;

            int actualizarHC = objHistoriaClinicaL.mtdActualizarHC(objHistoriaClinicaE);

            if (actualizarHC == 0)
            {
                MessageBox.Show("Error al actualizar Historia Clinica.");
            }
            else
            {
                MessageBox.Show("Historia Clinica No." + txtNoHistoriaClinica.Text + " ha sido Actualizada.");
                //validacion.BorrarCampos(groupBox2, groupBox3, groupBox4, groupBox5, groupBox6, groupBox7, groupBox8
                //    , groupBox9, groupBox10, groupBox11, groupBox12, groupBox13, groupBox14, groupBox15, groupBox16, groupBox17, groupBox18);
                //txtLensometriaOD.Text = lim; txtLensometriaOI.Text = lim;
                //txtPHOD.Text = lim; txtPHOI.Text = lim; txtReflejosPupilares.Text = lim;
                //txtCovertTestVL.Text = lim; txtCovertTestVP.Text = lim; txtCovertTestPPC.Text = lim;
                //txtDuccionesOD.Text = lim; txtDuccionesOI.Text = lim;
            }

            objHistoriaClinicaE.NoHistoriaClinica = txtNoHistoriaClinica.Text;
            clHistoriaClinicaE objHistoriaE = new clHistoriaClinicaE();
            objHistoriaE = objHistoriaClinicaD.mtdIdHC(objHistoriaClinicaE);

            mtdCargar();
            int actualizarValores = objHistoriaClinicaL.mtdActualizarValores(vecDatos, objHistoriaE);

            if (actualizarValores == 0)
            {
                MessageBox.Show("Error al actualizar valores opticos.");
            }
            else
            {
                MessageBox.Show("Valores opticos de Historia Clinica No." + txtNoHistoriaClinica.Text + " Actualizada");
                validacion = new clValidaciones();
                validacion.BorrarCampos(groupBox2, groupBox3, groupBox4, groupBox5, groupBox6, groupBox7, groupBox8
                    , groupBox9, groupBox10, groupBox11, groupBox12, groupBox13, groupBox14, groupBox15, groupBox16, groupBox17, groupBox18);
                txtLensometriaOD.Text = lim; txtLensometriaOI.Text = lim;
                txtPHOD.Text = lim; txtPHOI.Text = lim; txtReflejosPupilares.Text = lim;
                txtCovertTestVL.Text = lim; txtCovertTestVP.Text = lim; txtCovertTestPPC.Text = lim;
                txtDuccionesOD.Text = lim; txtDuccionesOI.Text = lim;

            }

        }


        int IdHC = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            objHistoriaClinicaL = new clHistoriaClinicaL();
            objHistoriaClinicaE = new clHistoriaClinicaE();

            objHistoriaClinicaE.NoHistoriaClinica = txtNoHistoriaClinica.Text;
           // objHistoriaClinicaE.Fecha = DateTime.Parse(dtpFecha.Text);

            int validacionHC = objHistoriaClinicaL.mtdHCExistente(objHistoriaClinicaE);

            if (txtNoHistoriaClinica.Text == "" )
            {
                MessageBox.Show("Ingresa No.Historia para poder realizar la busqueda.");
            }
            else
            {
                if (validacionHC == 1)
                {
                    objHistoriaClinicaE = objHistoriaClinicaL.mtdBuscarHC(objHistoriaClinicaE);

                    if (objHistoriaClinicaE == null)
                    {
                        MessageBox.Show("Verifica el dato ingresado.");
                    }
                    else
                    {
                        txtUltimoControl.Text = objHistoriaClinicaE.UltimoControl.ToString();
                        txtRX.Text = objHistoriaClinicaE.RX.ToString();
                        txtMotivoConsulta.Text = objHistoriaClinicaE.MotivoCOnsulta.ToString();
                        txtAntecedentes.Text = objHistoriaClinicaE.Antecedentes.ToString();
                        txtExamenExterno.Text = objHistoriaClinicaE.ExamenEsterno.ToString();
                        txtReflejosPupilares.Text = objHistoriaClinicaE.ReflejosPupilares.ToString();
                        txtBiomicroscopia.Text = objHistoriaClinicaE.BioMicroscopia.ToString();
                        txtDiagnostico.Text = objHistoriaClinicaE.Diagnostico.ToString();
                        txtTratamiento.Text = objHistoriaClinicaE.Tratamiento.ToString();
                        txtObservaciones.Text = objHistoriaClinicaE.Observaciones.ToString();

                        IdHC = objHistoriaClinicaE.IdHistoriaClinica;

                        objValoresE.IdHistoriaClinica = IdHC;
                        DataTable valores = new DataTable();
                        valores = objHistoriaClinicaL.mtdBuscarValores(objValoresE);

                        for (int i = 0; i < valores.Rows.Count; i++)
                        {
                            object n = valores.Rows[i][1];
                            string aspecto = n.ToString();
                            object d = valores.Rows[i][2];
                            string item = d.ToString();
                            if (aspecto == "1" && item == "1")
                            {
                                txtLensometriaOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "1" && item == "2")
                            {
                                txtLensometriaOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "4" && item == "1")
                            {
                                txtPHOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "4" && item == "2")
                            {
                                txtPHOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "2" && item == "1")
                            {
                                txtAVSCVLOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "2" && item == "2")
                            {
                                txtAVSCVLOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "3" && item == "1")
                            {
                                txtAVSCVPOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "3" && item == "2")
                            {
                                txtAVSCVPOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "2" && item == "3")
                            {
                                txtAVSCVLAO.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "3" && item == "3")
                            {
                                txtAVSCVPAO.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "5" && item == "1")
                            {
                                txtAVCCVLOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "5" && item == "2")
                            {
                                txtAVCCVLOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "5" && item == "3")
                            {
                                txtAVCCVLAO.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "6" && item == "1")
                            {
                                txtAVCCVPOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "6" && item == "2")
                            {
                                txtAVCCVPOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "6" && item == "3")
                            {
                                txtAVCCVPAO.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "7" && item == "4")
                            {
                                txtCovertTestVL.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "7" && item == "5")
                            {
                                txtCovertTestVP.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "7" && item == "6")
                            {
                                txtCovertTestPPC.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "8" && item == "1")
                            {
                                txtDuccionesOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "8" && item == "2")
                            {
                                txtDuccionesOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "9" && item == "1")
                            {
                                txtVersionesOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "9" && item == "2")
                            {
                                txtVersionesOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "10" && item == "1")
                            {
                                txtOftalmoscopiaOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "10" && item == "2")
                            {
                                txtOftalmoscopiaOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "11" && item == "1")
                            {
                                txtQueratometriaOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "11" && item == "7")
                            {
                                txtQueratometriaMirasOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "11" && item == "11")
                            {
                                txtQueratometriaMirasOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "11" && item == "2")
                            {
                                txtQueratometriaOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "12" && item == "1")
                            {
                                txtRetinoscopiaOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "12" && item == "8")
                            {
                                txtRetinoscopiaAVOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "12" && item == "2")
                            {
                                txtRetinoscopiaOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "12" && item == "13")
                            {
                                txtRetinoscopiaAVOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "13" && item == "1")
                            {
                                txtSubjetivoOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "13" && item == "2")
                            {
                                txtSubjetivoOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "13" && item == "8")
                            {
                                txtSubjetivoAVOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "13" && item == "13")
                            {
                                txtSubjetivoAVOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "14" && item == "1")
                            {
                                txtRXFinalOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "14" && item == "8")
                            {
                                txtRXFinalAVOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "14" && item == "9")
                            {
                                txtRXFinalDPOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "14" && item == "2")
                            {
                                txtRXFinalOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "14" && item == "13")
                            {
                                txtRXFinalAVOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "14" && item == "10")
                            {
                                txtRXFinalADDOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "15" && item == "12")
                            {
                                txtTonometriaInstrumento.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "15" && item == "1")
                            {
                                txtTonometriaOD.Text = valores.Rows[i][3].ToString().Trim();
                            }
                            else if (aspecto == "15" && item == "2")
                            {
                                txtTonometriaOI.Text = valores.Rows[i][3].ToString().Trim();
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Historia Clinica NO existente.");
                }
            }
        
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objHistoriaClinicaD = new clHistoriaClinicaD();
            objHistoriaClinicaL = new clHistoriaClinicaL();
            objHistoriaClinicaE = new clHistoriaClinicaE();

            objHistoriaClinicaE.NoHistoriaClinica = txtNoHistoriaClinica.Text;
            clHistoriaClinicaE objHistoriaE = new clHistoriaClinicaE();
            objHistoriaE = objHistoriaClinicaD.mtdIdHC(objHistoriaClinicaE);

           // idHC = objHistoriaE.IdHistoriaClinica;

            String lim = "";

            //clHistoriaClinicaE eidHC = new clHistoriaClinicaE();
            //eidHC.NoHistoriaClinica = txtNoHistoriaClinica.Text;


            //clHistoriaClinicaE objHistoria = new clHistoriaClinicaE();
            //objHistoria = objHistoriaClinicaD.mtdIdHC(objHistoriaClinicaE);


            mtdCargar();
            int eliminarValores = objHistoriaClinicaL.mtdEliminarValores(vecDatos, objHistoriaE);
            if (eliminarValores != 0)
            {
                
                MessageBox.Show("Valores eliminados con exito");
            }
            else
            {
                MessageBox.Show("Error al eliminar Valores de Historia Clinica");
                //validacion.BorrarCampos(groupBox2, groupBox3, groupBox4, groupBox5, groupBox6, groupBox7, groupBox8
                //    , groupBox9, groupBox10, groupBox11, groupBox12, groupBox13, groupBox14, groupBox15, groupBox16, groupBox17, groupBox18);
                //txtLensometriaOD.Text = lim; txtLensometriaOI.Text = lim;
                //txtPHOD.Text = lim; txtPHOI.Text = lim; txtReflejosPupilares.Text = lim;
                //txtCovertTestVL.Text = lim; txtCovertTestVP.Text = lim; txtCovertTestPPC.Text = lim;
                //txtDuccionesOD.Text = lim; txtDuccionesOI.Text = lim;
            }

            objHistoriaClinicaE.NoHistoriaClinica = txtNoHistoriaClinica.Text;
            objHistoriaClinicaE.Fecha = DateTime.Parse(dtpFecha.Text);
            objHistoriaClinicaE.Hora = txtHora.Text;
            objHistoriaClinicaE.IdPaciente = int.Parse(IdPaciente.ToString());
            objHistoriaClinicaE.UltimoControl = txtUltimoControl.Text;
            objHistoriaClinicaE.RX = txtRX.Text;
            objHistoriaClinicaE.MotivoCOnsulta = txtMotivoConsulta.Text;
            objHistoriaClinicaE.Antecedentes = txtAntecedentes.Text;
            objHistoriaClinicaE.ExamenEsterno = txtExamenExterno.Text;
            objHistoriaClinicaE.ReflejosPupilares = txtReflejosPupilares.Text;
            objHistoriaClinicaE.BioMicroscopia = txtBiomicroscopia.Text;
            objHistoriaClinicaE.Diagnostico = txtDiagnostico.Text;
            objHistoriaClinicaE.Tratamiento = txtTratamiento.Text;
            objHistoriaClinicaE.Observaciones = txtObservaciones.Text;
            objHistoriaClinicaE.IdHistoriaClinica = objHistoriaE.IdHistoriaClinica;

            int eliminarHC = objHistoriaClinicaL.mtdEliminarHC(objHistoriaClinicaE);

            if (eliminarHC == 0)
            {
                MessageBox.Show("Error al eliminar.");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Deseas eliminar la Historia Clinica?", "Eliminar", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Historia Clinica Eliminada con exito.");
                    validacion = new clValidaciones();
                    validacion.BorrarCampos(groupBox2, groupBox3, groupBox4, groupBox5, groupBox6, groupBox7, groupBox8
                    , groupBox9, groupBox10, groupBox11, groupBox12, groupBox13, groupBox14, groupBox15, groupBox16, groupBox17, groupBox18);
                    txtLensometriaOD.Text = lim; txtLensometriaOI.Text = lim;
                    txtPHOD.Text = lim; txtPHOI.Text = lim; txtReflejosPupilares.Text = lim;
                    txtCovertTestVL.Text = lim; txtCovertTestVP.Text = lim; txtCovertTestPPC.Text = lim;
                    txtDuccionesOD.Text = lim; txtDuccionesOI.Text = lim;

                }
                
            }

            

        }

        private void txtNoHistoriaClinica_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //validacion = new clValidaciones();
            //validacion.soloNumeros(e);
        }

        private void txtHora_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNoHistoriaClinica_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQueratometriaMirasOI_TextChanged(object sender, EventArgs e)
        {

        }
    }
}