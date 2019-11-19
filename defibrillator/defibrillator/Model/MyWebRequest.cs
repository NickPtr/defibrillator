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



       


        /* private const string URL = "";
         private HttpClient client = new HttpClient();*/

        public async Task OnAdd(User user)
         {
             //var post = new User {};
             //var content = JsonConvert.SerializeObject(user);

             var json = JsonConvert.SerializeObject(user);
             var data = new StringContent(json, Encoding.UTF8, "application/json");

             var url = "http://samosdefibrillator.azurewebsites.net/api/user";
             var client = new HttpClient();

             var response = await client.PostAsync(url, data);

             string result = response.Content.ReadAsStringAsync().Result;
             Console.WriteLine(result);

            // await client.PostAsync(URL, new StringContent(content));
            //var response = client.PostAsJsonAsync("http://www.samosdefibrillator.net/api/user",content);

            //Console.WriteLine(response);

        }

    }
}
