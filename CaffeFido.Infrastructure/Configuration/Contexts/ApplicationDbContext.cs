using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CaffeFido.Infrastructure.Configuration.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var coreAssembly = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select((item) => Assembly.Load(item)).Where(s => s.FullName.Contains("CaffeFido.Core"))?.FirstOrDefault();

            coreAssembly?.GetTypes().Where(t => t.Namespace != null && t.Namespace.Contains("CaffeFido.Core.Entities") && !t.IsAbstract).ToList().ForEach(item => { modelBuilder.Query(item); });
        }
    }
}
