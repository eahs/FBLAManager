using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            this.BindingContext = viewModel = new QandAViewModel();
        }
    }
}