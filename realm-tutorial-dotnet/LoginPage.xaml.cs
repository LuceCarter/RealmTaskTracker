﻿using System;
using System.Threading.Tasks;
using Realms.Sync;
using Xamarin.Forms;

namespace realm_tutorial_dotnet
{
    public partial class LoginPage : ContentPage
    {
        private string email;
        private string password;

        public LoginPage()
        {
            InitializeComponent();
           
        }

        void Login_Button_Clicked(object sender, EventArgs e)
        {
            DoLogin();   
        }

        public event EventHandler<EventArgs> OperationCompeleted;

        private async void DoLogin()
        {
            try
            {
                var user = await App.realmApp.LogInAsync(Credentials.EmailPassword(email, password));
                if (user != null)
                {
                    OperationCompeleted?.Invoke(this, EventArgs.Empty);
                    await Navigation.PopAsync();
                    return;
                }
                else
                {
                    HandleFailure();
                }
            }catch (Exception ex)
            {
                //todo:

            }
        }
        void Register_Button_CLicked(object sender, EventArgs e)
        {
            RegisterUser();
        }

        private async void RegisterUser()
        {
            try
            {
                await App.realmApp.EmailPasswordAuth.RegisterUserAsync(email, password);
                DoLogin();
            } catch (Exception ex)
            {
                //todo: show exception nicely ex.ToString()
            }
        }

        void Email_Entry_Completed(object sender, System.EventArgs e)
        {
            email = ((Entry)sender).Text;
        }

        void Password_Entry_Completed(object sender, System.EventArgs e)
        {
            password = ((Entry)sender).Text;
        }

        private void HandleFailure()
        {
            //throw new NotImplementedException();
        }
    }
}
