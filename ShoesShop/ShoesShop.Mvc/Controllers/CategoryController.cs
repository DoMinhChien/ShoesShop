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
        private readonly ICategoryBLL categoryBLL;
        public CategoryController(ICategoryBLL _categoryBLL)
        {
            categoryBLL = _categoryBLL;
        }
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetCategories()
        {
            var result = categoryBLL.GetCategoryForMasterData().Select(r => new SelectedItemOutput { id = r.CategoryId, text = r.CategoryName }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}