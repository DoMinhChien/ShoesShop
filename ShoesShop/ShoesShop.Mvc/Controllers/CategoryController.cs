using ShoesShop.BLL.Interfaces;
using ShoesShop.Model;
using ShoesShop.Mvc.Inputs;
using ShoesShop.Mvc.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryBLL _categoryBLL;
        public CategoryController(ICategoryBLL categoryBLL)
        {
            _categoryBLL = categoryBLL;
        }
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetCategories()
        {
            var result = _categoryBLL.GetCategories();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertCategory(CategoryInput Input)
        {
            var model = AutoMapper.Mapper.Map<CategoryModel>(Input);
            var result = _categoryBLL.InsertCategory(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateCategory(CategoryInput Input)
        {
            var model = AutoMapper.Mapper.Map<CategoryModel>(Input);
            bool result = _categoryBLL.UpdateCategory(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCategoryDetail(int CategoryId)
        {
            var data = _categoryBLL.GetCategoryDetail(CategoryId);
            var result = AutoMapper.Mapper.Map<CategoryOutput>(data);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteCategory(int CategoryId)
        {
            bool result = _categoryBLL.DeleteCategory(CategoryId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategoryForMasterData()
        {
            var ListCategory = _categoryBLL.GetCategoryForMasterData().Select(cat => new SelectedItemOutput { Id = cat.Id, Name = cat.Name }).ToList();

            return Json(ListCategory,JsonRequestBehavior.AllowGet);
        }
    }
}