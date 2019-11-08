﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FBLAManager
{
    public class GlobalConstants
    {
        // REST configuration
        public static readonly string EndPointURL = "http://fblamanager.me";
        public static readonly int RequestTimeout = 10 * 1000; // In milliseconds, time to return request

        public static readonly string MeetingEndPointRequestURL = "/api/Meetings";
        public static readonly string OfficerEndPointRequestURL = "/api/Officers?level={0}";
    
    }
}
