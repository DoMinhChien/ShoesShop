using ShoesShop.BLL.Interfaces;
using ShoesShop.Model;
using ShoesShop.Mvc.Inputs;
using ShoesShop.Mvc.Outputs;
using ShoesShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Mvc.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierBLL _supplierBLL;
        

        public SupplierController(ISupplierBLL supplierBLL)
        {
            _supplierBLL = supplierBLL;
        }
        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSuppliers()
        {
            var model = _supplierBLL.GetSuppliers();
            var result = model.MapToList<SupplierOutput>();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertSupplier(SupplierInput Input)
        {
            var model = Input.MapTo<SupplierModel>();
            var result = _supplierBLL.InsertSupplier(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateSupplier(SupplierInput Input)
        {
            var model = Input.MapTo<SupplierModel>();
            bool result = _supplierBLL.UpdateSupplier(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSupplierDetail(Guid SupplierId)
        {
            var data = _supplierBLL.GetSupplierDetail(SupplierId);
            var result = data.MapTo<SupplierOutput>();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteSupplier(Guid SupplierId)
        {
            bool result = _supplierBLL.DeleteSupplier(SupplierId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSupplierForMasterData()
        {
            var ListSupplier = _supplierBLL.GetSupplierForMasterData().Select(sup => new SelectedItemOutput { Id = sup.Id, Name = sup.Name }).ToList();

            return Json(ListSupplier, JsonRequestBehavior.AllowGet);
        }

    }
}