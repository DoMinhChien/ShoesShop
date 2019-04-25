using ShoesShop.BLL.Interfaces;
using ShoesShop.Model;
using ShoesShop.Repository;
using ShoesShop.Repository.Repo;
using ShoesShop.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using ShoesShop.Core.Constants;
namespace ShoesShop.BLL
{
    public class ProductBLL : IProductBLL
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductRepository _productRepository;
        CommonConstant commonConstant = new CommonConstant();

        public ProductBLL(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;

            _productRepository = new ProductRepository(_unitOfWork);
        }

        public List<ProductModel> GetListProduct()
        {
            List<ProductModel> list = _productRepository.GetAll(r=>!r.IsDeleted).OrderByDescending(c=>c.CreatedOn).Select(m =>  new ProductModel
            {
                Id= m.Id,
                Name = m.Name,
                Description = m.Description,
                Quantity = m.Quantity,
                CategoryId = m.categoryId,
                SupplierId = m.supplierId,
                StatusId = m.StatusId,
                UnitPrice = m.UnitPrice,
                UnitsInStock = m.UnitsInStock,
                ViewCounts = m.ViewCounts,
                ModifiedOn = m.ModifiedOn.HasValue ? m.ModifiedOn.Value : (DateTime?)null,
                ImageUrl = m.ImageStores.Select(r => r.ImagePath).ToList(),
                CategoryName = m.Category.Name,
                SupplierName = m.Supplier.Name
            }).ToList();

            return list;
        }
        public bool DeleteProduct(Guid Id)
        {
            bool result = false;
            var entity = _productRepository.GetById(Id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                result = true;  
            }
            _productRepository.Update(entity);
            _unitOfWork.SaveChanges();

            return result;
        }

        public ProductModel GetProductDetail(Guid productId)
        {
            var entity = _productRepository.GetById(productId);
            var model = AutoMapper.Mapper.Map<ProductModel>(entity);
            return model;
        }
        public bool InsertProduct(ProductModel model)
        {
            var entity = new Product();
            entity = AutoMapper.Mapper.Map<Product>(model);

            _productRepository.Insert(entity);
            _unitOfWork.SaveChanges();
            return true;

        }
        
        public bool UpdateProduct(ProductModel productModel)
        {

            var entity = _productRepository.GetById(productModel.Id);
            //entity = AutoMapper.Mapper.Map<Product>(productModel);
            entity.Name = productModel.Name;
            entity.Description = productModel.Description;
            entity.categoryId = productModel.CategoryId;
            entity.supplierId = productModel.SupplierId;
            entity.Quantity = productModel.Quantity;
            entity.UnitPrice = productModel.UnitPrice;

            //entity.ModifiedOn = DateTime.UtcNow;
            _productRepository.Update(entity);
            _unitOfWork.SaveChanges();
            return true;
                
        }


    }
}
