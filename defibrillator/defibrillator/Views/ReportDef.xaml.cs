using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using defibrillator.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace defibrillator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportDef : ContentPage
    {
        private Defibrillator d;
        private User user;
        public ReportDef(Defibrillator d, User user)
        {
            InitializeComponent();
            this.user = user;
            this.d = d;

        }

        private void SendButton(object sender, EventArgs e)
        {
            Report rep = new Report();
            rep.Posx = d.Posx;
            rep.Posy = d.Posy;
            rep.Comment = comment.Text;
            rep.Elses = other.Text;
            rep.Type = reason.SelectedItem.ToString();
            MyWebRequest req = new MyWebRequest();
            req.OnAdd(rep, "Report");
            UserDialogs.Instance.Alert("Ολκληρώθηκε");
            this.Navigation.PushAsync(new TabedPage(user), true);
        }

        private void Reason_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = reason.SelectedItem;
            if (selectedItem.ToString()=="Άλλο")
            {
                other.IsVisible = true;
            }
            else
            {
                other.IsVisible = false;
            }
        }
    }
}