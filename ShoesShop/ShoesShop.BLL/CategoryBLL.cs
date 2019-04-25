using ShoesShop.BLL.Interfaces;
using ShoesShop.Model;
using ShoesShop.Repository.Repo;
using ShoesShop.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using ShoesShop.Repository;

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
            var list = _categoryRepository.GetAll().Where(r => !r.IsDeleted).Select(r => new CategoryModel
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                ModifiedOn = r.ModifiedOn

            }).ToList();

            return list;
        }
        public bool InsertCategory(CategoryModel model)
        {

            if (model.Id ==0)
            {
                var maxId = _categoryRepository.GetAll().Select(r => r.Id).Max();
                model.Id = maxId + 1;
                
            }
            var entity = new Category();
            entity = AutoMapper.Mapper.Map<Category>(model);

            _categoryRepository.Insert(entity);
            _unitOfWork.SaveChanges();
            return true;
        }
        public bool UpdateCategory(CategoryModel Model)
        {

            var entity = _categoryRepository.GetById(Model.Id);
            entity.Name = Model.Name;
            entity.Description = Model.Description;
            entity.ModifiedOn = DateTime.UtcNow;
            _categoryRepository.Update(entity);
            _unitOfWork.SaveChanges();
            return true;

        }
        public CategoryModel GetCategoryDetail(int Id)
        {
            var entity = _categoryRepository.GetById(Id);
            var model = AutoMapper.Mapper.Map<CategoryModel>(entity);
            return model;
        }
        public bool DeleteCategory(int Id)
        {
            bool result = false;
            var entity = _categoryRepository.GetById(Id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                result = true;
            }
            _categoryRepository.Update(entity);
            _unitOfWork.SaveChanges();

            return result;
        }

    }
}
