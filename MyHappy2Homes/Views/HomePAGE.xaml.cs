using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHappy2Homes.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHappy2Homes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private HomePageViewModel homePageViewModel; 
        public HomePage(string email, string password)
        {
            InitializeComponent();

            homePageViewModel = new HomePageViewModel(email, password);
            BindingContext = homePageViewModel;
        }
    }
}