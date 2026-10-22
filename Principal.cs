using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    // PANTALLA PRINCIPAL: tiene tres botones. Cada uno abre otra pantalla o cierra la aplicación.
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();   // crea los controles definidos en Principal.Designer.cs
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            CargaDatos cargaDatos = new CargaDatos();
            cargaDatos.Show();
        }

        private void btnVerDatos_Click(object sender, EventArgs e)
        {
            VerDatos verDatos = new VerDatos();
            verDatos.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
