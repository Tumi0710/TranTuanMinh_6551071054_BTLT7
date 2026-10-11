using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace SunriseHomestay.Models
{
    public partial class SunriseDbContext : DbContext
    {
        public SunriseDbContext()
        {
        }

        public SunriseDbContext(DbContextOptions<SunriseDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=SunriseHomestayDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiPhong>(entity =>
            {
                entity.HasKey(e => e.MaLoai);
                entity.ToTable("LoaiPhong");
                entity.Property(e => e.TenLoai).HasMaxLength(100);
                entity.Property(e => e.GiaMoiDem).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.MoTa).HasMaxLength(255);
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.HasKey(e => e.MaPhong);
                entity.ToTable("Phong");
                entity.Property(e => e.SoPhong).HasMaxLength(10);
                entity.Property(e => e.TinhTrang).HasMaxLength(20);
                entity.Property(e => e.HinhAnh).HasMaxLength(255);

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.Phongs)
                    .HasForeignKey(d => d.MaLoai);
            });
        }
    }
}