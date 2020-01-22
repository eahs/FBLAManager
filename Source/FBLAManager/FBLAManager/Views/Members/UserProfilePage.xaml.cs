using Xamarin.Forms.Internals;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using FBLAManager.ViewModels.Members;

namespace FBLAManager.Views.Members
{
    /// <summary>
    /// Page to show chat profile page
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfilePage
    {
        ProfileViewModel vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfilePage" /> class.
        /// </summary>
        public UserProfilePage()
        {
            InitializeComponent();

            vm = new ProfileViewModel();
            BindingContext = vm;

            vm.LoadItemsCommand.Execute(null);

        }

        /// <summary>
        /// Opens new page to edit the member's information. 
        /// </summary>
        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            var editProfilePage = new EditProfilePage();

            await Navigation.PushAsync(editProfilePage); 
        }
    }
}