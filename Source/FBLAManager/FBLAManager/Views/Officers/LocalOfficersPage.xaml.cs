using FBLAManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views.Officers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocalOfficersPage : ContentPage
    {
        private OfficersViewModel viewModel;

        public LocalOfficersPage()
        {
            InitializeComponent();

            this.BindingContext = viewModel = new OfficersViewModel(3);
            LocalOfficersListView.ItemSelected += LocalOfficersListView_ItemSelected;
        }

        private void LocalOfficersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            LocalOfficersListView.SelectedItem = null;
        }
    }
}