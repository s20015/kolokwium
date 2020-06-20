using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class EventsDbContext : DbContext
    {
        public EventsDbContext() { }

        public EventsDbContext(DbContextOptions<EventsDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<ArtistEvent> ArtistEvent { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventOrganiser> EventOrganiser { get; set; }
        public virtual DbSet<Organiser> Organiser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s20015;Integrated Security=True");
            };
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasKey(e => e.IdArtist)
                    .HasName("Artist_pk");


                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.IdEvent)
                    .HasName("Event_pk");


                entity.Property(e => e.StartDate)
                    .IsRequired();

                entity.Property(e => e.EndDate)
                    .IsRequired();
            });

            modelBuilder.Entity<Organiser>(entity =>
            {
                entity.HasKey(e => e.IdOrganiser)
                    .HasName("Organiser_pk");


                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<EventOrganiser>(entity =>
            {
                entity.HasKey(e => new { e.IdEvent, e.IdOrganiser })
                    .HasName("Event_Organiser_pk");

                entity.ToTable("Event_Organiser");


                entity.HasOne(d => d.Event)
                    .WithMany(e => e.EventOrganiser)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Event_Organiser_Event");

                entity.HasOne(d => d.Organiser)
                    .WithMany(o => o.EventOrganiser)
                    .HasForeignKey(d => d.IdOrganiser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Event_Organiser_Organiser");

            });

            modelBuilder.Entity<ArtistEvent>(entity =>
            {
                entity.HasKey(e => new { e.IdEvent, e.IdArtist })
                    .HasName("Artist_Event_pk");

                entity.ToTable("Artist_Event");


                entity.HasOne(d => d.Event)
                    .WithMany(e => e.ArtistEvent)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Artist_Event_Event");

                entity.HasOne(d => d.Artist)
                    .WithMany(o => o.ArtistEvent)
                    .HasForeignKey(d => d.IdArtist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Artist_Event_Artist");

            });

        }
    }
}
