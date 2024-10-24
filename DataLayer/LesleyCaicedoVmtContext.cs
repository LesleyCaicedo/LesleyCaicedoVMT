using System;
using System.Collections.Generic;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public partial class LesleyCaicedoVmtContext : DbContext
{
    public LesleyCaicedoVmtContext()
    {
    }

    public LesleyCaicedoVmtContext(DbContextOptions<LesleyCaicedoVmtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrito> Carritos { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<ProdCarrito> ProdCarritos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=VMT-LCAIZEDO;Initial Catalog=LesleyCaicedoVMT;Integrated Security=True; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.IdCarrito).HasName("PK__Carrito__8B4A618CA0B896C9");

            entity.ToTable("Carrito");

            entity.Property(e => e.IdCarrito).ValueGeneratedNever();
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FkIdUser).HasColumnName("FK_IdUser");

            entity.HasOne(d => d.FkIdUserNavigation).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.FkIdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Carrito__FK_IdUs__3E52440B");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A101E639276");

            entity.Property(e => e.IdCategoria).ValueGeneratedNever();
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<ProdCarrito>(entity =>
        {
            entity.HasKey(e => e.IdProdCar).HasName("PK__ProdCarr__112261D730352123");

            entity.ToTable("ProdCarrito");

            entity.Property(e => e.IdProdCar).ValueGeneratedNever();
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FkIdCarrito).HasColumnName("FK_IdCarrito");
            entity.Property(e => e.FkIdProd).HasColumnName("FK_IdProd");

            entity.HasOne(d => d.FkIdCarritoNavigation).WithMany(p => p.ProdCarritos)
                .HasForeignKey(d => d.FkIdCarrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProdCarri__FK_Id__412EB0B6");

            entity.HasOne(d => d.FkIdProdNavigation).WithMany(p => p.ProdCarritos)
                .HasForeignKey(d => d.FkIdProd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProdCarri__FK_Id__4222D4EF");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProd).HasName("PK__Producto__E40D971DE3272E64");

            entity.Property(e => e.IdProd).ValueGeneratedNever();
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FkIdCategoria).HasColumnName("FK_IdCategoria");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.FkIdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.FkIdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__FK_Id__3B75D760");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Usuario__B7C9263842FD78E1");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUser).ValueGeneratedNever();
            entity.Property(e => e.Alias).HasMaxLength(50);
            entity.Property(e => e.Cedula).HasMaxLength(10);
            entity.Property(e => e.Clave).HasMaxLength(150);
            entity.Property(e => e.Correo).HasMaxLength(30);
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
