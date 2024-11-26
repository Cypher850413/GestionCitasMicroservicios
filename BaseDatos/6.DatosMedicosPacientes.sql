USE BDPERSONAS
GO

Select * From [dbo].[Medicos]

Insert into [dbo].[Medicos] (Id,Especialidad,Nombre,Apellido,TipoDocumento,Documento,Correo,Numerocontacto)
Values(NEWID(),'Medicina General','Jose Luis','Galindo Perez','CC','718735200','mieps@salud.com.co','3007886502'),
(NEWID(),'Cardiologia','Monica','Lopez Suarez','CC','4013735200','mieps2@salud.com.co','3007886405'),
(NEWID(),'Pediatria','Carlos','Ortega Guerrero','CC','4513735212','mieps3@salud.com.co','3017986310')

Select * From [dbo].[Pacientes]

Insert into [dbo].[Pacientes] (Id,Eps,Nombre,Apellido,TipoDocumento,Documento,Correo,Numerocontacto)
Values(NEWID(),'Sanitas','Luis Eduardo','Tellez Perez','CC','998735200','correo1@gmail.com','3107886502'),
(NEWID(),'Salud Total','Josefina','Buitrago Obregon','CC','2025735200','correo2@gmail.com','3108985023'),
(NEWID(),'Salud Total','Luisa Fernanda','Morales Cadena','TI','1234567852369','correo3@gmail.com','3157653422')