using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    // PANTALLA DE LISTADO: muestra las mascotas en una tabla (DataGridView).
    // Desde acá se puede editar una mascota o darla de baja.
    public partial class VerDatos : Form
    {
        // Tabla en memoria con los datos que muestra la grilla (equivale al DefaultTableModel de Swing)
        private DataTable _tabla;

        public VerDatos()
        {
            InitializeComponent();
        }

        // Se ejecuta al abrir la pantalla
        private void VerDatos_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        // Pide las mascotas a la capa de negocio y llena la grilla
        private void CargarTabla()
        {
            // 1) Definir las columnas
            _tabla = new DataTable();
            _tabla.Columns.Add("Num", typeof(int));
            _tabla.Columns.Add("Nombre", typeof(string));
            _tabla.Columns.Add("Raza", typeof(string));
            _tabla.Columns.Add("Color", typeof(string));
            _tabla.Columns.Add("Alergico", typeof(string));
            _tabla.Columns.Add("At.Esp.", typeof(string));
            _tabla.Columns.Add("Dueño", typeof(string));
            _tabla.Columns.Add("Cel", typeof(string));
            _tabla.Columns.Add("Observaciones", typeof(string));
            _tabla.Columns.Add("Estado", typeof(string));
            _tabla.Columns.Add("EstadoValor", typeof(int));   // 1 = activa, 0 = dada de baja (columna oculta)

            // 2) Traer las mascotas (Presentación -> Negocio -> Datos -> procedimiento almacenado)
            List<Mascota> lista = new CN_Mascota().Listar();

            // 3) Agregar una fila por cada mascota
            foreach (Mascota item in lista)
            {
                _tabla.Rows.Add(item.NumCliente, item.Nombre, item.Raza, item.Color,
                                item.Alergico, item.AtencionEspecial,
                                item.UnDuenio.Nombre, item.UnDuenio.CelDuenio,
                                item.Observaciones,
                                item.Estado ? "Activa" : "Dada de baja",
                                item.Estado ? 1 : 0);
            }

            // 4) Mostrar la tabla en la grilla y ocultar la columna auxiliar
            dgvMascotas.DataSource = _tabla;
            dgvMascotas.Columns["EstadoValor"].Visible = false;

            AplicarFiltro();
        }

        // Filtra las filas según lo elegido en el combo "Mostrar"
        private void AplicarFiltro()
        {
            if (_tabla == null) return;

            switch (cboEstado.SelectedIndex)
            {
                case 0: _tabla.DefaultView.RowFilter = "EstadoValor = 1"; break;   // Activas
                case 1: _tabla.DefaultView.RowFilter = "EstadoValor = 0"; break;   // Dadas de baja
                default: _tabla.DefaultView.RowFilter = ""; break;                 // Todas
            }

            // Que no quede ninguna fila seleccionada al cargar
            dgvMascotas.ClearSelection();
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        // Se ejecuta al dibujar cada celda: las mascotas dadas de baja se pintan en gris
        private void dgvMascotas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            object estado = dgvMascotas.Rows[e.RowIndex].Cells["EstadoValor"].Value;
            if (estado != null && estado.ToString() == "0")
            {
                e.CellStyle.ForeColor = Color.DarkGray;
            }
        }

        // DAR DE BAJA (baja lógica): no borra el registro, solo lo marca como no activo
        private void btnDarDeBaja_Click(object sender, EventArgs e)
        {
            // Control 1: que la tabla tenga filas
            if (dgvMascotas.Rows.Count == 0)
            {
                MessageBox.Show("No hay nada para dar de baja en la tabla", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Control 2: que haya una fila seleccionada
            if (dgvMascotas.SelectedRows.Count == 0)
            {
                MessageBox.Show("No seleccionó ninguna mascota", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataGridViewRow row = dgvMascotas.SelectedRows[0];

            // Control 3: que no esté dada de baja ya
            if (Convert.ToInt32(row.Cells["EstadoValor"].Value) == 0)
            {
                MessageBox.Show("La mascota ya está dada de baja", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int numCliente = Convert.ToInt32(row.Cells["Num"].Value);
            string nombre = Convert.ToString(row.Cells["Nombre"].Value);

            // Confirmación
            if (MessageBox.Show("¿Desea dar de baja a la mascota " + nombre + "?", "Confirmar baja",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string mensaje = string.Empty;
            bool respuesta = new CN_Mascota().DarDeBaja(numCliente, out mensaje);

            if (respuesta)
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTabla();   // vuelve a consultar para reflejar el cambio
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMascotas.Rows.Count == 0)
            {
                MessageBox.Show("No hay nada para editar en la tabla", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvMascotas.SelectedRows.Count == 0)
            {
                MessageBox.Show("No seleccionó ninguna mascota", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Tomo el número de la mascota seleccionada y abro la pantalla de edición
            int numCliente = Convert.ToInt32(dgvMascotas.SelectedRows[0].Cells["Num"].Value);

            ModificarDatos pantallaModi = new ModificarDatos(numCliente);
            pantallaModi.Show();

            Close();   // cierra el listado; al guardar, la edición lo vuelve a abrir
        }
    }
}
