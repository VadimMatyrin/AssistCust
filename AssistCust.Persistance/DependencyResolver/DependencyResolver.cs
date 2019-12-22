using AssistCust.Persistance.DependencyResolver.Interfaces;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace AssistCust.Persistance.DependencyResolver
{
    public class DependencyResolver
    {
        public IServiceProvider ServiceProvider { get; }
        public string CurrentDirectory { get; set; }

        public DependencyResolver()
        {
            // Set up Dependency Injection
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IEnvironmentService, EnvironmentService>();
            services.AddTransient<IConfigurationService, ConfigurationService>(provider => 
            new ConfigurationService(provider.GetService<IEnvironmentService>()));

            services.AddOptions();
            services.Configure<OperationalStoreOptions>(provider =>
            {
                provider.DeviceFlowCodes = new TableConfiguration("DeviceFlowCodes");
                provider.EnableTokenCleanup = false;
                provider.PersistedGrants = new TableConfiguration("PersistedGrants");
                provider.TokenCleanupBatchSize = 100;
                provider.TokenCleanupInterval = 3600;
            });
            // Register DbContext class
            services.AddTransient(provider =>
            {
                var configService = provider.GetService<IConfigurationService>();
                var connectionString = configService.GetConfiguration().GetConnectionString("AssistCustDatabase");
                var optionsBuilder = new DbContextOptionsBuilder<AssistCustDbContext>();
                optionsBuilder.UseSqlServer(connectionString);
                return new AssistCustDbContext(optionsBuilder.Options, provider.GetService<IOptions<OperationalStoreOptions>>());
            });
        }
    }
}
