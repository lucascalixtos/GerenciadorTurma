CREATE DATABASE [GerenciadorTurma]

USE [GerenciadorTurma]
GO
/****** Object:  Table [dbo].[aluno]    Script Date: 21/04/2024 19:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aluno](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](255) NOT NULL,
	[usuario] [varchar](45) NOT NULL,
	[senha] [char](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aluno_turma]    Script Date: 21/04/2024 19:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aluno_turma](
	[aluno_id] [int] NOT NULL,
	[turma_id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[turma]    Script Date: 21/04/2024 19:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[turma](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[curso_id] [int] NOT NULL,
	[turma] [varchar](45) NOT NULL,
	[ano] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[aluno_turma]  WITH CHECK ADD  CONSTRAINT [fk_aluno] FOREIGN KEY([aluno_id])
REFERENCES [dbo].[aluno] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[aluno_turma] CHECK CONSTRAINT [fk_aluno]
GO
ALTER TABLE [dbo].[aluno_turma]  WITH CHECK ADD  CONSTRAINT [fk_turma] FOREIGN KEY([turma_id])
REFERENCES [dbo].[turma] ([id])
GO
ALTER TABLE [dbo].[aluno_turma] CHECK CONSTRAINT [fk_turma]
GO
