﻿// <auto-generated />
using System;
using JITCATALOG.INFRASTRUCTURE.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JITCATALOG.INFRASTRUCTURE.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JITCATALOG.DOMAIN.Models.Auteur", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateNaissance")
                        .HasColumnType("date");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Auteur", (string)null);
                });

            modelBuilder.Entity("JITCATALOG.DOMAIN.Models.Catalogue", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateModif")
                        .HasColumnType("date");

                    b.Property<int?>("LivreId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("LivreId");

                    b.ToTable("Catalogue", (string)null);
                });

            modelBuilder.Entity("JITCATALOG.DOMAIN.Models.Editeur", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateEditeur")
                        .HasColumnType("date");

                    b.Property<string>("TitreEditeur")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Editeur", (string)null);
                });

            modelBuilder.Entity("JITCATALOG.DOMAIN.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genre", (string)null);
                });

            modelBuilder.Entity("JITCATALOG.DOMAIN.Models.Historique", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("AuteurId")
                        .HasColumnType("int");

                    b.Property<int?>("LivreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuteurId");

                    b.HasIndex("LivreId");

                    b.ToTable("Historique", (string)null);
                });

            modelBuilder.Entity("JITCATALOG.DOMAIN.Models.Livre", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("AuteurId")
                        .HasColumnType("int");

                    b.Property<string>("Couverture")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DatePublication")
                        .HasColumnType("date");

                    b.Property<int?>("EditeurId")
                        .HasColumnType("int");

                    b.Property<string>("FormatLivre")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDisponible")
                        .HasColumnType("bit");

                    b.Property<string>("Isbn")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ISBN");

                    b.Property<string>("Langue")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("NombrePage")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("EditeurId");

                    b.HasIndex("GenreId");

                    b.ToTable("Livre", (string)null);
                });

            modelBuilder.Entity("JITCATALOG.DOMAIN.Models.Catalogue", b =>
                {
                    b.HasOne("JITCATALOG.DOMAIN.Models.Livre", "Livre")
                        .WithMany("Catalogues")
                        .HasForeignKey("LivreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Catalogue_Livre");

                    b.Navigation("Livre");
                });

            modelBuilder.Entity("JITCATALOG.DOMAIN.Models.Historique", b =>
                {
                    b.HasOne("JITCATALOG.DOMAIN.Models.Auteur", "Auteur")
                        .WithMany("Historiques")
                        .HasForeignKey("AuteurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Historique_Auteur");

                    b.HasOne("JITCATALOG.DOMAIN.Models.Livre", "Livre")
                        .WithMany("Historiques")
                        .HasForeignKey("LivreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Historique_Livre");

                    b.Navigation("Auteur");

                    b.Navigation("Livre");
                });

            modelBuilder.Entity("JITCATALOG.DOMAIN.Models.Livre", b =>
                {
                    b.HasOne("JITCATALOG.DOMAIN.Models.Editeur", "Editeur")
                        .WithMany("Livres")
                        .HasForeignKey("EditeurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Livre_Editeur");

                    b.HasOne("JITCATALOG.DOMAIN.Models.Genre", "Genre")
                        .WithMany("Livres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Livre_Genre");

                    b.Navigation("Editeur");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("JITCATALOG.DOMAIN.Models.Auteur", b =>
                {
                    b.Navigation("Historiques");
                });

            modelBuilder.Entity("JITCATALOG.DOMAIN.Models.Editeur", b =>
                {
                    b.Navigation("Livres");
                });

            modelBuilder.Entity("JITCATALOG.DOMAIN.Models.Genre", b =>
                {
                    b.Navigation("Livres");
                });

            modelBuilder.Entity("JITCATALOG.DOMAIN.Models.Livre", b =>
                {
                    b.Navigation("Catalogues");

                    b.Navigation("Historiques");
                });
#pragma warning restore 612, 618
        }
    }
}
