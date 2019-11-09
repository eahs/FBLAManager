using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FBLAManager.Models
{
    public enum MeetingType
    {
        Meeting = 1,
        ClubEvent = 2,
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
        [JsonProperty("Start")]
        public DateTime From { get; set; }
        [JsonProperty("End")]
        public DateTime To { get; set; }
        public string Color { get; set; } = "000000";
        public Color XamColor
        {
            get
            {
                return Xamarin.Forms.Color.FromHex(Color);
            }
        }
        public MeetingType Type { get; set; } = MeetingType.Meeting;
       
        public bool AllDay { get; set; }
    }
}
