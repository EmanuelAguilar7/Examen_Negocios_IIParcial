USE tempdb
GO

CREATE DATABASE ERP
GO

USE ERP
GO

CREATE SCHEMA Usuario
GO

CREATE TABLE Usuario.Usuario
(
	Id INT IDENTITY(1,1) NOT NULL
	CONSTRAINT PK_Usuario_Usuario_Id PRIMARY KEY CLUSTERED,
	Nombre NVARCHAR(25) NOT NULL,
	Apellido NVARCHAR(25) NOT NULL,
	Nom_Usuario NVARCHAR(6) NOT NULL,
	Contraseña NVARCHAR(25) NOT NULL,
	Correo_Electronico NVARCHAR(50) NOT NULL,
	Fecha_Creacion DATETIME DEFAULT GETDATE(),
	Ultima_Conexion DATETIME,
	Tipo_Usuario NVARCHAR(25) NOT NULL,
	Estado NVARCHAR(25) NOT NULL
)
GO

CREATE TABLE Usuario.Tipo_Usuario
(
	Tipo_Usuario NVARCHAR(25) NOT NULL
	CONSTRAINT PK_Usuario_Tipo_Usuario_Id PRIMARY KEY CLUSTERED,
)
GO

CREATE TABLE Usuario.Estado
(
	Estado NVARCHAR(25)
	CONSTRAINT PK_Usuario_Estado_Id PRIMARY KEY CLUSTERED,
)
GO


ALTER TABLE Usuario.Usuario
	ADD CONSTRAINT FK_Usuario_Usuario_Tipo_Usuario$Usuario_Tipo_Usuario_Id
	FOREIGN KEY (Tipo_Usuario) REFERENCES Usuario.Tipo_Usuario(Tipo_Usuario)
	ON UPDATE CASCADE
	ON DELETE NO ACTION
GO

ALTER TABLE Usuario.Usuario
	ADD CONSTRAINT FK_Usuario_Usuario_Estado$Usuario_Estado_Id
	FOREIGN KEY (Estado) REFERENCES Usuario.Estado(Estado)
	ON UPDATE CASCADE
	ON DELETE NO ACTION
GO

INSERT INTO Usuario.Tipo_Usuario(Tipo_Usuario)
VALUES('Regular'),
		('Administrador'),
		('SuperUsuario')
GO

INSERT INTO Usuario.Estado(Estado)
VALUES('Activo'),
		('Inactivo')
GO

INSERT INTO Usuario.Usuario(Nombre,Apellido,Nom_Usuario,Contraseña,Correo_Electronico,Tipo_Usuario,Estado)
VALUES('Emanuel','Aguilar','Ema7','123456','emanuelaguilar68@yahoo.com','SuperUsuario','Activo')
GO

SELECT * FROM Usuario.Usuario

USE tempdb
GO
DROP DATABASE ERP
GO