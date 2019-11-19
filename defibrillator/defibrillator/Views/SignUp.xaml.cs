using System;
using System.IO;
using System.Net;
using defibrillator.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

            
            if (Password1.Text==Password2.Text)
            {
                try
                {
                    MyWebRequest request = new MyWebRequest();

                    await request.OnAdd(user, "register");
                    if (request.Get_Confirmation().Contains("OK"))
                    {
                        await ShowMessage("Succesfully register", "Alert", "Ok", async () =>
                        {
                            this.Navigation.PushAsync(new LogIn(), true);
                        });

                    }
                }
                catch (Exception exception)
                {
                   
                        await ShowMessage("This e-mail is already in use!", "Alert", "Ok", async () =>
                        {
                            this.Navigation.PushAsync(new SignUp(), true);
                        });

                    
                }
                
                
            }
            else
            {
                await ShowMessage("Not matched passwords", "Alert", "Ok", async () =>
                {
                    this.Navigation.PushAsync(new SignUp(), true);
                });
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
    }


    

}