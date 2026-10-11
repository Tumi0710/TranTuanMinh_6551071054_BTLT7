using Microsoft.EntityFrameworkCore;

namespace AnKhangClinic.Models
{
    public partial class AnKhangDbContext : DbContext
    {
        public AnKhangDbContext() { }

        public AnKhangDbContext(DbContextOptions<AnKhangDbContext> options) : base(options) { }

        public virtual DbSet<BacSi> BacSis { get; set; }
        public virtual DbSet<LichKham> LichKhams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=AnKhangClinicDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BacSi>(entity =>
            {
                entity.HasKey(e => e.MaBs);
                entity.ToTable("BacSi");
                entity.Property(e => e.MaBs).HasColumnName("MaBS");
                entity.Property(e => e.HoTen).HasMaxLength(100);
                entity.Property(e => e.ChuyenKhoa).HasMaxLength(100);
                entity.Property(e => e.Sdt).HasMaxLength(15).HasColumnName("SDT");
            });

            modelBuilder.Entity<LichKham>(entity =>
            {
                entity.HasKey(e => e.MaLich);
                entity.ToTable("LichKham");
                entity.Property(e => e.TenBenhNhan).HasMaxLength(100);
                entity.Property(e => e.Sdt).HasMaxLength(15).HasColumnName("SDT");
                entity.Property(e => e.GioKham).HasMaxLength(10);
                entity.Property(e => e.MaBs).HasColumnName("MaBS");
                entity.Property(e => e.TrangThai).HasMaxLength(20);

                entity.HasOne(d => d.MaBsNavigation)
                    .WithMany(p => p.LichKhams)
                    .HasForeignKey(d => d.MaBs);
            });
        }
    }
}