using BaseProject.Repositories.Seeds;

namespace BaseProject.Repositories.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BaseProject.Repositories.EfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BaseProject.Repositories.EfDbContext context)
        {
            UserSeed.Seed(context);
        }
    }
}
