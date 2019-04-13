using ShoesShop.BLL.Interfaces;
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
            var result = _categoryBLL.GetCategoryForMasterData().Select(r => new SelectedItemOutput { Id = r.CategoryId, Name = r.CategoryName }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}