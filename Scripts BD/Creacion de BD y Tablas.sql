/*Crear BD*/

CREATE DATABASE Entelgy
USE Entelgy

/*Crar Tablas*/

-- Crear tabla Aprobador	
CREATE TABLE Aprobador (
    CodAprobador INT IDENTITY(1,1) PRIMARY KEY,
    NombresApellidosAprobador VARCHAR(250) NOT NULL
);

-- Crear tabla Asociado
CREATE TABLE Asociado (
    ID_asociado INT IDENTITY(1,1) PRIMARY KEY,
    codigo_asociado VARCHAR(50) NOT NULL,
    nombre_asociado VARCHAR(100) NOT NULL,
    apellidos_asociado VARCHAR(100) NOT NULL,
    email_asociado VARCHAR(100),
    telefono_asociado BIGINT ,
    activo bit NOT NULL,
);

-- Crear tabla NotaCredito
CREATE TABLE NotaCredito (
    ID_notaCredito INT IDENTITY(1,1) PRIMARY KEY,
    ID_asociado INT NOT NULL,
    CodAprobador INT NOT NULL,
    sustento_aprobador VARCHAR(50) NOT NULL,
    importe_solicitud MONEY NOT NULL,
    numero_cuotas INT NOT NULL,
    fecha_solicitud DATETIME NOT NULL,
    FOREIGN KEY (ID_asociado) REFERENCES Asociado(ID_asociado),
    FOREIGN KEY (CodAprobador) REFERENCES Aprobador(CodAprobador)
);

-- Crear tabla log
CREATE TABLE Log (
    ID_log INT IDENTITY(1,1) PRIMARY KEY,
    ID_notaCredito INT NOT NULL,
    CodAprobador INT NOT NULL,
    fecha_hora_registro DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (ID_notaCredito) REFERENCES NotaCredito(ID_notaCredito),
    FOREIGN KEY (CodAprobador) REFERENCES Aprobador(CodAprobador)
);