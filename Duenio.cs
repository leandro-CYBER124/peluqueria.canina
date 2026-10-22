namespace CapaEntidad
{
    // ENTIDAD: representa al dueño de la mascota (equivale a una fila de la tabla Duenio).
    // Una entidad solo tiene propiedades: no tiene lógica ni sabe nada de la base de datos.
    public class Duenio
    {
        public int IdDuenio { get; set; }
        public string Nombre { get; set; }
        public string CelDuenio { get; set; }
    }
}
