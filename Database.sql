SET NOCOUNT ON
GO

USE master
GO
if exists (select * from sysdatabases where name='PruebaAdmision')
		drop database PruebaAdmision
go

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE PruebaAdmision
  ON PRIMARY (NAME = N''PruebaAdmision'', FILENAME = N''' + @device_directory + N'PruebAdmin.mdf'')
  LOG ON (NAME = N''PruebaAdmision_log'',  FILENAME = N''' + @device_directory + N'PruebAdmin.ldf'')')
go

if CAST(SERVERPROPERTY('ProductMajorVersion') AS INT)<12 
BEGIN
  exec sp_dboption 'PruebaAdmision','trunc. log on chkpt.','true'
  exec sp_dboption 'PruebaAdmision','select into/bulkcopy','true'
END
ELSE ALTER DATABASE [PruebaAdmision] SET RECOVERY SIMPLE WITH NO_WAIT
GO

set quoted_identifier on
GO

SET DATEFORMAT mdy
GO



use "PruebaAdmision"
go

if exists (select * from sysobjects where id = object_id('dbo.Clientes') and sysstat & 0xf = 3)
	drop table dbo.Clientes

if exists (select * from sysobjects where id = object_id('dbo.TipoContactos') and sysstat & 0xf = 3)
	drop table dbo.TipoContactos

CREATE TABLE dbo.TipoContactos (
    CodTipoCliente int IDENTITY(1,1) PRIMARY KEY,
    Descricion varchar(50) NOT NULL,
  
);
CREATE TABLE dbo.Clientes (
    CodClient int IDENTITY(1,1) PRIMARY KEY,
    Usuario varchar(50) NOT NULL,
    Nombres varchar(255) NOT NULL,
	Cargo varchar(100) NOT NULL,
	Telefono varchar(20) NOT NULL,
	Correo varchar(100) NOT NULL,
    CodTipoClienteFK int FOREIGN KEY REFERENCES TipoContactos(CodTipoCliente)

);

INSERT INTO [dbo].[TipoContactos]
           ([Descricion])
     VALUES
           ('Contacto Comercial')
INSERT INTO [dbo].[TipoContactos]
           ([Descricion])
     VALUES
           ('Pago de factura')
INSERT INTO [dbo].[TipoContactos]
           ([Descricion])
     VALUES
           ('Representante legal')
INSERT INTO [dbo].[TipoContactos]
           ([Descricion])
     VALUES
           ('Retiro de mercadería')


GO





CREATE PROCEDURE ClientesInsert
(
    @Usuario varchar(50),
    @Nombres varchar(255),
    @Cargo varchar(100),
    @Telefono varchar(20),
    @Correo varchar(100),
    @CodTipoClienteFK int
)
AS
BEGIN
    INSERT INTO [dbo].[Clientes]
           ([Usuario]
           ,[Nombres]
           ,[Cargo]
           ,[Telefono]
           ,[Correo]
           ,[CodTipoClienteFK])
     VALUES
           (@Usuario,
            @Nombres,
            @Cargo,
            @Telefono,
            @Correo,
            @CodTipoClienteFK);   
END
GO

CREATE PROCEDURE ClientesUpdate
(
    @CodClient int,
    @Usuario varchar(50),
    @Nombres varchar(255),
    @Cargo varchar(100),
    @Telefono varchar(20),
    @Correo varchar(100),
    @CodTipoClienteFK int
)
AS
BEGIN

    UPDATE Clientes
        SET
            Usuario = @Usuario,
            Nombres = @Nombres,
            Cargo = @Cargo,
            Telefono = @Telefono,
            Correo = @Correo,
            CodTipoClienteFK = @CodTipoClienteFK
        where CodClient = @CodClient

END
GO

CREATE PROCEDURE ClientesDelete
(
    @CodClient nchar (5)
)
AS
BEGIN

    DELETE Clientes
    WHERE CodClient = @CodClient

END
GO

CREATE PROCEDURE ClientesList
AS
BEGIN

    SELECT CodClient,[Usuario]
           ,[Nombres]
           ,[Cargo]
           ,[Telefono]
           ,[Correo]
           ,[CodTipoClienteFK]
    FROM Clientes

END
GO

CREATE PROCEDURE ClientesGetByID
(
    @CodClient nchar (5)
)
AS
BEGIN

    SELECT CodClient,[Usuario]
           ,[Nombres]
           ,[Cargo]
           ,[Telefono]
           ,[Correo]
           ,[CodTipoClienteFK]
    FROM Clientes
    where CodClient = @CodClient
END
GO