using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace DefibrillatorBase
{
    public class MobileMessagingClient
    {
        public readonly FirebaseMessaging messaging;

        public MobileMessagingClient()
        {
            var app = FirebaseApp.Create(new AppOptions() { Credential = GoogleCredential.FromFile("key.json").CreateScoped("https://www.googleapis.com/auth/firebase.messaging") });
            messaging = FirebaseMessaging.GetMessaging(app);
        }
        //...          
    }
}