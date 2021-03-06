﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kolokwium.Models;

namespace kolokwium.Migrations
{
    [DbContext(typeof(EventsDbContext))]
    [Migration("20200620134354_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("kolokwium.Models.Artist", b =>
                {
                    b.Property<int>("IdArtist")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("IdArtist")
                        .HasName("Artist_pk");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("kolokwium.Models.ArtistEvent", b =>
                {
                    b.Property<int>("IdEvent")
                        .HasColumnType("int");

                    b.Property<int>("IdArtist")
                        .HasColumnType("int");

                    b.Property<DateTime>("PerformanceDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdEvent", "IdArtist")
                        .HasName("Artist_Event_pk");

                    b.HasIndex("IdArtist");

                    b.ToTable("Artist_Event");
                });

            modelBuilder.Entity("kolokwium.Models.Event", b =>
                {
                    b.Property<int>("IdEvent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdEvent")
                        .HasName("Event_pk");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("kolokwium.Models.EventOrganiser", b =>
                {
                    b.Property<int>("IdEvent")
                        .HasColumnType("int");

                    b.Property<int>("IdOrganiser")
                        .HasColumnType("int");

                    b.HasKey("IdEvent", "IdOrganiser")
                        .HasName("Event_Organiser_pk");

                    b.HasIndex("IdOrganiser");

                    b.ToTable("Event_Organiser");
                });

            modelBuilder.Entity("kolokwium.Models.Organiser", b =>
                {
                    b.Property<int>("IdOrganiser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("IdOrganiser")
                        .HasName("Organiser_pk");

                    b.ToTable("Organiser");
                });

            modelBuilder.Entity("kolokwium.Models.ArtistEvent", b =>
                {
                    b.HasOne("kolokwium.Models.Artist", "Artist")
                        .WithMany("ArtistEvent")
                        .HasForeignKey("IdArtist")
                        .HasConstraintName("Artist_Event_Artist")
                        .IsRequired();

                    b.HasOne("kolokwium.Models.Event", "Event")
                        .WithMany("ArtistEvent")
                        .HasForeignKey("IdEvent")
                        .HasConstraintName("Artist_Event_Event")
                        .IsRequired();
                });

            modelBuilder.Entity("kolokwium.Models.EventOrganiser", b =>
                {
                    b.HasOne("kolokwium.Models.Event", "Event")
                        .WithMany("EventOrganiser")
                        .HasForeignKey("IdEvent")
                        .HasConstraintName("Event_Organiser_Event")
                        .IsRequired();

                    b.HasOne("kolokwium.Models.Organiser", "Organiser")
                        .WithMany("EventOrganiser")
                        .HasForeignKey("IdOrganiser")
                        .HasConstraintName("Event_Organiser_Organiser")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
