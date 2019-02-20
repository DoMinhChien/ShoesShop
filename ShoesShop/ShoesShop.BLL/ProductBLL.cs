using ShoesShop.BLL.Interfaces;
using ShoesShop.Model;
using ShoesShop.Repository;
using ShoesShop.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoesShop.BLL
{
    public class ProductBLL : IProductBLL
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ProductRepository productRepository;


        public ProductBLL(IUnitOfWork _unitOfWork)
        {

            unitOfWork = _unitOfWork;

            productRepository = new ProductRepository(unitOfWork);
        }

        public List<ProductModel> GetListProduct()
        {
            List<ProductModel> list = productRepository.GetAll(r=>!r.IsDeleted).Select(m =>  new ProductModel
            {
                Id= m.Id,
                Name = m.Name,
                Description = m.Description,
                Quantity = m.Quantity,
                CategoryId = m.CategoryId,
                SupplierId = m.SupplierId,
                StatusId = m.StatusId,
                UnitPrice = m.UnitPrice,
                UnitsInStock = m.UnitsInStock,
                ViewCounts = m.ViewCounts,
                ModifiedOn = m.ModifiedOn.HasValue ? m.ModifiedOn.Value : (DateTime?)null,
                ImageUrl = m.tblImageStores.Select(r => r.ImagePath).ToList(),
                CategoryName = m.tblCategory.CategoryName,
                SupplierName = m.tblSupplier.Name
            }).ToList();

            return list;
        }
        public bool DeleteProduct(Guid productId)
        {
            bool result = false;
            var entity = productRepository.GetById(productId);
            if (entity != null)
            {
                entity.IsDeleted = true;
                result = true;  
            }
            productRepository.Update(entity);
            unitOfWork.SaveChanges();

            return result;
        }

        public ProductModel GetProductDetail(Guid productId)
        {
            var entity = productRepository.GetById(productId);
            var model = AutoMapper.Mapper.Map<ProductModel>(entity);
            return model;
        }
        public bool InsertProduct(ProductModel model)
        {
            var entity = new tblProduct();
            entity = AutoMapper.Mapper.Map<tblProduct>(model);

            productRepository.Insert(entity);
            unitOfWork.SaveChanges();
            return true;

        
        }

        public bool UpdateProduct(ProductModel productModel)
        {

            var entity = productRepository.GetById(productModel.Id);
            entity = AutoMapper.Mapper.Map<tblProduct>(productModel);

            productRepository.Update(entity);
            unitOfWork.SaveChanges();
            return true;
                
        }

    }
}
