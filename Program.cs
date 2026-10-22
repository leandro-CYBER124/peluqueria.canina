using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    internal static class Program
    {
        // Punto de entrada de la aplicación: abre la pantalla principal
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Principal());
        }
    }
}
