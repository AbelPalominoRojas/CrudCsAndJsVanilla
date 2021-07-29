using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using apr.Entities;
using apr.Business;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using apr.WebMVC.Models;

namespace apr.WebMVC.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public JsonResult findAll()
        {
            ResponseResult<Pedido> responseResult = new ResponseResult<Pedido>();
            try
            {
                responseResult.Items = new PedidosBll().findAll();
            }
            catch (Exception ex)
            {
                responseResult.Message = ex.Message;
            }

            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult create(Pedido pedido)
        {
            ResponseResult<Pedido> responseResult = new ResponseResult<Pedido>();

            try
            {
                responseResult.State = new PedidosBll().create(pedido);

                if (responseResult.State)
                    responseResult.Message = "Pedido Registrado correctamete";
                else
                    responseResult.Message = "El Registro de Pedido no Fue posible";
            }
            catch (Exception ex)
            {
                responseResult.Message = ex.Message;
            }

            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }

    }
}