CREATE TRIGGER Solicitud_Update
on SolicitudGeneral
 

AFTER UPDATE
  AS
  BEGIN
set nocount on;

DECLARE 

	@iduser         int, 	
	@id             int, 
	@descripcion    varchar(250), 
    @olddescripcion varchar(250), 
	@inicio         date, 
	@final          date,
	@path           varchar(max),
	@oldpath        varchar(max),
	@user           varchar(30),
	@new            varchar(max),
	@old            varchar(max)

Select @id=              IdSolicitud      FROM inserted
Select @iduser=          IdUsuario        FROM inserted
Select @descripcion=     Descripcion      FROM inserted
Select @inicio=          FechaInicio      FROM inserted
Select @final=           FechaFinal       FROM inserted
Select @path=            Path             FROM inserted
SELECT @user=            AccesoUsuario    FROM Usuario   WHERE @iduser=IdUsuario
Select @olddescripcion=  Descripcion      FROM deleted
Select @oldpath=         Path             FROM deleted

Select @new=          CONCAT('ID Solicitud: ',@id,' Descripción: ',@descripcion,' Fecha de inicio: ',@inicio,' Fecha Final: ',@final,' Path: ',@path)
Select @old=          CONCAT('ID Solicitud: ',@id,' Descripción: ',@olddescripcion,' Fecha de inicio: ',@inicio,' Fecha Final: ',@final,' Path: ',@oldpath)

BEGIN
		INSERT INTO Bitacora (Pantalla, Accion,Usuario,Descripcion,FechaBitacora,RegistroAnterior,RegistroNuevo) VALUES ('Solicitud General Index',3,@user,'Proceso de edición en: Solicitud General Index',GETDATE(),@old,@new)
END
END


