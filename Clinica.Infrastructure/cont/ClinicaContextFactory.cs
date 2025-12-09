using Clinica.Infrastructure;
using Clinica.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Clinica.Infrastructure
{
    public class ClinicaContextFactory : IDesignTimeDbContextFactory<ClinicaContext>
    {
        public ClinicaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ClinicaContext>();

            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-8LAE31G;Database=ClinicaDB;Trusted_Connection=True;TrustServerCertificate=True;"
            );

            return new ClinicaContext(optionsBuilder.Options);
        }
    }
}
