using Microsoft.EntityFrameworkCore.Design;

namespace AssistCust.Persistance
{
    public class AssistCustDbContextFactory : IDesignTimeDbContextFactory<AssistCustDbContext> 
    {
        public AssistCustDbContext CreateDbContext(string[] args)
        {
            var resolver = new DependencyResolver.DependencyResolver();
            return resolver.ServiceProvider.GetService(typeof(AssistCustDbContext)) as AssistCustDbContext;
        }
    }
}
