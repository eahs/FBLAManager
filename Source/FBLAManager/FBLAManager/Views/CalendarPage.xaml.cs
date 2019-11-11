using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Syncfusion.SfSchedule.XForms;
using Syncfusion.SfSchedule;
using FBLAManager.ViewModels;

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
           

            schedule.CellTapped += Schedule_CellTapped1; ;

            ViewMonth();

        }

        public CalendarPage(CalendarViewModel vm, DateTime date)
        {
            InitializeComponent();

            BindingContext = viewModel = vm;

            ViewDay(date);
        }

        /*
        private DateTime day;
        public string SelectedDate
        {
            set
            {
                string dt = value;                
            }
            get
            {
                return day.ToString();
            }
        }
        */

        private async void Schedule_CellTapped1(object sender, CellTappedEventArgs e)
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
