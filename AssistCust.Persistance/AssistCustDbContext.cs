using System;
using Microsoft.EntityFrameworkCore;

namespace AssistCust.Persistance
{
    public class AssistCustDbContext: DbContext
    {
        public AssistCustDbContext(DbContextOptions<AssistCustDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssistCustDbContext).Assembly);
        }
    }
}
