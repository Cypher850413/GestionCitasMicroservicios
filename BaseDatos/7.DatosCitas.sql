USE BDCITAS
GO

Select * From [dbo].[Citas]

Insert into [dbo].[Citas] (Id,Fecha,Lugar,PacienteID,MedicoId,Estado)
Values(NEWID(),getdate(),'Virrey Solis','5A7E2586-CFD4-40A9-9EB1-134F1D4ECBF6','D7C042C9-13D7-4C45-9BA0-2F93B51D08DA','Pendiente')
