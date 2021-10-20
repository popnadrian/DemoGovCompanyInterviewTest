using DataAccessInterfaces;
using Microsoft.EntityFrameworkCore;


namespace EfDal
{
    public class CompanyDbContext : DbContext
    {
        public DbSet<Company> Company { get; set; }

        public CompanyDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Company>()
                .HasIndex(c => c.ISIN)
                .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=company.db");

            base.OnConfiguring(optionsBuilder);
        }
    }
}