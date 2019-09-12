using ShoesShop.BLL;
using ShoesShop.BLL.Interfaces;
using ShoesShop.Core.Extensions;
using ShoesShop.Mvc.Areas.Admin.Controllers;
using ShoesShop.Mvc.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Mvc.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProductBLL _productBLL;
        private readonly IHistoryBLL _historyBLL;
        public HomeController(IHistoryBLL historyBLL, IProductBLL productBLL)
        {
            _historyBLL = historyBLL;
            _productBLL = productBLL;
        }
        public ActionResult Index()
        {
            this.ViewBag.ListSize = GetLisSizes();
            return View();
        }
        private List<SelectedItemOutput> GetLisSizes()
        {
            var result = new List<SelectedItemOutput>();
            result.Add(new SelectedItemOutput { Id = 1, Name = "S" });
            result.Add(new SelectedItemOutput { Id = 2, Name = "M" });
            return result;
        }
        public JsonResult GetTop16Products()
        {
            var model = _productBLL.GetListProduct();
            var result = model.MapTo<List<ProductOutput>>();

            JSPagedDataResult.rows = result;


            return Json(JSPagedDataResult, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public JsonResult GetHistories(Guid objectId)
        {
            var result = _historyBLL.GetHistories(objectId).MapTo<List<HistoryOutput>>();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}