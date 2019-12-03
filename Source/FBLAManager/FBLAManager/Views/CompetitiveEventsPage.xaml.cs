using FBLAManager.Models;
using FBLAManager.ViewModels.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompetitiveEventsPage : ContentPage
    {
        private CompetitionsViewModel viewModel;

        public CompetitiveEventsPage()
        {
            InitializeComponent();

            this.BindingContext = viewModel = new CompetitionsViewModel();
            CompetitionsListView.ItemSelected += CompetitionsListView_ItemSelected;
        }

        private async void CompetitionsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) 
                return;

            var competition = e.SelectedItem as Competition;
            CompetitionsListView.SelectedItem = null;

            await Browser.OpenAsync(competition.URL, BrowserLaunchMode.SystemPreferred);
        }
    }
}