USE [BDPERSONAS]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pacientes](
	[Id] [uniqueidentifier] NOT NULL,
	[Eps] [nvarchar](max) NULL,
	[Nombre] [nvarchar](max) NULL,
	[Apellido] [nvarchar](max) NULL,
	[TipoDocumento] [nvarchar](max) NULL,
	[Documento] [nvarchar](max) NULL,
	[Correo] [nvarchar](max) NULL,
	[NumeroContacto] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Pacientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


