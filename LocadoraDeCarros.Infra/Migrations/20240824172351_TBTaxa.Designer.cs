﻿// <auto-generated />
using LocadoraDeCarros.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocadoraDeCarros.Infra.Migrations
{
    [DbContext(typeof(LocadoraDeCarrosDbContext))]
    [Migration("20240824172351_TBTaxa")]
    partial class TBTaxa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LocadoraDeCarros.Dominio.ModuloAutomoveis.Automovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ano")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("CapacidadeCombustivel")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<int>("GrupoId")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("TipoCombustivel")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("TBAutomovel", (string)null);
                });

            modelBuilder.Entity("LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Grupo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TBGrupoAutomoveis", (string)null);
                });

            modelBuilder.Entity("LocadoraDeCarros.Dominio.ModuloPlanos.Planos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GrupoId")
                        .HasColumnType("int");

                    b.Property<decimal>("KmDisponivel")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("KmExtrapolado")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Plano")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("PrecoDiaria")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("PrecoKm")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("TBPlanos", (string)null);
                });

            modelBuilder.Entity("LocadoraDeCarros.Dominio.ModuloTaxa.Taxa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PlanoCobranca")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("TBTaxa", (string)null);
                });

            modelBuilder.Entity("LocadoraDeCarros.Dominio.ModuloAutomoveis.Automovel", b =>
                {
                    b.HasOne("LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("LocadoraDeCarros.Dominio.ModuloPlanos.Planos", b =>
                {
                    b.HasOne("LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Grupo");
                });
#pragma warning restore 612, 618
        }
    }
}
