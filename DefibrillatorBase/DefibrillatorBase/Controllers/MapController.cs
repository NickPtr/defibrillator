using Core.Models;
using Mashine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DefibrillatorBase.Controllers
{
    public class MapController : ApiController
    {
        MapService db = new MapService();


        //Get api/Map/GetAllMapData
        public List<Defibrillator> GetAllMapData()
        {
           return db.GetAll();
        }

        //POST api/Map/AddNewDefibrillator
        public void AddNewDefibrillator(Defibrillator def)
        {
            db.AddNew(def);
        }
    }
}
