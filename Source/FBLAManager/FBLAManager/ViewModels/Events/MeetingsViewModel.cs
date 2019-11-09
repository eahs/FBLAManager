using Newtonsoft.Json;
using RestSharp;
﻿using FBLAManager.Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

using Xamarin.Forms;

namespace FBLAManager.ViewModels
{
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

                var response = await client.ExecuteTaskAsync(request);

                if (response.IsSuccessful)
                {
                    var items = JsonConvert.DeserializeObject<List<Meeting>>(response.Content) ?? new List<Meeting>();

                    foreach (var meeting in items)
                    {
                        if (meeting.Type == type)
                        {
                            Meetings.Add(meeting);
                        }
                        
                    }

                    OnPropertyChanged("Meetings");

                    IsError = false;
                    DataAvailable = true;
                }
                else
                {
                    // An error occurred that is stored
                    ErrorMessage = "An error occurred";
                    DataAvailable = false;
                    IsError = true;
                }
            }
            catch (Exception e)
            {
                // An exception occurred
                DataAvailable = false;
            }
        }


    }

}