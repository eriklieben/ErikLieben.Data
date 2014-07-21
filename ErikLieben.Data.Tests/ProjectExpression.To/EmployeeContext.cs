namespace ErikLieben.Tests.ProjectExpression.To
{
    using System.Data.Entity;

    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
            Database.SetInitializer<EmployeeContext>(null);
        }

        public DbSet<Person> People
        {
            get;
            set;
        }

        public DbSet<Region> Region
        {
            get;
            set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>().HasKey(i => i.Id);
            modelBuilder.Entity<Person>().HasRequired<Region>(i => i.Region).WithMany().HasForeignKey(i => i.RegionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
