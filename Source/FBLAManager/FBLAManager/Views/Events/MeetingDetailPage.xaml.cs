using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FBLAManager.Models;
using FBLAManager.ViewModels.Events;
using System;

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

        private void SignUp_Pressed(object sender, EventArgs e)
        {
            DisplayAlert("Sign up", "Sign up for this event?", "Yes", "No");
            
            //throw new NotImplementedException();
        }

        public MeetingDetailPage()
        {
            InitializeComponent();
        }

    }
}