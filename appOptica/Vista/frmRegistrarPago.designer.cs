namespace appOptica.Vista
{
    partial class frmRegistrarPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarPago));
            this.label3 = new System.Windows.Forms.Label();
            this.gbCredito = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardarCr = new System.Windows.Forms.Button();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblTotalPagado = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblTotalAPagar = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtAbono = new System.Windows.Forms.TextBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.gbCredito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(196, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 29);
            this.label3.TabIndex = 35;
            this.label3.Text = "Registrar Pago";
            // 
            // gbCredito
            // 
            this.gbCredito.Controls.Add(this.label1);
            this.gbCredito.Controls.Add(this.label2);
            this.gbCredito.Controls.Add(this.btnGuardarCr);
            this.gbCredito.Controls.Add(this.lblSaldo);
            this.gbCredito.Controls.Add(this.label22);
            this.gbCredito.Controls.Add(this.lblTotalPagado);
            this.gbCredito.Controls.Add(this.label20);
            this.gbCredito.Controls.Add(this.lblTotalAPagar);
            this.gbCredito.Controls.Add(this.label18);
            this.gbCredito.Controls.Add(this.txtEfectivo);
            this.gbCredito.Controls.Add(this.label14);
            this.gbCredito.Controls.Add(this.label16);
            this.gbCredito.Controls.Add(this.txtAbono);
            this.gbCredito.Location = new System.Drawing.Point(12, 64);
            this.gbCredito.Name = "gbCredito";
            this.gbCredito.Size = new System.Drawing.Size(600, 178);
            this.gbCredito.TabIndex = 41;
            this.gbCredito.TabStop = false;
            this.gbCredito.Text = "Credito";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(358, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 24);
            this.label1.TabIndex = 35;
            this.label1.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(210, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 24);
            this.label2.TabIndex = 34;
            this.label2.Text = "No Factura";
            // 
            // btnGuardarCr
            // 
            this.btnGuardarCr.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGuardarCr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCr.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCr.Location = new System.Drawing.Point(157, 134);
            this.btnGuardarCr.Name = "btnGuardarCr";
            this.btnGuardarCr.Size = new System.Drawing.Size(88, 31);
            this.btnGuardarCr.TabIndex = 33;
            this.btnGuardarCr.Text = "Guardar";
            this.btnGuardarCr.UseVisualStyleBackColor = false;
            this.btnGuardarCr.Click += new System.EventHandler(this.btnGuardarCr_Click);
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(504, 134);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(32, 24);
            this.lblSaldo.TabIndex = 32;
            this.lblSaldo.Text = "$0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(340, 134);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 24);
            this.label22.TabIndex = 31;
            this.label22.Text = "Saldo:";
            // 
            // lblTotalPagado
            // 
            this.lblTotalPagado.AutoSize = true;
            this.lblTotalPagado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagado.Location = new System.Drawing.Point(504, 96);
            this.lblTotalPagado.Name = "lblTotalPagado";
            this.lblTotalPagado.Size = new System.Drawing.Size(32, 24);
            this.lblTotalPagado.TabIndex = 30;
            this.lblTotalPagado.Text = "$0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(337, 93);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(139, 24);
            this.label20.TabIndex = 29;
            this.label20.Text = "Total Pagado:";
            // 
            // lblTotalAPagar
            // 
            this.lblTotalAPagar.AutoSize = true;
            this.lblTotalAPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAPagar.Location = new System.Drawing.Point(504, 55);
            this.lblTotalAPagar.Name = "lblTotalAPagar";
            this.lblTotalAPagar.Size = new System.Drawing.Size(32, 24);
            this.lblTotalAPagar.TabIndex = 28;
            this.lblTotalAPagar.Text = "$0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(337, 54);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(142, 24);
            this.label18.TabIndex = 27;
            this.label18.Text = "Total A Pagar:";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.BackColor = System.Drawing.Color.White;
            this.txtEfectivo.ForeColor = System.Drawing.Color.DarkCyan;
            this.txtEfectivo.Location = new System.Drawing.Point(133, 98);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(136, 20);
            this.txtEfectivo.TabIndex = 26;
            this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivo_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(62, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 18);
            this.label14.TabIndex = 25;
            this.label14.Text = "Efectivo:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(62, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 18);
            this.label16.TabIndex = 24;
            this.label16.Text = "Abono:";
            // 
            // txtAbono
            // 
            this.txtAbono.BackColor = System.Drawing.Color.White;
            this.txtAbono.ForeColor = System.Drawing.Color.DarkCyan;
            this.txtAbono.Location = new System.Drawing.Point(133, 59);
            this.txtAbono.Name = "txtAbono";
            this.txtAbono.Size = new System.Drawing.Size(136, 20);
            this.txtAbono.TabIndex = 23;
            this.txtAbono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAbono_KeyPress);
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackgroundImage = global::appOptica.Properties.Resources.Captura;
            this.pictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox11.Location = new System.Drawing.Point(548, 9);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(64, 49);
            this.pictureBox11.TabIndex = 36;
            this.pictureBox11.TabStop = false;
            // 
            // frmRegistrarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(626, 267);
            this.Controls.Add(this.gbCredito);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox11);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRegistrarPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Pago";
            this.Load += new System.EventHandler(this.frmRegistrarPago_Load);
            this.gbCredito.ResumeLayout(false);
            this.gbCredito.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.GroupBox gbCredito;
        private System.Windows.Forms.Button btnGuardarCr;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblTotalPagado;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblTotalAPagar;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtAbono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}