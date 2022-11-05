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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnSignupClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Signup());
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}