

/****** Object:  Table [dbo].[tblHistory]    Script Date: 2/20/2019 6:37:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ObjectId] [uniqueidentifier] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[Content] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_tblHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblHistory]  WITH CHECK ADD  CONSTRAINT [FK_History_Product] FOREIGN KEY([ObjectId])
REFERENCES [dbo].[tblProducts] ([Id])
GO

ALTER TABLE [dbo].[tblHistory] CHECK CONSTRAINT [FK_History_Product]
GO


