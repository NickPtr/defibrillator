using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace defibrillator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabedPage : TabbedPage
    {
        public TabedPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            this.Children.Add(new MainPage());
            this.Children.Add(new Camera());
        }
    }
}