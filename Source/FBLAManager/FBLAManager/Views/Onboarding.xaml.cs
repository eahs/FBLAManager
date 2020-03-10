using FBLAManager.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Onboarding : ContentPage
    {
        public ObservableCollection<Board> Boards { get; set; } = new ObservableCollection<Board>();
        private CancellationTokenSource TokenSource = new CancellationTokenSource();

        public Onboarding()
        {
            InitializeComponent();

            Boards.Add(new Board
            {
                Title = "Join",
                Text = "View and sign up for FBLA events! FBLA is the greatest organization on this good earth. We'll show you a good time (if you know what I mean).",
                Animation = GetAnimation("4333-calendar-event.json", true),
                BackgroundColor = Color.FromHex("#077187")
            });

            Boards.Add(new Board
            {
                Title = "Consume",
                Text = "Stay up to date with the latest FBLA news! Believe what we tell you to believe.",
                Animation = GetAnimation("2099-new-notification-bell.json", true),
                BackgroundColor = Color.FromHex("#53BA92")
            });

            Boards.Add(new Board
            {
                Title = "Infect",
                Text = "Connect with your fellow FBLA comrades, and form a legion that will pierce a light through our world's plague of darkness.",
                Animation = GetAnimation("8575-network.json", true),
                BackgroundColor = Color.FromHex("#074F57")
            });



            this.BindingContext = this;
            CV.ItemsSource = Boards;
        }

        private Lottie.Forms.AnimationView GetAnimation(string filename, bool autoplay = false)
        {
            return new Lottie.Forms.AnimationView
            {
                Animation = filename,
                Loop = false,
                IsVisible = true,
                AutoPlay = autoplay,
                Scale = 1.3,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand,
                WidthRequest = 300,
                HeightRequest = 300
            };
        }

        private void SignIn_Button_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("WatchedTutorial", true);
            MessagingCenter.Send<Onboarding>(this, "GetStarted");
        }
    }
}
