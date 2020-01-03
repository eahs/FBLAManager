using System;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views.Members
{
    /// <summary>
    /// Page to show chat profile page
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MembersDetailPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChatProfilePage" /> class.
        /// </summary>
        public MembersDetailPage()
        {
            InitializeComponent();
        }

    }
}