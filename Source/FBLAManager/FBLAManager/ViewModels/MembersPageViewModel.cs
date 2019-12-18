using FBLAManager.Helpers;
using FBLAManager.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FBLAManager.ViewModels;
using FBLAManager; 

public class MembersPageViewModel : BaseViewModel
{
    public ObservableCollection<Member> Members { get; set; }
    public MembersPageViewModel()
    {
        Members = new ObservableCollection<Member>();

        LoadItemsCommand.Execute(null);
    }

    /// <summary>
    /// Loads the members from the backend server.
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
            request.Resource = String.Format(GlobalConstants.MembersEndPointRequestURL);
            UserManager.Current.AddAuthorization(request);

            try
            {

                var response = await client.ExecuteTaskAsync(request);

                if (response.IsSuccessful)
                {
                    var items = JsonConvert.DeserializeObject<List<Member>>(response.Content) ?? new List<Member>();


                    Members.Clear();

                    foreach (var member in items)
                    {
                        Members.Add(member);
                    }

                    OnPropertyChanged("Members");

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
                    { "Category", "Members" }
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