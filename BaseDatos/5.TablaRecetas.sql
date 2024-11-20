USE [BDRECETAS]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Recetas](
	[Id] [uniqueidentifier] NOT NULL,
	[Codigo] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[PacienteId] [uniqueidentifier] NOT NULL,
	[Estado] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Recetas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

