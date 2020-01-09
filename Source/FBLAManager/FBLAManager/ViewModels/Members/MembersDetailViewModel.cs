using FBLAManager.Models;

namespace FBLAManager.ViewModels.Events
{
    /// <summary>
    /// Viewmodel of meeting detail templates.
    /// </summary>

    //[QueryProperty("Meeting", "meeting")]
    public class MembersDetailViewModel : BaseViewModel
    {
        public Member Member { get; set; }

        public MembersDetailViewModel(Member member = null)
        {
            Title = member?.FullName;
            Member = member;
        }
    }
}

