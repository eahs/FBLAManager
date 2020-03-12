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
using Microsoft.AppCenter.Crashes;
using System.Linq;

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

                DataAvailable = false;

                var response = await client.ExecuteCachedAPITaskAsync(request, GlobalConstants.MaxCacheMembers, false, true);

                ErrorMessage = response.ErrorMessage;
                IsError = !response.IsSuccessful;

                if (response.IsSuccessful)
                {
                    var items = JsonConvert.DeserializeObject<List<Member>>(response.Content) ?? new List<Member>();


                    Members.Clear();

                    foreach (var member in items)
                    {
                        Members.Add(member);
                    }

                    OnPropertyChanged("Members");

                    DataAvailable = true;
                }

            }
            catch (Exception e)
            {
                var properties = new Dictionary<string, string> {
                    { "Category", "Members" }
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

    public List<Member> GetSearchResults(string queryString)
    {
        var normalizedQuery = queryString?.ToLower() ?? "";

        var newMembersList = new List<Member>(Members); 

        return newMembersList.Where(f => f.FullName.ToLowerInvariant().Contains(normalizedQuery)).ToList();
    }
}