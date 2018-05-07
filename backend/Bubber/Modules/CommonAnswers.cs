namespace Bubber.Modules
{
    public static class CommonAnswers
    {
        public static object NotSupported(string method) => new { error = true, error_message = method + " is not supported on this endpoint" };
        public static object NotYetSupported(string method) => new { error = true, error_message = method + " is not yet supported on this endpoint" };
        public static object WrongUse(string message) => new { error = true, error_message = message };

    }
}