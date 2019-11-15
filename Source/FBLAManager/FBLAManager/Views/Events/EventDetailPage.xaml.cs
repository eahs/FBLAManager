using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FBLAManager.Models;
using System;
using FBLAManager.Helpers;

namespace FBLAManager.Views.Events
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventDetailPage : ContentPage
    {
        private Meeting Meeting { get; set; }
        public EventDetailPage()
        {
            InitializeComponent();
        }

        public EventDetailPage(Meeting meeting)
        {
            InitializeComponent();

            this.Meeting = meeting;

            BindingContext = meeting;
        }

        private async void SignUp_Pressed(object sender, EventArgs e)
        {
            if (await DisplayAlert("Sign up", "Sign up for this event?", "Yes", "No"))
            {
                UserManagerResponseStatus status = await UserManager.Current.MeetingSignup(Meeting);

                if (status == UserManagerResponseStatus.Success)
                {
                    await DisplayAlert("Success!", "You have signed up for this event.", "OK");
                }
            }

            
        }

        

    }
}