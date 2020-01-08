using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FBLAManager.ViewModels.Members
{
    /// <summary>
    /// ViewModel for profile page
    /// </summary>
    [Preserve(AllMembers = true)]
    public class MembersDetailViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="ProfileViewModel" /> class
        /// </summary>
        public MembersDetailViewModel()
        {
            this.TextCommand = new Command(this.TextButtonClicked);
            this.EmailCommand = new Command(this.EmailClicked);
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the edit button is clicked.
        /// </summary>
        public Command TextCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the available status is clicked.
        /// </summary>
        public Command EmailCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the edit button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void TextButtonClicked(object obj)
        {
            // Do something
        }

        private void EmailClicked(object obj)
        {
            Launcher.TryOpenAsync("makennaswartz03@gmail.com");
        }

        #endregion
    }
}
