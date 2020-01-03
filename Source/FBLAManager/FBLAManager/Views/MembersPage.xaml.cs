using FBLAManager.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        private void MembersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MembersListView.SelectedItem = null;           
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