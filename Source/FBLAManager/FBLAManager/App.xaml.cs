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

            MessagingCenter.Subscribe<LoginPageViewModel>(this, "SignupClicked", (sender) =>
            {
                MainPage = new AppShell();
            });


            MessagingCenter.Subscribe<LoginPageViewModel>(this, "SignupClicked", SignupClicked);
            MessagingCenter.Subscribe<SignUpPageViewModel>(this, "LoginClicked", LoginClicked);

            MainPage = new SimpleLoginPage();
        }

        async private void SignupClicked (Object o)
        {
            await MainPage.Navigation.PushModalAsync(new SimpleSignUpPage());
        }

        async private void LoginClicked (Object o)
        {
            await MainPage.Navigation.PopModalAsync(false);
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
