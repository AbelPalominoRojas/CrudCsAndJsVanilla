using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using apr.Entities;
using apr.Business;
using apr.WebMVC.Models;

namespace apr.WebMVC.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult findAll()
        {
            ResponseResult<Producto> responseResult = new ResponseResult<Producto>();
            try
            {
                responseResult.Items = new ProductosBll().findAll();
            }
            catch (Exception ex)
            {
                responseResult.Message = ex.Message;
            }

            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult create(Producto producto)
        {
            ResponseResult<Producto> responseResult = new ResponseResult<Producto>();

            try
            {
                responseResult.State = new ProductosBll().create(producto);

                if (responseResult.State)
                    responseResult.Message = "Producto Registrado correctamete" ;
                else
                    responseResult.Message = "El Registro de Producto no Fue posible" ;
            }
            catch (Exception ex)
            {
                responseResult.Message = ex.Message;
            }

            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult find(Int32 idproducto)
        {
            ResponseResult<Producto> responseResult = new ResponseResult<Producto>();
            try
            {
                responseResult.Item = new ProductosBll().find(idproducto);
            }
            catch (Exception ex)
            {
                responseResult.Message = ex.Message;
            }

            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult edit(Producto producto)
        {
            ResponseResult<Producto> responseResult = new ResponseResult<Producto>();

            try
            {
                responseResult.State = new ProductosBll().edit(producto);

                if (responseResult.State)
                    responseResult.Message = "Producto Actualizado correctamete";
                else
                    responseResult.Message = "La Actualización de Producto no Fue posible";
            }
            catch (Exception ex)
            {
                responseResult.Message = ex.Message;
            }

            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult remove(Int32 idproducto)
        {
            ResponseResult<Producto> responseResult = new ResponseResult<Producto>();

            try
            {
                responseResult.State = new ProductosBll().remove(idproducto);

                if (responseResult.State)
                    responseResult.Message = "Producto Eliminado correctamete";
                else
                    responseResult.Message = "La Eliminacion de Producto no Fue posible" ;
            }
            catch (Exception ex)
            {
                responseResult.Message = ex.Message;
            }

            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult findAllByIdCategoria(Int32 idcategoria)
        {
            ResponseResult<Producto> responseResult = new ResponseResult<Producto>();

            try
            {
                responseResult.Items = new ProductosBll().findAllByIdCategoria(idcategoria);
            }
            catch (Exception ex)
            {
                responseResult.Message = ex.Message;
            }

            return Json(responseResult, JsonRequestBehavior.AllowGet);
        }
    }
}