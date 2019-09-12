using ShoesShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Mvc.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            JSPagedDataResult = new JsonPagedDataResult();
        }
        public JsonPagedDataResult JSPagedDataResult { get; set; }
    }
}