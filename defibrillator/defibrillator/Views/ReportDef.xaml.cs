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
    public partial class ReportDef : ContentPage
    {
        public ReportDef(Defibrillator d)
        {
            InitializeComponent();



        }

        private void SendButton(object sender, EventArgs e)
        {
            
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