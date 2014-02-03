using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Visao.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Message = "Seja bem-vindo ao Sistema Hoteleiro.";
            return View();
        }

        public ActionResult Sobre()
        {
            ViewBag.Message = "Conheça tudo sobre o Sistema Hoteleiro.";
            ViewBag.Title = "Sobre";
            return View();
        }

        public ActionResult Autor()
        {
            ViewBag.Message = "Tiago Romero Garcia, a seu dispor.";
            ViewBag.Title = "Autor";
            return View();
        }
    }
}
