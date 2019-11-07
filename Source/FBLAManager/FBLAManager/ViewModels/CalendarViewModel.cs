using FBLAManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FBLAManager.ViewModels
{
    /// <summary>   
    /// Represents collection of appointments.   
    /// </summary> 
    public class CalendarViewModel
    {
        public ObservableCollection<Meeting> CalendarMeetings { get; set; }


        private MeetingsViewModel meetings;

        public CalendarViewModel()
        {
            meetings = new MeetingsViewModel();
            CalendarMeetings = new ObservableCollection<Meeting>();


            foreach (Meeting m in meetings.Meetings)
            {
                CalendarMeetings.Add(m);
            }

  
        }

       
    }
}
