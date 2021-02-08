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

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {          
            modelBuilder.Entity<Departamento>()
                .HasKey(f => f.Codigo);
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("Departamento");
                entity.Property(p => p.Codigo)
                      .HasColumnName("Codigo");
                entity.Property(p => p.nombre)
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false);
                entity.Property(a => a.presupuesto)
                     .HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<Empleado>()
              .HasKey(a => a.DNI);
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("Articulo");
                entity.Property(a => a.DNI)
                      .HasColumnName("Codigo");
                entity.Property(a => a.nombre)
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false);
                entity.Property(a => a.apellidos)
                      .IsRequired()
                      .HasMaxLength(255)
                      .IsUnicode(false);               
                entity.Property(a => a.id_departamento)
                      .HasColumnName("id_departamento");
                entity.HasOne(a => a.departamento)
                      .WithMany(f => f.empleados)
                      .HasForeignKey(a => a.id_departamento)
                      .OnDelete(DeleteBehavior.ClientSetNull);
                      //.HasConstraintName("FK_Departamento");                                           
            });

        }
    }
}
