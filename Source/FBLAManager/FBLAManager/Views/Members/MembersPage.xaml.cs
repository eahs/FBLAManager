using FBLAManager.ViewModels;
using FBLAManager.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FBLAManager.Views.Members;

namespace FBLAManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MembersPage : ContentPage
    {
        public MembersPage()
        {
            InitializeComponent();

            BindingContext = new MembersPageViewModel();

            MembersListView.ItemSelected += MembersListView_ItemSelected;
        }

        private async void MembersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var memberDetailPage = new MembersDetailPage();

            await Navigation.PushAsync(memberDetailPage);
        }
    }
}