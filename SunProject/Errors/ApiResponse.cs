using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunProject.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        private string GetDefaultStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "You Made a Bad Request",
                401 => "You're not Authorized!",
                404 => "What you're looking for does not exist!",
                500 => "The Errors you made will bring you to a dark place!",
                _ => null
            };
        }
    }
}
