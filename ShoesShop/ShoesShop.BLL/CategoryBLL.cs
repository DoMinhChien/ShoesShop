using ShoesShop.BLL.Interfaces;
using ShoesShop.Model;
using ShoesShop.Repository.Repo;
using ShoesShop.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using ShoesShop.Repository;
using ShoesShop.Core.Extensions;

namespace ShoesShop.BLL
{

    public class CategoryBLL : ICategoryBLL
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CategoryRepository _categoryRepository;

        public CategoryBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = new CategoryRepository(unitOfWork);
        }

        public List<Category> GetCategoryForMasterData()
        {
            return _categoryRepository.GetAll(r => !r.IsDeleted).ToList();
        }

        public List<CategoryModel> GetCategories()
        {
            var list = _categoryRepository.GetAll().Where(r => !r.IsDeleted).ToList();
            var result = list.MapTo<List<CategoryModel>>();
            return result;
        }
        public bool InsertCategory(CategoryModel model)
        {

            if (model.Id ==0)
            {
                var maxId = _categoryRepository.GetAll().Select(r => r.Id).Max();
                model.Id = maxId + 1;
                
            }
            var entity = new Category();
            entity = model.MapTo<Category>();

            _categoryRepository.Insert(entity);
            _unitOfWork.SaveChanges();
            return true;
        }
        public bool UpdateCategory(CategoryModel model)
        {
            bool result = false;
            var entity = _categoryRepository.GetById(model.Id);
            if (entity != null)
            {
                entity.Name = model.Name;
                entity.IsActive = model.IsActive;
                entity.Description = model.Description;
                entity.ModifiedOn = DateTime.UtcNow;
                _categoryRepository.Update(entity);
                _unitOfWork.SaveChanges();
                result = true;
            }

            return result ;

        }
        public CategoryModel GetCategoryDetail(int Id)
        {
            var entity = _categoryRepository.GetById(Id);
            var model = entity.MapTo<CategoryModel>();
            return model;
        }
        public bool DeleteCategory(int Id)
        {
            bool result = false;
            var entity = _categoryRepository.GetById(Id);
            if (entity != null)
            {
                result= _categoryRepository.SoftDelete(entity);
            }
            _unitOfWork.SaveChanges();

            return result;
        }

    }
}
