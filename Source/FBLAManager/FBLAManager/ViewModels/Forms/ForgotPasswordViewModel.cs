using Xamarin.Forms;
using Xamarin.Forms.Internals;
using FBLAManager.Helpers;

namespace FBLAManager.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for forgot password page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ForgotPasswordViewModel : LoginViewModel
    {
        

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ForgotPasswordViewModel" /> class.
        /// </summary>
        public ForgotPasswordViewModel()
        {
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.SendCommand = new Command(this.SendClickedAsync);

            
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Send button is clicked.
        /// </summary>
        public Command SendCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Send button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void SendClickedAsync(object obj)
        {
            UserManagerResponseStatus status = await UserManager.Current.ForgotPassword(Email);

            switch (status)
            {
                case UserManagerResponseStatus.Success:
                    //MessagingCenter.Send(this, "LoadApp"); display success alert
                    break;

                default:
                    MessagingCenter.Send(this, "UnknownResponse");
                    break;
            }
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SignUpClicked(object obj)
        {
            MessagingCenter.Send(this, "SignupClicked");
        }

        #endregion
    }
}