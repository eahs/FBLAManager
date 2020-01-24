using FBLAManager.Views.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfilePage : ContentPage
    {
        public EditProfilePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens new page to edit the member's information. 
        /// </summary>
        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}