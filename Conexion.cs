using System.Configuration;

namespace CapaDatos
{
    public class Conexion
    {
        // Lee la cadena de conexión "cadena_conexion" del App.config (proyecto CapaPresentacion).
        // Está en un solo lugar: si cambia el servidor o la contraseña, se cambia solo en el App.config.
        public static string cadena = ConfigurationManager.ConnectionStrings["cadena_conexion"].ToString();
    }
}
