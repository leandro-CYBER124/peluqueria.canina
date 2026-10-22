using System;
using System.Collections.Generic;
using System.Data;
using CapaEntidad;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    // CAPA DE DATOS: es la única que habla con la base de datos.
    // No usa consultas SQL escritas acá: llama a PROCEDIMIENTOS ALMACENADOS guardados en MySQL.
    public class CD_Mascota
    {
        // Trae todas las mascotas (activas y dadas de baja) llamando a sp_ListarMascotas
        public List<Mascota> Listar()
        {
            List<Mascota> lista = new List<Mascota>();

            // "using" cierra la conexión automáticamente al terminar el bloque
            using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("sp_ListarMascotas", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;   // le indica que es un procedimiento almacenado

                    oconexion.Open();

                    // El DataReader recorre el resultado fila por fila
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Por cada fila se arma una entidad Mascota (con su Duenio)
                            lista.Add(new Mascota
                            {
                                NumCliente = Convert.ToInt32(dr["NumCliente"]),
                                Nombre = dr["Nombre"].ToString(),
                                Raza = dr["Raza"].ToString(),
                                Color = dr["Color"].ToString(),
                                Alergico = dr["Alergico"].ToString(),
                                AtencionEspecial = dr["AtencionEspecial"].ToString(),
                                Observaciones = dr["Observaciones"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                UnDuenio = new Duenio
                                {
                                    IdDuenio = Convert.ToInt32(dr["IdDuenio"]),
                                    Nombre = dr["NombreDuenio"].ToString(),
                                    CelDuenio = dr["CelDuenio"].ToString()
                                }
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Se relanza el error para saber exactamente qué falló en la base
                    throw new Exception("Error al consultar mascotas: " + ex.Message);
                }
            }
            return lista;
        }

        // Guarda dueño + mascota con sp_RegistrarMascota.
        // Devuelve el NumCliente generado (0 si falló) y un mensaje por el parámetro "out".
        public int Registrar(Mascota obj, out string Mensaje)
        {
            int idGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("sp_RegistrarMascota", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de ENTRADA (los nombres coinciden con los del procedimiento)
                    cmd.Parameters.AddWithValue("p_Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("p_Raza", obj.Raza);
                    cmd.Parameters.AddWithValue("p_Color", obj.Color);
                    cmd.Parameters.AddWithValue("p_Alergico", obj.Alergico);
                    cmd.Parameters.AddWithValue("p_AtencionEspecial", obj.AtencionEspecial);
                    cmd.Parameters.AddWithValue("p_Observaciones", obj.Observaciones ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("p_NombreDuenio", obj.UnDuenio.Nombre);
                    cmd.Parameters.AddWithValue("p_CelDuenio", obj.UnDuenio.CelDuenio);

                    // Parámetros de SALIDA: el procedimiento los completa y acá los leemos
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();   // ejecuta el procedimiento (no devuelve filas)

                    idGenerado = Convert.ToInt32(cmd.Parameters["p_Resultado"].Value);
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idGenerado = 0;
                Mensaje = ex.Message;
            }
            return idGenerado;
        }

        // Modifica la mascota y su dueño con sp_ModificarMascota. Devuelve true si salió bien.
        public bool Editar(Mascota obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("sp_ModificarMascota", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_NumCliente", obj.NumCliente);
                    cmd.Parameters.AddWithValue("p_Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("p_Raza", obj.Raza);
                    cmd.Parameters.AddWithValue("p_Color", obj.Color);
                    cmd.Parameters.AddWithValue("p_Alergico", obj.Alergico);
                    cmd.Parameters.AddWithValue("p_AtencionEspecial", obj.AtencionEspecial);
                    cmd.Parameters.AddWithValue("p_Observaciones", obj.Observaciones ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("p_NombreDuenio", obj.UnDuenio.Nombre);
                    cmd.Parameters.AddWithValue("p_CelDuenio", obj.UnDuenio.CelDuenio);

                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    // El procedimiento devuelve 1 si modificó y 0 si no
                    respuesta = Convert.ToInt32(cmd.Parameters["p_Resultado"].Value) == 1;
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }

        // BAJA LÓGICA: sp_DarDeBajaMascota no borra el registro, solo pone Estado = 0.
        // (En el repo del instituto este método se llama Eliminar y hace lo mismo.)
        public bool DarDeBaja(int numCliente, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (MySqlConnection oconexion = new MySqlConnection(Conexion.cadena))
                {
                    MySqlCommand cmd = new MySqlCommand("sp_DarDeBajaMascota", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_NumCliente", numCliente);

                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToInt32(cmd.Parameters["p_Resultado"].Value) == 1;
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }
    }
}
