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
    public partial class TabedPage : TabbedPage
    {
        private User user;
        public TabedPage(User user)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.user = user;
            BarBackgroundColor = Color.FromHex("#6A2C90");
            BarTextColor = Color.White;
            this.Children.Add(new MainPage(user));
            this.Children.Add(new Camera(user));
            this.Children.Add(new Profile(user));
        }


    }
}