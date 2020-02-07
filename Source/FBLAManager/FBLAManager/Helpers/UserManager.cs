using FBLAManager.Models;
using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FBLAManager.Helpers
{
    /// <summary>
    /// Possible response status codes for API requests
    /// </summary>
    public enum UserManagerResponseStatus
    {
        MissingFields,
        UserExists,
        Success,
        InvalidCredentials,
        UnknownResponse,
        InvalidRequest,
        NotLoggedIn,
        NetworkError
    }

    public class UserManagerResponse
    {
        public string Status { get; set; }
        public string Key { get; set; }        
        public Member Profile { get; set; }
        public Meeting Meeting { get; set; }
    }

    /// <summary>
    /// Singleton patterned UserManager that interacts with the backend Server - All API endspoints are in GlobalConstants.cs 
    /// </summary>
    public class UserManager
    {
        private static UserManager _userManager = null;
        public Member Profile { get; set; }

        private UserManager ()
        {
            _userManager = this;
        }

        /// <summary>
        /// Provides a singleton reference to a UserManager
        /// </summary>
        public static UserManager Current
        {
            get { return _userManager ?? new UserManager(); }
        }

        private string sessionkey = "";

        /// <summary>
        /// User session key after they have logged on - Empty if not currently logged in
        /// </summary>
        public string SessionKey
        {
            get
            {
                return this.sessionkey;
            }
            set
            {
                this.sessionkey = value;

                // Save to disk
                try
                {
                    Task t = SecureStorage.SetAsync("sessionkey", sessionkey);
                    t.RunSynchronously();
                }
                catch (Exception ex)
                {
                    // Possible that device doesn't support secure storage on device.
                }
            }
        }

        /// <summary>
        /// Adds the appropriate authorization header for correctly interacting with the backend API
        /// </summary>
        /// <param name="request"></param>
        public void AddAuthorization (RestRequest request)
        {
            request.AddHeader("auth", SessionKey);
        }

        /// <summary>
        /// Determines if the user is currently logged in with the backend
        /// </summary>
        /// <returns>bool - True if user is logged in</returns>
        public async Task<bool> IsLoggedIn ()
        {
            try
            {
                var _sessionkey = await SecureStorage.GetAsync("sessionkey");
                if (_sessionkey != null)
                    sessionkey = _sessionkey;
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }

            return SessionKey != "";
        }

        /// <summary>
        /// Logs the user out
        /// </summary>
        public void Logout ()
        {
            SessionKey = "";
        }


        public async Task<UserManagerResponseStatus> SaveProfileImage (string encodedImage)
        {
            var client = new RestClient(GlobalConstants.EndPointURL);

            var request = new RestRequest
            {
                Resource = GlobalConstants.EditMemberEndPointRequestURL,
                Timeout = GlobalConstants.RequestTimeout,
                Method = Method.POST
            };

            request.AddParameter("profileImageSource", encodedImage);

            AddAuthorization(request);


            try
            {

                var response = await client.ExecuteTaskAsync(request);

                if (response.Content != null)
                {
                    UserManagerResponse data = JsonConvert.DeserializeObject<UserManagerResponse>(response.Content);

                    if (data.Status != null)
                    {
                        switch (data.Status)
                        {
                            case "Success": return UserManagerResponseStatus.Success;
                            case "NotLoggedIn": return UserManagerResponseStatus.InvalidCredentials;
                            default: return UserManagerResponseStatus.UnknownResponse;
                        }
                    }
                }
            }

            catch (Exception e)
            {
                var properties = new Dictionary<string, string> {
                    { "Category", "UserManager" }
                  };
                Crashes.TrackError(e, properties);

                return UserManagerResponseStatus.NetworkError;
            }

            return UserManagerResponseStatus.InvalidRequest;
        }

        /// <summary>
        /// Allows the user to signup for a particular meeting with a password provided by the meeting organizer
        /// </summary>
        /// <param name="meeting">Meeting member wants to sign up for</param>
        /// <param name="password">Password code for meeting</param>
        /// <returns></returns>
        public async Task<UserManagerResponseStatus> MeetingSignup(Meeting meeting, string password = "")
        {
            var client = new RestClient(GlobalConstants.EndPointURL);

            var request = new RestRequest
            {
                Resource = GlobalConstants.MeetingSignupEndPointRequestURL,
                Timeout = GlobalConstants.RequestTimeout,
                Method = Method.POST
            };

            request.AddParameter("meetingid", meeting.MeetingId);
            request.AddParameter("password", password);

            AddAuthorization(request);

            try
            {

                var response = await client.ExecuteTaskAsync(request);

                if (response.Content != null)
                {
                    UserManagerResponse data = JsonConvert.DeserializeObject<UserManagerResponse>(response.Content);

                    if (data.Status != null)
                    {
                        switch (data.Status)
                        {
                            case "NotLoggedIn": return UserManagerResponseStatus.NotLoggedIn;
                            case "InvalidCredentials": return UserManagerResponseStatus.InvalidCredentials;
                            case "Success":

                                if (data.Meeting != null)
                                {
                                    meeting.EventName = data.Meeting.EventName;
                                    meeting.AllDay = data.Meeting.AllDay;
                                    meeting.Capacity = data.Meeting.Capacity;
                                    meeting.Color = data.Meeting.Color;
                                    meeting.ContactId = data.Meeting.ContactId;
                                    meeting.Description = data.Meeting.Description;
                                    meeting.From = data.Meeting.From;
                                    meeting.MeetingId = data.Meeting.MeetingId;
                                    meeting.Organizer = data.Meeting.Organizer;
                                    meeting.To = data.Meeting.To;
                                    meeting.Type = data.Meeting.Type;
                                    meeting.MeetingAttendees.Clear();
                                    foreach (var attendee in data.Meeting.MeetingAttendees)
                                    {
                                        meeting.MeetingAttendees.Add(attendee);
                                    }
                                    meeting.OnPropertyChanged("MeetingAttendees");
                                }

                                return UserManagerResponseStatus.Success;
                            default: return UserManagerResponseStatus.UnknownResponse;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                var properties = new Dictionary<string, string> {
                    { "Category", "UserManager" }
                  };
                Crashes.TrackError(e, properties);

                return UserManagerResponseStatus.NetworkError;
            }

            return UserManagerResponseStatus.InvalidRequest;
        }

        /// <summary>
        /// Logs user into the FBLA backend
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<UserManagerResponseStatus> Login (string email, string password)
        {
            var client = new RestClient(GlobalConstants.EndPointURL);

            var request = new RestRequest
            {
                Resource = GlobalConstants.LoginEndPointRequestURL,
                Timeout = GlobalConstants.RequestTimeout,
                Method = Method.POST
            };

            request.AddParameter("email", email);
            request.AddParameter("password", password);

            try
            {
                var response = await client.ExecuteTaskAsync(request);

                if (response.Content != null)
                {
                    UserManagerResponse data = JsonConvert.DeserializeObject<UserManagerResponse>(response.Content);

                    if (data.Status != null)
                    {
                        switch (data.Status)
                        {
                            case "Invalid form data": return UserManagerResponseStatus.InvalidRequest;
                            case "LoggedIn":
                                SessionKey = data.Key;
                                Profile = data.Profile;
                                return UserManagerResponseStatus.Success;
                            case "InvalidCredentials": return UserManagerResponseStatus.InvalidCredentials;
                            default: return UserManagerResponseStatus.UnknownResponse;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                var properties = new Dictionary<string, string> {
                    { "Category", "UserManager" }
                  };
                Crashes.TrackError(e, properties);

                return UserManagerResponseStatus.NetworkError;
            }

            return UserManagerResponseStatus.InvalidRequest;
        }

        /// <summary>
        /// Notifies the backend server that the user forgot their password - Server sends a recovery email in response
        /// </summary>
        /// <param name="email"></param>
        /// <returns>UserManagerResponseStatus</returns>
        public async Task<UserManagerResponseStatus> ForgotPassword(string email)
        {
            var client = new RestClient(GlobalConstants.EndPointURL);

            var request = new RestRequest
            {
                Resource = GlobalConstants.ForgotPasswordEndPointRequestURL,
                Timeout = GlobalConstants.RequestTimeout,
                Method = Method.POST
            };

            request.AddParameter("email", email);

            try
            {

                var response = await client.ExecuteTaskAsync(request);

                if (response.Content != null)
                {
                    UserManagerResponse data = JsonConvert.DeserializeObject<UserManagerResponse>(response.Content);

                    if (data.Status != null)
                    {
                        switch (data.Status)
                        {
                            case "Success": return UserManagerResponseStatus.Success;
                            case "InvalidCredentials": return UserManagerResponseStatus.InvalidCredentials;
                            default: return UserManagerResponseStatus.UnknownResponse;
                        }
                    }
                }
            }

            catch (Exception e)
            {
                var properties = new Dictionary<string, string> {
                    { "Category", "UserManager" }
                  };
                Crashes.TrackError(e, properties);

                return UserManagerResponseStatus.NetworkError;
            }

            return UserManagerResponseStatus.InvalidRequest;
        }

        /// <summary>
        /// Creates a new member by notifying the backend server
        /// </summary>
        /// <param name="m"></param>
        /// <returns>UserManagerResponseStatus</returns>
        public async Task<UserManagerResponseStatus> CreateMember(Member m)
        {
            var client = new RestClient(GlobalConstants.EndPointURL);

            var request = new RestRequest
            {
                Resource = GlobalConstants.CreateMemberEndPointRequestURL,
                Timeout = GlobalConstants.RequestTimeout,
                Method = Method.POST
            };

            PropertyInfo[] properties = typeof(Member).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                request.AddParameter(property.Name, property.GetValue(m));
            }

            try
            {

                var response = await client.ExecuteTaskAsync(request);

                if (response.Content != null)
                {
                    UserManagerResponse data = JsonConvert.DeserializeObject<UserManagerResponse>(response.Content);

                    switch (data.Status)
                    {
                        case "MissingFields": return UserManagerResponseStatus.MissingFields;
                        case "Success":
                            SessionKey = data.Key;
                            return UserManagerResponseStatus.Success;
                        case "UserExists": return UserManagerResponseStatus.UserExists;
                        default: return UserManagerResponseStatus.UnknownResponse;
                    }
                }
            }

            catch (Exception e)
            {
                var property = new Dictionary<string, string> {
                    { "Category", "UserManager" }
                  };
                Crashes.TrackError(e, property);

                return UserManagerResponseStatus.NetworkError;
            }

            return UserManagerResponseStatus.InvalidRequest;
        }

        /// <summary>
        /// Updates a member by notifying the backend server
        /// </summary>
        /// <param name="m"></param>
        /// <returns>UserManagerResponseStatus</returns>
        public async Task<UserManagerResponseStatus> EditMember(Member m)
        {
            var client = new RestClient(GlobalConstants.EndPointURL);

            var request = new RestRequest
            {
                Resource = GlobalConstants.EditMemberEndPointRequestURL,
                Timeout = GlobalConstants.RequestTimeout,
                Method = Method.POST
            };

            AddAuthorization(request);

            PropertyInfo[] properties = typeof(Member).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                request.AddParameter(property.Name, property.GetValue(m));
            }

            try
            {

                var response = await client.ExecuteTaskAsync(request);

                if (response.Content != null)
                {
                    UserManagerResponse data = JsonConvert.DeserializeObject<UserManagerResponse>(response.Content);

                    switch (data.Status)
                    {
                        case "Success":
                            return UserManagerResponseStatus.Success;
                        default: return UserManagerResponseStatus.UnknownResponse;
                    }
                }
            }

            catch (Exception e)
            {
                var property = new Dictionary<string, string> {
                    { "Category", "UserManager" }
                  };
                Crashes.TrackError(e, property);

                return UserManagerResponseStatus.NetworkError;
            }

            return UserManagerResponseStatus.InvalidRequest;
        }
    }


}
