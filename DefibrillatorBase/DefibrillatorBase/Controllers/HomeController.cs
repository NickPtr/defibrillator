using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Core.Models;
using DefibrillatorBase.Model;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Mashine;

using Newtonsoft.Json;

namespace DefibrillatorBase.Controllers
{
    public class
        HomeController : Controller
    {
        public static List<Defibrillator> no_internet=new List<Defibrillator> ();

        private MapService db=new MapService ();

        public ActionResult Index ()
        {
            ViewBag.Title="Home Page";
            FakePoints ();
            //KANONIKA EINAI TO db.getAll();
            return View(FixLaTLon(no_internet));
        }

        public ActionResult Main ()
        {
            ViewBag.Title="Main Page";
            FakePoints ();
            return View(FixLaTLon(CombineResults ()));
        }

        public ActionResult Profile ()
        {
            ViewBag.Title="Profile";
            return View ();
        }

        public ActionResult NewAction ()
        {
            return View ();
        }
        private List<Def> FixLaTLon(List<Defibrillator> list)
        {
            var fixed_items=new List<Def> ();
            foreach (var i in list)
                fixed_items.Add(new Def
                {
                    Description=i.Description,
                    Name=i.Name,
                    PhotoLink=i.PhotoLink,
                    Posx=float.Parse(i.Posx),
                    Posy=float.Parse(i.Posy)
                });
            return fixed_items;
        }

        private List<Combined> FixLaTLon(List<Combined> list)
        {
            var fixed_items=new List<Combined> ();
            foreach (var i in list)
                fixed_items.Add(new Combined
                {
                    Description=i.Description,
                    Name=i.Name,
                    ErrorStatus=i.ErrorStatus,
                    Posx=i.Posx,
                    Posy=i.Posy,
                    Elses=i.Elses
                });
            return fixed_items;
        }

        public RedirectResult RedirectToAspx ()
        {
            return Redirect("~/Login.aspx");
        }

        public void FakePoints ()
        {
            no_internet.Clear ();
            no_internet.Add(new Defibrillator {Name="thanos1", Description="kapsalis", Posx="12", Posy="14"});
            no_internet.Add(new Defibrillator {Name="thanos2", Description="kapsalis", Posx="13", Posy="12"});
            no_internet.Add(new Defibrillator {Name="thanos3", Description="kapsalis", Posx="14", Posy="11"});
        }

        public RedirectResult Logout ()
        {
            var AuthenticationManager=HttpContext.GetOwinContext ().Authentication;
            AuthenticationManager.SignOut ();
            return Redirect("~/Home/Index");
        }

        public RedirectResult ProfileRe ()
        {
            return Redirect("~/Home/Profile");
        }

        public List<Combined> CombineResults ()
        {
            var final=new List<Combined> ();
            List<Report> reports=db.GetReports ();
            
            //Needs to get the online list 
            foreach (var i in no_internet)
                final.Add(new Combined
                {

                    Name=i.Name, Description=i.Description, ErrorStatus = CheckIfReport(reports, i)[0],Elses = CheckIfReport(reports,i)[1], Posx =float.Parse(i.Posx),
                    Posy=float.Parse(i.Posy)
                });

            return final;
        }

        private List<string> CheckIfReport(List<Report> reports, Defibrillator defibrillator)
        {
            List<string> list = new List<string> ();
            foreach (var report in reports)
            {
                if (report.Posx == defibrillator.Posx && report.Posy == defibrillator.Posy)
                {
                    list.Add(report.Comment);
                    list.Add(report.Elses);
                    return list;
                }
            }
            list.Add("Καμία βλάβη");
            list.Add("-");
            return list;
        }

        public void SendPushNotification (Not model)
        {
           
        }
    }



}
