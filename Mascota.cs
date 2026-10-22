namespace CapaEntidad
{
    // ENTIDAD: representa una mascota (equivale a una fila de la tabla Mascota).
    // Se usa para pasar los datos entre las capas: Presentación -> Negocio -> Datos.
    public class Mascota
    {
        public int NumCliente { get; set; }           // clave primaria (autonumérica)
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public string Color { get; set; }
        public string Alergico { get; set; }          // "SI" o "NO"
        public string AtencionEspecial { get; set; }  // "SI" o "NO"
        public string Observaciones { get; set; }

        // Baja lógica: true = activa, false = dada de baja (el registro NO se borra)
        public bool Estado { get; set; }

        // Relación uno a uno: cada mascota tiene un dueño
        public Duenio UnDuenio { get; set; }
    }
}
