using MyHappy2Homes.Views;
using System.ComponentModel;
using Xamarin.Forms;

namespace MyHappy2Homes.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public Command LoginCommand => new Command(Login);

        public Command SignUp
        {
            get
            {
                return new Command(() => { Application.Current.MainPage.Navigation.PushAsync(new Signup()); });
            }
        }

        private async void Login()
        {
            //null or empty field validation, check weather email and password is null or empty    

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                await Application.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                //call GetUser function which we define in Firebase helper class    
                var account = await FirebaseHelper.GetAccount(Email);
                //firebase return null valuse if user data not found in database    
                if (account != null)
                    if (Email == account.UserEmail && Password == account.Password)
                    {
                        await Application.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                        //Navigate to Wellcom page after successfuly login    
                        //pass user email to welcom page    
                        await Application.Current.MainPage.Navigation.PushAsync(new HomePage(Email, Password));
                    }
                    else
                        await Application.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
                else
                    await Application.Current.MainPage.DisplayAlert("Login Fail", "User not found", "OK");
            }
        }
    }
}
