namespace Application.Exceptions
{
    public class ApiException : System.Exception
    {
        public int StatusCode { get; private set; }
        public string Response { get; private set; }
        public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; private set; }

        public ApiException(string message, int statusCode, string response, IReadOnlyDictionary<string, IEnumerable<string>> headers)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + (response == null ? "(null)" : response.Substring(0, response.Length)))
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }
    }


    public class ApiException<TResult> : ApiException
    {
        public TResult Result { get; private set; }

        public ApiException(string message, int statusCode, string response, IReadOnlyDictionary<string, IEnumerable<string>> headers, TResult result)
         : base(message, statusCode, response, headers)
        {

        }
    }
}
