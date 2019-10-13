namespace TFL.WebClientConsole
{
    public class ApiError
    {
        public string ExceptionType { get; set; }
        public string Message { get; set; }

    }
    public class ApiException: System.Exception
    {
        public ApiError ApiError { get; set; }

        public ApiException()
        {
        }

        public ApiException(string message)
            : base(message)
        {
        }

        public ApiException(string message, System.Exception inner)
            : base(message, inner)
        {
        }

    }
}
