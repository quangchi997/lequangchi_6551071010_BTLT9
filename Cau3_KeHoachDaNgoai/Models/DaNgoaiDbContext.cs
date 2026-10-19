using Microsoft.EntityFrameworkCore;

namespace Cau3_KeHoachDaNgoai.Models
{
    public class DaNgoaiDbContext : DbContext
    {
        public DbSet<ChuyenDi> ChuyenDis { get; set; } = null!;

        public DaNgoaiDbContext()
        {
        }

        public DaNgoaiDbContext(DbContextOptions<DaNgoaiDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conn = Configuration.ConfigHelper.GetConnectionString();
                optionsBuilder.UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChuyenDi>(entity =>
            {
                entity.ToTable("ChuyenDi");
                entity.HasKey(e => e.MaChuyen);
                entity.Property(e => e.TenChuyen).HasMaxLength(100);
                entity.Property(e => e.DiaDiem).HasMaxLength(100);
                entity.Property(e => e.NganSach).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.PhuongTien).HasMaxLength(30);
                entity.Property(e => e.GhiChu).HasMaxLength(200);
            });
        }
    }
}
