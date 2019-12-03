using FBLAManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views.Officers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StateOfficersPage : ContentPage
    {
        private OfficersViewModel viewModel;

        public StateOfficersPage()
        {
            InitializeComponent();

            this.BindingContext = viewModel = new OfficersViewModel(2);

            StateOfficersListView.ItemSelected += StateOfficersListView_ItemSelected;
        }

        private void StateOfficersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            StateOfficersListView.SelectedItem = null;
        }
    }
}