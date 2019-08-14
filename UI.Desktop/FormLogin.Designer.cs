namespace UI.Desktop
{
    partial class FormLogin
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
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lblInicio = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtLeg = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblLegajo = new System.Windows.Forms.Label();
            this.panelIngreso = new System.Windows.Forms.Panel();
            this.lblUTN = new System.Windows.Forms.Label();
            this.lblSAA = new System.Windows.Forms.Label();
            this.panelIngreso.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(131, 104);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(75, 23);
            this.btnIngresar.TabIndex = 11;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(87, 18);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(82, 13);
            this.lblInicio.TabIndex = 10;
            this.lblInicio.Text = "Inicio de Sesión";
            this.lblInicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(79, 78);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(127, 20);
            this.txtContraseña.TabIndex = 9;
            // 
            // txtLeg
            // 
            this.txtLeg.Location = new System.Drawing.Point(79, 46);
            this.txtLeg.Name = "txtLeg";
            this.txtLeg.Size = new System.Drawing.Size(127, 20);
            this.txtLeg.TabIndex = 8;
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(16, 81);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(64, 13);
            this.lblContraseña.TabIndex = 7;
            this.lblContraseña.Text = "Contraseña:";
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.Location = new System.Drawing.Point(38, 49);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Size = new System.Drawing.Size(42, 13);
            this.lblLegajo.TabIndex = 6;
            this.lblLegajo.Text = "Legajo:";
            // 
            // panelIngreso
            // 
            this.panelIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelIngreso.Controls.Add(this.btnIngresar);
            this.panelIngreso.Controls.Add(this.lblLegajo);
            this.panelIngreso.Controls.Add(this.lblInicio);
            this.panelIngreso.Controls.Add(this.lblContraseña);
            this.panelIngreso.Controls.Add(this.txtContraseña);
            this.panelIngreso.Controls.Add(this.txtLeg);
            this.panelIngreso.Location = new System.Drawing.Point(122, 141);
            this.panelIngreso.Name = "panelIngreso";
            this.panelIngreso.Size = new System.Drawing.Size(245, 160);
            this.panelIngreso.TabIndex = 12;
            // 
            // lblUTN
            // 
            this.lblUTN.AutoSize = true;
            this.lblUTN.Font = new System.Drawing.Font("Clarendon BT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUTN.Location = new System.Drawing.Point(61, 42);
            this.lblUTN.Name = "lblUTN";
            this.lblUTN.Size = new System.Drawing.Size(385, 50);
            this.lblUTN.TabIndex = 13;
            this.lblUTN.Text = "Universidad Tecnológica Nacional\r\n       Facultad Regional Rosario";
            // 
            // lblSAA
            // 
            this.lblSAA.AutoSize = true;
            this.lblSAA.Font = new System.Drawing.Font("Clarendon BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSAA.Location = new System.Drawing.Point(126, 107);
            this.lblSAA.Name = "lblSAA";
            this.lblSAA.Size = new System.Drawing.Size(241, 19);
            this.lblSAA.TabIndex = 14;
            this.lblSAA.Text = "Sistema autogestión alumnos";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 371);
            this.Controls.Add(this.lblSAA);
            this.Controls.Add(this.lblUTN);
            this.Controls.Add(this.panelIngreso);
            this.Name = "FormLogin";
            this.Text = "Ingreso SYSACAD";
            this.panelIngreso.ResumeLayout(false);
            this.panelIngreso.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtLeg;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.Panel panelIngreso;
        private System.Windows.Forms.Label lblUTN;
        private System.Windows.Forms.Label lblSAA;
    }
}