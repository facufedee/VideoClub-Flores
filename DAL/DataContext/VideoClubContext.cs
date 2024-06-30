using BE;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext;

public partial class VideoClubContext : DbContext
{
    public VideoClubContext()
    {
    }

    public VideoClubContext(DbContextOptions<VideoClubContext> options)
        : base(options)
    {
    }
     
    public virtual DbSet<Pelicula> Peliculas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pelicula__3213E83FDFED50E2");

            entity.ToTable("pelicula");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
