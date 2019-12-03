using FBLAManager.Models;
using FBLAManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views.Events
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompetitionsPage : ContentPage
    {
        private MeetingsViewModel viewModel;
        public CompetitionsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MeetingsViewModel(MeetingType.CompetitiveEvent);
        }


        private async void Meetings_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Meeting m = (Meeting)e.Item;

            if (Meetings.SelectedItem != null)
                Meetings.SelectedItem = null;

            var meetingDetailPage = new EventDetailPage(m);

            await Navigation.PushAsync(meetingDetailPage);
        }

    }

}