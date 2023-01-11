using MyHappy2Homes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHappy2Homes.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyHappy2Homes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signup : INotifyPropertyChanged
    {
        private SignupViewModel signupViewModel; 
        public Signup()
        {
            InitializeComponent();
            signupViewModel = new SignupViewModel();
            BindingContext = signupViewModel;
        }
    }
}