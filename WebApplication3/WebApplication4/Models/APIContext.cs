using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication1.Models
{
    public class APIContext : DbContext
    {

        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {

        }

        public DbSet<Almacen> Almacenes { get; set; }
        public DbSet<Caja> Cajas { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {          
            modelBuilder.Entity<Almacen>()
                .HasKey(f => f.Codigo);
            modelBuilder.Entity<Almacen>(entity =>
            {
                entity.ToTable("Almacen");
                entity.Property(p => p.Codigo)
                      .HasColumnName("Codigo");
                entity.Property(p => p.lugar)
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false);
                entity.Property(a => a.capacidad)
                     .HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<Caja>()
              .HasKey(a => a.num_referencia);
            modelBuilder.Entity<Caja>(entity =>
            {
                entity.ToTable("Caja");
                entity.Property(a => a.num_referencia)
                      .HasColumnName("Codigo");
                entity.Property(a => a.contenido)
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false);
                entity.Property(a => a.valor)
                      .HasColumnType("decimal(10,2)");
                entity.Property(a => a.id_almacen)
                      .HasColumnName("id_almacen");
                entity.HasOne(a => a.almacen)
                      .WithMany(f => f.cajas)
                      .HasForeignKey(a => a.id_almacen)
                      .OnDelete(DeleteBehavior.ClientSetNull);
                      //.HasConstraintName("FK_Departamento");                                           
            });

        }
    }
}
