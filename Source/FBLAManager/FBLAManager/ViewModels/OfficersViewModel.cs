using FBLAManager.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace FBLAManager.ViewModels
{
    public class OfficersViewModel : BaseViewModel
    {
        public ObservableCollection<Officer> Officers { get; set; }
        public int Level { get; set; } = 0;

        public OfficersViewModel(int level = 0)
        {
            Officers = new ObservableCollection<Officer>();
            Level = level;

            LoadItemsCommand.Execute(null);

            /*
            Officers.Add(
                    new Officer
                    {
                        Name = "Travis Johnson",
                        Position = "FBLA National President",
                        Image = "test.jpg",
                        WebsiteLink = "https://www.fbla-pbl.org/fbla/officers/president/"
                    }
                );

            Officers.Add(
                    new Officer
                    {
                        Name = "Margo Boyd",
                        Position = "FBLA National Secretary",
                        Image = "test.jpg",
                        WebsiteLink = "https://www.fbla-pbl.org/fbla/officers/secretary/"
                    }
                );

            Officers.Add(
                    new Officer
                    {
                        Name = "Vivian Clarke",
                        Position = "FBLA National Treasurer",
                        Image = "test.jpg",
                        WebsiteLink = "https://www.fbla-pbl.org/fbla/officers/treasurer/"
                    }
                );

            Officers.Add(
                    new Officer
                    {
                        Name = "Elizabeth Howell",
                        Position = "FBLA National Parliamentarian",
                        Image = "test.jpg",
                        WebsiteLink = "https://www.fbla-pbl.org/fbla/officers/parliamentarian/"
                    }
                );

            Officers.Add(
                    new Officer
                    {
                        Name = "Drew Lojewski",
                        Position = "FBLA Eastern Region Vice President",
                        Image = "test.jpg",
                        WebsiteLink = "https://www.fbla-pbl.org/fbla/officers/eastern-region-vp/"
                    }
                );

            Officers.Add(
                    new Officer
                    {
                        Name = "Drake Vorderstrasse",
                        Position = "FBLA Mountain Plains Region Vice President",
                        Image = " test.jpg",
                        WebsiteLink = "https://www.fbla-pbl.org/fbla/officers/mountain-plains-region-vp/"
                    }
                );

            Officers.Add(
                    new Officer
                    {
                        Name = "Ben Morrison",
                        Position = "FBLA North Central Region Vice President",
                        Image = "test.jpg",
                        WebsiteLink = "https://www.fbla-pbl.org/fbla/officers/north-central-region-vp/"
                    }
                );

            Officers.Add(
                    new Officer
                    {
                        Name = "Ethan Ghozali",
                        Position = "FBLA Southern Region Vice President",
                        Image = "test.jpg",
                        WebsiteLink = "https://www.fbla-pbl.org/fbla/officers/southern-region-vp/"
                    }
                );

            Officers.Add(
                    new Officer
                    {
                        Name = "Haneol (John) Lee",
                        Position = "FBLA Western Region Vice President",
                        Image = "test.jpg",
                        WebsiteLink = "https://www.fbla-pbl.org/fbla/officers/western-region-vp/"
                    }
                );
            */
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
                request.Resource = String.Format(GlobalConstants.OfficerEndPointRequestURL, Level);

                var response = await client.ExecuteTaskAsync(request);

                if (response.IsSuccessful)
                {
                    var items = JsonConvert.DeserializeObject<List<Officer>>(response.Content) ?? new List<Officer>();

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
                // An exception occurred
                DataAvailable = false;
            }
        }

    }
}
