using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

    public class Meeting : INotifyPropertyChanged
    {
        private string eventname, color = "000000", organizer, description, contactId;
        private int meetingId, capacity;
        private DateTime from, to;
        private bool allDay;
        private ObservableCollection<MeetingAttendees> meetingAttendees;

        public ObservableCollection<MeetingAttendees> MeetingAttendees {
            get { return meetingAttendees; }
            set { SetProperty(ref meetingAttendees, value);  }
        }

        public string EventName {
            get { return eventname; }
            set { SetProperty(ref eventname, value); }
        }

        public string Organizer
        {
            get { return organizer; }
            set { SetProperty(ref organizer, value); }
        }

        public int MeetingId
        {
            get { return meetingId; }
            set { SetProperty(ref meetingId, value); }
        }

        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        public string ContactId
        {
            get { return contactId; }
            set { SetProperty(ref contactId, value); }
        }

        public int Capacity
        {
            get { return capacity; }
            set { SetProperty(ref capacity, value); }
        }

        [JsonProperty("Start")]
        public DateTime From
        {
            get { return from; }
            set { SetProperty(ref from, value); }
        }

        [JsonProperty("End")]
        public DateTime To
        {
            get { return to; }
            set { SetProperty(ref to, value); }
        }

        public string Color {
            get { return color; }
            set { SetProperty(ref color, value); OnPropertyChanged("XamColor"); }
        }

        public Color XamColor
        {
            get
            {
                return Xamarin.Forms.Color.FromHex(Color.Replace("#", ""));
            }
        }

        public MeetingType Type { get; set; } = MeetingType.Meeting;

        public bool AllDay
        {
            get { return allDay; }
            set { SetProperty(ref allDay, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
