using FBLAManager.Helpers;
using FBLAManager.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using FBLAManager.ViewModels.Forms;

namespace FBLAManager.ViewModels
{
    /// <summary>
    /// ViewModel for sign-up page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class EditProfileViewModel : LoginViewModel
    {
        #region Fields
        private Member member;
        private string password;

        private string confirmPassword;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="EditProfileViewModel" /> class. 
        /// </summary>
        public EditProfileViewModel()
        {
            this.SaveCommand = new Command(this.SaveClicked);
            member = UserManager.Current.Profile;
        }


        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the name from user in the Sign Up page.
        /// </summary>
        public Member Member
        {
            get { return member; }
            set
            {
                member = value;
                OnPropertyChanged("Member");
            }
        }

        public override string Email
        {
            get => base.Email;
            set
            {
                base.Email = value;
                member.Email = base.Email;
                OnPropertyChanged("Email");
            }
        }

        #endregion

        #region Command


        /// <summary>
        /// Gets or sets the command that is executed when the Save button is clicked.
        /// </summary>
        public Command SaveCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Save button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void SaveClicked(object sender)
        {
            UserManagerResponseStatus status = await UserManager.Current.EditMember(member);

            switch (status)
            {
                case UserManagerResponseStatus.Success:
                    MessagingCenter.Send(this, "LoadApp");
                    break;

                default:
                    MessagingCenter.Send(this, "UnknownResponse");
                    break;
            }


        }

        #endregion
    }
}