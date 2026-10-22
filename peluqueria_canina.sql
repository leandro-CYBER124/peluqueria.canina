-- =====================================================================
--  Peluquería Canina - Base de datos con procedimientos almacenados
--  Para MySQL Workbench
--
--  Cómo usarlo:
--    1) Abrir MySQL Workbench y conectarse al servidor local.
--    2) File > Open SQL Script... y elegir este archivo.
--    3) Ejecutar todo con el rayo (Ctrl+Shift+Enter).
--    4) Actualizar el panel SCHEMAS: aparece "peluqueria_canina".
--
--  ATENCIÓN: la primera línea borra la base si ya existía (para partir
--  de cero). Si tenés datos que querés conservar, no la ejecutes.
--
--  La aplicación C# NO escribe SQL: llama a estos procedimientos
--  (sp_ListarMascotas, sp_RegistrarMascota, sp_ModificarMascota y
--  sp_DarDeBajaMascota).
-- =====================================================================

DROP DATABASE IF EXISTS peluqueria_canina;
CREATE DATABASE peluqueria_canina CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE peluqueria_canina;

-- ---------------------------------------------------------------------
--  TABLAS
-- ---------------------------------------------------------------------
CREATE TABLE Duenio (
    IdDuenio   INT          NOT NULL AUTO_INCREMENT,
    Nombre     VARCHAR(50)  NOT NULL,
    CelDuenio  VARCHAR(15)  NOT NULL,
    PRIMARY KEY (IdDuenio)
);

-- Estado = 1 -> mascota activa | Estado = 0 -> dada de baja (baja lógica)
CREATE TABLE Mascota (
    NumCliente        INT           NOT NULL AUTO_INCREMENT,
    Nombre            VARCHAR(50)   NOT NULL,
    Raza              VARCHAR(50)   NOT NULL,
    Color             VARCHAR(50)   NOT NULL,
    Alergico          VARCHAR(2)    NOT NULL,
    AtencionEspecial  VARCHAR(2)    NOT NULL,
    Observaciones     VARCHAR(200)  NULL,
    Estado            TINYINT(1)    NOT NULL DEFAULT 1,
    IdDuenio          INT           NOT NULL,
    PRIMARY KEY (NumCliente),
    CONSTRAINT FK_Mascota_Duenio FOREIGN KEY (IdDuenio) REFERENCES Duenio (IdDuenio)
);

-- ---------------------------------------------------------------------
--  PROCEDIMIENTOS ALMACENADOS
-- ---------------------------------------------------------------------
DELIMITER $$

-- Lista todas las mascotas (activas y dadas de baja) con los datos del dueño
CREATE PROCEDURE sp_ListarMascotas()
BEGIN
    SELECT m.NumCliente, m.Nombre, m.Raza, m.Color, m.Alergico, m.AtencionEspecial,
           m.Observaciones, m.Estado,
           d.IdDuenio, d.Nombre AS NombreDuenio, d.CelDuenio
    FROM Mascota m
    INNER JOIN Duenio d ON d.IdDuenio = m.IdDuenio
    ORDER BY m.NumCliente;
END$$

-- Registra el dueño y la mascota juntos. p_Resultado = NumCliente generado (0 si falló)
CREATE PROCEDURE sp_RegistrarMascota(
    IN  p_Nombre            VARCHAR(50),
    IN  p_Raza              VARCHAR(50),
    IN  p_Color             VARCHAR(50),
    IN  p_Alergico          VARCHAR(2),
    IN  p_AtencionEspecial  VARCHAR(2),
    IN  p_Observaciones     VARCHAR(200),
    IN  p_NombreDuenio      VARCHAR(50),
    IN  p_CelDuenio         VARCHAR(15),
    OUT p_Resultado         INT,
    OUT p_Mensaje           VARCHAR(500)
)
BEGIN
    DECLARE v_IdDuenio INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al registrar la mascota';
    END;

    SET p_Resultado = 0;
    SET p_Mensaje = '';

    START TRANSACTION;

    INSERT INTO Duenio (Nombre, CelDuenio) VALUES (p_NombreDuenio, p_CelDuenio);
    SET v_IdDuenio = LAST_INSERT_ID();

    INSERT INTO Mascota (Nombre, Raza, Color, Alergico, AtencionEspecial, Observaciones, Estado, IdDuenio)
    VALUES (p_Nombre, p_Raza, p_Color, p_Alergico, p_AtencionEspecial, p_Observaciones, 1, v_IdDuenio);

    SET p_Resultado = LAST_INSERT_ID();
    COMMIT;

    SET p_Mensaje = 'Mascota registrada correctamente';
END$$

-- Modifica los datos de la mascota y de su dueño. p_Resultado = 1 si salió bien
CREATE PROCEDURE sp_ModificarMascota(
    IN  p_NumCliente        INT,
    IN  p_Nombre            VARCHAR(50),
    IN  p_Raza              VARCHAR(50),
    IN  p_Color             VARCHAR(50),
    IN  p_Alergico          VARCHAR(2),
    IN  p_AtencionEspecial  VARCHAR(2),
    IN  p_Observaciones     VARCHAR(200),
    IN  p_NombreDuenio      VARCHAR(50),
    IN  p_CelDuenio         VARCHAR(15),
    OUT p_Resultado         INT,
    OUT p_Mensaje           VARCHAR(500)
)
BEGIN
    DECLARE v_IdDuenio INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al modificar la mascota';
    END;

    SET p_Resultado = 0;
    SET p_Mensaje = '';

    SELECT IdDuenio INTO v_IdDuenio FROM Mascota WHERE NumCliente = p_NumCliente;

    IF v_IdDuenio IS NULL THEN
        SET p_Mensaje = 'La mascota no existe';
    ELSE
        START TRANSACTION;

        UPDATE Mascota
        SET Nombre = p_Nombre, Raza = p_Raza, Color = p_Color, Alergico = p_Alergico,
            AtencionEspecial = p_AtencionEspecial, Observaciones = p_Observaciones
        WHERE NumCliente = p_NumCliente;

        UPDATE Duenio
        SET Nombre = p_NombreDuenio, CelDuenio = p_CelDuenio
        WHERE IdDuenio = v_IdDuenio;

        COMMIT;

        SET p_Resultado = 1;
        SET p_Mensaje = 'Mascota modificada correctamente';
    END IF;
END$$

-- Baja lógica: no se borra nada, Estado pasa a 0
CREATE PROCEDURE sp_DarDeBajaMascota(
    IN  p_NumCliente  INT,
    OUT p_Resultado   INT,
    OUT p_Mensaje     VARCHAR(500)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al dar de baja la mascota';
    END;

    SET p_Resultado = 0;
    SET p_Mensaje = '';

    UPDATE Mascota SET Estado = 0 WHERE NumCliente = p_NumCliente;

    IF ROW_COUNT() > 0 THEN
        SET p_Resultado = 1;
        SET p_Mensaje = 'Mascota dada de baja correctamente';
    ELSE
        SET p_Mensaje = 'La mascota no existe o ya estaba dada de baja';
    END IF;
END$$

DELIMITER ;

-- ---------------------------------------------------------------------
--  DATOS DE EJEMPLO (opcional, se pueden borrar)
-- ---------------------------------------------------------------------
CALL sp_RegistrarMascota('Firulais', 'Labrador', 'Marron', 'NO', 'NO', 'Muy tranquilo',        'Juan Perez',   '3814001122', @res, @msg);
CALL sp_RegistrarMascota('Luna',     'Caniche',  'Blanco', 'SI', 'SI', 'Alergica al shampoo',  'Maria Lopez',  '3815003344', @res, @msg);
CALL sp_RegistrarMascota('Rocky',    'Bulldog',  'Gris',   'NO', 'SI', 'Cliente dado de baja', 'Carlos Gomez', '3816005566', @res, @msg);
CALL sp_DarDeBajaMascota(3, @res, @msg);

-- ---------------------------------------------------------------------
--  CONSULTAS ÚTILES PARA LA PRESENTACIÓN
-- ---------------------------------------------------------------------

-- 1) Todas las mascotas con su dueño (llama al procedimiento que usa la app)
CALL sp_ListarMascotas();

-- 2) Solo las activas
SELECT NumCliente, Nombre, Raza FROM Mascota WHERE Estado = 1;

-- 3) Las dadas de baja
SELECT NumCliente, Nombre, Raza FROM Mascota WHERE Estado = 0;

-- 4) Mascotas alérgicas y activas
SELECT Nombre, Raza FROM Mascota WHERE Alergico = 'SI' AND Estado = 1;

-- 5) Buscar por nombre
SELECT * FROM Mascota WHERE Nombre LIKE '%Lu%';

-- 6) Cantidad de mascotas activas
SELECT COUNT(*) AS TotalActivas FROM Mascota WHERE Estado = 1;
