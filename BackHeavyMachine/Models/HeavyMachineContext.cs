using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackHeavyMachine.Models
{
    public partial class HeavyMachineContext : DbContext
    {
        public HeavyMachineContext()
        {
        }

        public HeavyMachineContext(DbContextOptions<HeavyMachineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TCamiones> TCamiones { get; set; }
        public virtual DbSet<TCliente> TCliente { get; set; }
        public virtual DbSet<TUsuarios> TUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=HeavyMachine;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TCamiones>(entity =>
            {
                entity.ToTable("tCamiones");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("marca")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.TCamiones)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tCamiones_tCliente");
            });

            modelBuilder.Entity<TCliente>(entity =>
            {
                entity.ToTable("tCliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TUsuarios>(entity =>
            {
                entity.ToTable("tUsuarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
