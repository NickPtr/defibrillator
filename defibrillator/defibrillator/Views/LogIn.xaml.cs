using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using defibrillator.Model;
using defibrillator.Views;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace defibrillator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {
        private List<User> posdef = null;
        private User user;
        private User user_photo;
        private MyWebRequest request;
        private String[] strlist;
        private string ok;
        private string body;
        public LogIn()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Σύνδεση");

            user = new User();

            user.Mail = Username.Text;
            user.Password = Password.Text;
            
            
            try
            {
                 request = new MyWebRequest();

                 await request.OnAdd(user, "login");

                if (request.Get_Confirmation().Contains("OK"))
                {
                    await Request();

                    Console.WriteLine(strlist[13]);
                    Console.WriteLine(ok);
                    user.ProfilePicture = ok;
                    Username.Text = "";
                    Password.Text = "";
                    UserDialogs.Instance.HideLoading();
                    this.Navigation.PushAsync(new TabedPage(user), true);
                }
                else
                {
                    Alert.Text = "Wrong e-mail or password";
                    Username.Text = "";
                    Password.Text = "";
                }
            }
            catch (Exception exception)
            {
                DisplayAlert("ok",exception.ToString(),"ok");

            }

            
        }

        
        public async Task Request()
        {
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://samosdefibrillator.azurewebsites.net/api/user/postuser";
            var client = new HttpClient();

            HttpResponseMessage response = await client.PostAsync(url, data);
            body = await response.Content.ReadAsStringAsync();

            String[] spearator = { "\"" , "}]" };
            Int32 count = 15;
            strlist = body.Split(spearator, count, StringSplitOptions.None);
            this.ok = strlist[13];

            Console.WriteLine(strlist);

            


            //Set_Confirmation(result.ToString());
        }

        public async Task ShowMessage(string message,
            string title,
            string buttonText,
            Action afterHideCallback)
        {
            await DisplayAlert(
                title,
                message,
                buttonText);

            afterHideCallback?.Invoke();
        }

        private void Create_OnClicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new SignUp(), true);
        }
    }
}