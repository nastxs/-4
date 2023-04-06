using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using лаба4;
using Npgsql;


namespace Лабораторная_работа__4
{
    public partial class TrianglesContext : DbContext
    {
        public TrianglesContext()
        {
        }

        public TrianglesContext(DbContextOptions<TrianglesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Triangle> triangle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=127.0.0.1; Port=5433; Database=Triangles; Username=postgres; Password=asd123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Triangle>(entity =>
            {
                entity.ToTable("triangles");

                entity.Property(e => e.id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.a).HasColumnName("a");

                entity.Property(e => e.sq).HasColumnName("square");

                entity.Property(e => e.b).HasColumnName("b");

                entity.Property(e => e.c).HasColumnName("c");

                entity.Property(e => e.type).HasColumnName("type");

               
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
