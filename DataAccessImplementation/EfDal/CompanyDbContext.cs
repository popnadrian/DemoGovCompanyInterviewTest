using DataAccessInterfaces;
using Microsoft.EntityFrameworkCore;


namespace EfDal
{
    public class CompanyDbContext : DbContext
    {
        public virtual DbSet<Company> Company { get; set; }

        public CompanyDbContext()
        {

        }
        public CompanyDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Company>()
                .HasKey(c => c.Id);

            builder.Entity<Company>()
                .HasIndex(c => c.ISIN)
                .IsUnique();


            base.OnModelCreating(builder);
        }
    }
}