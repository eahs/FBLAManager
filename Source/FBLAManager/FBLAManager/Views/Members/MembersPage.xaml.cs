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

        /// <summary>
        /// Called when the user taps on a member.
        /// </summary>
        private async void MembersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (MembersListView.SelectedItem == null)
                return;
            
            Member m = (Member)e.SelectedItem;
            MembersListView.SelectedItem = null;

            var membersDetailPage = new MembersDetailPage(m);
       
            await Navigation.PushAsync(membersDetailPage);

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