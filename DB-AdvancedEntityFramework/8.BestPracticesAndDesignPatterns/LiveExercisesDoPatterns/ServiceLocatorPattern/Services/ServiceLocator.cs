using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ServiceLocatorPattern.Services
{
    public class ServiceLocator
    {
        private static ServiceLocator instance;
        private Dictionary<string, Logger> services;

        private ServiceLocator()
        {
            this.services = new Dictionary<string, Logger>();
        }

        public static ServiceLocator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceLocator();
                }

                return instance;
            }
        }

        public void AddService(string name, Logger logger)
        {
            this.services.Add(name, logger);
        }

        public Logger GetService()
        {
            var type = ConfigurationManager.AppSettings["logger"];
            return this.services.FirstOrDefault(s => s.Key == type).Value;
        }
    }
}
