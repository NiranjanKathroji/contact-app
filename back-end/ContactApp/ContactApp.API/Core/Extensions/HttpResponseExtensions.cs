using Microsoft.AspNetCore.Http;

namespace ContactApp.API.Core.Extensions
{
    /// <summary>
    /// This class contains extensions method to Response headers.
    /// </summary>
    public static class HttpResponseExtensions
    {
        /// <summary>
        /// Extension method to add error information to Response headers.
        /// </summary>
        /// <param name="response">Response.</param>
        /// <param name="message">Message.</param>
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            // CORS
            response.Headers.Add("access-control-expose-headers", "Application-Error");
        }
    }
}

