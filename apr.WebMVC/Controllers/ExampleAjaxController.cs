using apr.Business;
using apr.Entities;
using apr.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace apr.WebMVC.Controllers
{
    public class ExampleAjaxController : Controller
    {
        // GET: ExampleAjax
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult XMLHttpRequest()
        {
            return View();
        }

        public ActionResult FetchAPI()
        {
            return View();
        }

        public ActionResult FetchAPIAsync()
        {
            return View();
        }

    }
}