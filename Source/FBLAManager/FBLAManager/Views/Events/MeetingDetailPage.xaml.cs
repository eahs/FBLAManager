using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FBLAManager.Models;
using System;
using FBLAManager.Helpers;

namespace FBLAManager.Views.Events
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class MeetingDetailPage : ContentPage
    {

        private Meeting Meeting { get; set; }

        public MeetingDetailPage()
        {
            InitializeComponent();
        }

        public MeetingDetailPage(Meeting meeting)
        {
            InitializeComponent();

            this.Meeting = meeting;

            BindingContext = meeting;
              
        }

        private async void SignUp_Pressed(object sender, EventArgs e)
        {
            string code = await DisplayPromptAsync("Sign in", "Enter meeting code");

            UserManagerResponseStatus status = await UserManager.Current.MeetingSignup(Meeting.MeetingId, code);

            if (status == UserManagerResponseStatus.Success)
            {
                await DisplayAlert("Success!", "You have signed in.", "OK");
            }
            else if (status == UserManagerResponseStatus.InvalidCredentials)
            {
                await DisplayAlert("Invalid code", "The meeting code you input was incorrect.", "OK");
            }

        }

        
        

    }
}