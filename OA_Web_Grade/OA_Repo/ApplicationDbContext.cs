using Microsoft.EntityFrameworkCore;
using OA_Data;

namespace OA_Repo
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new GradeMap(modelBuilder.Entity<Grade>());
        }
    }
}