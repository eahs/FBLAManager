﻿using FBLAManager.Models;
using System.Collections.ObjectModel;


using Xamarin.Forms;

namespace FBLAManager.ViewModels
{
    public class MeetingsViewModel : BaseViewModel
    {
        public MeetingsViewModel()
        {
            Meetings = new ObservableCollection<Meeting>();

            Meetings.Add(
                new Meeting
                {
                   EventName="MDA",
                   Organizer="FBLA",
                   Type=MeetingType.CompetitiveEvent
                }

             );
            Meetings.Add(
                new Meeting
                {
                    EventName = "October Meeting",
                    Organizer = "FBLA",
                    Type = MeetingType.Meeting
                }

             );

        }

        public ObservableCollection<Meeting> Meetings { get; set; }
    }
}