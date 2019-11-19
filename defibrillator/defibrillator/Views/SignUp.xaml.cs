using System;
using System.IO;
using System.Net;
using defibrillator.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using System.Text;

namespace defibrillator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
         

        private string status;
        public SignUp()
        {
            InitializeComponent();
        }

        private async void Register_OnClicked(object sender, EventArgs e)
        {
            var user = new User();

            user.Mail = mail.Text;
            user.Password = Password1.Text;

            MyWebRequest request = new MyWebRequest();

            await request.OnAdd(user);

            //request = WebRequest.Create("http://www.samosdefibrillator.net/api/user");
            //HttpContent content = new StringContent(user.ToString(), Encoding.UTF8, "http://www.samosdefibrillator.net/api/user");


            // MyWebRequest myRequest = new MyWebRequest("http://www.samosdefibrillator.net", "POST", user);


        }



        


    }


    

}