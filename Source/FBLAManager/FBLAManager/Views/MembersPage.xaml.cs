using FBLAManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        private void MembersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MembersListView.SelectedItem = null;
        }
    }
}