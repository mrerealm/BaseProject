using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BaseProject.Domain.Entities;
using BaseProject.Repositories.EntityTypeConfigurations;

namespace BaseProject.Repositories
{
    public class EfDbContext : DbContext
    {
        public EfDbContext()
            : base("EfDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(50));

            modelBuilder.Configurations.Add(new UserConfigurations());
        }
    }
}
