using FBLAManager.Helpers;
using FBLAManager.Models;
using FBLAManager.Models.AboutUs;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FBLAManager.ViewModels.Events
{
    public class CompetitionsViewModel : BaseViewModel
    {
        public CompetitionsViewModel()
        {
            Competitions = new ObservableCollection<Competition>
            {

            };
            this.LoadItemsCommand.Execute(null);
        }

        public ObservableCollection<Competition> Competitions { get; }


        private RelayCommand refreshItemsCommand;
        public ICommand RefreshCommand
        {
            get
            {
                return refreshItemsCommand ?? (refreshItemsCommand = new RelayCommand(async () => await ExecuteLoadItemsCommand()));
            }
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
            }
        }

        protected override async Task ExecuteLoadItemsCommand()
        {
            IsRefreshing = true;
            await base.ExecuteLoadItemsCommand();
            IsRefreshing = false;
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
                request.Resource = GlobalConstants.CompetitiveEventsEndPointRequestURL;
                UserManager.Current.AddAuthorization(request);

                var response = await client.ExecuteTaskAsync(request);

                if (response.IsSuccessful)
                {
                    Competitions.Clear();

                    var items = JsonConvert.DeserializeObject<List<Competition>>(response.Content) ?? new List<Competition>();

                    foreach (var competition in items)
                    {
                        Competitions.Add(competition);    
                    }

                    OnPropertyChanged("Competitions");

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
            catch (Exception)
            {
                // An exception occurred
                DataAvailable = false;
            }
        }

    }
}
