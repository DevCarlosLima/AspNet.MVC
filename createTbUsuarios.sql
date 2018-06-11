USE [crudmvc]
GO

/****** Object:  Table [dbo].[TB_USUARIOS]    Script Date: 11/06/2018 13:20:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_USUARIOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](150) NULL,
	[Email] [nvarchar](150) NULL,
	[Ativo] [int] NULL,
	[DataCadastro] [datetime] NULL,
	[DataAtualizacao] [datetime] NULL
) ON [PRIMARY]
GO

