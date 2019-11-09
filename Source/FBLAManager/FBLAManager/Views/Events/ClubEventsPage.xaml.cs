using FBLAManager.ViewModels;
using FBLAManager.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views.Events
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClubEventsPage : ContentPage
    {
        private MeetingsViewModel viewModel;
        public ClubEventsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MeetingsViewModel(MeetingType.ClubEvent);
        }

        private async void Meetings_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Meeting m = (Meeting)e.ItemData;

            var meetingDetailPage = new MeetingDetailPage(m);

            await Navigation.PushAsync(meetingDetailPage);
        }
    }
}