/*Creacion de storeProcedures*/

CREATE PROCEDURE sp_ObtenerAprobadores
AS
BEGIN
    SELECT 
	CodAprobador, 
	NombresApellidosAprobador
    FROM dbo.Aprobador
END

CREATE PROCEDURE sp_InsertarAprobador
    @NombresApellidosAprobador NVARCHAR(250),
    @IdAprobador INT OUTPUT -- Definir parámetro de salida para el ID del aprobador
AS
BEGIN
    INSERT INTO dbo.Aprobador ( NombresApellidosAprobador )
    VALUES (@NombresApellidosAprobador)

    SET @IdAprobador = SCOPE_IDENTITY(); -- Obtener el ID del aprobador insertado
END

CREATE PROCEDURE sp_ObtenerAsociadoById
    @idAsociado int
AS
BEGIN
    SELECT 
	ID_asociado, 
	codigo_asociado, 
	nombre_asociado, 
	apellidos_asociado,
	 email_asociado, 
	 telefono_asociado, 
	 activo
    FROM Asociado
    WHERE ID_asociado =@idAsociado
END

CREATE PROCEDURE sp_ObtenerAsociadoByCodigo
    @codAsociado VARCHAR(50)
AS
BEGIN
    SELECT 
	ID_asociado, 
	codigo_asociado, 
	nombre_asociado, 
	apellidos_asociado,
	 email_asociado, 
	 telefono_asociado, 
	 activo
    FROM Asociado
    WHERE codigo_asociado =@codAsociado
END


CREATE PROCEDURE sp_InsertarNotaCredito
    @AsociadoId INT,
    @Importe MONEY,
    @NumeroCuotas INT,
    @Fecha DATETIME,
    @CodAprobador INT,
    @Sustento VARCHAR(50),
    @NotaCreditoId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        
        INSERT INTO NotaCredito (ID_asociado, importe_solicitud, numero_cuotas, fecha_solicitud, CodAprobador, sustento_aprobador)
        VALUES (@AsociadoId, @Importe, @NumeroCuotas, @Fecha, @CodAprobador, @Sustento);

          
        SET @NotaCreditoId = SCOPE_IDENTITY(); 

       
        INSERT INTO Log (ID_notaCredito, CodAprobador, fecha_hora_registro)
        VALUES (@NotaCreditoId, @CodAprobador, GETDATE());

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        
        THROW;
    END CATCH;
END

CREATE PROCEDURE sp_ObtenerAprobadorByCodigo
    @codAprobador int
AS
BEGIN
    SELECT 
	CodAprobador,
	NombresApellidosAprobador
    FROM dbo.Aprobador
    WHERE CodAprobador =@codAprobador
END