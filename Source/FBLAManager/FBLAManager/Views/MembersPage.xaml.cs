using FBLAManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MembersPage : ContentPage
    {
        public MembersPage()
        {
            InitializeComponent();

            BindingContext = new MembersPageViewModel();
        }
    }
}