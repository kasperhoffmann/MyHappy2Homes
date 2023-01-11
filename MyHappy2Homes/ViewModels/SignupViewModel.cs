using System.ComponentModel;
using MyHappy2Homes.Views;
using Xamarin.Forms;

namespace MyHappy2Homes.ViewModels
{
    public class SignupViewModel : INotifyPropertyChanged
    {
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

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("ConfirmPassword"));
            }
        }
        public Command SignUpCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (Password == ConfirmPassword)
                        SignUp();
                    else
                        Application.Current.MainPage.DisplayAlert("", "Password must be same as above!", "OK");
                });
            }
        }
        private async void SignUp()
        {
            //null or empty field validation, check weather email and password is null or empty    

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                await Application.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                //call AddUser function which we define in Firebase helper class    
                var account = await FirebaseHelper.AddAccount(Email, Password);
                //AddUser return true if data insert successfuly     
                if (account)
                {
                    await Application.Current.MainPage.DisplayAlert("SignUp Success", "", "Ok");
                    //Navigate to Wellcom page after successfuly SignUp    
                    //pass user email to welcom page    
                    await Application.Current.MainPage.Navigation.PushAsync(new HomePage(Email, Password));
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "SignUp Fail", "OK");

            }
        }
    }
}
