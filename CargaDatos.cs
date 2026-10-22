using System;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    // PANTALLA DE ALTA: el usuario completa el formulario y toca Guardar.
    // La pantalla NO valida ni toca la base: solo arma la entidad y se la pasa a la capa de negocio.
    public partial class CargaDatos : Form
    {
        public CargaDatos()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1) Armar la entidad con lo que escribió el usuario (Trim saca espacios de los costados)
            Mascota obj = new Mascota()
            {
                Nombre = txtNombre.Text.Trim(),
                Raza = txtRaza.Text.Trim(),
                Color = txtColor.Text.Trim(),
                Alergico = cmbAlergico.SelectedItem.ToString(),
                AtencionEspecial = cmbAtEsp.SelectedItem.ToString(),
                Observaciones = txtObservaciones.Text.Trim(),
                Estado = true,   // toda mascota nueva se da de alta como activa
                UnDuenio = new Duenio()
                {
                    Nombre = txtNombreDuenio.Text.Trim(),
                    CelDuenio = txtCelDuenio.Text.Trim()
                }
            };

            string mensaje = string.Empty;

            // 2) Pasarla a la capa de negocio: valida y, si está bien, la capa de datos
            //    llama al procedimiento almacenado. Devuelve el id generado (0 = falló).
            int idGenerado = new CN_Mascota().Registrar(obj, out mensaje);

            // 3) Mostrar el resultado
            if (idGenerado > 0)
            {
                MessageBox.Show("Guardado Exitoso.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                // "mensaje" trae la lista de errores de validación o el error de la base
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Evento KeyPress del celular: si la tecla no es un dígito (ni de control, como borrar),
        // se descarta (Handled = true). Así el campo solo acepta números.
        private void txtCelDuenio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtRaza.Clear();
            txtColor.Clear();
            txtNombreDuenio.Clear();
            txtCelDuenio.Clear();
            txtObservaciones.Clear();
            cmbAlergico.SelectedIndex = 0;   // vuelve a "-"
            cmbAtEsp.SelectedIndex = 0;
        }
    }
}
