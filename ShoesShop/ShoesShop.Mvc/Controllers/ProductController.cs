using ShoesShop.BLL.Interfaces;
using ShoesShop.Model;
using ShoesShop.Mvc.Inputs;
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
        public ProductController(IProductBLL _productBLL)
        {
            productBLL = _productBLL;
        }
        // GET: Product
        public ActionResult Index()
        {
            var model = productBLL.GetListProduct();
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
