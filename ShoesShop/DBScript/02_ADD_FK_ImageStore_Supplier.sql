ALTER TABLE [dbo].[tblSuppliers] WITH CHECK ADD  CONSTRAINT [FK_tblSuppliers_ImageStore] FOREIGN KEY([ImageId])
REFERENCES [dbo].[TblImageStore] ([ImageId])
GO
ALTER TABLE [dbo].[tblSuppliers] CHECK CONSTRAINT [FK_tblSuppliers_ImageStore]
GO
