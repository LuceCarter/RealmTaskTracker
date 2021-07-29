using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Realms.Sync;

namespace RealmDotnetTutorial
{
    public partial class App : Application
    {
        private const string appId = "tasktracker-uaahz";
        public static Realms.Sync.App RealmApp;

        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            // TODO: call Realms.Sync.App.Create()
            RealmApp = Realms.Sync.App.Create(appId);
            if (App.RealmApp.CurrentUser == null)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new ProjectPage());
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }

    public static class Constants
    {
        public static bool AlreadyWarnedAboutBackendSetup { get; set; }
    }
}
