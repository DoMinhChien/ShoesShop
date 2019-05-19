EXEC sp_RENAME 'Product.StatusId' , 'IsActive', 'COLUMN'

alter table Product
alter column IsActive bit 