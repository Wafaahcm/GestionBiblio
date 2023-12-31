﻿using System;
using System.Collections.Generic;
using JITCATALOG.DOMAIN.Models;
using Microsoft.EntityFrameworkCore;

namespace JITCATALOG.INFRASTRUCTURE.DB;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auteur> Auteurs { get; set; }

    public virtual DbSet<Catalogue> Catalogues { get; set; }

    public virtual DbSet<Editeur> Editeurs { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Historique> Historiques { get; set; }

    public virtual DbSet<Livre> Livres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.;Database=JIT_CATALOGUE;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auteur>(entity =>
        {
            entity.ToTable("Auteur");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateNaissance).HasColumnType("date");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Catalogue>(entity =>
        {
            entity.ToTable("Catalogue");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateModif).HasColumnType("date");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Livre).WithMany(p => p.Catalogues)
                .HasForeignKey(d => d.LivreId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Catalogue_Livre");
        });

        modelBuilder.Entity<Editeur>(entity =>
        {
            entity.ToTable("Editeur");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateEditeur).HasColumnType("date");
            entity.Property(e => e.TitreEditeur)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("Genre");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Historique>(entity =>
        {
            entity.ToTable("Historique");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Auteur).WithMany(p => p.Historiques)
                .HasForeignKey(d => d.AuteurId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Historique_Auteur");

            entity.HasOne(d => d.Livre).WithMany(p => p.Historiques)
                .HasForeignKey(d => d.LivreId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Historique_Livre");
        });

        modelBuilder.Entity<Livre>(entity =>
        {
            entity.ToTable("Livre");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Couverture).HasColumnType("text");
            entity.Property(e => e.DatePublication).HasColumnType("date");
            entity.Property(e => e.FormatLivre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.Langue)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Titre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Editeur).WithMany(p => p.Livres)
                .HasForeignKey(d => d.EditeurId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Livre_Editeur");

            entity.HasOne(d => d.Genre).WithMany(p => p.Livres)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Livre_Genre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
