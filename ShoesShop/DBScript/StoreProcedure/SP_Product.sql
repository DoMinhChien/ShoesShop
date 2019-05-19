
declare
	@PageSize as int =10,
	@PageIndex as int = 1,
	@Sort nvarchar(500) = 'Name'

	declare @Total int =0 	
	declare @sql nvarchar(2000) = ''
	create table #Product(
	Id uniqueidentifier,
	Name nvarchar(500),
	CategoryId int,
	CategoryName nvarchar(100),
	SupplierId uniqueidentifier,
	SupplierName nvarchar(100),
	Quantity int,
	UnitPrice float,
	UnitsInStock int,
	IsActive bit,
	ModifiedOn datetime,
	Total int
	)
	create index #Product_ID on #Product(Id)

	insert into #Product
	(Id,Name,CategoryId,CategoryName,SupplierId,SupplierName,Quantity,UnitPrice,UnitsInStock,IsActive,ModifiedOn)
	select p.Id,p.Name,cat.Id,cat.Name,sup.Id,sup.Name,p.Quantity,P.UnitPrice,P.UnitsInStock,P.IsActive,P.ModifiedOn
	from Product as p
	join Category as cat on p.categoryId = cat.Id
	join Supplier as sup on p.supplierId = sup.Id
	where p.IsDeleted =0

	select @Total = count(1) from #Product

	set @sql= 'select 
	Id ,
	Name ,
	CategoryId ,
	CategoryName,
	SupplierId ,
	SupplierName,
	Quantity ,
	UnitPrice ,
	UnitsInStock,
	IsActive ,
	ModifiedOn,
	@Total Total
	from #Product order by '+ @Sort + '
	OFFSET((@PageIndex -1) * @PageSize) ROWS
	FETCH NEXT @PageSize ROWS ONLY;
	 '
	 exec sp_executesql  @sql,N'@PageIndex INT, @PageSize INT,@total INT',@PageIndex,@PageSize,@Total

	drop table #Product

 