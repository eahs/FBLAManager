using Newtonsoft.Json;
using RestSharp;
﻿using FBLAManager.Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using FBLAManager.Helpers;
using System.Windows.Input;
using Microsoft.AppCenter.Crashes;

namespace FBLAManager.ViewModels
{
    /// <summary>
    /// Viewmodel for meetings and events pages. 
    /// </summary>
    public class MeetingsViewModel : BaseViewModel
    {
        public ObservableCollection<Meeting> Meetings { get; set; }
        
        public MeetingType type { get; set; } = MeetingType.Meeting;
        public MeetingsViewModel(MeetingType meetingType = MeetingType.Meeting)
        {
            Meetings = new ObservableCollection<Meeting>();
            type = meetingType;

            LoadItemsCommand.Execute(null);
        }

        private RelayCommand refreshItemsCommand;
        public ICommand RefreshCommand
        {
            get
            {
                return refreshItemsCommand ?? (refreshItemsCommand = new RelayCommand(async () => await ExecuteLoadItemsCommand()));
            }
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
            }
        }

        protected override async Task ExecuteLoadItemsCommand()
        {
            IsRefreshing = true;
            await base.ExecuteLoadItemsCommand();
            IsRefreshing = false;
        }

        protected override async Task LoadItemsAsync()
        {

            try
            {
                // Make async request to obtain data
                var client = new RestClient(GlobalConstants.EndPointURL);
                var request = new RestRequest
                {
                    Timeout = GlobalConstants.RequestTimeout
                };
                request.Resource = GlobalConstants.MeetingEndPointRequestURL;
                UserManager.Current.AddAuthorization(request);

                try
                {

                    DataAvailable = false;

                    var response = await client.ExecuteCachedAPITaskAsync(request, GlobalConstants.MaxCacheMeetings, false, true);

                    ErrorMessage = response.ErrorMessage;
                    IsError = !response.IsSuccessful;

                    if (response.IsSuccessful)
                    {
                        var items = JsonConvert.DeserializeObject<List<Meeting>>(response.Content) ?? new List<Meeting>();

                        foreach (var meeting in items)
                        {
                            // only adds meeting from backend if it matches the meeting type of the page and if it's in the future
                            if (meeting.Type == type && meeting.From >= DateTime.Now)
                            {
                                var existingMeeting = Meetings.FirstOrDefault(m => m.MeetingId == meeting.MeetingId);

                                if (existingMeeting != null)
                                {
                                    existingMeeting.AllDay = meeting.AllDay;
                                    existingMeeting.Capacity = meeting.Capacity;
                                    existingMeeting.Color = meeting.Color;
                                    existingMeeting.ContactId = meeting.ContactId;
                                    existingMeeting.Description = meeting.Description;
                                    existingMeeting.EventName = meeting.EventName;
                                    existingMeeting.From = meeting.From;
                                    existingMeeting.MeetingId = meeting.MeetingId;
                                    existingMeeting.Organizer = meeting.Organizer;
                                    existingMeeting.To = meeting.To;
                                    existingMeeting.Type = meeting.Type;
                                    existingMeeting.MeetingAttendees.Clear();
                                    foreach (var attendee in meeting.MeetingAttendees)
                                    {
                                        existingMeeting.MeetingAttendees.Add(attendee);
                                    }
                                    existingMeeting.OnPropertyChanged("MeetingAttendees");
                                }
                                else
                                {
                                    Meetings.Add(meeting);
                                }
                            }

                        }

                        OnPropertyChanged("Meetings");

                        DataAvailable = true;
                    }
                }
                catch (Exception e)
                {
                    var properties = new Dictionary<string, string> {
                    { "Category", "Meetings" }
                    };
                    Crashes.TrackError(e, properties);

                }
            }
            catch (Exception)
            {
                // An exception occurred
                DataAvailable = false;
            }
        }


    }

}