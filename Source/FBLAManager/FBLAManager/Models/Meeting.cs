using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace FBLAManager.Models
{
    /// <summary>
    /// The four different types of meetings.
    /// </summary>
    public enum MeetingType
    {
        Meeting = 1,
        ClubEvent = 2,
        CompetitiveEvent = 3,
        CommunityService = 4
    }

    /// <summary>
    /// Model for meeting templates.
    /// </summary>
    public class Meeting : INotifyPropertyChanged
    {
        #region Fields

        private string eventname;

        private string color = "000000";

        private string organizer;

        private string description;

        private string contactId;

        private int meetingId;
        
        private int capacity;

        private DateTime from;

        private DateTime to;

        private bool allDay;

        private ObservableCollection<MeetingAttendees> meetingAttendees;

        #endregion

        #region EventHandler

        /// <summary>
        /// EventHandler of property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public ObservableCollection<MeetingAttendees> MeetingAttendees {
            get { return meetingAttendees; }
            set { SetProperty(ref meetingAttendees, value);  }
        }

        /// <summary>
        /// Gets or sets the meeting name. 
        /// </summary>
        public string EventName {
            get { return eventname; }
            set { SetProperty(ref eventname, value); }
        }

        /// <summary>
        /// Gets or sets the organizer name. 
        /// </summary>
        public string Organizer
        {
            get { return organizer; }
            set { SetProperty(ref organizer, value); }
        }

        /// <summary>
        /// Gets or sets the meeting ID. 
        /// </summary>
        public int MeetingId
        {
            get { return meetingId; }
            set { SetProperty(ref meetingId, value); }
        }

        /// <summary>
        /// Gets or sets the meeting description. 
        /// </summary>
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        /// <summary>
        /// Gets or sets the contact ID of the organizer. 
        /// </summary>
        public string ContactId
        {
            get { return contactId; }
            set { SetProperty(ref contactId, value); }
        }

        /// <summary>
        /// Gets or sets the maximum meeting capacity. 
        /// </summary>
        public int Capacity
        {
            get { return capacity; }
            set { SetProperty(ref capacity, value); }
        }

        /// <summary>
        /// Gets or sets the start date and time of the meeting. 
        /// </summary>
        [JsonProperty("Start")]
        public DateTime From
        {
            get { return from; }
            set { SetProperty(ref from, value); }
        }

        /// <summary>
        /// Gets or sets the end date and time of the meeting. 
        /// </summary>
        [JsonProperty("End")]
        public DateTime To
        {
            get { return to; }
            set { SetProperty(ref to, value); }
        }

        /// <summary>
        /// Gets or sets the color used to display the meeting in the app. 
        /// </summary>
        public string Color {
            get { return color; }
            set { SetProperty(ref color, value); OnPropertyChanged("XamColor"); }
        }

        /// <summary>
        /// Helper method that changes a color value. 
        /// </summary>
        public Color XamColor
        {
            get
            {
                return Xamarin.Forms.Color.FromHex(Color.Replace("#", ""));
            }
        }

        /// <summary>
        /// Gets or sets the meeting type. 
        /// </summary>
        public MeetingType Type { get; set; } = MeetingType.Meeting;

        /// <summary>
        /// Gets or sets the "All Day" bool. 
        /// </summary>
        public bool AllDay
        {
            get { return allDay; }
            set { SetProperty(ref allDay, value); }
        }

        #endregion

        #region Methods 

        /// <summary>
        /// The PropertyChanged method is used to change the value of a property.
        /// </summary>

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

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>
        
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
