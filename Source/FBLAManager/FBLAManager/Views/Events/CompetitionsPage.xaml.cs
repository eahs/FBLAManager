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


        private async void Meetings_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Meeting m = (Meeting)e.ItemData;

            // Look up parameters at https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/shell/navigation

            // await Shell.Current.GoToAsync($"signup?meetingId={m.MeetingId}");

            //await Shell.Current.GoToAsync("MeetingDetailPage");

            var meetingDetailPage = new MeetingDetailPage(m);

            await Navigation.PushAsync(meetingDetailPage);
        }

    }

}