# Peluquería Canina — C# en capas con procedimientos almacenados (MySQL)

Misma estructura que el repo `SistemaVentasTaller`: CapaEntidad, CapaDatos, CapaNegocio y CapaPresentacion
(Windows Forms), en **.NET Framework 4.7.2**. La aplicación no escribe SQL: llama a procedimientos
almacenados de MySQL. Para estudiar el código, leé `GUIA_DE_ESTUDIO.md`.

## Cómo ejecutarlo
1. En MySQL Workbench: File > Open SQL Script > `BaseDatos/peluqueria_canina.sql` y ejecutarlo con el rayo.
   Crea la base `peluqueria_canina`, las tablas `Duenio` y `Mascota`, los 4 procedimientos y datos de ejemplo.
   (Borra la base `peluqueria_canina` si ya existía.)
2. Abrir `CapaPresentacion/App.config` y reemplazar `TU_CONTRASEÑA` por la contraseña de tu MySQL
   (la de Workbench). Si el usuario no es `root`, cambiarlo también.
3. Abrir `SistemaPeluqueria.sln` en Visual Studio 2022, dejar como proyecto de inicio `CapaPresentacion` y F5.
   La primera vez, Visual Studio descarga solo el paquete `MySql.Data` (hace falta internet).

## Capas
| Capa | Qué tiene |
|---|---|
| CapaEntidad | `Mascota`, `Duenio` (solo propiedades) |
| CapaDatos | `Conexion` (lee `cadena_conexion` del App.config) y `CD_Mascota` (llama a los procedimientos) |
| CapaNegocio | `CN_Mascota`: validaciones y paso de datos a CapaDatos |
| CapaPresentacion | `Principal`, `CargaDatos`, `VerDatos`, `ModificarDatos` |

## Procedimientos almacenados
`sp_ListarMascotas`, `sp_RegistrarMascota`, `sp_ModificarMascota`, `sp_DarDeBajaMascota`
(los de registrar, modificar y dar de baja devuelven `p_Resultado` y `p_Mensaje`, igual que en el repo).

## Validaciones (CapaNegocio/CN_Mascota.cs)
- Nombre de mascota, raza, color y nombre del dueño: obligatorios, solo letras y espacios, 2 a 50 caracteres.
- Alérgico y Atención Especial: SI o NO (no puede quedar en "-").
- Celular: obligatorio, solo números (el campo no deja escribir letras), 8 a 15 dígitos.
- Observaciones: opcional, hasta 200 caracteres.

## Baja lógica
**Dar de Baja** pide confirmación y el procedimiento pone `Estado = 0`. No se borra nada. El combo
"Mostrar" permite ver Activas, Dadas de baja o Todas (las de baja se ven en gris).

## Cómo agregar una consulta nueva (ejemplo: buscar por nombre)
1. MySQL: crear `sp_BuscarMascotas(IN p_Texto VARCHAR(50))` con `WHERE m.Nombre LIKE CONCAT('%', p_Texto, '%')`.
2. CapaDatos: un método en `CD_Mascota` igual a `Listar()` pero con `cmd.Parameters.AddWithValue("p_Texto", texto)`.
3. CapaNegocio: un método en `CN_Mascota` que lo llame.
4. CapaPresentacion: un TextBox y un botón en el formulario, y el evento `Click` que llama a `CN_Mascota`.

## Nota sobre los .csproj
Los proyectos apuntan a .NET Framework 4.7.2 (igual que el repo), pero usan el formato moderno de `.csproj`
(con `PackageReference`) para que Visual Studio descargue `MySql.Data` solo. Para el código no cambia nada.
