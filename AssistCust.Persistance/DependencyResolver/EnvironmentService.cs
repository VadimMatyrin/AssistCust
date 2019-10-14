using AssistCust.Persistance.DependencyResolver.Interfaces;
using System;

namespace AssistCust.Persistance.DependencyResolver
{
    public class EnvironmentService : IEnvironmentService
    {
        public EnvironmentService()
        {
            EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                ?? "Production";
        }

        public string EnvironmentName { get; set; }
    }
}
