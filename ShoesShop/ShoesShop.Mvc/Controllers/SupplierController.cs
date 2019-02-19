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
        private readonly ISupplierBLL supplierBLL;
        

        public SupplierController(ISupplierBLL _supplierBLL)
        {
            supplierBLL = _supplierBLL;
        }
        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSuppliers()
        {
            var result = supplierBLL.GetSupplierForMasterData().Select(r => new SelectedItemOutput { id = r.SupplierId, text = r.Name }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}