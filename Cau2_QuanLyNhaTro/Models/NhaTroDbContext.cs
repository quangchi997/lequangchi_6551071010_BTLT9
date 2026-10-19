using Microsoft.EntityFrameworkCore;

namespace Cau2_QuanLyNhaTro.Models
{
    public class NhaTroDbContext : DbContext
    {
        public DbSet<PhongTro> PhongTros { get; set; } = null!;
        public DbSet<KhachThue> KhachThues { get; set; } = null!;

        public NhaTroDbContext()
        {
        }

        public NhaTroDbContext(DbContextOptions<NhaTroDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = Configuration.ConfigHelper.GetConnectionString();
                optionsBuilder.UseSqlServer(connStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhongTro>(entity =>
            {
                entity.ToTable("PhongTro");
                entity.HasKey(e => e.MaPhong);
                entity.Property(e => e.TenPhong).HasMaxLength(20);
                entity.Property(e => e.GiaThue).HasColumnType("decimal(18, 0)");
                entity.Property(e => e.TinhTrang).HasMaxLength(20);

                entity.HasMany(e => e.KhachThues)
                      .WithOne(e => e.PhongTro)
                      .HasForeignKey(e => e.MaPhong)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<KhachThue>(entity =>
            {
                entity.ToTable("KhachThue");
                entity.HasKey(e => e.MaKhach);
                entity.Property(e => e.HoTen).HasMaxLength(100);
                entity.Property(e => e.GioiTinh).HasMaxLength(5);
                entity.Property(e => e.SoDienThoai).HasMaxLength(15);
                entity.Property(e => e.TenTinh).HasMaxLength(100);
                entity.Property(e => e.TenPhuongXa).HasMaxLength(100);
            });
        }
    }
}
