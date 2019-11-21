using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using defibrillator.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace defibrillator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditDef : ContentPage
    {
        
        public EditDef(Defibrillator d)
        {
            InitializeComponent();

            namedef.Text = d.Name;
            discriptiondef.Text = d.Description;
            posxdef.Text = d.Posx;
            posydef.Text = d.Posy;
            imagedef.Source = d.PhotoLink;
           

        }

        private async void Save(object sender, EventArgs e)
        {
            Defibrillator d = new Defibrillator();
            d.Name = namedef.Text;
            d.Description = discriptiondef.Text;
            d.PhotoLink = imagedef.Source.ToString();
            d.Posx = posxdef.Text;
            d.Posy = posydef.Text;
            try
            {
                MyWebRequest request = new MyWebRequest();
                //DisplayAlert("Alert", d.Name, "Ok");
                await request.OnAdd(d, "UpdateData");

                if (request.Get_Confirmation().Contains("OK"))
                {
                    DisplayAlert("Alert", "Your changes applied succesfully", "Ok");
                    MainPage main = new MainPage();
                    this.Navigation.PushAsync(new TabedPage(), true);

                }
                else
                {
                    DisplayAlert("Alert", "Something went wrong!", "Ok");
                }
            }
            catch (Exception exception)
            {
                DisplayAlert("Alert", exception.ToString(), "Ok");

            }
        }
    }
}