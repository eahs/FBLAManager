using FBLAManager.Services;
using FBLAManager.ViewModels;
using Xamarin.Essentials;
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

        private void ReportBug_Clicked(object sender, System.EventArgs e)
        {
            DependencyService.Get<IBugReporter>().Trigger();
        }

        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = "Check out the new FBLA Navigator app!  It's really useful for FBLA members to learn all about FBLA, take attendance, and stay up to date with the latest announcements!",
                Title = "FBLA Navigator App"
            });
        }

    }
}