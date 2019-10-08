using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Syncfusion.SfSchedule.XForms;
using FBLAManager.ViewModels;

namespace FBLAManager.Views
{
    public partial class CalendarPage : ContentPage
    {
        private CalendarViewModel viewModel;

        public CalendarPage()
        {
            InitializeComponent();

            this.BindingContext = viewModel = new CalendarViewModel();

            schedule.ScheduleView = ScheduleView.MonthView;


        }
    }
}
