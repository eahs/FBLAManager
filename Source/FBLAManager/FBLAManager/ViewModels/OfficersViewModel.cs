﻿using FBLAManager.Helpers;
using FBLAManager.Models;
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

                    var response = await client.ExecuteTaskAsync(request);

                    if (response.IsSuccessful)
                    {
                        var items = JsonConvert.DeserializeObject<List<Officer>>(response.Content) ?? new List<Officer>();


                        Officers.Clear();

                        foreach (var officer in items)
                        {
                            Officers.Add(officer);
                        }

                        OnPropertyChanged("Officers");

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
                    { "Category", "Officers" }
                  };
                    Crashes.TrackError(e, properties);

                    return UserManagerResponseStatus.NetworkError;
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
