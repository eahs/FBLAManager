﻿using FBLAManager.ViewModels;
using FBLAManager.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views.Events
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClubEventsPage : ContentPage
    {
        private MeetingsViewModel viewModel;
        public ClubEventsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MeetingsViewModel(MeetingType.ClubEvent);
        }

        private async void Meetings_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Meeting m = (Meeting)e.Item;

            if (Meetings.SelectedItem != null)
                Meetings.SelectedItem = null;

            var meetingDetailPage = new EventDetailPage(m);

            await Navigation.PushAsync(meetingDetailPage);
        }
    }
}