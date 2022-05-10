using System;
using DataAccessLayer.DataObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DataAccessLayer.EntityFramework
{
    public partial class BibliotecaPeliculasContext : DbContext
    {
        public BibliotecaPeliculasContext()
        {
        }

        public BibliotecaPeliculasContext(DbContextOptions<BibliotecaPeliculasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<Director> Director { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieActor> MovieActor { get; set; }
        public virtual DbSet<MovieGenre> MovieGenre { get; set; }
        public virtual DbSet<Production> Production { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=Luis\\SQLEXPRESS;Database=BibliotecaPeliculas;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.IdActor)
                    .HasName("PK__Actor__F86BE717B21605DD");

                entity.Property(e => e.IdActor).HasColumnName("id_actor");

                entity.Property(e => e.ActorAge).HasColumnName("actor_age");

                entity.Property(e => e.ActorLastname)
                    .IsRequired()
                    .HasColumnName("actor_lastname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ActorName)
                    .IsRequired()
                    .HasColumnName("actor_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(e => e.IdDirector)
                    .HasName("PK__Director__6B65E2A2CD36D826");

                entity.Property(e => e.IdDirector).HasColumnName("id_director");

                entity.Property(e => e.DirectorAge).HasColumnName("director_age");

                entity.Property(e => e.DirectorLastname)
                    .IsRequired()
                    .HasColumnName("director_lastname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DirectorName)
                    .IsRequired()
                    .HasColumnName("director_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.IdGenre)
                    .HasName("PK__Genre__CB767C6971C7F22E");

                entity.Property(e => e.IdGenre).HasColumnName("id_genre");

                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasColumnName("genre_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.IdMovie)
                    .HasName("PK__Movie__FB90FCD755251D7B");

                entity.Property(e => e.IdMovie).HasColumnName("id_movie");

                entity.Property(e => e.IdDirector).HasColumnName("id_director");

                entity.Property(e => e.IdProduction).HasColumnName("id_production");

                entity.Property(e => e.MovieCartel).HasColumnName("movie_cartel");

                entity.Property(e => e.MovieName)
                    .IsRequired()
                    .HasColumnName("movie_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MovieSynopsis)
                    .IsRequired()
                    .HasColumnName("movie_synopsis")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MovieYear).HasColumnName("movie_year");

                entity.HasOne(d => d.IdDirectorNavigation)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.IdDirector)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MvoieDirector");

                entity.HasOne(d => d.IdProductionNavigation)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.IdProduction)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieProduction");
            });

            modelBuilder.Entity<MovieActor>(entity =>
            {
                entity.HasKey(e => e.IdMovieActor);

                entity.ToTable("Movie_Actor");

                entity.Property(e => e.IdMovieActor).HasColumnName("id_movie_actor");

                entity.Property(e => e.IdActor).HasColumnName("id_actor");

                entity.Property(e => e.IdMovie).HasColumnName("id_movie");

                entity.Property(e => e.MovieRole)
                    .IsRequired()
                    .HasColumnName("movie_role")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdActorNavigation)
                    .WithMany(p => p.MovieActor)
                    .HasForeignKey(d => d.IdActor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActorMovie");

                entity.HasOne(d => d.IdMovieNavigation)
                    .WithMany(p => p.MovieActor)
                    .HasForeignKey(d => d.IdMovie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieActor");
            });

            modelBuilder.Entity<MovieGenre>(entity =>
            {
                entity.HasKey(e => e.IdMovieGenre);

                entity.ToTable("Movie_Genre");

                entity.Property(e => e.IdMovieGenre).HasColumnName("id_movie_genre");

                entity.Property(e => e.IdGenre).HasColumnName("id_genre");

                entity.Property(e => e.IdMovie).HasColumnName("id_movie");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany(p => p.MovieGenre)
                    .HasForeignKey(d => d.IdGenre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GenreMovie");

                entity.HasOne(d => d.IdMovieNavigation)
                    .WithMany(p => p.MovieGenre)
                    .HasForeignKey(d => d.IdMovie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieGenre");
            });

            modelBuilder.Entity<Production>(entity =>
            {
                entity.HasKey(e => e.IdProduction)
                    .HasName("PK__Producti__37D53444AE5FF398");

                entity.Property(e => e.IdProduction).HasColumnName("id_production");

                entity.Property(e => e.ProductionName)
                    .IsRequired()
                    .HasColumnName("production_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
       
    }
}
