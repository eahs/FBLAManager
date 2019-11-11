

namespace FBLAManager.Models
{
    public class MeetingAttendees
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }

    }
}
