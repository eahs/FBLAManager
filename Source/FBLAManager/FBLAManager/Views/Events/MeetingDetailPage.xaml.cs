using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FBLAManager.Models;
using FBLAManager.ViewModels.Events;

namespace FBLAManager.Views.Events
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeetingDetailPage : ContentPage
    {
        MeetingDetailViewModel viewModel;
        public MeetingDetailPage(MeetingDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public MeetingDetailPage()
        {
            InitializeComponent();

            var meeting = new Meeting
            {
                EventName = "whatever",
                Organizer = "idc",
                ContactID = "666",
                Description = "I want to go home",
                Capacity = 9999,
                From = new System.DateTime(1),
                To = new System.DateTime(2),
                color = new Color(),
                Type = new MeetingType(),
                AllDay = true

            };

            viewModel = new MeetingDetailViewModel(meeting);
            BindingContext = viewModel;
        }

    }
}