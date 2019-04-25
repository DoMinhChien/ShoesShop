﻿using ShoesShop.BLL.Interfaces;
using ShoesShop.Model;
using ShoesShop.Mvc.Inputs;
using ShoesShop.Mvc.Outputs;
using System;
using System.Linq;
using System.Web.Mvc;


namespace ShoesShop.Mvc.Controllers
{
    public class ProductController : Controller
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
            var model = _productBLL.GetListProduct();
            return View(model);
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
            var result = AutoMapper.Mapper.Map<ProductOutput>(data);
            result.ListCategory = _categoryBLL.GetCategoryForMasterData().Select(cat => new SelectedItemOutput { Id = cat.Id, Name =cat.Name }).ToList();
            result.ListSupplier = _supplierBLL.GetSupplierForMasterData().Select(sup=> new SelectedItemOutput { Id = sup.SupplierId, Name = sup.Name }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertProduct(ProductInput Input)
        {
            var model = AutoMapper.Mapper.Map<ProductModel>(Input);
            bool result = _productBLL.InsertProduct(model);
            return Json(result, JsonRequestBehavior.AllowGet);
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
            var ListCategory = _categoryBLL.GetCategoryForMasterData().Select(cat => new SelectedItemOutput { Id = cat.Id, Name = cat.Name }).ToList();
            var ListSupplier = _supplierBLL.GetSupplierForMasterData().Select(sup => new SelectedItemOutput { Id = sup.SupplierId, Name = sup.Name }).ToList();

            return Json( new {model = model, ListCategory = ListCategory,ListSupplier = ListSupplier}, JsonRequestBehavior.AllowGet);
        }

        

    }
}
