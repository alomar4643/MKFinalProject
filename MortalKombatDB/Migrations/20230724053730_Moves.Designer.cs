﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MortalKombatDB.Data;

#nullable disable

namespace MortalKombatDB.Migrations
{
    [DbContext(typeof(MortalKombatDBContext))]
    [Migration("20230724053730_Moves")]
    partial class Moves
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("CharacterMove", b =>
                {
                    b.Property<Guid>("MovesId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("charactersId")
                        .HasColumnType("TEXT");

                    b.HasKey("MovesId", "charactersId");

                    b.HasIndex("charactersId");

                    b.ToTable("CharacterMove");
                });

            modelBuilder.Entity("MortalKombatDB.Models.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("MortalKombatDB.Models.Move", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsFatality")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("CharacterMove", b =>
                {
                    b.HasOne("MortalKombatDB.Models.Move", null)
                        .WithMany()
                        .HasForeignKey("MovesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MortalKombatDB.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("charactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
