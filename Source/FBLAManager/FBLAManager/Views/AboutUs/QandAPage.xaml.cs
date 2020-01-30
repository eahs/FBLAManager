using System;
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
        //private QandAViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FBLAManager.Views.AboutUs.QandAPage"/> class.
        /// </summary>
        public QandAPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        //URL of the Q & A page from the backend 
        public string ContentURL { get; set; } = "http://fblamanager.me/FAQs/faqpage"; 
    }
}