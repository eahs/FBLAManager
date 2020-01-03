using FBLAManager.Helpers;
using FBLAManager.Models;
using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FBLAManager.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<Announcement> Announcements { get; set; }

        public HomePageViewModel()
        {
            Announcements = new ObservableCollection<Announcement>();

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
                request.Resource = String.Format(GlobalConstants.MessageBoardEndPointRequestURL);
                UserManager.Current.AddAuthorization(request);

                try
                {

                    var response = await client.ExecuteTaskAsync(request);

                    if (response.IsSuccessful)
                    {
                        var items = JsonConvert.DeserializeObject<List<Announcement>>(response.Content) ?? new List<Announcement>();

                        Announcements.Clear();

                        foreach (var announcement in items)
                        {
                            Announcements.Add(announcement);
                        }

                        OnPropertyChanged("Announcements");

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
                    { "Category", "HomePage" }
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
