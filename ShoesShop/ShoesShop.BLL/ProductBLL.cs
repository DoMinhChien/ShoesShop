using ShoesShop.BLL.Interfaces;
using ShoesShop.Model;
using ShoesShop.Repository;
using ShoesShop.Repository.Repo;
using ShoesShop.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using ShoesShop.Core.Constants;
using ShoesShop.Model.FilterModel;
using ShoesShop.Core.Extensions;

namespace ShoesShop.BLL
{
    public class ProductBLL : IProductBLL
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ProductRepository _productRepository;
        private readonly IHistoryBLL _historyBLL;
        
        CommonConstant commonConstant = new CommonConstant();

        public ProductBLL(IUnitOfWork unitOfWork,
                          IHistoryBLL historyBLL)
        {
            _historyBLL = historyBLL;
            _unitOfWork = unitOfWork;

            _productRepository = new ProductRepository(_unitOfWork);
        }

        public List<ProductModel> GetListProduct(ProductFilterModel filterModel)
        {

            var list = _productRepository.GetAll(r => !r.IsDeleted).OrderByDescending(c => c.CreatedOn).ToList();
            var result = list.MapTo<List<ProductModel>>();
            return result;
        }
        public List<ProductModel> GetListProduct()
        {

            var list = _productRepository.GetAll(r => !r.IsDeleted).OrderByDescending(c => c.CreatedOn).Take(16).ToList();
            var result = list.MapTo<List<ProductModel>>();
            return result;
        }
        public bool DeleteProduct(Guid Id)
        {
            bool result = false;
            var entity = _productRepository.GetById(Id);
            if (entity != null)
            {
                result = _productRepository.SoftDelete(entity);
            }
            _productRepository.Update(entity);
            _unitOfWork.SaveChanges();

            return result;
        }

        public ProductModel GetProductDetail(Guid productId)
        {
            var entity = _productRepository.GetById(productId);
            var model = entity.MapTo<ProductModel>();
            return model;
        }
        public bool InsertProduct(ProductModel model)
        {
            var entity = new Product();
            entity = model.MapTo<Product>();

            _productRepository.Insert(entity);
            _unitOfWork.SaveChanges();
            return true;

        }
        
        public bool UpdateProduct(ProductModel productModel)
        {

            var entity = _productRepository.GetById(productModel.Id);

            var oldEntity = entity.MapTo<ProductModel>();

            entity.IsActive = productModel.IsActive;
            entity.Name = productModel.Name;
            entity.Description = productModel.Description;
            entity.categoryId = productModel.CategoryId;
            entity.supplierId = productModel.SupplierId;
            //entity.Quantity = productModel.Quantity;
            entity.UnitPrice = productModel.UnitPrice;
            _historyBLL.SaveHistory(oldEntity, productModel, "Has updated this Product");
            _productRepository.Update(entity);
            _unitOfWork.SaveChanges();
            return true;
                
        }


    }
}
