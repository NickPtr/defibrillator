using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Android.Media;
using defibrillator.Model;
using Microsoft.WindowsAzure.Storage;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace defibrillator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public HtmlWebViewSource Source { get; set; }
        public MediaFile _mediaFile;
        private string URL { get; set; }
        private User user;
        public Profile(User user)
        {
            InitializeComponent();
            this.user = user;
            profname.Text=user.Mail;
            if (user.ProfilePicture == "")
            {
                profpic.Source = "profile.png";
            }
            else
            {
                profpic.Source = user.ProfilePicture;
            }

        }

        private void Logout_OnClicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new LogIn(), true);
        }

        private async void Profpic_OnClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "This is not support on your device.", "OK");
                return;
            }
            else
            {
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Small
                };
                _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile == null) return;

                if (_mediaFile == null)
                {
                    await DisplayAlert("Error", "There was an error when trying to get your image.", "OK");
                    return;
                }
                else
                {
                    UploadImage(_mediaFile.GetStream());
                }

                profpic.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
                //UploadedUrl.Text = "Image URL:";


            }
        }

   
        private async void UploadImage(System.IO.Stream stream)
        {
            UserDialogs.Instance.ShowLoading("Ανέβασμα Φωτογραφίας");
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=defibrillatorphotodata;AccountKey=d7CG+7nZGxUc40BPZXSLVi1eILcwEd3wb/JyrMh/AlL+kp/jjFGhW2vZawUQEpRDTujlJJ0hrStaM7n4We2vWw==;EndpointSuffix=core.windows.net");
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference("images");
            await container.CreateIfNotExistsAsync();
            var name = Guid.NewGuid().ToString();
            var blockBlob = container.GetBlockBlobReference($"{name}.png");
            await blockBlob.UploadFromStreamAsync(stream);
            string URL = blockBlob.Uri.OriginalString;
            user.ProfilePicture = URL;
            MyWebRequest newreq = new MyWebRequest();
            newreq.OnAdd(user, "UpdateUser");
            UserDialogs.Instance.HideLoading();
            
        }

    }
}