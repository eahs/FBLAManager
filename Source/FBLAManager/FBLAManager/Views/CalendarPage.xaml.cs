using System;
using Xamarin.Forms;
using Syncfusion.SfSchedule.XForms;
using Syncfusion.SfSchedule;
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

            schedule.CellTapped += Schedule_CellTapped1; 
            schedule.CellDoubleTapped += Schedule_CellTapped2;

            ViewMonth();

        }

        public CalendarPage(CalendarViewModel vm, DateTime date)
        {
            InitializeComponent();

            BindingContext = viewModel = vm;

            ViewDay(date);

            schedule.CellTapped += Schedule_CellTapped2;
        }

        //Monthview: Brings up dayview for that date
        private async void Schedule_CellTapped1(object sender, CellTappedEventArgs e)
        {
            if (schedule.ScheduleView == ScheduleView.MonthView)
            {
                var dateTime = e.Datetime;

                try
                {
                    await Shell.Current.Navigation.PushAsync(new CalendarPage(viewModel, dateTime));
                }

                catch
                {
                    new NotImplementedException();
                }
            }
        }


        //Dayview: Brings up event detail page
        private async void Schedule_CellTapped2(object sender, CellTappedEventArgs e)
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


        public void ViewDay(DateTime dateTime)
        {
            schedule.ScheduleView = ScheduleView.DayView;
            schedule.SelectedDate = dateTime;
            schedule.MoveToDate = dateTime;
        }

        public void ViewMonth()
        {
            schedule.ScheduleView = ScheduleView.MonthView;
        }


      

    }
}
