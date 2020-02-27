using Xamarin.Forms.Internals;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using FBLAManager.ViewModels.Members;
using FBLAManager.Services;
using System.IO;
using Syncfusion.XForms.Buttons;

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

            MessagingCenter.Subscribe<ProfileImageEditor, byte[]>(this, "UpdateProfileImage", (sender, rawImage) =>
            {
                Image.Source = ImageSource.FromStream(() => new MemoryStream(rawImage));
            });
        }

        /// <summary>
        /// Opens new page to edit the member's information. 
        /// </summary>
        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            var editProfilePage = new EditProfilePage();

            await Navigation.PushAsync(editProfilePage); 
        }

        /// <summary>
        /// Opens the photo picker for the user to upload an image.
        /// </summary>
        private async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            SfButton button = sender as SfButton;
            button.IsEnabled = false;

            var picker = DependencyService.Get<IPhotoPickerService>();
            Stream stream = await picker?.GetImageStreamAsync();
            if (stream != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);

                    byte[] rawImage = memoryStream.ToArray();
                    string encoded = Convert.ToBase64String(rawImage);
                    
                    Image.Source = ImageSource.FromStream(() => new MemoryStream(rawImage));

                    await Navigation.PushModalAsync(new ProfileImageEditor(Image.Source));                   
                }

            }

            button.IsEnabled = true;
        }

    }
}