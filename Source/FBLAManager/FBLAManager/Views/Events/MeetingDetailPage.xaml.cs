using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FBLAManager.Models;
using System;

namespace FBLAManager.Views.Events
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class MeetingDetailPage : ContentPage
    {
        public MeetingDetailPage()
        {
            InitializeComponent();
        }

        public MeetingDetailPage(Meeting meeting)
        {
            InitializeComponent();

            BindingContext = meeting;

        }

        private void SignUp_Pressed(object sender, EventArgs e)
        {
            //https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/pop-ups
            //DisplayAlert("Sign up", "Sign up for this event?", "Yes", "No");

            DisplayPromptAsync("Sign in", "Enter meeting code");
        }

        

    }
}