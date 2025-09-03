using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<MusteriTanim> MusteriTanimlar { get; set; }
        public DbSet<MusteriFatura> MusteriFaturalar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MusteriTanim>(entity =>
            {
                entity.ToTable("musteri_tanim_table"); 
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Unvan).HasColumnName("UNVAN").HasMaxLength(255);
            });


            modelBuilder.Entity<MusteriFatura>(entity =>
            {
                entity.ToTable("musteri_fatura_table"); 
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.MusteriId).HasColumnName("MUSTERI_ID");
                entity.Property(e => e.FaturaTarihi).HasColumnName("FATURA_TARIHI").HasColumnType("date");
                entity.Property(e => e.FaturaTutari).HasColumnName("FATURA_TUTARI").HasColumnType("decimal(18,2)");
                entity.Property(e => e.OdemeTarihi).HasColumnName("ODEME_TARIHI").HasColumnType("date");

                
                entity.HasOne(d => d.Musteri)
                      .WithMany(p => p.Faturalar)
                      .HasForeignKey(d => d.MusteriId)
                      .OnDelete(DeleteBehavior.Restrict); 
            });
        }
    }
}
