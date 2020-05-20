using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace FBLAManager.Helpers
{
    public static class ErrorLogger
    {
        public static void LogErrors(string ErrorMessage, IRestRequest request, IRestResponse response)
        {

            if (!response.IsSuccessful && request != null && response != null)
            {
                try
                {
                    var properties = new Dictionary<string, string>
                    {
                        { "ErrorMessage", ErrorMessage },
                        { "Request.URL", request.Resource },
                        { "Request.Attempts", request.Attempts.ToString() },
                        { "Response.StatusCode", response.StatusCode.ToString() },
                        { "Response.StatusDescription", response.StatusDescription },
                        { "Response.Headers", JsonConvert.SerializeObject( response.Headers, Formatting.Indented ) }
                    };

                    Microsoft.AppCenter.Crashes.Crashes.TrackError(response.ErrorException ?? new Exception("General Network Error"), properties);
                }
                catch (Exception e)
                {
                    // Come on man.. how do you crash while logging a crash?
                    Microsoft.AppCenter.Crashes.Crashes.TrackError(e);
                }
            }

        }
    }
}
