using System.Net;

namespace Backend.Wrappers
{
    public class ErrorResponse : Response<object>
    {
        public int StatusCode { get; set; }

        public ErrorResponse(HttpStatusCode statusCode, string message = null) : this((int)statusCode, message) { }

        public ErrorResponse(int statusCode, string message = null) : base(null)
        {
            StatusCode = statusCode;
            IsError = true;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to the dark side. Errors lead to anger.  Anger leads to hate.  Hate leads to career change",
                _ => null
            };
        }
    }
}