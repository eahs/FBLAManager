using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Xamarin.Essentials;

namespace FBLAManager.Droid
{

    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
        DataScheme = CALLBACK_SCHEME)]
    public class WebAuthenticationCallbackActivity : Xamarin.Essentials.WebAuthenticatorCallbackActivity
    {
        const string CALLBACK_SCHEME = "fblanavigator";       
    }
}