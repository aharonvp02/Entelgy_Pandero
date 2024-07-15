SELECT 
A.codigo_asociado,
A.nombre_asociado,
A.apellidos_asociado,
AP.CodAprobador,
AP.NombresApellidosAprobador,
NC.fecha_solicitud AS fecha_hora_aprobacion
 FROM dbo.NotaCredito NC
INNER JOIN dbo.Asociado A ON A.ID_asociado = NC.ID_asociado
INNER JOIN dbo.Aprobador AP ON AP.CodAprobador = NC.CodAprobador