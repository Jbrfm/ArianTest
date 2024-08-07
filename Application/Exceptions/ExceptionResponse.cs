namespace Application.Exceptions
{
    public class ExceptionResponse
    {
        public string ExceptionMessage { get; set; }
        public string ExceptionMessageStatus { get; set; }
        //public string RedirectTo { get; set; }
        //public string ValidationErrors { get; set; }
        //public bool Success { get; set; }
        //public T? Data { get; set; }
    }

    public static class ExceptionMessageStatus
    {
        public const string SUCCESS = "success";
        public const string WARNING = "warning";
        public const string ERROR = "error";
        public const string INFO = "info";
    }
}
