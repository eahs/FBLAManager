using FBLAManager.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FBLAManager.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginPageViewModel : LoginViewModel
    {
        #region Fields

        private string password;
        private bool errorVisible = false;
        private string errorMessage = "";
        private bool isBusy = false;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginPageViewModel" /> class.
        /// </summary>
        public LoginPageViewModel()
        {
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.ForgotPasswordCommand = new Command(this.ForgotPasswordClicked);
            this.SocialMediaLoginCommand = new Command(this.SocialLoggedIn);

            this.Email = "judge@fbla.com";
            this.Password = "judge";
        }

        #endregion

        #region property

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.password = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get { return this.isBusy; }
            set { this.isBusy = value; OnPropertyChanged("IsBusy"); }
        }

        public bool ErrorIsVisible
        {
            get
            {
                return this.errorVisible;
            }

            set
            {
                this.errorVisible = value;
                OnPropertyChanged("ErrorIsVisible");
            }
        }

        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }

            set
            {
                if (this.errorMessage == value)
                {
                    return;
                }

                this.errorMessage = value;
                this.OnPropertyChanged();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Forgot Password button is clicked.
        /// </summary>
        public Command ForgotPasswordCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the social media login button is clicked.
        /// </summary>
        public Command SocialMediaLoginCommand { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Invoked when the Log In button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void LoginClicked(object obj)
        {
            if (IsBusy) return;

            IsBusy = true;

            var res = App.Current.Resources.MergedDictionaries;

            // TODO: LoginClicked error checks
            if (Password == "" || Email == "")
            { 
                ErrorIsVisible = true;
                ErrorMessage = "Invalid Credentials";
            }

            if (IsInvalidEmail)
            {
                ErrorIsVisible = true;
                ErrorMessage = "Email is invalid";
            }

            if (!IsInvalidEmail)
            {
                UserManagerResponseStatus status = await UserManager.Current.Login(Email, Password);

                if (status == UserManagerResponseStatus.Success)
                    MessagingCenter.Send<LoginPageViewModel>(this, "LoadApp");
                else if (status == UserManagerResponseStatus.InvalidCredentials)
                {
                    ErrorIsVisible = true;
                    ErrorMessage= "Password was incorrect.";
                }
            }

            IsBusy = false;
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SignUpClicked(object obj)
        {
            // Do something
            MessagingCenter.Send(this, "SignupClicked");
        }

        /// <summary>
        /// Invoked when the Forgot Password button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void ForgotPasswordClicked(object obj)
        {
            var label = obj as Label;
            label.BackgroundColor = Color.FromHex("#70FFFFFF");
            await Task.Delay(100);
            label.BackgroundColor = Color.Transparent;

            MessagingCenter.Send(this, "ForgotPasswordClicked"); 
        }

        /// <summary>
        /// Invoked when social media login button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SocialLoggedIn(object obj)
        {
            // Do something
        }

        #endregion
    }
}