using PagedList;
using ShoesShop.BLL.Interfaces;
using ShoesShop.Core.Extensions;
using ShoesShop.Model;
using ShoesShop.Model.FilterModel;
using ShoesShop.Mvc.Inputs;
using ShoesShop.Mvc.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoesShop.Mvc.Areas.Admin.Controllers
{
    public class EmployeeController :  BaseController
    {
        private readonly IEmployeeBLL _employeeBLL;
        public EmployeeController(IEmployeeBLL employeeBLL)
        {
            _employeeBLL = employeeBLL;
        }
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult DeleteEmployee(Guid EmployeeId)
        {
            bool result = _employeeBLL.DeleteEmployee(EmployeeId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetEmployeeDetail(Guid EmployeeId)
        {
            var data = _employeeBLL.GetEmployeeDetail(EmployeeId);
            var result = data.MapTo<EmployeeOutput>();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertEmployee(EmployeeInput Input)
        {
            var model = Input.MapTo<EmployeeModel>();
            bool result = _employeeBLL.InsertEmployee(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateEmployee(EmployeeInput Input)
        {
            var model = Input.MapTo<EmployeeModel>();
            bool result = _employeeBLL.UpdateEmployee(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetEmployees(EmployeeFilterModel filterModel)
        {
            var model = _employeeBLL.GetListEmployee(filterModel);
            var result = model.MapTo<List<EmployeeOutput>>();
            var pagedListData = result.ToPagedList(filterModel.PageIndex, filterModel.PageSize);


            JSPagedDataResult.rows = pagedListData;
            JSPagedDataResult.records = pagedListData.TotalItemCount;

            return Json(JSPagedDataResult, JsonRequestBehavior.AllowGet);
        }
    }
}