namespace CarDealer.Web.Infrastructure.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using System.Reflection;
    using Services;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            Assembly
                .GetAssembly(typeof(IService)) // gets assembly with type IService
                .GetTypes() // get types
                .Where(t => t.IsClass && t.GetInterfaces().Any(i => i.Name == $"I{t.Name}")) // get all the classes which only implemented this IService
                .Select(t => new
                {
                    Interface = t.GetInterface($"I{t.Name}"), // interfaces
                    Implementation = t // implemented classes
                })
                .ToList()
                .ForEach(s => services.AddTransient(s.Interface, s.Implementation));

            return services;
        }
    }
}
