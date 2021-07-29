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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult findAll()
        {
            ResponseResult<Cliente> responseResult = new ResponseResult<Cliente>();

            try
            {
                responseResult.Items = new ClientesBll().findAll();
            }
            catch (Exception ex)
            {
                responseResult.Message = ex.Message;
            }

            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }
    }
}