using FBLAManager.Views;
using FBLAManager.Views.Events;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FBLAManager
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("ItemDetailPage", typeof(ItemDetailPage));
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

            if (await DisplayAlert("Confirm", "Do you want to log out?", "Yes", "No") && dest == "//logout/logoutpage")
            {
                
                
            }
            else
            {
                e.Cancel();
            }
           
        }
    }
}
