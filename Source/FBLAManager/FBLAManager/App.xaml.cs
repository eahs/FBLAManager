using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FBLAManager.Services;
using FBLAManager.Views;

namespace FBLAManager
{
    public partial class App : Application
    {

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTQ4MTk0QDMxMzcyZTMzMmUzMG1MVzdHOCtuR1kyM3lJdEVrM0RSZ1ZtTE5HK2Z5ZGNuOTM3Nld1dmNKWFE9");

            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
