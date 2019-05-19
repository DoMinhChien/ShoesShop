using PagedList;
using ShoesShop.BLL.Interfaces;
using ShoesShop.Model;
using ShoesShop.Model.FilterModel;
using ShoesShop.Mvc.Infrastructure.Extensions;
using ShoesShop.Mvc.Inputs;
using ShoesShop.Mvc.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace ShoesShop.Mvc.Controllers
{
    public class ProductController : BaseController 
    {
        private readonly IProductBLL _productBLL;
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
            return View();
        }

        public ActionResult EditProduct(Guid productId)
        {

            var model = _productBLL.GetProductDetail(productId);
            return View(model);
        }


        [HttpPost]
        public JsonResult DeleteProduct(Guid ProductId)
        {
            bool result = _productBLL.DeleteProduct(ProductId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProductDetail(Guid ProductId)
        {
            var data = _productBLL.GetProductDetail(ProductId);
            var result = data.MapTo<ProductOutput>();
            result.ListCategory = _categoryBLL.GetCategoryForMasterData().Select(cat => new SelectedItemOutput { Id = cat.Id, Name =cat.Name }).ToList();
            result.ListSupplier = _supplierBLL.GetSupplierForMasterData().Select(sup=> new SelectedItemOutput { Id = sup.Id, Name = sup.Name }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertProduct(ProductInput Input)
        {
             var model = Input.MapTo<ProductModel>();
            bool result = _productBLL.InsertProduct(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateProduct(ProductInput Input)
        {
            var model = Input.MapTo<ProductModel>();
            bool result = _productBLL.UpdateProduct(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProducts(ProductFilterModel filterModel)
        {
            var model = _productBLL.GetListProduct(filterModel);
            var result = model.MapTo<List<ProductOutput>>();
            var pagedListData = result.ToPagedList(filterModel.PageIndex, filterModel.PageSize);
            var ListCategory = _categoryBLL.GetCategoryForMasterData().Select(cat => new SelectedItemOutput { Id = cat.Id, Name = cat.Name }).ToList();
            var ListSupplier = _supplierBLL.GetSupplierForMasterData().Select(sup => new SelectedItemOutput { Id = sup.Id, Name = sup.Name }).ToList();

            JSPagedDataResult.rows = pagedListData;
            JSPagedDataResult.records = pagedListData.TotalItemCount;

            return Json(JSPagedDataResult, JsonRequestBehavior.AllowGet);
        }

        

    }
}
