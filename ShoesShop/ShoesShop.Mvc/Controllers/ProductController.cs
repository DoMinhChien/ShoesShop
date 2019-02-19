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
    public class ProductController : Controller
    {
       private  readonly IProductBLL productBLL;
        private readonly ISupplierBLL supplierBLL;
        private readonly ICategoryBLL categoryBLL;
        public ProductController(IProductBLL _productBLL, ISupplierBLL _supplierBLL, ICategoryBLL _categoryBLL)
        {
            productBLL = _productBLL;
            supplierBLL = _supplierBLL;
            categoryBLL = _categoryBLL;
        }
        // GET: Product
        public ActionResult Index()
        {
            var model = productBLL.GetListProduct();
            return View(model);
        }

        public ActionResult EditProduct(Guid productId)
        {
            var model =productBLL.GetProductDetail(productId);
            ViewBag.Categories = categoryBLL.GetCategoryForMasterData().Select(r => new SelectedItemOutput { id = r.CategoryId, text = r.CategoryName }).ToList();
            ViewBag.Suppliers = supplierBLL.GetSupplierForMasterData().Select(r => new SelectedItemOutput { id = r.SupplierId, text = r.Name }).ToList();
            return View(model);
        }


        [HttpPost]
        public JsonResult DeleteProduct(Guid productId)
        {
            bool result = productBLL.DeleteProduct(productId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult InsertProduct(ProductInput Input)
        {
            var model = AutoMapper.Mapper.Map<ProductModel>(Input);
            bool result = productBLL.InsertProduct(model);
            return Json(result,JsonRequestBehavior.AllowGet);
        }
     

       


    }
}
