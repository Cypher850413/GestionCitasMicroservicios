USE BDRECETAS
GO

Select * From [dbo].[Recetas]

Insert into [dbo].[Recetas] (Id,Codigo,Descripcion,PacienteID,Estado)
Values(NEWID(),'AG001','ACETAMINOFEN 500 MG','5A7E2586-CFD4-40A9-9EB1-134F1D4ECBF6','Activa')