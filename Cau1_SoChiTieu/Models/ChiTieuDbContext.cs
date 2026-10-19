using Microsoft.EntityFrameworkCore;

namespace Cau1_SoChiTieu.Models
{
    public class ChiTieuDbContext : DbContext
    {
        public DbSet<ChiTieu> ChiTieus { get; set; } = null!;

        public ChiTieuDbContext()
        {
        }

        public ChiTieuDbContext(DbContextOptions<ChiTieuDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = Configuration.ConfigHelper.GetConnectionString();
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTieu>(entity =>
            {
                entity.ToTable("ChiTieu");
                entity.HasKey(e => e.MaCT);
                entity.Property(e => e.NoiDung).HasMaxLength(100);
                entity.Property(e => e.LoaiChi).HasMaxLength(30);
                entity.Property(e => e.SoTien).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.GhiChu).HasMaxLength(200);
            });
        }
    }
}
