﻿// <auto-generated />
using DungeonWorldFIcha.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DungeonWorldFIcha.Migrations
{
    [DbContext(typeof(DungeonWorldContext))]
    partial class DungeonWorldContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("DungeonWorldFIcha.Models.Habilidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Carisma")
                        .HasColumnType("int");

                    b.Property<int>("Constituicao")
                        .HasColumnType("int");

                    b.Property<int>("Destreza")
                        .HasColumnType("int");

                    b.Property<int>("Forca")
                        .HasColumnType("int");

                    b.Property<int>("Inteligencia")
                        .HasColumnType("int");

                    b.Property<int>("Sabedoria")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Habilidades");
                });

            modelBuilder.Entity("DungeonWorldFIcha.Models.Personagem", b =>
                {
                    b.Property<int>("PersonagemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PersonagemId"));

                    b.Property<int>("Armadura")
                        .HasColumnType("int");

                    b.Property<string>("Classe")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("DadoDano")
                        .HasColumnType("int");

                    b.Property<string>("DescricaoDois")
                        .HasColumnType("longtext");

                    b.Property<string>("DescricaoUm")
                        .HasColumnType("longtext");

                    b.Property<string>("Equipamento")
                        .HasColumnType("longtext");

                    b.Property<int>("HabilidadeId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<int>("Nivel")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Pv")
                        .HasColumnType("int");

                    b.Property<int>("PvTotal")
                        .HasColumnType("int");

                    b.HasKey("PersonagemId");

                    b.HasIndex("HabilidadeId");

                    b.ToTable("Personagens");
                });

            modelBuilder.Entity("DungeonWorldFIcha.Models.Personagem", b =>
                {
                    b.HasOne("DungeonWorldFIcha.Models.Habilidade", "Habilidade")
                        .WithMany()
                        .HasForeignKey("HabilidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habilidade");
                });
#pragma warning restore 612, 618
        }
    }
}
