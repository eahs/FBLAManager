using FBLAManager.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FBLAManager.Helpers
{
    public enum UserManagerResponseStatus
    {
        MissingFields,
        UserExists,
        Success,
        InvalidCredentials,
        UnknownResponse,
        InvalidRequest
    }

    public class UserManagerResponse
    {
        public string Status { get; set; }
        public string Key { get; set; }
    }

    public class UserManager
    {
        private static UserManager _userManager = null;

        private UserManager ()
        {
            _userManager = this;
        }

        public static UserManager Current
        {
            get { return _userManager ?? new UserManager(); }
        }

        public string SessionKey { get; set; } = "";

        public void AddAuthorization (RestRequest request)
        {
            request.AddHeader("auth", SessionKey);
        }

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

            var response = await client.ExecuteTaskAsync(request);

            if (response.Content != null)
            {
                UserManagerResponse data = JsonConvert.DeserializeObject<UserManagerResponse>(response.Content);

                if (data.Status != null)
                {
                    switch (data.Status)
                    {
                        case "Invalid form data":  return UserManagerResponseStatus.InvalidRequest;
                        case "LoggedIn":           SessionKey = data.Key;
                                                   return UserManagerResponseStatus.Success;
                        case "InvalidCredentials": return UserManagerResponseStatus.InvalidCredentials;
                        default:                   return UserManagerResponseStatus.UnknownResponse;
                    }
                }
            }

            return UserManagerResponseStatus.InvalidRequest;
        }


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

            var response = await client.ExecuteTaskAsync(request);

            if (response.Content != null)
            {
                UserManagerResponse data = JsonConvert.DeserializeObject<UserManagerResponse>(response.Content);

                switch (data.Status)
                {
                    case "MissingFields": return UserManagerResponseStatus.MissingFields; 
                    case "Success":       return UserManagerResponseStatus.Success;  
                    case "UserExists":    return UserManagerResponseStatus.UserExists;
                    default:              return UserManagerResponseStatus.UnknownResponse;
                }
            }

            return UserManagerResponseStatus.InvalidRequest;
        }
    }
}
