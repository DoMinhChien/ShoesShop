USE [StoreManagement]
GO

/****** Object:  Table [dbo].[tblHistoryDetail]    Script Date: 2/20/2019 6:38:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblHistoryDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HistoryId] [int] NOT NULL,
	[OldValue] [nvarchar](500) NULL,
	[NewValue] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_HistoryDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblHistoryDetail] ADD  CONSTRAINT [DF_HistoryDetail_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[tblHistoryDetail]  WITH CHECK ADD  CONSTRAINT [FK_History_HistoryDetail] FOREIGN KEY([HistoryId])
REFERENCES [dbo].[tblHistory] ([Id])
GO

ALTER TABLE [dbo].[tblHistoryDetail] CHECK CONSTRAINT [FK_History_HistoryDetail]
GO


