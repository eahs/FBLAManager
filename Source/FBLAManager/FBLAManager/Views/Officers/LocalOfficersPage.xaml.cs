using FBLAManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views.Officers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocalOfficersPage : ContentPage
    {
        private LocalOfficersViewModel viewModel;

        public LocalOfficersPage()
        {
            InitializeComponent();

            this.BindingContext = viewModel = new LocalOfficersViewModel();

        }
    }
}