using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using defibrillator.Model;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;
using Plugin.Media.Abstractions;

namespace defibrillator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Camera : ContentPage
    {
        private double lan;
        private double lon;
        private Stream camerasStream;
        private User user;
        public Camera(User user)
        {
            InitializeComponent();
            this.user = user;
            CameraButton.Clicked += CameraButton_Clicked;

            Position position = new Position(lan, lon);
            MapSpan mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(0.444));
            map.MoveToRegion(mapSpan);
            
            Location();

        }

        public async void Location()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
            lan = position.Latitude;
            lon = position.Longitude;
        }

       
        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { PhotoSize = PhotoSize.Small});

            if (photo != null)
                PhotoImage.Source = ImageSource.FromStream(() =>
                {
                    
                    camerasStream = photo.GetStream();
                    return photo.GetStream();
                });
        }


        private async void UploadImage(Stream stream)
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
            Defibrillator def = new Defibrillator();
            def.Description = description.Text;
            def.Name = this.name.Text;
            def.PhotoLink = URL;
            Location();
            def.Posx = lan.ToString();
            def.Posy = lon.ToString();
            UserDialogs.Instance.HideLoading();
            UserDialogs.Instance.ShowLoading("Προσθήκη στο χάρτη");
            MyWebRequest newreq = new MyWebRequest();
            newreq.OnAdd(def, "AddNewDefibrillator");
            UserDialogs.Instance.HideLoading();
            UserDialogs.Instance.Alert("Ολολκηρώθηκε");
            MainPage main = new MainPage(user);
            this.Navigation.PushAsync(new TabedPage(user), true);
        }




        private void Save_OnClicked(object sender, EventArgs e)
        {

            if (Check())
            {
                UploadImage(camerasStream);
            }

          
           
        }

        private bool Check()
        {
            if (name.Text == "" || description.Text == "" )
            {
                UserDialogs.Instance.Alert("Όλα τα παιδία πρέπει να είναι συμπληρωμένα");
                return false;
            }

            if (PhotoImage.Source == null)
            {
                UserDialogs.Instance.Alert("Δεν υπάρχει φωτογραφία");
                return false;
            }
                
            return true;
        }
    }
}