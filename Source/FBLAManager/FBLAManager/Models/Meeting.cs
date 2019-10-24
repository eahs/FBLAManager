using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FBLAManager.Models
{
    public enum MeetingType
    {
        Meeting = 1,
        Fundraiser = 2,
        CompetitiveEvent = 3,
        CommunityService = 4
    }

    public class Meeting
    {
        public string EventName { get; set; }
        public string Organizer { get; set; }

        public int MeetingId { get; set; }
        public string Description { get; set; }
        public string ContactID { get; set; }
        public int Capacity { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Color color { get; set; }
        public MeetingType Type { get; set; } = MeetingType.Meeting;
       
        public bool AllDay { get; set; }
    }
}
