using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.Models;
using Mashine;

namespace DefibrillatorBase.Controllers
{
    public class MapController : ApiController
    {
        private readonly MapService db=new MapService ();


        //Get api/Map/GetAllMapData
        public List<Defibrillator> GetAllMapData ()
        {
            return db.GetAll ();
        }

        //POST api/Map/AddNewDefibrillator
        public void AddNewDefibrillator(Defibrillator def)
        {
            db.AddNew(def);
        }

        //GET api/Map/GetAllPoints

        public List<Defibrillator> GetAllPoints ()
        {
            return db.GetAll ();
        }

        //POST api/Map/UpdateData
        public HttpResponseMessage UpdateData(Defibrillator defibrillator)
        {
            if (db.Update(defibrillator))
                return new HttpResponseMessage(HttpStatusCode.OK);
            return new HttpResponseMessage(HttpStatusCode.NotModified);
        }

        //POST api/Map/Post
        public void Report(Report report)
        {
            db.SendReport(report);
        }
    }
}