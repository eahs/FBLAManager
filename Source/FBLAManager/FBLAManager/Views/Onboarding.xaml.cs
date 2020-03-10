
using FBLAManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
                Title = "Hello",
                Text = "Welcome to hell",
                Animation = GetAnimation("4887-book.json", true),
                BackgroundColor = Color.FromHex("#53BA92")
            });

           
        }

        private Lottie.Forms.AnimationView GetAnimation(String filename, bool autoplay = false)
        {
            return new Lottie.Forms.AnimationView
            {
                Animation = filename,
                Loop = false,
                IsVisible = true,
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
