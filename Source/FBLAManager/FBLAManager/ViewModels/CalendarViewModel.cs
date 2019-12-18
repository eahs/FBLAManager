using FBLAManager.Helpers;
using FBLAManager.Models;
using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FBLAManager.ViewModels
{
    /// <summary>   
    /// Represents collection of appointments.   
    /// </summary> 
    public class CalendarViewModel : BaseViewModel
    {
        public ObservableCollection<Meeting> CalendarMeetings { get; set; }


        public CalendarViewModel()
        {
            CalendarMeetings = new ObservableCollection<Meeting>();

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

                UserManager.Current.AddAuthorization(request);

                try
                {

                    var response = await client.ExecuteTaskAsync(request);

                    if (response.IsSuccessful)
                    {
                        var items = JsonConvert.DeserializeObject<List<Meeting>>(response.Content) ?? new List<Meeting>();

                        foreach (var meeting in items)
                        {
                            CalendarMeetings.Add(meeting);
                        }

                        OnPropertyChanged("CalendarMeetings");

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
                    var properties = new Dictionary<string, string> {
                    { "Category", "Calendar" }
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
