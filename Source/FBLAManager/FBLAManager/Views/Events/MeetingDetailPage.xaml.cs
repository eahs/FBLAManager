using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FBLAManager.Models;
using FBLAManager.ViewModels.Events;

namespace FBLAManager.Views.Events
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class MeetingDetailPage : ContentPage
    {
        public MeetingDetailPage(Meeting meeting)
        {
            InitializeComponent();

            BindingContext = meeting;
        }

        public MeetingDetailPage()
        {
            InitializeComponent();
        }

    }
}