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
        public static List<Defibrillator> no_internet = new List<Defibrillator>();

        public ActionResult Index()
        {
            
            ViewBag.Title = "Home Page";
            FakePoints();
            //KANONIKA EINAI TO db.getAll();
            return View(FixLaTLon(no_internet));
            
        }

        public ActionResult Main()
        {

            ViewBag.Title = "Main Page";
            FakePoints();
            //KANONIKA EINAI TO db.getAll();
            return View();

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

        public RedirectResult RedirectToAspx()
        {
            return Redirect("~/Login.aspx");
        }

        public void FakePoints()
        {
            no_internet.Add(new Defibrillator {Name="thanos",Description="kapsalis",Posx="12",Posy="14" });
            no_internet.Add(new Defibrillator { Name = "thanos", Description = "kapsalis", Posx = "13", Posy = "12" });
            no_internet.Add(new Defibrillator { Name = "thanos", Description = "kapsalis", Posx = "14", Posy = "11" });

        }
    }
}
