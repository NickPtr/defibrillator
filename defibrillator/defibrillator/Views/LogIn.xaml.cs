﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using defibrillator.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace defibrillator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {
        public LogIn()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Create_OnClicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new SignUp(), true);
        }
    }
}