using System;
using System.Linq;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    // PANTALLA DE EDICIÓN: se abre desde VerDatos con el número de la mascota elegida.
    // Carga sus datos en el formulario y, al guardar, los manda a la capa de negocio.
    public partial class ModificarDatos : Form
    {
        private int _numCliente;   // id de la mascota que se está editando

        public ModificarDatos(int numCliente)
        {
            InitializeComponent();
            _numCliente = numCliente;
            CargarDatos();
        }

        // Busca la mascota entre las del listado y llena los campos del formulario
        private void CargarDatos()
        {
            Mascota masco = new CN_Mascota().Listar().FirstOrDefault(m => m.NumCliente == _numCliente);

            if (masco == null)
            {
                MessageBox.Show("No se encontró la mascota", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            txtNombre.Text = masco.Nombre;
            txtRaza.Text = masco.Raza;
            txtColor.Text = masco.Color;
            txtNombreDuenio.Text = masco.UnDuenio.Nombre;
            txtCelDuenio.Text = masco.UnDuenio.CelDuenio;
            txtObservaciones.Text = masco.Observaciones;

            cmbAlergico.SelectedIndex = IndiceSiNo(masco.Alergico);
            cmbAtEsp.SelectedIndex = IndiceSiNo(masco.AtencionEspecial);
        }

        // Los combos tienen: 0 = "-", 1 = "SI", 2 = "NO". Convierte el texto guardado en la posición del combo.
        private int IndiceSiNo(string valor)
        {
            if (string.Equals(valor, "SI", StringComparison.OrdinalIgnoreCase)) return 1;
            if (string.Equals(valor, "NO", StringComparison.OrdinalIgnoreCase)) return 2;
            return 0;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtRaza.Clear();
            txtColor.Clear();
            txtNombreDuenio.Clear();
            txtCelDuenio.Clear();
            txtObservaciones.Clear();
            cmbAlergico.SelectedIndex = 0;
            cmbAtEsp.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Armar la entidad con los datos nuevos (incluye el NumCliente para saber a quién modificar)
            Mascota obj = new Mascota()
            {
                NumCliente = _numCliente,
                Nombre = txtNombre.Text.Trim(),
                Raza = txtRaza.Text.Trim(),
                Color = txtColor.Text.Trim(),
                Alergico = cmbAlergico.SelectedItem.ToString(),
                AtencionEspecial = cmbAtEsp.SelectedItem.ToString(),
                Observaciones = txtObservaciones.Text.Trim(),
                UnDuenio = new Duenio()
                {
                    Nombre = txtNombreDuenio.Text.Trim(),
                    CelDuenio = txtCelDuenio.Text.Trim()
                }
            };

            string mensaje = string.Empty;
            bool respuesta = new CN_Mascota().Editar(obj, out mensaje);

            if (respuesta)
            {
                MessageBox.Show("Edicion realizada correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Vuelve al listado y cierra esta pantalla
                VerDatos pantalla = new VerDatos();
                pantalla.Show();
                Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Solo permite escribir números en el celular
        private void txtCelDuenio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
