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
    public partial class Profile : ContentPage
    {
        public Profile(User user)
        {
            InitializeComponent();
            profname.Text=user.Mail;
            if (user.ProfilePicture == null)
            {
                profpic.Source = "profile.png";
            }
            else
            {
                profpic.Source = user.ProfilePicture;
            }

        }

    }
}