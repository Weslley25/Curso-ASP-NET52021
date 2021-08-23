CREATE TABLE [dbo].[Pessoa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NULL,
	[Cpf] [bigint] NULL,
	[atendimentoespecial] [bit] NULL,
 CONSTRAINT [PK_Pessoas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
));