using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace defibrillator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Camera : ContentPage
    {
        private Stream camerasStream;
        public Camera()
        {
            InitializeComponent();

            CameraButton.Clicked += CameraButton_Clicked;

        }


        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
                PhotoImage.Source = ImageSource.FromStream(() =>
                {
                    camerasStream = photo.GetStream();
                    return photo.GetStream();
                });
        }


        private async void UploadImage(Stream stream)
        {
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=defibrillatorphotodata;AccountKey=d7CG+7nZGxUc40BPZXSLVi1eILcwEd3wb/JyrMh/AlL+kp/jjFGhW2vZawUQEpRDTujlJJ0hrStaM7n4We2vWw==;EndpointSuffix=core.windows.net");
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference("images");
            await container.CreateIfNotExistsAsync();
            var name = Guid.NewGuid().ToString();
            var blockBlob = container.GetBlockBlobReference($"{name}.png");
            await blockBlob.UploadFromStreamAsync(stream);
            string URL = blockBlob.Uri.OriginalString;
           
            await DisplayAlert("Uploaded", "Image uploaded to Blob Storage Successfully!", "OK");
        }

        private void Save_OnClicked(object sender, EventArgs e)
        {
           UploadImage(camerasStream);
        }
    }
}