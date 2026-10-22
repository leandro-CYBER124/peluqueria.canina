namespace CapaPresentacion
{
    partial class VerDatos
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
            this.lblFiltro = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.dgvMascotas = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnDarDeBaja = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMascotas)).BeginInit();
            this.SuspendLayout();
            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Text = "Visualizacion de Datos";
            this.lblTitulo.Name = "lblTitulo";
            // lblFiltro
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFiltro.Location = new System.Drawing.Point(520, 34);
            this.lblFiltro.Text = "Mostrar:";
            this.lblFiltro.Name = "lblFiltro";
            // cboEstado
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboEstado.Location = new System.Drawing.Point(590, 30);
            this.cboEstado.Size = new System.Drawing.Size(200, 28);
            this.cboEstado.Items.AddRange(new object[] { "Activas", "Dadas de baja", "Todas" });
            this.cboEstado.SelectedIndex = 0;
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.cboEstado_SelectedIndexChanged);
            // dgvMascotas
            this.dgvMascotas.AllowUserToAddRows = false;
            this.dgvMascotas.AllowUserToDeleteRows = false;
            this.dgvMascotas.AllowUserToResizeRows = false;
            this.dgvMascotas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMascotas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMascotas.BackgroundColor = System.Drawing.Color.White;
            this.dgvMascotas.Location = new System.Drawing.Point(20, 80);
            this.dgvMascotas.MultiSelect = false;
            this.dgvMascotas.ReadOnly = true;
            this.dgvMascotas.RowHeadersVisible = false;
            this.dgvMascotas.RowTemplate.Height = 25;
            this.dgvMascotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMascotas.Size = new System.Drawing.Size(860, 300);
            this.dgvMascotas.Name = "dgvMascotas";
            this.dgvMascotas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMascotas_CellFormatting);
            // btnEditar
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditar.Location = new System.Drawing.Point(540, 400);
            this.btnEditar.Size = new System.Drawing.Size(160, 50);
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // btnDarDeBaja
            this.btnDarDeBaja.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDarDeBaja.Location = new System.Drawing.Point(720, 400);
            this.btnDarDeBaja.Size = new System.Drawing.Size(160, 50);
            this.btnDarDeBaja.Text = "Dar de Baja";
            this.btnDarDeBaja.UseVisualStyleBackColor = true;
            this.btnDarDeBaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDarDeBaja.Name = "btnDarDeBaja";
            this.btnDarDeBaja.Click += new System.EventHandler(this.btnDarDeBaja_Click);
            // VerDatos
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 470);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualización de Datos";
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.dgvMascotas);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnDarDeBaja);
            this.Name = "VerDatos";
            this.Load += new System.EventHandler(this.VerDatos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMascotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.DataGridView dgvMascotas;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnDarDeBaja;
    }
}
