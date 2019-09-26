using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Syncfusion.SfSchedule.XForms;
using FBLAManager.ViewModels;

namespace FBLAManager.Views
{
    public partial class JunkPage : ContentPage
    {
        private CalendarViewModel viewModel;

        public JunkPage()
        {
            InitializeComponent();

            this.BindingContext = viewModel = new CalendarViewModel();

            schedule.ScheduleView = ScheduleView.MonthView;


        }
    }
}
