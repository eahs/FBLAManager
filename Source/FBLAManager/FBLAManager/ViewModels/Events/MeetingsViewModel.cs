
﻿using FBLAManager.Models;
using System.Collections.ObjectModel;


using Xamarin.Forms;

namespace FBLAManager.ViewModels
{
    public class MeetingsViewModel : BaseViewModel
    {
        public MeetingsViewModel()
        {
            Meetings = new ObservableCollection<Meeting>
            {
                new Meeting
                {
                    MeetingId = 1,

                    EventName = "Bingo Night Fundraiser",
                    Organizer = "FBLA",
                    Description = "Volunteer at the bingo night fundraiser.",

                    From = new System.DateTime(2019, 11, 1, 7, 0, 0),
                    To = new System.DateTime(2019, 11, 1, 10, 0, 0),

                    Color = new Color(255, 0, 0),

                    Type = MeetingType.CompetitiveEvent
                },

                new Meeting
                {
                    MeetingId = 2,

                    EventName = "October Meeting",
                    Organizer = "FBLA",
                    Description = "Discuss how to storm the White House.",

                    

                    Type = MeetingType.Meeting
                }
            };

        }

        public ObservableCollection<Meeting> Meetings { get; set; }
    }

}