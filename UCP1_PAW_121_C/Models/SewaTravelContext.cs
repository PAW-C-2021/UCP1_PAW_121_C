using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_121_C.Models
{
    public partial class SewaTravelContext : DbContext
    {
        public SewaTravelContext()
        {
        }

        public SewaTravelContext(DbContextOptions<SewaTravelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Jadwal> Jadwals { get; set; }
        public virtual DbSet<KotaTujuan> KotaTujuans { get; set; }
        public virtual DbSet<Mobil> Mobils { get; set; }
        public virtual DbSet<Pelanggan> Pelanggans { get; set; }
        public virtual DbSet<SewaMobil> SewaMobils { get; set; }
        public virtual DbSet<SewaTravel> SewaTravels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasKey(e => e.IdDriver);

                entity.ToTable("Driver");

                entity.Property(e => e.IdDriver)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Driver");

                entity.Property(e => e.NamaDriver)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Driver");

                entity.Property(e => e.NoHpDriver)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("No_HP_Driver");
            });

            modelBuilder.Entity<Jadwal>(entity =>
            {
                entity.HasKey(e => e.IdJadwal);

                entity.ToTable("Jadwal");

                entity.Property(e => e.IdJadwal)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Jadwal");

                entity.Property(e => e.IdKotaTujuan).HasColumnName("ID_KotaTujuan");

                entity.Property(e => e.Jam)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TglSewa)
                    .HasColumnType("datetime")
                    .HasColumnName("Tgl_Sewa");

                entity.Property(e => e.Tujuan)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdKotaTujuanNavigation)
                    .WithMany(p => p.Jadwals)
                    .HasForeignKey(d => d.IdKotaTujuan)
                    .HasConstraintName("FK_Jadwal_Kota_Tujuan");
            });

            modelBuilder.Entity<KotaTujuan>(entity =>
            {
                entity.HasKey(e => e.IdKotaTujuan);

                entity.ToTable("Kota_Tujuan");

                entity.Property(e => e.IdKotaTujuan)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_KotaTujuan");

                entity.Property(e => e.Biaya)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.KotaTujuan1)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Kota_Tujuan");
            });

            modelBuilder.Entity<Mobil>(entity =>
            {
                entity.HasKey(e => e.IdMobil);

                entity.ToTable("Mobil");

                entity.Property(e => e.IdMobil)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Mobil");

                entity.Property(e => e.JenisMobil)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Jenis_Mobil");

                entity.Property(e => e.NamaMobil)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Mobil");

                entity.Property(e => e.SewaMobil)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Sewa_Mobil");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pelanggan>(entity =>
            {
                entity.HasKey(e => e.IdPelanggan);

                entity.ToTable("Pelanggan");

                entity.Property(e => e.IdPelanggan)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Pelanggan");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NamaPelanggan)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Pelanggan");

                entity.Property(e => e.NoHpPelanggan)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("No_HP_Pelanggan");
            });

            modelBuilder.Entity<SewaMobil>(entity =>
            {
                entity.HasKey(e => e.IdSewaMobil);

                entity.ToTable("Sewa_Mobil");

                entity.Property(e => e.IdSewaMobil)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_SewaMobil");

                entity.Property(e => e.IdDriver).HasColumnName("ID_Driver");

                entity.Property(e => e.IdMobil).HasColumnName("ID_Mobil");

                entity.Property(e => e.IdPelanggan).HasColumnName("ID_Pelanggan");

                entity.Property(e => e.JumlahHari)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Jumlah_Hari");

                entity.Property(e => e.Total)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDriverNavigation)
                    .WithMany(p => p.SewaMobils)
                    .HasForeignKey(d => d.IdDriver)
                    .HasConstraintName("FK_Sewa_Mobil_Driver");

                entity.HasOne(d => d.IdMobilNavigation)
                    .WithMany(p => p.SewaMobils)
                    .HasForeignKey(d => d.IdMobil)
                    .HasConstraintName("FK_Sewa_Mobil_Mobil");

                entity.HasOne(d => d.IdPelangganNavigation)
                    .WithMany(p => p.SewaMobils)
                    .HasForeignKey(d => d.IdPelanggan)
                    .HasConstraintName("FK_Sewa_Mobil_Pelanggan");
            });

            modelBuilder.Entity<SewaTravel>(entity =>
            {
                entity.HasKey(e => e.IdSewaTravel);

                entity.ToTable("Sewa_Travel");

                entity.Property(e => e.IdSewaTravel)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_SewaTravel");

                entity.Property(e => e.Biaya)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdJadwal).HasColumnName("ID_Jadwal");

                entity.Property(e => e.IdPelanggan).HasColumnName("ID_Pelanggan");

                entity.Property(e => e.Kuota)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TotalBayar)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Total_Bayar");

                entity.HasOne(d => d.IdJadwalNavigation)
                    .WithMany(p => p.SewaTravels)
                    .HasForeignKey(d => d.IdJadwal)
                    .HasConstraintName("FK_Sewa_Travel_Jadwal");

                entity.HasOne(d => d.IdPelangganNavigation)
                    .WithMany(p => p.SewaTravels)
                    .HasForeignKey(d => d.IdPelanggan)
                    .HasConstraintName("FK_Sewa_Travel_Pelanggan");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
