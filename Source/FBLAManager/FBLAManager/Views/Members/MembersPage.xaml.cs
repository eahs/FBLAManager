using FBLAManager.ViewModels;
using FBLAManager.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FBLAManager.Views.Members;
using System;

namespace FBLAManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MembersPage : ContentPage
    {
        private MembersPageViewModel MembersPageViewModel;
        public MembersPage()
        {
            InitializeComponent();

            BindingContext = MembersPageViewModel = new MembersPageViewModel();

            MembersListView.ItemSelected += MembersListView_ItemSelected;
        }

        private async void MembersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var memberDetailPage = new MembersDetailPage();

            await Navigation.PushAsync(memberDetailPage);
        }

        /// <summary>
        /// Called when the user types in the search bar. 
        /// </summary>
        private void OnTextChanged(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;

            MembersListView.ItemsSource = MembersPageViewModel.GetSearchResults(searchBar.Text);
        }
    }
}