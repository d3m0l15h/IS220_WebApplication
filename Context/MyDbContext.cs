using System;
using System.Collections.Generic;
using IS220_WebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Developer> Developers { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameCategory> GameCategories { get; set; }

    public virtual DbSet<GameOwned> GameOwneds { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var cfg = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

        optionsBuilder.UseMySQL(cfg["dbGameStore"] ?? string.Empty);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Developer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("developer");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("game");

            entity.HasIndex(e => e.DeveloperId, "FK_Game_Developer");

            entity.HasIndex(e => e.PublisherId, "FK_Game_Publisher");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DeveloperId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("developerID");
            entity.Property(e => e.DownloadLink)
                .HasColumnType("tinytext")
                .HasColumnName("downloadLink");
            entity.Property(e => e.ImgPath)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("tinytext")
                .HasColumnName("imgPath");
            entity.Property(e => e.Price)
                .HasPrecision(10)
                .HasColumnName("price");
            entity.Property(e => e.PublisherId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("publisherID");
            entity.Property(e => e.ReleaseDate)
                .HasColumnType("date")
                .HasColumnName("releaseDate");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.Developer).WithMany(p => p.Games)
                .HasForeignKey(d => d.DeveloperId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Game_Developer");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Games)
                .HasForeignKey(d => d.PublisherId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Game_Publisher");
        });

        modelBuilder.Entity<GameCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("game_category");

            entity.HasIndex(e => e.CategoryId, "FK_GameCategory_Category");

            entity.HasIndex(e => e.GameId, "FK_GameCategory_Game");

            entity.Property(e => e.CategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("categoryID");
            entity.Property(e => e.GameId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("gameID");

            entity.HasOne(d => d.Category).WithMany()
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_GameCategory_Category");

            entity.HasOne(d => d.Game).WithMany()
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK_GameCategory_Game");
        });

        modelBuilder.Entity<GameOwned>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("game_owned");

            entity.HasIndex(e => e.GameId, "FK_GameOwner_Game");

            entity.HasIndex(e => e.UserEmail, "FK_GameOwner_User");

            entity.Property(e => e.GameId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("gameID");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(100)
                .HasColumnName("userEmail");

            entity.HasOne(d => d.Game).WithMany()
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK_GameOwner_Game");

            entity.HasOne(d => d.UserEmailNavigation).WithMany()
                .HasForeignKey(d => d.UserEmail)
                .HasConstraintName("FK_GameOwner_User");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("publisher");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName(" id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.Username, "username").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Birth)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("date")
                .HasColumnName("birth");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("lastName");
            entity.Property(e => e.Modified)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime")
                .HasColumnName("modified");
            entity.Property(e => e.Password)
                .HasColumnType("text")
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("phone");
            entity.Property(e => e.Role)
                .HasColumnType("tinyint(4)")
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}