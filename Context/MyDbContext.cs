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

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameCategory> GameCategories { get; set; }

    public virtual DbSet<GameOwned> GameOwneds { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

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
        });

        modelBuilder.Entity<Developer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Description).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.ImgPath).HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.DeveloperNavigation).WithMany(p => p.Games)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Game_Developer");

            entity.HasOne(d => d.PublisherNavigation).WithMany(p => p.Games)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Game_Publisher");
        });

        modelBuilder.Entity<GameCategory>(entity =>
        {
            entity.HasKey(e => new { e.Game, e.Category }).HasName("PRIMARY");
            entity.HasOne(d => d.CategoryNavigation).WithMany()
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_GC_Category");

            entity.HasOne(d => d.GameNavigation).WithMany()
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_GC_Game");
        });

        modelBuilder.Entity<GameOwned>(entity =>
        {
            entity.HasOne(d => d.Game).WithMany().HasConstraintName("FK_GameOwner_Game");

            entity.HasOne(d => d.UserEmailNavigation).WithMany().HasConstraintName("FK_GameOwner_User");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Date).HasDefaultValueSql("'current_timestamp()'");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.Transactions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_TRANSACTION_USER");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PRIMARY");

            entity.Property(e => e.Birth).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Created).HasDefaultValueSql("'current_timestamp()'");
            entity.Property(e => e.FirstName).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.LastName).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Modified)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Phone).HasDefaultValueSql("'NULL'");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
