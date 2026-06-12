namespace TaskManager.Brokers
{
    public static class LoggingBroker
    {
        public static void LogInfo(string message)
        {
            Console.WriteLine($"INFO: {message}");
            Console.WriteLine(Environment.StackTrace);
        }

        public static void LogError(string message)
        {
            Console.WriteLine($"ERROR: {message}");
            Console.WriteLine(Environment.StackTrace);
        }
    }
}