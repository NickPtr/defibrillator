using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace defibrillator.Model
{
    class MyWebRequest
    {

        public string result;
        public async Task OnAdd(User user,string what)
         {

             var json = JsonConvert.SerializeObject(user);
             var data = new StringContent(json, Encoding.UTF8, "application/json");

             var url = "http://samosdefibrillator.azurewebsites.net/api/user/"+what;
             var client = new HttpClient();

             var response = await client.PostAsync(url, data);

             var result = response.EnsureSuccessStatusCode().StatusCode;
             Console.WriteLine(result);
            Set_Confirmation(result.ToString());


        }

        public async Task OnAdd(Defibrillator def, string what)
        {

            var json = JsonConvert.SerializeObject(def);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://samosdefibrillator.azurewebsites.net/api/Map/"+ what;
            var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            var result = response.EnsureSuccessStatusCode().StatusCode;
            Console.WriteLine(result);
            Set_Confirmation(result.ToString());


        }


        public async Task OnAdd(Report rep, string what)
        {

            var json = JsonConvert.SerializeObject(rep);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://samosdefibrillator.azurewebsites.net/api/Map/" + what;
            var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            var result = response.EnsureSuccessStatusCode().StatusCode;
            Console.WriteLine(result);
            Set_Confirmation(result.ToString());


        }

        public void Set_Confirmation(string result)
        {
            this.result = result;
        }

        public string Get_Confirmation()
        {
            return result;
        }

    }
}
