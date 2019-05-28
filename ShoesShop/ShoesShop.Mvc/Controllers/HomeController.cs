using ShoesShop.BLL;
using ShoesShop.BLL.Interfaces;
using ShoesShop.Core.Extensions;
using ShoesShop.Mvc.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHistoryBLL _historyBLL;
        public HomeController(IHistoryBLL historyBLL)
        {
            _historyBLL = historyBLL;
        }
        public ActionResult Index()
        {
            return View();
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