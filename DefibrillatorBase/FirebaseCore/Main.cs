using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Hosting;

namespace FirebaseCore
{
    public class MainFire
    {
        private IHostingEnvironment env;
        public string result;

        public MainFire(IHostingEnvironment env)
        {
            this.env = env;
        }

        public async Task OnGetAsync()
        {
            var path = env.ContentRootPath;
            path = path + "\\key.json";
            FirebaseApp app = null;
            try
            {
                app = FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile(path)
                }, "DefibrillatorBase");
            }
            catch (Exception ex)
            {
                app = FirebaseApp.GetInstance("DefibrillatorBase");
            }

            var fcm = FirebaseAdmin.Messaging.FirebaseMessaging.GetMessaging(app);
            Message message = new Message()
            {
                Notification = new Notification
                {
                    Title = "My push notification title",
                    Body = "Content for this push notification"
                },
                Data = new Dictionary<string, string>()
                {
                    { "AdditionalData1", "data 1" },
                    { "AdditionalData2", "data 2" },
                    { "AdditionalData3", "data 3" },
                },

                Topic = "all"
            };

            this.result = await fcm.SendAsync(message);
        }



    }
}
