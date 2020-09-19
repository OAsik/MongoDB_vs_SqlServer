using Microsoft.EntityFrameworkCore;
using DbComparison.DataLayer.SqlServer;
using DbComparison.ProjectLayer.Data.Common.Model;

namespace DbComparison.ProjectLayer.Data.SqlServer.DataContext
{
    public partial class SqlServerDbContext : BaseDataContext
    {
        public SqlServerDbContext()
        {

        }

        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-02M08H9\\RAZZLESQLSERVER;database=ComparisonDb;user=sa;password=2222mysql8888;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserAddress).HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.UserRating).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UserTag)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}