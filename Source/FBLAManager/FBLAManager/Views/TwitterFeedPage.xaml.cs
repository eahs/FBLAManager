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

            var htmlSource = new HtmlWebViewSource();

            
            htmlSource.Html = @"<html> <body> 
                                    <a class=""twitter-timeline"" href=""https://twitter.com/FblaManager/lists/fbla-tweets?ref_src=twsrc%5Etfw\""></a>
                                     <script async src = ""https://platform.twitter.com/widgets.js"" charset=""utf-8""> </script>
                                    </body></html>";

            webView.Source = htmlSource;

        }

    }
}