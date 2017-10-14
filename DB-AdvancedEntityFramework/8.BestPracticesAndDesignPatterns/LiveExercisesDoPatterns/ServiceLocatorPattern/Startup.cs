namespace ServiceLocatorPattern
{
    using Services;
    using System;

    public class Startup
    {
        public static void Main()
        {
            RegisterServices();
            string value = "Hello, Service Locator!";

            var logger = ServiceLocator.Instance.GetService();
            logger.Log(value);
            Console.ReadKey();
        }

        static void RegisterServices()
        {
            ServiceLocator.Instance.AddService("console", new ConsoleLogger());
            ServiceLocator.Instance.AddService("decorated", new DecoratedLogger());
        }
    }
}
