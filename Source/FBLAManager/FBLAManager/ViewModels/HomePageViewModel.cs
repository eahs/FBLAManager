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
                    Title = "Up Coming Meeting",
                    Message = "Reminder: The next meeting will be this thursday at 3 in J317. We will be discussing competitive events. ",
                    Director = "Posted by Mrs. Klein"
                }

             );
            Announcements.Add(
                new Announcement
                {
                    Title = "Deadlines",
                    Message = "Reminder: Due date to sign up for this years events is October 31st.",
                    Director = "Posted by Paige Mayer"
                }

             );
            Announcements.Add(
                new Announcement
                {
                    Title = "Volunteers Needed",
                    Message = "Volunteers for the club fair are needed. To sign up, see Mrs. Klein.",
                    Director = "Posted by Vincent Caminneci"
                }

             );

        }

        public ObservableCollection<Announcement> Announcements { get; set;  }
    }
}