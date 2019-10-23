using FBLAManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.ListView.XForms;

namespace FBLAManager.Views.Events
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeetingsPage : ContentPage
    {
        public MeetingsPage()
        {
            InitializeComponent();

           
        }

        private async void Meetings_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Meeting m = (Meeting)e.ItemData;

            // Look up parameters at https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/shell/navigation

           // await Shell.Current.GoToAsync($"signup?meetingId={m.MeetingId}");

            await Shell.Current.GoToAsync("MeetingsDetailPage");
        }

        private void Meetings_ItemHolding(object sender, ItemHoldingEventArgs e)
        {
            //do something
        }
    }
}