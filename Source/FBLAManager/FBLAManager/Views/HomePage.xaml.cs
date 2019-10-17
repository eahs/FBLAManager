using FBLAManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private HomePageViewModel viewModel;

        public HomePage()
        {
            InitializeComponent();

            this.BindingContext = viewModel = new HomePageViewModel();

            // viewModel.LoadItemsCommand.Execute(null);
            AnnouncementListView.ItemSelected += AnnouncementListView_ItemSelected;
        }

       

        private void AnnouncementListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            AnnouncementListView.SelectedItem = null;
        }
    }
}