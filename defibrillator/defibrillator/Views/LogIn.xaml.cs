using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using defibrillator.Model;
using defibrillator.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace defibrillator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {
        public LogIn()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {

            var user = new User();

            user.Mail = Username.Text;
            user.Password = Password.Text;

            
            try
            {
                MyWebRequest request = new MyWebRequest();

                await request.OnAdd(user, "login");

                if (request.Get_Confirmation().Contains("OK"))
                {
                    this.Navigation.PushAsync(new TabedPage(), true);

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