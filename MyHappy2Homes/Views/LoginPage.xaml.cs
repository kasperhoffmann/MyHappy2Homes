using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Commands;
using System.Text.RegularExpressions;
using MyHappy2Homes.ViewModels;

namespace MyHappy2Homes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel loginViewModel;
        public LoginPage()
        {
            InitializeComponent();

            loginViewModel = new LoginViewModel();
            BindingContext = loginViewModel;
        }
    }
}