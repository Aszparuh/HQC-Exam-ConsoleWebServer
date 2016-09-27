namespace ConsoleWebServer.Application
{
    public static class Startup
    {
        // TODO: Describe patterns, SOLID, bugs and bottleneck in Documentation.txt
        public static void Main()
        {
            var webSever = new WebServerConsole();
            webSever.Start();
        }
    }
}
