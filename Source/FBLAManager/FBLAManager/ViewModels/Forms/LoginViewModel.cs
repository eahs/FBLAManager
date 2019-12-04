using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Xamarin.Forms.Internals;

namespace FBLAManager.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string email;

        private bool isInvalidEmail;

        #endregion

        #region Event

        /// <summary>
        /// The declaration of property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the email ID from user in the login page.
        /// </summary>
        public virtual string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (this.email == value)
                {
                    return;
                }

                this.email = value;
                this.IsInvalidEmail = !CheckValidEmail(this.email);
                this.OnPropertyChanged();
            }
        }

        public string LoginButtonStyleKey
        {
            get
            {
                return ""; 
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the entered email is valid or invalid.
        /// </summary>
        public bool IsInvalidEmail
        {
            get
            {
                return this.isInvalidEmail;
            }

            set
            {
                if (this.isInvalidEmail == value)
                {
                    return;
                }

                this.isInvalidEmail = value;
                this.OnPropertyChanged();
            }
        }

        #endregion

        #region Method

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool CheckValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return true;
            }

            var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            return regex.IsMatch(email) && !email.EndsWith(".");
        }

        #endregion
    }
}
