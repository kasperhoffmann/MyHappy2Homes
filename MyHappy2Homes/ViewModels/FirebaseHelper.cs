using MyHappy2Homes.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace MyHappy2Homes.ViewModels
{
    public class FirebaseHelper
    {
        //Connect app with firebase using API Url  
        public static FirebaseClient firebase = new FirebaseClient("your database API URI");

        //Read All    
        public static async Task<List<Account>> GetAllAccounts()
        {
            try
            {
                var accountlist = (await firebase
                .Child("Account")
                .OnceAsync<Account>()).Select(item =>
                new Account()
                {
                    UserEmail = item.Object.UserEmail,
                    Password = item.Object.Password
                }).ToList();
                return accountlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Read     
        public static async Task<Account> GetAccount(string email)
        {
            try
            {
                var allAccounts = await GetAllAccounts();
                await firebase
                .Child("Account")
                .OnceAsync<Account>();
                return allAccounts.Where(a => a.UserEmail == email).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Insert an Account    
        public static async Task<bool> AddAccount(string email, string password)
        {
            try
            {


                await firebase
                .Child("Account")
                .PostAsync(new Account() { UserEmail = email, Password = password });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Update     
        public static async Task<bool> UpdateAccount(string email, string password)
        {
            try
            {


                var toUpdateAccount = (await firebase
                    .Child("Account")
                    .OnceAsync<Account>()).FirstOrDefault(a => a.Object.UserEmail == email);
                if (toUpdateAccount != null)
                    await firebase
                        .Child("Account")
                        .Child(toUpdateAccount.Key)
                        .PutAsync(new Account() { UserEmail = email, Password = password });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Delete Account    
        public static async Task<bool> DeleteAccount(string email)
        {
            try
            {


                var toDeleteAccount = (await firebase
                    .Child("Account")
                    .OnceAsync<Account>()).FirstOrDefault(a => a.Object.UserEmail == email);
                if (toDeleteAccount != null) await firebase.Child("Account").Child(toDeleteAccount.Key).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

    }
}
