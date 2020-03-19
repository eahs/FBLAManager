using FBLAManager.Helpers;
using FBLAManager.Views;
using FBLAManager.Views.Events;
using FBLAManager.Views.Members;
using System;
using Xamarin.Forms;

namespace FBLAManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("MeetingDetailPage", typeof(MeetingDetailPage));
            Routing.RegisterRoute("calendar/dayview", typeof(CalendarPage));

            Navigating += AppShell_Navigating;
        }

        private async void AppShell_Navigating(object sender, ShellNavigatingEventArgs e)
        {
            //if (e.Source == ShellNavigationSource.Pop)
            //{
            //    e.Cancel();
            // }

            var dest = e.Target.Location.ToString();

            if (dest == "//logout/logoutpage")
            {
                e.Cancel();

                if (await DisplayAlert("Confirm", "Are you sure you want to log out?", "Yes", "No"))
                {
                    UserManager.Current.Logout();

                    await Shell.Current.GoToAsync("//logout/logoutpage?confirm=true");
                }
            }         
        }

        private async void OnProfileImageClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushModalAsync(new UserProfilePage()); 
        }
    }
}
