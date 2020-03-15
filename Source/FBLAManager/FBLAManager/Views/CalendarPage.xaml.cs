using System;
using Xamarin.Forms;
using Syncfusion.SfSchedule.XForms;
using FBLAManager.Models;
using FBLAManager.ViewModels;
using FBLAManager.Views.Events;

namespace FBLAManager.Views
{
    [QueryProperty("SelectedDate", "selecteddate")]
    public partial class CalendarPage : ContentPage
    {
        private CalendarViewModel viewModel;

        public CalendarPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CalendarViewModel();

            schedule.MonthInlineAppointmentTapped += Schedule_InlineEventTapped;

            schedule.ScheduleView = ScheduleView.MonthView;
        }


        //Brings up the detail page of a tapped inline event
        private async void Schedule_InlineEventTapped(object sender, MonthInlineAppointmentTappedEventArgs e)
        {
            Meeting m = (Meeting)e.Appointment;

            try
            {
                if (m.Type == MeetingType.Meeting)
                {
                    await Shell.Current.Navigation.PushAsync(new MeetingDetailPage(m));
                }
                else
                {
                    await Shell.Current.Navigation.PushAsync(new EventDetailPage(m));
                }
            }

            catch
            {
                new NotImplementedException();
            }
        }         
    }
}
