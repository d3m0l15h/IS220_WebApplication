using System;
using System.Collections.Generic;
using IS220_WebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Context;

public partial class MyDbContext : IdentityDbContext<Aspnetuser, IdentityRole<uint>, uint>
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Aspnetrole> Aspnetroles { get; set; }

    public virtual DbSet<Aspnetroleclaim> Aspnetroleclaims { get; set; }

    public virtual DbSet<Aspnetuser> Aspnetusers { get; set; }

    public virtual DbSet<Aspnetuserclaim> Aspnetuserclaims { get; set; }

    public virtual DbSet<Aspnetuserlogin> Aspnetuserlogins { get; set; }

    public virtual DbSet<Aspnetusertoken> Aspnetusertokens { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Developer> Developers { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<UserOrder> UserOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var cfg = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

        optionsBuilder.UseMySql(cfg["dbGameStore"] ?? string.Empty,
            new MySqlServerVersion(new Version(10, 4, 28)));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            entity.HasOne(d => d.User).WithMany(p => p.Addresses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ADD_USER");
        });

        modelBuilder.Entity<Aspnetrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Aspnetroleclaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Role).WithMany(p => p.Aspnetroleclaims).HasConstraintName("FK_ASPNETROLECLAIMS_ASPNETROLES_ROLEID");
        });

        modelBuilder.Entity<Aspnetuser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Created).HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.Firstname).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Lastname).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Modified).ValueGeneratedOnAddOrUpdate();
            entity.Property(e => e.Phone).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Status).HasDefaultValueSql("'active'");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "Aspnetuserrole",
                    r => r.HasOne<Aspnetrole>().WithMany()
                        .HasForeignKey("Roleid")
                        .HasConstraintName("FK_ASPNETUSERROLES_ASPNETROLES_ROLEID"),
                    l => l.HasOne<Aspnetuser>().WithMany()
                        .HasForeignKey("Userid")
                        .HasConstraintName("FK_ASPNETUSERROLES_ASPNETUSERS_USERID"),
                    j =>
                    {
                        j.HasKey("Userid", "Roleid")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("aspnetuserroles");
                        j.HasIndex(new[] { "Roleid" }, "IX_ASPNETUSERROLES_ROLEID");
                        j.IndexerProperty<uint>("Userid")
                            .HasColumnType("int(10) unsigned")
                            .HasColumnName("USERID");
                        j.IndexerProperty<uint>("Roleid")
                            .HasColumnType("int(10) unsigned")
                            .HasColumnName("ROLEID");
                    });
        });

        modelBuilder.Entity<Aspnetuserclaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.User).WithMany(p => p.Aspnetuserclaims).HasConstraintName("FK_ASPNETUSERCLAIMS_ASPNETUSERS_USERID");
        });

        modelBuilder.Entity<Aspnetuserlogin>(entity =>
        {
            entity.HasKey(e => new { e.Loginprovider, e.Providerkey })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.HasOne(d => d.User).WithMany(p => p.Aspnetuserlogins).HasConstraintName("FK_ASPNETUSERLOGINS_ASPNETUSERS_USERID");
        });

        modelBuilder.Entity<Aspnetusertoken>(entity =>
        {
            entity.HasKey(e => new { e.Userid, e.Loginprovider, e.Name })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.HasOne(d => d.User).WithMany(p => p.Aspnetusertokens).HasConstraintName("FK_ASPNETUSERTOKENS_ASPNETUSERS_USERID");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Uid, e.GameId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Created).HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.Modified)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()");

            entity.HasOne(d => d.Game).WithMany(p => p.Carts).HasConstraintName("FK_GAME-ID");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.Carts).HasConstraintName("FK_ASPNETUSERS-UID");
        });

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
            entity.HasKey(e => e.Migrationid).HasName("PRIMARY");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Status).HasDefaultValueSql("'active'");
            entity.Property(e => e.Type).HasDefaultValueSql("'2'");

            entity.HasOne(d => d.DeveloperNavigation).WithMany(p => p.Games)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GAME_DEVELOPER");

            entity.HasOne(d => d.PublisherNavigation).WithMany(p => p.Games)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GAME_PUBLISHER");

            entity.HasMany(d => d.Categories).WithMany(p => p.Games)
                .UsingEntity<Dictionary<string, object>>(
                    "GameCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_GC_CATEGORY"),
                    l => l.HasOne<Game>().WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_GC_GAME"),
                    j =>
                    {
                        j.HasKey("GameId", "CategoryId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("game_category");
                        j.HasIndex(new[] { "CategoryId" }, "FK_GC_CATEGORY");
                        j.HasIndex(new[] { "GameId" }, "FK_GC_GAME");
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
                    r => r.HasOne<Aspnetuser>().WithMany()
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_GAMEOWNER_USER"),
                    l => l.HasOne<Game>().WithMany()
                        .HasForeignKey("Gameid")
                        .HasConstraintName("FK_GAMEOWNER_GAME"),
                    j =>
                    {
                        j.HasKey("Gameid", "Userid")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("game_owned");
                        j.HasIndex(new[] { "Gameid" }, "FK_GAMEOWNER_GAME");
                        j.HasIndex(new[] { "Userid" }, "FK_GAMEOWNER_USER");
                        j.IndexerProperty<uint>("Gameid")
                            .HasColumnType("int(10) unsigned")
                            .HasColumnName("GAMEID");
                        j.IndexerProperty<uint>("Userid")
                            .HasColumnType("int(10) unsigned")
                            .HasColumnName("USERID");
                    });
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Created).HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.Modified).ValueGeneratedOnAddOrUpdate();

            entity.HasOne(d => d.Game).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ord_det_Game");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ord_det_Order");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<UserOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();

            entity.HasOne(d => d.Address).WithMany(p => p.UserOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ADDRESS_ORD");

            entity.HasOne(d => d.User).WithMany(p => p.UserOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER_ORD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
