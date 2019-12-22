using AssistCust.Persistance.DependencyResolver.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace AssistCust.Persistance.DependencyResolver
{
    public class ConfigurationService : IConfigurationService
    {
        public IEnvironmentService EnvService { get; }
        public string CurrentDirectory { get; set; }
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        public ConfigurationService(IEnvironmentService envService)
        {
            EnvService = envService;
        }

        public IConfiguration GetConfiguration()
        {
            CurrentDirectory ??= Directory.GetCurrentDirectory() + string.Format("{0}..{0}AssistCust", Path.DirectorySeparatorChar);
            return new ConfigurationBuilder()
                .SetBasePath(CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable(AspNetCoreEnvironment)}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
