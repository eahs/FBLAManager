using FBLAManager.Models;
using System.Collections.ObjectModel;


using Xamarin.Forms;

namespace FBLAManager.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public HomePageViewModel()
        {
            Announcements = new ObservableCollection<Announcement>();

            Announcements.Add(
                new Announcement
                {
                    Title = "test",
                    Message = "message",
                    Director = "admin"
                }

             );

        }

        public ObservableCollection<Announcement> Announcements { get; set;  }
    }
}