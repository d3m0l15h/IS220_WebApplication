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
    
    public virtual DbSet<GameOwned> GameOwneds { get; set; }
    
    public virtual DbSet<GameCategory> GameCategories { get; set; }
    
    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionInfomation> TransactionInfomations { get; set; }

    public virtual DbSet<TransactionType> TransactionTypes { get; set; }

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
        
        modelBuilder.Entity<GameCategory>(entity =>
        {
            entity.HasKey(e => new { e.GameId, e.CategoryId }).HasName("PRIMARY");
            entity.HasOne(d => d.GameNavigation).WithMany().HasConstraintName("FK_GC_Game");

            entity.HasOne(d => d.CategoryNavigation).WithMany()
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_GC_Category");
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
            entity.Property(e => e.Status).HasDefaultValueSql("'''active'''");
            entity.Property(e => e.Type).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.DeveloperNavigation).WithMany(p => p.Games)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Game_Developer");

            entity.HasOne(d => d.PublisherNavigation).WithMany(p => p.Games)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Game_Publisher");

            entity.HasMany(d => d.Categories).WithMany(p => p.Games)
                .UsingEntity<Dictionary<string, object>>(
                    "GameCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_GC_Category"),
                    l => l.HasOne<Game>().WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_GC_Game"),
                    j =>
                    {
                        j.HasKey("GameId", "CategoryId").HasName("PRIMARY");
                        j.ToTable("game_category");
                        j.HasIndex(new[] { "CategoryId" }, "FK_GC_Category");
                        j.HasIndex(new[] { "GameId" }, "FK_GC_Game");
                        j.IndexerProperty<uint>("GameId")
                            .HasColumnType("int(10) unsigned")
                            .HasColumnName("gameID");
                        j.IndexerProperty<uint>("CategoryId")
                            .HasColumnType("int(10) unsigned")
                            .HasColumnName("categoryID");
                    });

            entity.HasMany(d => d.Users).WithMany(p => p.Games)
                .UsingEntity<Dictionary<string, object>>(
                    "GameOwned",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_GameOwner_User"),
                    l => l.HasOne<Game>().WithMany()
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK_GameOwner_Game"),
                    j =>
                    {
                        j.HasKey("GameId", "UserId").HasName("PRIMARY");
                        j.ToTable("game_owned");
                        j.HasIndex(new[] { "GameId" }, "FK_GameOwner_Game");
                        j.HasIndex(new[] { "UserId" }, "FK_GameOwner_User");
                        j.IndexerProperty<uint>("GameId")
                            .HasColumnType("int(10) unsigned")
                            .HasColumnName("gameID");
                        j.IndexerProperty<uint>("UserId")
                            .HasColumnType("int(10) unsigned")
                            .HasColumnName("userID");
                    });
        });
        
        modelBuilder.Entity<GameOwned>(entity =>
        {
            entity.HasKey(e => new { e.GameId, e.UserId }).HasName("PRIMARY");
            entity.HasOne(d => d.Game).WithMany().HasConstraintName("FK_GameOwner_Game");

            entity.HasOne(d => d.User).WithMany()
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_GameOwner_User");
        });
        
        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Date).HasDefaultValueSql("'current_timestamp()'");

            entity.HasOne(d => d.TransInfo).WithMany(p => p.Transactions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Info_Trans");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_User_Trans");
        });

        modelBuilder.Entity<TransactionInfomation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.GameId).HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.Game).WithMany(p => p.TransactionInfomations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Game_Trans");

            entity.HasOne(d => d.Type).WithMany(p => p.TransactionInfomations)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Fk_Type_Trans");
        });

        modelBuilder.Entity<TransactionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Birth).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Created).HasDefaultValueSql("'current_timestamp()'");
            entity.Property(e => e.FirstName).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.LastName).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Modified)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Phone).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Status).HasDefaultValueSql("'''active'''");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
