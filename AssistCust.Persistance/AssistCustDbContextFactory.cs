using AssistCust.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AssistCust.Persistance
{
    public class AssistCustDbContextFactory : DesignTimeDbContextFactoryBase<AssistCustDbContext>
    {
        protected override AssistCustDbContext CreateNewInstance(DbContextOptions<AssistCustDbContext> options)
        {
            return new AssistCustDbContext(options);
        }
    }
}
