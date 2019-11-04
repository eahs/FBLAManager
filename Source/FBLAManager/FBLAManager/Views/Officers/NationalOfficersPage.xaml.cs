using FBLAManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views.Officers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NationalOfficersPage : ContentPage
    {
        private NationalOfficerViewModel viewModel;

        public NationalOfficersPage()
        {
            InitializeComponent();

            this.BindingContext = viewModel = new NationalOfficerViewModel();

            // viewModel.LoadItemsCommand.Execute(null);
            OfficersListView.ItemSelected += OfficersListView_ItemSelected;
        }

        private void OfficersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            OfficersListView.SelectedItem = null;
        }
    }
}