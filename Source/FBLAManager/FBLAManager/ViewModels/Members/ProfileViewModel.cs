using FBLAManager.Helpers;
using FBLAManager.Models;
using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace FBLAManager.ViewModels.Members
{
    class ProfileViewModel : BaseViewModel
    {
        public Member Profile { get; set; }

        public ProfileViewModel()
        {
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
                request.Resource = String.Format(GlobalConstants.ProfileEndPointRequestURL);
                UserManager.Current.AddAuthorization(request);

                try
                {

                    var response = await client.ExecuteTaskAsync(request);

                    if (response.IsSuccessful)
                    {
                        var profile = JsonConvert.DeserializeObject<Member>(response.Content) ?? new Member();

                        UserManager.Current.Profile = profile;
                        Profile = profile;

                        OnPropertyChanged("Profile");

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
                    { "Category", "Profile" }
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
