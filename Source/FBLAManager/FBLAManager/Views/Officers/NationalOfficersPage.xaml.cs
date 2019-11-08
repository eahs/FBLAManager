using FBLAManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views.Officers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NationalOfficersPage : ContentPage
    {
        private OfficersViewModel viewModel;

        public NationalOfficersPage()
        {
            InitializeComponent();

            this.BindingContext = viewModel = new OfficersViewModel(1);

            // viewModel.LoadItemsCommand.Execute(null);
            OfficersListView.ItemSelected += OfficersListView_ItemSelected;
        }

        private void OfficersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            OfficersListView.SelectedItem = null;
        }
    }
}