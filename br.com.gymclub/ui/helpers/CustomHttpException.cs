using System;
namespace helpers
{
    public class CustomHttpException : Exception
    {
        public int StatusCode { get; set; }
        public String ErrorMessage { get; set; }

        public CustomHttpException(int statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.ErrorMessage = message ;
        }
    }
}
