using ShoesShop.BLL.Interfaces;
using ShoesShop.Repository;
using ShoesShop.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesShop.BLL
{
   
    public class CategoryBLL : ICategoryBLL
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CategoryRepository categoryRepository;

        public CategoryBLL(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            categoryRepository = new CategoryRepository(unitOfWork);
        }      

        public List<TblCategory> GetCategoryForMasterData()
        {
            return categoryRepository.GetAll(r => !r.IsDeleted).ToList();
        }
    }
}
