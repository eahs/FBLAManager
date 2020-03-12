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

                    DataAvailable = false;

                    var response = await client.ExecuteCachedAPITaskAsync(request, GlobalConstants.MaxCacheProfile, false, true);

                    ErrorMessage = response.ErrorMessage;
                    IsError = !response.IsSuccessful;

                    if (response.IsSuccessful)
                    {
                        var profile = JsonConvert.DeserializeObject<Member>(response.Content) ?? new Member();

                        UserManager.Current.Profile = profile;
                        Profile = profile;
                        OnPropertyChanged("Profile");

                        DataAvailable = true;
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
