using Microsoft.EntityFrameworkCore;

namespace FitZoneGym.Models
{
    public partial class FitZoneDbContext : DbContext
    {
        public FitZoneDbContext()
        {
        }

        public FitZoneDbContext(DbContextOptions<FitZoneDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HoiVien> HoiViens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Thay đổi tên server nếu SQL Server của bạn có instance khác (ví dụ: .\SQLEXPRESS)
                optionsBuilder.UseSqlServer("Server=.;Database=FitZoneGymDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoiVien>(entity =>
            {
                entity.HasKey(e => e.MaHv);
                entity.ToTable("HoiVien");

                entity.Property(e => e.MaHv).HasColumnName("MaHV");
                entity.Property(e => e.HoTen).HasMaxLength(100);
                entity.Property(e => e.Sdt).HasMaxLength(15).HasColumnName("SDT");
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.HangThanhVien).HasMaxLength(20);
                entity.Property(e => e.NgayDangKy)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.TrangThai).HasDefaultValue(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}