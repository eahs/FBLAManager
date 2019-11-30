using FBLAManager.ViewModels.AboutUs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views.AboutUs
{
    /// <summary>
    /// Q and A page.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QandAPage : ContentPage
    {
        private QandAViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FBLAManager.Views.AboutUs.QandAPage"/> class.
        /// Sets its binding context to an instance of the <see cref="T:FBLAManager.ViewModels.AboutUs.QandAViewModel"/> class.
        /// </summary>
        public QandAPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new QandAViewModel();
        }
    }
}