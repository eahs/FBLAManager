using FBLAManager.ViewModels.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views.Forms
{
    /// <summary>
    /// Page to retrieve the password forgotten.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleForgotPasswordPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleForgotPasswordPage" /> class.
        /// </summary>
        public SimpleForgotPasswordPage()
        {
            

            this.InitializeComponent();

            MessagingCenter.Subscribe<ForgotPasswordViewModel>(this, "ForgotPasswordSuccess", (sender) =>
            {
                DisplayAlert("Success", "Password request received.  Please check your email inbox to reset your password.", "OK");
            });

            MessagingCenter.Subscribe<ForgotPasswordViewModel>(this, "InvalidCredentials", (sender) =>
            {
                DisplayAlert("Oops!", "We were unable to reset the password for the email address you entered.  Enter a new email address.", "OK");
            });

        }
    }
}