using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyHappy2Homes.ViewModels
{
    public class HomePageViewModel
    {
        private string UserEmail { get; set; }
        private string Password { get; set; }
        public Command UpdateCommand => new Command(Update);
        public Command DeleteCommand => new Command(Delete);
        public Command LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    Application.Current.MainPage.Navigation.PopAsync();
                });
            }
        }

        public HomePageViewModel(string userEmail, string password)
        {
            UserEmail = userEmail;
            Password = password;
        }

        private async void Update()
        {
            try
            {
                if (!string.IsNullOrEmpty(Password))
                {
                    var isupdate = await FirebaseHelper.UpdateAccount(UserEmail, Password);
                    if (isupdate)
                        await Application.Current.MainPage.DisplayAlert("Update Success", "", "Ok");
                    else
                        await Application.Current.MainPage.DisplayAlert("Error", "Record not update", "Ok");
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Password Require", "Please Enter your password", "Ok");
            }
            catch (Exception e)
            {

                Debug.WriteLine($"Error:{e}");
            }
        }

        private async void Delete()
        {
            try
            {
                var isdelete = await FirebaseHelper.DeleteAccount(UserEmail);
                if (isdelete)
                    await Application.Current.MainPage.Navigation.PopAsync();
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "Record not delete", "Ok");
            }
            catch (Exception e)
            {

                Debug.WriteLine($"Error:{e}");
            }
        }
    }
}
