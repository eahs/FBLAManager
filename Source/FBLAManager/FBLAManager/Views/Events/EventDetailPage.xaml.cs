using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FBLAManager.Models;
using System;


namespace FBLAManager.Views.Events
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventDetailPage : ContentPage
    {
        public EventDetailPage()
        {
            InitializeComponent();
        }

        public EventDetailPage(Meeting meeting)
        {
            InitializeComponent();

            BindingContext = meeting;
        }

        private void SignUp_Pressed(object sender, EventArgs e)
        {
            DisplayAlert("Sign up", "Sign up for this event?", "Yes", "No");
        }

    }
}