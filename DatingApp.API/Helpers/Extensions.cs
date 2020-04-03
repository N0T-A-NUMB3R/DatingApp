using System;
using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error",message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Access-Origin","*");
        }

        public static int CalculateAge(this DateTime dateTime)
        {
            int diff = DateTime.Now.Year - dateTime.Year;
            diff -= DateTime.Today > dateTime.AddYears(diff) ? 0 : 1;

            return diff;
        }
    }
}