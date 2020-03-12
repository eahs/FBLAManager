using FBLAManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
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
                Title = "Get involved",
                Text = "View and sign up for events",
                Animation = GetAnimation("4333-calendar-event.json", true),
                BackgroundColor = Color.FromHex("#077187")
            });

            Boards.Add(new Board
            {
                Title = "Stay Informed",
                Text = "Learn about upcoming events, new announcements, and frequently asked questions",
                Animation = GetAnimation("3520-light-bulb.json", true),
                BackgroundColor = Color.FromHex("#53BA92")
            });

            Boards.Add(new Board
            {
                Title = "Connect",
                Text = "Easily communicate with advisors, officers, and fellow club members",
                Animation = GetAnimation("10051-consultation.json", true),
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
                IsPlaying = autoplay,
                Scale = 1.0,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand,
                WidthRequest = 300,
                HeightRequest = 300
            };
        }

        private async void SignIn_Button_Clicked(object sender, EventArgs e)
        {
            List<Task> tasks = new List<Task>();

            tasks.Add(Task.Run(async () =>
            {
                await ButtonFrame.ScaleTo(1.025, 150, Easing.CubicInOut);
                await ButtonFrame.ScaleTo(1.0, 150, Easing.CubicInOut);
            }));

            Preferences.Set("WatchedTutorial", true);

            await Task.WhenAll(tasks);

            MessagingCenter.Send<Onboarding>(this, "GetStarted");

        }

        private void CV_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            Boards[CV.Position].Animation.Progress = 0;
            Boards[CV.Position].Animation.Play();
        }
    }
}
