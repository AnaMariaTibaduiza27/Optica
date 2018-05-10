namespace appOptica.Vista
{
    partial class frmCita
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCita));
            this.btnCita = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.mtHora = new System.Windows.Forms.MaskedTextBox();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTipoCita = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaCita = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Hora1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTipoPaciente = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCita
            // 
            this.btnCita.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCita.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCita.ForeColor = System.Drawing.Color.White;
            this.btnCita.Location = new System.Drawing.Point(234, 412);
            this.btnCita.Name = "btnCita";
            this.btnCita.Size = new System.Drawing.Size(173, 35);
            this.btnCita.TabIndex = 0;
            this.btnCita.Text = "Registar Cita";
            this.btnCita.UseVisualStyleBackColor = false;
            this.btnCita.Click += new System.EventHandler(this.btnCita_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.mtHora);
            this.groupBox1.Controls.Add(this.txtPaciente);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbTipoCita);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFechaCita);
            this.groupBox1.Location = new System.Drawing.Point(21, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 138);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Cita";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.Window;
            this.btnBuscar.Location = new System.Drawing.Point(472, 32);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(121, 31);
            this.btnBuscar.TabIndex = 46;
            this.btnBuscar.Text = "Buscar Cita";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // mtHora
            // 
            this.mtHora.Location = new System.Drawing.Point(372, 34);
            this.mtHora.Mask = "00:00 a.m";
            this.mtHora.Name = "mtHora";
            this.mtHora.Size = new System.Drawing.Size(94, 26);
            this.mtHora.TabIndex = 1;
            this.mtHora.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtHora_MaskInputRejected);
            // 
            // txtPaciente
            // 
            this.txtPaciente.Enabled = false;
            this.txtPaciente.HideSelection = false;
            this.txtPaciente.Location = new System.Drawing.Point(206, 83);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.Size = new System.Drawing.Size(135, 26);
            this.txtPaciente.TabIndex = 4;
            this.txtPaciente.TextChanged += new System.EventHandler(this.txtPaciente_TextChanged);
            this.txtPaciente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaciente_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "Documento del Paciente:";
            // 
            // cbTipoCita
            // 
            this.cbTipoCita.FormattingEnabled = true;
            this.cbTipoCita.Location = new System.Drawing.Point(474, 83);
            this.cbTipoCita.Name = "cbTipoCita";
            this.cbTipoCita.Size = new System.Drawing.Size(109, 28);
            this.cbTipoCita.TabIndex = 3;
            this.cbTipoCita.SelectedIndexChanged += new System.EventHandler(this.cbTipoCita_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "Tipo de Cita:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Hora:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Fecha:";
            // 
            // dtpFechaCita
            // 
            this.dtpFechaCita.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCita.Location = new System.Drawing.Point(92, 36);
            this.dtpFechaCita.Name = "dtpFechaCita";
            this.dtpFechaCita.Size = new System.Drawing.Size(205, 26);
            this.dtpFechaCita.TabIndex = 0;
            this.dtpFechaCita.ValueChanged += new System.EventHandler(this.dtpFechaCita_ValueChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(25, 412);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 35);
            this.button2.TabIndex = 42;
            this.button2.Text = "Actualizar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(667, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 170);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Citas Disponibles";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hora1,
            this.Hora2,
            this.Hora3,
            this.Hora4,
            this.Hora5,
            this.Hora6,
            this.Hora7,
            this.Hora8,
            this.Hora9,
            this.Hora10,
            this.Hora11,
            this.Hora12,
            this.Hora13,
            this.Hora14});
            this.dataGridView1.Location = new System.Drawing.Point(32, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(444, 102);
            this.dataGridView1.TabIndex = 2;
            // 
            // Hora1
            // 
            this.Hora1.HeaderText = "Cita 1";
            this.Hora1.Name = "Hora1";
            // 
            // Hora2
            // 
            this.Hora2.HeaderText = "Cita 2";
            this.Hora2.Name = "Hora2";
            // 
            // Hora3
            // 
            this.Hora3.HeaderText = "Cita 3";
            this.Hora3.Name = "Hora3";
            // 
            // Hora4
            // 
            this.Hora4.HeaderText = "Cita 4";
            this.Hora4.Name = "Hora4";
            // 
            // Hora5
            // 
            this.Hora5.HeaderText = "Cita 5";
            this.Hora5.Name = "Hora5";
            // 
            // Hora6
            // 
            this.Hora6.HeaderText = "Cita 6";
            this.Hora6.Name = "Hora6";
            // 
            // Hora7
            // 
            this.Hora7.HeaderText = "Cita 7";
            this.Hora7.Name = "Hora7";
            // 
            // Hora8
            // 
            this.Hora8.HeaderText = "Cita 8";
            this.Hora8.Name = "Hora8";
            // 
            // Hora9
            // 
            this.Hora9.HeaderText = "Cita 9";
            this.Hora9.Name = "Hora9";
            // 
            // Hora10
            // 
            this.Hora10.HeaderText = "Cita 10";
            this.Hora10.Name = "Hora10";
            // 
            // Hora11
            // 
            this.Hora11.HeaderText = "Cita 11";
            this.Hora11.Name = "Hora11";
            // 
            // Hora12
            // 
            this.Hora12.HeaderText = "Cita 12";
            this.Hora12.Name = "Hora12";
            // 
            // Hora13
            // 
            this.Hora13.HeaderText = "Cita 13";
            this.Hora13.Name = "Hora13";
            // 
            // Hora14
            // 
            this.Hora14.HeaderText = "Cita 14";
            this.Hora14.Name = "Hora14";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::appOptica.Properties.Resources.Captura;
            this.pictureBox1.Location = new System.Drawing.Point(1086, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(458, 412);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(173, 35);
            this.btnEliminar.TabIndex = 44;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(466, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(279, 29);
            this.label7.TabIndex = 45;
            this.label7.Text = "Programación de Citas";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTipoPaciente);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.txtDireccion);
            this.groupBox3.Controls.Add(this.txtTelefono);
            this.groupBox3.Controls.Add(this.txtNombres);
            this.groupBox3.Controls.Add(this.txtBusqueda);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(630, 161);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cliente";
            // 
            // txtTipoPaciente
            // 
            this.txtTipoPaciente.BackColor = System.Drawing.Color.White;
            this.txtTipoPaciente.Location = new System.Drawing.Point(129, 107);
            this.txtTipoPaciente.Name = "txtTipoPaciente";
            this.txtTipoPaciente.ReadOnly = true;
            this.txtTipoPaciente.Size = new System.Drawing.Size(198, 26);
            this.txtTipoPaciente.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(16, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "Tipo Paciente:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.Location = new System.Drawing.Point(251, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "..";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.White;
            this.txtDireccion.Location = new System.Drawing.Point(455, 101);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(147, 26);
            this.txtDireccion.TabIndex = 11;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.White;
            this.txtTelefono.Location = new System.Drawing.Point(455, 57);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(147, 26);
            this.txtTelefono.TabIndex = 10;
            // 
            // txtNombres
            // 
            this.txtNombres.BackColor = System.Drawing.Color.White;
            this.txtNombres.Location = new System.Drawing.Point(129, 63);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.ReadOnly = true;
            this.txtNombres.Size = new System.Drawing.Size(198, 26);
            this.txtNombres.TabIndex = 9;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(129, 19);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(116, 26);
            this.txtBusqueda.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(343, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Dirección:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(343, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Telefono:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(5, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Busqueda(CC):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(16, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "Nombres:";
            // 
            // frmCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1198, 484);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCita);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cita";
            this.Load += new System.EventHandler(this.frmCita_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCita;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox mtHora;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTipoCita;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaCita;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora14;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTipoPaciente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPaciente;
    }
}