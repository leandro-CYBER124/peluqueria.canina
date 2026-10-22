namespace CapaPresentacion
{
    partial class Principal
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
            this.btnCargarDatos = new System.Windows.Forms.Button();
            this.btnVerDatos = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // lblTitulo
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(30, 30);
            this.lblTitulo.Size = new System.Drawing.Size(400, 60);
            this.lblTitulo.Text = "Peluqueria canina";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Name = "lblTitulo";
            // btnCargarDatos
            this.btnCargarDatos.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCargarDatos.Location = new System.Drawing.Point(105, 120);
            this.btnCargarDatos.Size = new System.Drawing.Size(250, 60);
            this.btnCargarDatos.Text = "Cargar Datos";
            this.btnCargarDatos.UseVisualStyleBackColor = true;
            this.btnCargarDatos.Name = "btnCargarDatos";
            this.btnCargarDatos.Click += new System.EventHandler(this.btnCargarDatos_Click);
            // btnVerDatos
            this.btnVerDatos.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnVerDatos.Location = new System.Drawing.Point(105, 200);
            this.btnVerDatos.Size = new System.Drawing.Size(250, 60);
            this.btnVerDatos.Text = "Ver Datos";
            this.btnVerDatos.UseVisualStyleBackColor = true;
            this.btnVerDatos.Name = "btnVerDatos";
            this.btnVerDatos.Click += new System.EventHandler(this.btnVerDatos_Click);
            // btnSalir
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSalir.Location = new System.Drawing.Point(105, 280);
            this.btnSalir.Size = new System.Drawing.Size(250, 60);
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // Principal
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 400);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Peluquería canina";
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCargarDatos);
            this.Controls.Add(this.btnVerDatos);
            this.Controls.Add(this.btnSalir);
            this.Name = "Principal";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCargarDatos;
        private System.Windows.Forms.Button btnVerDatos;
        private System.Windows.Forms.Button btnSalir;
    }
}
