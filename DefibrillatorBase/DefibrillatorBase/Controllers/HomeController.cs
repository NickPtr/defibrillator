using Core.Models;
using DefibrillatorBase.Model;
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
            
           
            return View(FixLaTLon(db.GetAll()));
        }

        private List<Def> FixLaTLon(List<Defibrillator> list)
        {
           List<Def> fixed_items = new List<Def>();
            foreach(var i  in list)
            {
                fixed_items.Add(new Def()
                {
                    Description = i.Description,
                    Name = i.Name,
                    PhotoLink=i.PhotoLink,
                    Posx=float.Parse(i.Posx),
                    Posy=float.Parse(i.Posy)
                });
            }
            return fixed_items;

            
        }
    }
}
