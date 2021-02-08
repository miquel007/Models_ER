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

        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sala> Salas { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {          
            modelBuilder.Entity<Pelicula>()
                .HasKey(f => f.Codigo);
            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.ToTable("Pelicula");
                entity.Property(p => p.Codigo)
                      .HasColumnName("Codigo");
                entity.Property(p => p.nombre)
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<Sala>()
              .HasKey(a => a.Codigo);
            modelBuilder.Entity<Sala>(entity =>
            {
                entity.ToTable("Caja");
                entity.Property(a => a.Codigo)
                      .HasColumnName("Codigo");
                entity.Property(a => a.nombre)
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false);
                entity.Property(a => a.id_pelicula)
                      .HasColumnName("id_almacen");
                entity.HasOne(a => a.pelicula)
                    .WithMany(f => f.salas)
                    .HasForeignKey(a => a.id_pelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                    //.HasConstraintName("FK_Departamento");                                           
            });

        }
    }
}
