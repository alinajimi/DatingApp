using System;
using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Helpers
{
    public static class Extensions
    {
        
        public static int Age(this DateTime dt) {
            TimeSpan time= DateTime.Now.Subtract(dt);
            return time.Days /365;
        }
        public static void AddApplicationError(this HttpResponse respponse , string message)
        {
            respponse.Headers.Add("Applicatioon-Error",message );
            respponse.Headers.Add("Access-control-Expose-Headers" , "Application-Error");
           respponse.Headers.Add("Access-control-Allow-Origin" , "*");

        }
    }
}