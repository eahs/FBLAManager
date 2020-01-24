using Xamarin.Essentials;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views.SocialMedia
{
    /// <summary>
    /// About us with parallax scroll page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutUsWithScrollPage
    {
        
        public AboutUsWithScrollPage()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = "Check out the new FBLA Navigator app!  It's really useful for FBLA members to learn all about FBLA, take attendance, and stay up to date with the latest announcements!",
                Title = "FBLA Navigator App"
            });
        }
    }
}