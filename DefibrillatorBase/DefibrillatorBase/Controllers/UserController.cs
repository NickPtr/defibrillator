using Core.Models;
using Mashine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace DefibrillatorBase.Controllers
{
    public class UserController : ApiController
    {
        Worker db = new Worker();


        // POST api/User/Login
        public HttpResponseMessage Login(User user)
        {
            if (db.CheckLogin(user))
                return new HttpResponseMessage(HttpStatusCode.OK);
            return new HttpResponseMessage(HttpStatusCode.NotFound);

        }

        // POST api/User/Register
        public HttpResponseMessage Register(User user)
        {
            if (!db.CreateANewUser(user))
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            return new HttpResponseMessage(HttpStatusCode.OK);
            

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}