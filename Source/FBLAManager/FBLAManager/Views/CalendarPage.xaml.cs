using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Syncfusion.SfSchedule.XForms;
using Syncfusion.SfSchedule;
using FBLAManager.ViewModels;

namespace FBLAManager.Views
{
    public partial class CalendarPage : ContentPage
    {
        private CalendarViewModel viewModel;

        public CalendarPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CalendarViewModel();

            schedule.CellTapped += Handle_CellTapped1;
            schedule.HeaderTapped += Handle_HeaderTapped1; 

            ViewMonth();

        }

        private void Handle_CellTapped1(object sender, CellTappedEventArgs e)
        {
            var dateTime = e.Datetime;

            try 
            {
                ViewDay(dateTime);
            }

            catch
            {
                new NotImplementedException();
            }
        }

        private void Handle_HeaderTapped1(object sender, HeaderTappedEventArgs e)
        {
            try
            {
                ViewMonth();
            }

            catch
            {
                new NotImplementedException();
            }
        }

        public void ViewDay(DateTime dateTime)
        {
            schedule.SelectedDate = dateTime;
            schedule.ScheduleView = ScheduleView.DayView;
        }

        public void ViewMonth()
        {
            schedule.ScheduleView = ScheduleView.MonthView;
        }


      

    }
}
