using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FBLAManager.Services;
using FBLAManager.Views;
using FBLAManager.ViewModels.Forms;
using FBLAManager.Views.Forms;
using FBLAManager.Helpers;
using System.Threading.Tasks;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Com.OneSignal;
using Xamarin.Essentials;
using AsyncAwaitBestPractices;
using MonkeyCache.FileStore;

namespace FBLAManager
{
    public partial class App : Application
    {
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTQ4MTk0QDMxMzcyZTMzMmUzMG1MVzdHOCtuR1kyM3lJdEVrM0RSZ1ZtTE5HK2Z5ZGNuOTM3Nld1dmNKWFE9");
            Barrel.ApplicationId = "fblamanager";

            InitializeComponent();

            MessagingCenter.Subscribe<LoginPageViewModel>(this, "LoadApp", (sender) =>
            {
                MainPage = new AppShell();
            });

            MessagingCenter.Subscribe<SignUpPageViewModel>(this, "LoadApp", (sender) =>
            {
                MainPage = new AppShell();
            });

            MessagingCenter.Subscribe<LoginPageViewModel>(this, "SignupClicked", SignupClicked);
            MessagingCenter.Subscribe<LoginPageViewModel>(this, "ForgotPasswordClicked", ForgotPasswordClicked);
            MessagingCenter.Subscribe<SignUpPageViewModel>(this, "LoginClicked", LoginClicked);
            MessagingCenter.Subscribe<ForgotPasswordViewModel>(this, "SignupClicked", SignupClicked);
            MessagingCenter.Subscribe<Onboarding>(this, "GetStarted", (sender) => {

                Startup(true).SafeFireAndForget(onException: ex => Crashes.TrackError(ex));

            });

            Startup().SafeFireAndForget(onException: ex => Crashes.TrackError(ex)); ;

            OneSignal.Current.StartInit("1c3e4393-0690-49b2-8e35-1281c2172bef")
                  .EndInit();
        }

        async private Task<bool> Startup (bool skipWalkthrough = false)
        {
#if DEBUG
            bool watchedTutorial = skipWalkthrough;
#else
            bool watchedTutorial = Preferences.Get("WatchedTutorial", false);
#endif
            if (!watchedTutorial)
                MainPage = new Onboarding();
            else if (await UserManager.Current.IsLoggedIn())
                MainPage = new AppShell();
            else
                MainPage = new SimpleLoginPage();

            return true;
        }

        async private void SignupClicked (Object o)
        {
            await MainPage.Navigation.PushModalAsync(new SimpleSignUpPage());
        }

        async private void LoginClicked (Object o)
        {
            //await MainPage.Navigation.PopModalAsync(false);
            await MainPage.Navigation.PushModalAsync(new SimpleLoginPage());
        }
        

        async private void ForgotPasswordClicked(Object o)
        {
            await MainPage.Navigation.PushModalAsync(new SimpleForgotPasswordPage());

        }

        protected override void OnStart()
        {
            AppCenter.Start("android=f13f8936-f34e-4a53-9afe-132ccd13c0bf;" +
                              "ios=97c915d2-476e-416d-a980-00a08f5b05b3",
                              typeof(Analytics), typeof(Crashes));
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
