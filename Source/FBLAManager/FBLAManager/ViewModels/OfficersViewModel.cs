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
    public class OfficersViewModel : BaseViewModel
    {
        public ObservableCollection<Officer> Officers { get; set; }

        //Level: national, state, local 
        public int Level { get; set; } = 0;

        public OfficersViewModel(int level = 0)
        {
            Officers = new ObservableCollection<Officer>();
            Level = level;

            LoadItemsCommand.Execute(null);

        }

        /// <summary>
        /// Loads the officers from the backend server.
        /// </summary>
        /// <returns></returns>
        protected override async Task LoadItemsAsync()
        {
            await Task.Delay(2000);

            try
            {

                // Make async request to obtain data
                var client = new RestClient(GlobalConstants.EndPointURL);
                var request = new RestRequest
                {
                    Timeout = GlobalConstants.RequestTimeout
                };
                request.Resource = String.Format(GlobalConstants.OfficerEndPointRequestURL, Level);
                UserManager.Current.AddAuthorization(request);

                try
                {

                    DataAvailable = false;

                    var response = await client.ExecuteCachedAPITaskAsync(request, GlobalConstants.MaxCacheOfficers, false, true);

                    response.IsSuccessful = false;
                    ErrorMessage = response.ErrorMessage;
                    
                    IsError = !response.IsSuccessful;

                    if (response.IsSuccessful)
                    {
                        var items = JsonConvert.DeserializeObject<List<Officer>>(response.Content) ?? new List<Officer>();


                        Officers.Clear();

                        foreach (var officer in items)
                        {
                            Officers.Add(officer);
                        }

                        OnPropertyChanged("Officers");

                        DataAvailable = Officers.Count > 0;
                    }
                }
                catch (Exception e)
                {
                    var properties = new Dictionary<string, string> {
                    { "Category", "Officers" }
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
