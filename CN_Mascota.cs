using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    // CAPA DE NEGOCIO: está en el medio. Valida las reglas ANTES de llegar a la base de datos
    // y recién después le pasa los datos a la capa de datos.
    public class CN_Mascota
    {
        // La capa de negocio usa a la capa de datos (nunca al revés)
        private CD_Mascota objcd_Mascota = new CD_Mascota();

        public List<Mascota> Listar()
        {
            return objcd_Mascota.Listar();
        }

        // Si hay errores de validación devuelve 0 y el mensaje con los errores.
        // Si está todo bien, llama a la capa de datos.
        public int Registrar(Mascota obj, out string Mensaje)
        {
            Mensaje = Validar(obj);

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Mascota.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Mascota obj, out string Mensaje)
        {
            Mensaje = Validar(obj);

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Mascota.Editar(obj, out Mensaje);
            }
        }

        public bool DarDeBaja(int numCliente, out string Mensaje)
        {
            return objcd_Mascota.DarDeBaja(numCliente, out Mensaje);
        }

        // ---------------- VALIDACIONES ----------------
        // Devuelve "" si está todo bien, o un texto con la lista de errores (uno por línea)
        private string Validar(Mascota obj)
        {
            string errores = string.Empty;

            // Nombre, raza y color: obligatorios, solo letras, 2 a 50 caracteres
            errores += ValidarTexto(obj.Nombre, "El nombre de la mascota");
            errores += ValidarTexto(obj.Raza, "La raza");
            errores += ValidarTexto(obj.Color, "El color");

            // Los combos deben tener SI o NO (el valor "-" significa que no eligió nada)
            if (obj.Alergico != "SI" && obj.Alergico != "NO")
            {
                errores += "• Indique si la mascota es alérgica (SI / NO).\n";
            }
            if (obj.AtencionEspecial != "SI" && obj.AtencionEspecial != "NO")
            {
                errores += "• Indique si la mascota requiere atención especial (SI / NO).\n";
            }

            errores += ValidarTexto(obj.UnDuenio.Nombre, "El nombre del dueño");

            // Celular: obligatorio, solo números, entre 8 y 15 dígitos
            string celu = obj.UnDuenio.CelDuenio;
            if (string.IsNullOrWhiteSpace(celu))
            {
                errores += "• El celular del dueño es obligatorio.\n";
            }
            else if (!Regex.IsMatch(celu, @"^\d+$"))
            {
                errores += "• El celular del dueño debe contener solo números.\n";
            }
            else if (celu.Length < 8 || celu.Length > 15)
            {
                errores += "• El celular del dueño debe tener entre 8 y 15 dígitos.\n";
            }

            // Observaciones: opcional, máximo 200 caracteres
            if (obj.Observaciones != null && obj.Observaciones.Length > 200)
            {
                errores += "• Las observaciones no pueden superar los 200 caracteres.\n";
            }

            if (errores != string.Empty)
            {
                errores = "Corrija los siguientes datos:\n\n" + errores;
            }
            return errores;
        }

        // Regla reutilizada para nombre, raza, color y nombre del dueño
        private string ValidarTexto(string valor, string campo)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                return "• " + campo + " es obligatorio.\n";
            }
            if (valor.Length < 2 || valor.Length > 50)
            {
                return "• " + campo + " debe tener entre 2 y 50 caracteres.\n";
            }
            // Expresión regular: empieza con una letra y luego solo letras, espacios, punto, apóstrofe o guion
            if (!Regex.IsMatch(valor, @"^\p{L}[\p{L} .'\-]*$"))
            {
                return "• " + campo + " solo puede contener letras y espacios.\n";
            }
            return string.Empty;
        }
    }
}
