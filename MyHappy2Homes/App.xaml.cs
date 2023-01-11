using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyHappy2Homes.Views;

namespace MyHappy2Homes
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
            MainPage = new NavigationPage(new LoginPage());
            

        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}
