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
       private  readonly IProductBLL _productBLL;
        private readonly ISupplierBLL _supplierBLL;
        private readonly ICategoryBLL _categoryBLL;
        public ProductController(IProductBLL productBLL, ISupplierBLL supplierBLL, ICategoryBLL categoryBLL)
        {
            _productBLL = productBLL;
            _supplierBLL = supplierBLL;
            _categoryBLL = categoryBLL;
        }
        // GET: Product
        public ActionResult Index()
        {
            var model = _productBLL.GetListProduct();
            return View(model);
        }

        public ActionResult EditProduct(Guid productId)
        {

            var model =_productBLL.GetProductDetail(productId);
            ViewBag.Categories = _categoryBLL.GetCategoryForMasterData().Select(r => new SelectedItemOutput { id = r.CategoryId, text = r.CategoryName }).ToList();
            ViewBag.Suppliers = _supplierBLL.GetSupplierForMasterData().Select(r => new SelectedItemOutput { id = r.SupplierId, text = r.Name }).ToList();
            return View(model);
        }


        [HttpPost]
        public JsonResult DeleteProduct(Guid productId)
        {
            bool result = _productBLL.DeleteProduct(productId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult InsertProduct(ProductInput Input)
        {
            var model = AutoMapper.Mapper.Map<ProductModel>(Input);
            bool result = _productBLL.InsertProduct(model);
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateProduct(ProductInput Input)
        {
            var model = AutoMapper.Mapper.Map<ProductModel>(Input);
            bool result = _productBLL.UpdateProduct(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public JsonResult GetProducts()
        {
            var model = _productBLL.GetListProduct();

            return Json(model, JsonRequestBehavior.AllowGet);
        }





    }
}
