using Core.Models;
using Mashine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefibrillatorBase.Controllers
{
    public class HomeController : Controller
    {
        MapService db = new MapService();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            
           
            return View();
        }

        public ActionResult AddMarker()
        {
            return View();
        }
    }
}
