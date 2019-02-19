﻿using ShoesShop.BLL.Interfaces;
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
        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       


    }
}
