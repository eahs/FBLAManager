using FBLAManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views.Officers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NationalOfficersPage : ContentPage
    {
        private OfficerViewModel viewModel;

        public NationalOfficersPage()
        {
            InitializeComponent();

            this.BindingContext = viewModel = new OfficerViewModel();

           // viewModel.LoadItemsCommand.Execute(null);
        }
    }
}