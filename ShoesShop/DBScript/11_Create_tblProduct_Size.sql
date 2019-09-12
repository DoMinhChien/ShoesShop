
CREATE TABLE [dbo].[Product_Size](
	[productId] [uniqueidentifier] NOT NULL,
	[sizeId] int not null,
	[Name] [nvarchar](100) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[ModifiedOn] [datetime] NULL,
	primary key(productId,sizeId)
)

ALTER TABLE [dbo].[Product_Size]  WITH CHECK ADD  CONSTRAINT [FK__Product_Products_Size] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([Id])
GO

ALTER TABLE [dbo].[Product_Size] CHECK CONSTRAINT [FK__Product_Products_Size]
GO

ALTER TABLE [dbo].[Product_Size]  WITH CHECK ADD  CONSTRAINT [FK__Size_Products_Size] FOREIGN KEY([sizeId])
REFERENCES [dbo].[Size] ([Id])
GO

ALTER TABLE [dbo].[Product_Size] CHECK CONSTRAINT [FK__Size_Products_Size]
GO


