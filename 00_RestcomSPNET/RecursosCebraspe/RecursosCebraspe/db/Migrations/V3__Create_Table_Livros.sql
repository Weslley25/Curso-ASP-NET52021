CREATE TABLE [dbo].[Livro](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Autor] [varchar](100) NULL,
	[Data_lançamento] [datetime] NULL,
	[preço] [decimal](38,2) NOT NULL,
	[Titulo] [varchar](150) NULL,
 CONSTRAINT [PK_Livro] PRIMARY KEY CLUSTERED 
(
	[id] ASC
));