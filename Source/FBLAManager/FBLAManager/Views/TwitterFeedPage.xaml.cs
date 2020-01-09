using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TwitterFeedPage : ContentPage
    {
        public TwitterFeedPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        public string ContentURL { get; set; } = "https://twitter.com/FblaManager/lists/fbla-tweets?ref_src=twsrc%5Etfw" + Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 8);

        //public string ContentURL { get; set; } = "http://fblamanager.me/api/twitter" + Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 8);

        //page does not load for some reason
    }
}