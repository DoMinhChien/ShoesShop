using ShoesShop.Model;
using ShoesShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesShop.BLL.Interfaces
{
    public interface ICategoryBLL
    {
        List<Category> GetCategoryForMasterData();
        List<CategoryModel> GetCategories();
        bool InsertCategory(CategoryModel model);
        bool UpdateCategory(CategoryModel Model);
        CategoryModel GetCategoryDetail(int Id);
        bool DeleteCategory(int Id);
    }
}
