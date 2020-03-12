
namespace FBLAManager
{
    public class GlobalConstants
    {
        // REST configuration
        public static readonly string EndPointURL = "http://fblamanager.me";
        public static readonly int RequestTimeout = 10 * 1000; // In milliseconds, time to return request

        public static readonly string MeetingEndPointRequestURL         = "/api/Meetings";
        public static readonly string MeetingSignupEndPointRequestURL   = "/api/MeetingSignup";
        public static readonly string OfficerEndPointRequestURL         = "/api/Officers?level={0}";
        public static readonly string CreateMemberEndPointRequestURL    = "/api/CreateMember";
        public static readonly string LoginEndPointRequestURL           = "/api/Login";
        public static readonly string MessageBoardEndPointRequestURL    = "/api/MessageBoard";
        public static readonly string CompetitiveEventsEndPointRequestURL = "/json/CompetitiveEvents.json";
        public static readonly string ForgotPasswordEndPointRequestURL  = "/api/ForgotPassword";
        public static readonly string MembersEndPointRequestURL         = "/api/Members";
        public static readonly string ProfileEndPointRequestURL         = "/api/Profile";
        public static readonly string EditMemberEndPointRequestURL      = "/api/EditMember";
        public static readonly string EditProfileImageRequestURL        = "/api/EditProfileImage";

        // Cache lifetimes (in seconds)
        public static readonly int MaxCacheCompetitiveEvents = 24 * 60 * 60 * 7; // 7 days
        public static readonly int MaxCacheCalendar = 30 * 60; // 30 mins
        public static readonly int MaxCacheMessageBoard = 15 * 60; // 15 minutes
        public static readonly int MaxCacheMeetings = 30 * 60; // 30 minutes
        public static readonly int MaxCacheMembers = 60 * 60; // 30 minutes
        public static readonly int MaxCacheOfficers = 2 * 60 * 60; // 2 hours
        public static readonly int MaxCacheProfile = 5 * 60; // 5 minutes
    }
}
