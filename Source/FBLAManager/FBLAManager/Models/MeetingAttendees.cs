
namespace FBLAManager.Models
{
    /// <summary>
    /// The model for the attendees of a meeting. 
    /// </summary>
    public class MeetingAttendees
    {
        /// <summary>
        /// The ID of an attending member.
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// A member attending the meeting. 
        /// </summary>
        public Member Member { get; set; }

        /// <summary>
        /// The ID of the meeting.
        /// </summary>
        public int MeetingId { get; set; }

        /// <summary>
        /// The meeting in question. 
        /// /// </summary>
        public Meeting Meeting { get; set; }

    }
}
