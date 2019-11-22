using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using defibrillator.Model;
using Newtonsoft.Json;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace defibrillator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Defibrillator> list { get; set; }
        private List<Defibrillator> posdef=null;
        private double lan;
        private double lon;
        public MainPage()
        {
            InitializeComponent();
            
            Request();
            Location();
            Position position = new Position(lan,lon);
            MapSpan mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(0.444));
            map.MoveToRegion(mapSpan);
      
           
            foreach (var i in posdef)
            {
                Pin pin = new Pin
                {
                    Label = i.Name,
                    Address = i.Description,
                    Type = PinType.Place,
                    Position = new Position(double.Parse(i.Posx), double.Parse(i.Posy))
                };
                map.Pins.Add(pin);
            }

            if (!posdef.Equals(null))
            {
                list = new ObservableCollection<Defibrillator>();
                foreach (var i in posdef)
                {
                    list.Add(i);
                }

                listView.ItemsSource = list;
            }
           
            
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

        public void Request()
        {
            var apireq =
                WebRequest.Create("http://samosdefibrillator.azurewebsites.net/api/map/getallpoints") as HttpWebRequest;
            var apiresp = "";

            using (var response = apireq.GetResponse() as HttpWebResponse)
            {
                var reader = new StreamReader(response.GetResponseStream());
                apiresp = reader.ReadToEnd();
            }

            posdef = JsonConvert.DeserializeObject<List<Defibrillator>>(apiresp);
            
            
        }


        private void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            Defibrillator d = (Defibrillator)listView.SelectedItem;
        }

        private void OnTaped(object sender, ItemTappedEventArgs e)
        {
            Defibrillator d = (Defibrillator) listView.SelectedItem;
            Position position = new Position(double.Parse(d.Posx), double.Parse(d.Posy));
            MapSpan mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(0.444));
            map.MoveToRegion(mapSpan);
        }

        private void Edit(object sender, EventArgs e)
        {
            Defibrillator d = (Defibrillator)listView.SelectedItem;
            this.Navigation.PushAsync(new EditDef(d),true);
        }

        private void Report(object sender, EventArgs e)
        {
            Defibrillator d = (Defibrillator)listView.SelectedItem;
            this.Navigation.PushAsync(new ReportDef(d), true);
        }
    }

}