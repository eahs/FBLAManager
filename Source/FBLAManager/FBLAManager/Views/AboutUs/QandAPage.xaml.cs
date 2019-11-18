using FBLAManager.ViewModels.AboutUs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views.AboutUs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QandAPage : ContentPage
    {
        private QandAViewModel viewModel;

        public QandAPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new QandAViewModel();
        }
    }
}