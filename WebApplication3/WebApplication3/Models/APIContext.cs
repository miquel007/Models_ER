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

        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Articulo> Articulos { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {          
            modelBuilder.Entity<Fabricante>()
                .HasKey(f => f.Codigo);
            modelBuilder.Entity<Fabricante>(entity =>
            {
                entity.ToTable("Fabricante");
                entity.Property(p => p.Codigo)
                      .HasColumnName("Codigo");
                entity.Property(p => p.nombre)
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<Articulo>()
              .HasKey(a => a.Codigo);
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.ToTable("Articulo");
                entity.Property(a => a.Codigo)
                      .HasColumnName("Codigo");
                entity.Property(a => a.nombre)
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false);
                entity.Property(a => a.precio)
                      .HasColumnType("decimal(10,2)");
                entity.Property(a => a.id_fabricante)
                      .HasColumnName("id_fabricante");
                entity.HasOne(a => a.fabricante)
                      .WithMany(f => f.articulos)
                      .HasForeignKey(a => a.id_fabricante)
                      .OnDelete(DeleteBehavior.ClientSetNull);
                      //.HasConstraintName("FK_Fabricante");                                           
            });

        }
    }
}
