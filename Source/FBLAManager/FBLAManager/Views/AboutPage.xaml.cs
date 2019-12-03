using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FBLAManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            MainScrollView.Scrolled += MainScrollView_Scrolled;

            BindingContext = this;

        }

        public string ContentURL { get; set; } = "https://eahs.github.io/FBLAManager/?" + Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 8);


        private void MainScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            double progress = Math.Min(e.ScrollY, 100) / 100;

            MainHeaderImage.Scale = 1 + progress;
            MainHeaderImage.Opacity = 1 - progress;
        }
    }
}