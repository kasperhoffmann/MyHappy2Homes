using System;
using System.Collections.Generic;
using MyHappy2Homes.ViewModels;
using MyHappy2Homes.Views.MenuPages;
using MyHappy2Homes.Views;
using Xamarin.Forms;

namespace MyHappy2Homes
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
        }

    }
}
