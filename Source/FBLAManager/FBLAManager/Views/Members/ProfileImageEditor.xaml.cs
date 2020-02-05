using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views.Members
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileImageEditor : ContentPage
    {
        public ProfileImageEditor()
        {
            InitializeComponent();
        }

        public ProfileImageEditor(ImageSource src)
        {
            InitializeComponent();

            editor.Source = src;
        }

    }
}