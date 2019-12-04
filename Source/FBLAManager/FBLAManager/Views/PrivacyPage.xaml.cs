using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrivacyPage : ContentPage
    {
        public PrivacyPage()
        {
            InitializeComponent();

            BindingContext = this;

        }

        public string ContentURL { get; set; } = "https://eahs.github.io/FBLAManager/PRIVACY.html?" + Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 8);


    }
}