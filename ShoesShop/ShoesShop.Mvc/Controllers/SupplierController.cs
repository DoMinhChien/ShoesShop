using ShoesShop.BLL.Interfaces;
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
            var result = _supplierBLL.GetSupplierForMasterData().Select(r => new SelectedItemOutput { Id = r.Id, Name = r.Name }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSupplierForMasterData()
        {
            var ListSupplier = _supplierBLL.GetSupplierForMasterData().Select(sup => new SelectedItemOutput { Id = sup.Id, Name = sup.Name }).ToList();

            return Json(ListSupplier, JsonRequestBehavior.AllowGet);
        }
    }
}