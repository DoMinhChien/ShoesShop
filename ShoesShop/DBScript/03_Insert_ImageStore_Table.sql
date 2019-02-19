CREATE TABLE [dbo].[ImageStore](
 [ImageId] [int] IDENTITY(1,1) NOT NULL,
 [ObjectId] [uniqueidentifier] not null,
 [ImageName] [nvarchar](1000) NULL,
 [ImageByte] [image] NULL,
 [ImagePath] [nvarchar](1000) NULL,
 
 CONSTRAINT [PK_ImageStore] PRIMARY KEY CLUSTERED 
(
 [ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

ALTER TABLE [dbo].[ImageStore]  WITH CHECK ADD  CONSTRAINT [FK_ImageStore_Product] FOREIGN KEY([ObjectId])
REFERENCES [dbo].[tblProducts] ([Id])
GO
ALTER TABLE [dbo].[ImageStore] CHECK CONSTRAINT [FK_ImageStore_Product]
GO
