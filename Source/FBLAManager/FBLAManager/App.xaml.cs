using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FBLAManager.Services;
using FBLAManager.Views;
using FBLAManager.ViewModels.Forms;
using FBLAManager.Views.Forms;

namespace FBLAManager
{
    public partial class App : Application
    {

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTQ4MTk0QDMxMzcyZTMzMmUzMG1MVzdHOCtuR1kyM3lJdEVrM0RSZ1ZtTE5HK2Z5ZGNuOTM3Nld1dmNKWFE9");

            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            MessagingCenter.Subscribe<LoginPageViewModel>(this, "LoadApp", (sender) =>
            {
                MainPage = new AppShell();
            });

            MessagingCenter.Subscribe<LoginPageViewModel>(this, "SignupClicked", SignupClicked);


            MainPage = new FBLAManager.Views.Forms.SimpleLoginPage();
        }

        private void SignupClicked (Object o)
        {
            MainPage.Navigation.PushAsync(new SimpleSignUpPage());
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
