using System;
using System.Collections.Generic;
using System.Text;

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

        public static readonly string ForgotPasswordEndPointRequestURL = "/api/ForgotPassword";
    }
}
