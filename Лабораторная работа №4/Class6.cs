//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Emit;
//using System.Text;
//using System.Threading.Tasks;
//using лаба4;
//using Npgsql;

//namespace Лабораторная_работа__4
//{
//    public partial class TrianglesContext : DbContext
//    {
//        public TrianglesContext()
//        {
//        }

//        public TrianglesContext(DbContextOptions<TrianglesContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<Triangle> triangle { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Triangles;Username=postgres;Password=фыв123");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Triangle>(entity =>
//            {
//                entity.ToTable("Triangles");

//                entity.Property(e => e.ID)
//                    .HasColumnName("id")
//                    .ValueGeneratedNever();

//                entity.Property(e => e.A).HasColumnName("_a");

//                entity.Property(e => e.Sq).HasColumnName("_area");

//                entity.Property(e => e.B).HasColumnName("_b");

//                entity.Property(e => e.C).HasColumnName("_c");

//                entity.Property(e => e.Type).HasColumnName("_type");

//                entity.Property(e => e.IsValidType).HasColumnName("_isvalidtype");
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}
