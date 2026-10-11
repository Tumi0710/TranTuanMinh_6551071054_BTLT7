using Microsoft.EntityFrameworkCore;

namespace NhaSachTriThuc.Models
{
    public partial class NhaSachDbContext : DbContext
    {
        public NhaSachDbContext()
        {
        }

        public NhaSachDbContext(DbContextOptions<NhaSachDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TheLoaiSach> TheLoaiSaches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Chuỗi kết nối tới SQL Server (thay đổi Server=. nếu tên SQL Server của bạn khác)
                optionsBuilder.UseSqlServer("Server=.;Database=NhaSachTriThucDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TheLoaiSach>(entity =>
            {
                entity.HasKey(e => e.MaTl);
                entity.ToTable("TheLoaiSach");

                entity.HasIndex(e => e.TenTheLoai).IsUnique();

                entity.Property(e => e.MaTl).HasColumnName("MaTL");
                entity.Property(e => e.TenTheLoai).HasMaxLength(100);
                entity.Property(e => e.MoTa).HasMaxLength(255);
                entity.Property(e => e.SoLuongSach).HasDefaultValue(0);
                entity.Property(e => e.NgayTao)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}