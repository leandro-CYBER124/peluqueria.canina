namespace CapaPresentacion
{
    partial class ModificarDatos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblRaza = new System.Windows.Forms.Label();
            this.txtRaza = new System.Windows.Forms.TextBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.lblAlergico = new System.Windows.Forms.Label();
            this.cmbAlergico = new System.Windows.Forms.ComboBox();
            this.lblAtEsp = new System.Windows.Forms.Label();
            this.cmbAtEsp = new System.Windows.Forms.ComboBox();
            this.lblNombreDuenio = new System.Windows.Forms.Label();
            this.txtNombreDuenio = new System.Windows.Forms.TextBox();
            this.lblCelDuenio = new System.Windows.Forms.Label();
            this.txtCelDuenio = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(25, 15);
            this.lblTitulo.Text = "Modificación de Datos";
            this.lblTitulo.Name = "lblTitulo";
            // lblNombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.Location = new System.Drawing.Point(30, 94);
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Name = "lblNombre";
            // txtNombre
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Size = new System.Drawing.Size(290, 27);
            this.txtNombre.Location = new System.Drawing.Point(190, 90);
            this.txtNombre.Name = "txtNombre";
            // lblRaza
            this.lblRaza.AutoSize = true;
            this.lblRaza.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRaza.Location = new System.Drawing.Point(30, 139);
            this.lblRaza.Text = "Raza:";
            this.lblRaza.Name = "lblRaza";
            // txtRaza
            this.txtRaza.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRaza.MaxLength = 50;
            this.txtRaza.Size = new System.Drawing.Size(290, 27);
            this.txtRaza.Location = new System.Drawing.Point(190, 135);
            this.txtRaza.Name = "txtRaza";
            // lblColor
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblColor.Location = new System.Drawing.Point(30, 184);
            this.lblColor.Text = "Color:";
            this.lblColor.Name = "lblColor";
            // txtColor
            this.txtColor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtColor.MaxLength = 50;
            this.txtColor.Size = new System.Drawing.Size(290, 27);
            this.txtColor.Location = new System.Drawing.Point(190, 180);
            this.txtColor.Name = "txtColor";
            // lblAlergico
            this.lblAlergico.AutoSize = true;
            this.lblAlergico.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAlergico.Location = new System.Drawing.Point(30, 229);
            this.lblAlergico.Text = "Alérgico:";
            this.lblAlergico.Name = "lblAlergico";
            // cmbAlergico
            this.cmbAlergico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlergico.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbAlergico.Size = new System.Drawing.Size(290, 28);
            this.cmbAlergico.Items.AddRange(new object[] { "-", "SI", "NO" });
            this.cmbAlergico.SelectedIndex = 0;
            this.cmbAlergico.Location = new System.Drawing.Point(190, 225);
            this.cmbAlergico.Name = "cmbAlergico";
            // lblAtEsp
            this.lblAtEsp.AutoSize = true;
            this.lblAtEsp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAtEsp.Location = new System.Drawing.Point(30, 274);
            this.lblAtEsp.Text = "Atención Especial:";
            this.lblAtEsp.Name = "lblAtEsp";
            // cmbAtEsp
            this.cmbAtEsp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAtEsp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbAtEsp.Size = new System.Drawing.Size(290, 28);
            this.cmbAtEsp.Items.AddRange(new object[] { "-", "SI", "NO" });
            this.cmbAtEsp.SelectedIndex = 0;
            this.cmbAtEsp.Location = new System.Drawing.Point(190, 270);
            this.cmbAtEsp.Name = "cmbAtEsp";
            // lblNombreDuenio
            this.lblNombreDuenio.AutoSize = true;
            this.lblNombreDuenio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombreDuenio.Location = new System.Drawing.Point(30, 319);
            this.lblNombreDuenio.Text = "Nombre Dueño:";
            this.lblNombreDuenio.Name = "lblNombreDuenio";
            // txtNombreDuenio
            this.txtNombreDuenio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombreDuenio.MaxLength = 50;
            this.txtNombreDuenio.Size = new System.Drawing.Size(290, 27);
            this.txtNombreDuenio.Location = new System.Drawing.Point(190, 315);
            this.txtNombreDuenio.Name = "txtNombreDuenio";
            // lblCelDuenio
            this.lblCelDuenio.AutoSize = true;
            this.lblCelDuenio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCelDuenio.Location = new System.Drawing.Point(30, 364);
            this.lblCelDuenio.Text = "Cel. Dueño:";
            this.lblCelDuenio.Name = "lblCelDuenio";
            // txtCelDuenio
            this.txtCelDuenio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCelDuenio.MaxLength = 15;
            this.txtCelDuenio.Size = new System.Drawing.Size(290, 27);
            this.txtCelDuenio.Location = new System.Drawing.Point(190, 360);
            this.txtCelDuenio.Name = "txtCelDuenio";
            this.txtCelDuenio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCelDuenio_KeyPress);
            // lblObservaciones
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblObservaciones.Location = new System.Drawing.Point(30, 409);
            this.lblObservaciones.Text = "Observaciones:";
            this.lblObservaciones.Name = "lblObservaciones";
            // txtObservaciones
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtObservaciones.MaxLength = 200;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(290, 90);
            this.txtObservaciones.Location = new System.Drawing.Point(190, 405);
            this.txtObservaciones.Name = "txtObservaciones";
            // btnLimpiar
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLimpiar.Location = new System.Drawing.Point(60, 535);
            this.btnLimpiar.Size = new System.Drawing.Size(180, 50);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // btnGuardar
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.Location = new System.Drawing.Point(270, 535);
            this.btnGuardar.Size = new System.Drawing.Size(190, 50);
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // ModificarDatos
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 610);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificación de Datos";
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblRaza);
            this.Controls.Add(this.txtRaza);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.lblAlergico);
            this.Controls.Add(this.cmbAlergico);
            this.Controls.Add(this.lblAtEsp);
            this.Controls.Add(this.cmbAtEsp);
            this.Controls.Add(this.lblNombreDuenio);
            this.Controls.Add(this.txtNombreDuenio);
            this.Controls.Add(this.lblCelDuenio);
            this.Controls.Add(this.txtCelDuenio);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "ModificarDatos";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblRaza;
        private System.Windows.Forms.TextBox txtRaza;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label lblAlergico;
        private System.Windows.Forms.ComboBox cmbAlergico;
        private System.Windows.Forms.Label lblAtEsp;
        private System.Windows.Forms.ComboBox cmbAtEsp;
        private System.Windows.Forms.Label lblNombreDuenio;
        private System.Windows.Forms.TextBox txtNombreDuenio;
        private System.Windows.Forms.Label lblCelDuenio;
        private System.Windows.Forms.TextBox txtCelDuenio;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
    }
}
