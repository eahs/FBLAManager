using FBLAManager.Models;

namespace FBLAManager.ViewModels.Events
{
    /// <summary>
    /// Viewmodel of meeting detail templates.
    /// </summary>

    //[QueryProperty("Meeting", "meeting")]
    public class MeetingDetailViewModel : BaseViewModel
    {
        public Meeting Meeting { get; set; }

        public MeetingDetailViewModel(Meeting meeting = null)
        {
            Title = meeting?.EventName;
            Meeting = meeting;
        }
    }
}
