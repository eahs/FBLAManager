using FBLAManager.Models;
using FBLAManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views.Events
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeetingsPage : ContentPage
    {
        private MeetingsViewModel viewModel;
        public MeetingsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MeetingsViewModel(MeetingType.Meeting);

        }

        private async void Meetings_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Meeting m = (Meeting)e.ItemData;

            var meetingDetailPage = new MeetingDetailPage(m);

            await Navigation.PushAsync(meetingDetailPage);
        }

    }
}