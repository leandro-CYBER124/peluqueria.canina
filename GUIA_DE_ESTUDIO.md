# Guía de estudio — Peluquería Canina (para rendir el final)

## 1. De qué trata el proyecto (en 3 líneas)
Aplicación de escritorio (Windows Forms, C#) para una peluquería canina: se cargan mascotas con su dueño,
se listan, se editan y se dan de baja. Está organizada en **4 capas** y toda la base de datos (MySQL) se
maneja con **procedimientos almacenados**. Sigue la misma estructura que el repo `SistemaVentasTaller`.

## 2. Mapa: repo del instituto ↔ este proyecto
| En `SistemaVentasTaller` | En Peluquería Canina | Qué hace |
|---|---|---|
| `CapaEntidad/Cliente.cs` | `CapaEntidad/Mascota.cs`, `Duenio.cs` | Entidad: solo propiedades |
| `CapaDatos/Conexion.cs` | `CapaDatos/Conexion.cs` | Lee la cadena `cadena_conexion` del App.config |
| `CapaDatos/CD_Cliente.cs` | `CapaDatos/CD_Mascota.cs` | Llama a los procedimientos almacenados |
| `CapaNegocio/CN_Cliente.cs` | `CapaNegocio/CN_Mascota.cs` | Valida y llama a la capa de datos |
| `CapaPresentacion/frmClientes.cs` | `VerDatos.cs` | Listado en grilla, editar y dar de baja |
| `Modales/mdClienteDetalle` (alta y edición) | `CargaDatos.cs` y `ModificarDatos.cs` | Formularios de alta y edición |
| `sp_RegistrarCliente` | `sp_RegistrarMascota` | Inserta y devuelve id y mensaje |
| `sp_ModificarCliente` | `sp_ModificarMascota` | Actualiza y devuelve resultado y mensaje |
| `SP_EliminarCliente` (hace `Estado = 0`) | `sp_DarDeBajaMascota` | Baja lógica |
| `App.config` | `CapaPresentacion/App.config` | Cadena de conexión |

Diferencias: el repo usa **SQL Server** (`System.Data.SqlClient`) y este proyecto **MySQL** (`MySql.Data`);
las clases cambian de nombre (`SqlConnection` → `MySqlConnection`) pero se usan igual. En el repo, `Listar`
usa una consulta directa y el resto procedimientos; acá `Listar` también usa uno.

## 3. Recorrido completo: "Guardar una mascota"
1. **`CargaDatos.btnGuardar_Click`** arma un objeto `Mascota` (con su `Duenio`) con lo que escribió el usuario.
2. Llama a **`CN_Mascota.Registrar(obj, out mensaje)`** (capa de negocio).
3. **`CN_Mascota.Validar`** revisa las reglas. Si hay errores, devuelve 0 y el texto con los errores: **no llega a la base**.
4. Si está todo bien, llama a **`CD_Mascota.Registrar`** (capa de datos).
5. `CD_Mascota` abre la conexión, carga los parámetros y ejecuta **`sp_RegistrarMascota`**.
6. En MySQL, el procedimiento inserta el dueño, inserta la mascota con el id del dueño y devuelve
   `p_Resultado` (id generado) y `p_Mensaje`, todo dentro de una **transacción**.
7. El resultado vuelve por las capas hasta `CargaDatos`, que muestra "Guardado Exitoso" o el error.

Regla de oro: **Presentación → Negocio → Datos → Base de datos**. Cada capa solo conoce a la de abajo.

## 4. Conceptos clave (definiciones cortas)
- **Arquitectura en capas:** separar el programa en partes con una responsabilidad cada una (pantallas, reglas, acceso a datos, entidades). Facilita cambiar o probar una parte sin romper las otras.
- **Entidad:** clase que representa una fila de una tabla; solo tiene propiedades.
- **ADO.NET:** conjunto de clases de .NET para conectarse a una base (`Connection`, `Command`, `DataReader`).
- **Procedimiento almacenado:** código SQL guardado dentro de la base de datos que se ejecuta por su nombre. Ventajas: la lógica de datos queda en la base, es más ordenado y evita armar SQL en C#.
- **Parámetros IN / OUT:** de entrada (datos que se envían) y de salida (valores que el procedimiento devuelve, como `p_Resultado` y `p_Mensaje`).
- **Baja lógica:** en vez de borrar el registro (`DELETE`) se marca como no activo (`Estado = 0`). Se conserva el historial y se puede recuperar.
- **Validación en la capa de negocio:** las reglas se controlan antes de tocar la base de datos.
- **`using`:** cierra y libera la conexión automáticamente al terminar el bloque.
- **`try / catch`:** captura errores para mostrar un mensaje en vez de que se cierre el programa.
- **Transacción:** varias operaciones que se completan todas o ninguna (`START TRANSACTION`, `COMMIT`, `ROLLBACK`). Se usa al guardar dueño y mascota juntos.
- **`DataTable` y `DataGridView`:** la tabla en memoria y el control que la muestra en pantalla.
- **Evento:** acción del usuario que dispara código (por ejemplo `btnGuardar_Click`).
- **Expresión regular (`Regex`):** patrón para validar texto, por ejemplo que el celular tenga solo dígitos.

## 5. Preguntas típicas y respuestas cortas
1. **¿Por qué usaron capas?** Para separar responsabilidades: si cambia la base solo se toca CapaDatos; si cambian las reglas, CapaNegocio; si cambia el diseño, CapaPresentacion.
2. **¿Qué hace cada capa?** Entidad: modela los datos. Datos: habla con la base. Negocio: valida. Presentación: pantallas.
3. **¿Por qué la pantalla no habla directo con la base?** Para no mezclar el diseño con el acceso a datos y poder reutilizar y mantener el código.
4. **¿Dónde se validan los datos?** En `CN_Mascota.Validar`. Además el celular solo acepta números en la pantalla.
5. **¿Qué es la baja lógica y por qué?** Marcar `Estado = 0` en lugar de borrar, para no perder el historial.
6. **¿Cómo se conecta la aplicación a MySQL?** Con `MySqlConnection` y la cadena `cadena_conexion` del App.config, leída en `Conexion.cs`.
7. **¿Cómo se llama a un procedimiento almacenado desde C#?** Con `MySqlCommand`, `CommandType.StoredProcedure`, agregando los parámetros y `ExecuteNonQuery()`; para consultas, `ExecuteReader()`.
8. **¿Para qué sirven los parámetros de salida?** Para que el procedimiento devuelva el resultado (id generado u OK) y un mensaje.
9. **¿Qué pasa si falla el guardado del dueño o de la mascota?** El procedimiento hace `ROLLBACK`: no queda ninguno de los dos guardado.
10. **¿Cómo agregarías una consulta nueva?** Procedimiento en MySQL → método en `CD_Mascota` → método en `CN_Mascota` → botón y evento en la pantalla (ver `LEEME.md`).

## 6. Archivos para repasar primero (en orden)
1. `BaseDatos/peluqueria_canina.sql` (tablas y procedimientos)
2. `CapaEntidad/Mascota.cs`
3. `CapaDatos/CD_Mascota.cs`
4. `CapaNegocio/CN_Mascota.cs`
5. `CapaPresentacion/CargaDatos.cs` y `VerDatos.cs`
