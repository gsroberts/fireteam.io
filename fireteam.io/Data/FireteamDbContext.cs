using System;
using System.Collections.Generic;
using System.Text;
using Fireteam.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Fireteam.Data
{
    public class FireteamDbContext : IdentityDbContext<User>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityUser> ActivityUsers { get; set; }
        public DbSet<BlockedUser> BlockedUsers { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<GameConsoleModel> GameConsoleModels { get; set; }
        public DbSet<ConsoleModel> ConsoleModels { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<GroupType> GroupTypes { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<PlatformAccount> PlatformAccounts { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<GroupPlatform> GroupPlatform { get; set; }

        public FireteamDbContext(DbContextOptions<FireteamDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .HasMaxLength(36);
            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .HasMaxLength(200);
            modelBuilder.Entity<User>()
                .Property(u => u.NormalizedUserName)
                .HasMaxLength(200);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Groups);
            modelBuilder.Entity<User>()
                .HasMany(u => u.BlockedUsers)
                .WithOne(b => b.UserBeingBlocked);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithOne(b => b.FriendedUser);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Games)
                .WithOne(b => b.User);

            modelBuilder.Entity<Activity>()
                .HasKey(a => a.ID);
            modelBuilder.Entity<Activity>()
                .HasMany(a => a.Participants)
                .WithOne(b => b.Activity);
            modelBuilder.Entity<Activity>()
                .HasOne(a => a.Organizer);
            modelBuilder.Entity<Activity>()
                .HasOne(a => a.ActivityType);


            modelBuilder.Entity<UserGame>()
                .HasKey(u => u.ID);
            modelBuilder.Entity<UserGame>()
                .HasOne(u => u.User);
            modelBuilder.Entity<UserGame>()
                .Property(u => u.UserID)
                .HasMaxLength(36);


            modelBuilder.Entity<ConsoleModel>()
                .HasKey(u => u.ID);


            modelBuilder.Entity<ActivityUser>()
                .HasKey(a => a.ID);
            modelBuilder.Entity<ActivityUser>()
                .HasOne(a => a.Activity);
            modelBuilder.Entity<ActivityUser>()
                .HasOne(a => a.User);
            modelBuilder.Entity<ActivityUser>()
                .Property(a => a.UserID)
                .HasMaxLength(36);


            modelBuilder.Entity<BlockedUser>()
                .HasKey(b => b.ID);
            modelBuilder.Entity<BlockedUser>()
                .HasOne(b => b.BlockingUser);
            modelBuilder.Entity<BlockedUser>()
                .Property(a => a.UserID)
                .HasMaxLength(36);
            modelBuilder.Entity<BlockedUser>()
                .Property(a => a.BlockingUserID)
                .HasMaxLength(36);
            modelBuilder.Entity<BlockedUser>()
                .HasOne(b => b.Group);
            modelBuilder.Entity<BlockedUser>()
                .HasOne(b => b.Activity);
            modelBuilder.Entity<BlockedUser>()
                .HasOne(b => b.UserBeingBlocked);


            modelBuilder.Entity<Game>()
                .HasKey(g => g.ID);
            modelBuilder.Entity<Game>()
                .HasOne(g => g.GameType);

            modelBuilder.Entity<GameType>()
                .HasKey(g => g.ID);

            modelBuilder.Entity<GamePlatform>()
                .HasKey(p => p.ID);

            modelBuilder.Entity<Group>()
                .HasKey(g => g.ID);
            modelBuilder.Entity<Group>()
                .HasOne(g => g.GroupType);


            modelBuilder.Entity<GroupUser>()
                .HasKey(g => g.ID);
            modelBuilder.Entity<GroupUser>()
                .Property(a => a.UserID)
                .HasMaxLength(36);


            modelBuilder.Entity<PlatformAccount>()
                .HasKey(g => g.ID);
            modelBuilder.Entity<PlatformAccount>()
                .HasOne(g => g.Platform);
            modelBuilder.Entity<PlatformAccount>()
                .HasOne(g => g.ConsoleModel);


            modelBuilder.Entity<UserFriend>()
                .HasKey(u => u.ID);
            modelBuilder.Entity<UserFriend>()
                .HasOne(u => u.FriendedUser);
            modelBuilder.Entity<UserFriend>()
                .HasOne(u => u.Friend);
            modelBuilder.Entity<UserFriend>()
                .Property(a => a.FriendID)
                .HasMaxLength(36);
            modelBuilder.Entity<UserFriend>()
                .Property(a => a.UserID)
                .HasMaxLength(36);


            modelBuilder.Entity<UserGroup>()
                .HasKey(u => u.ID);
            modelBuilder.Entity<UserGroup>()
                .Property(a => a.UserID)
                .HasMaxLength(36);
            modelBuilder.Entity<UserGroup>()
                .HasOne(u => u.User);
            modelBuilder.Entity<UserGroup>()
                .HasOne(u => u.Group);


            modelBuilder.Entity<PlatformAccount>()
                .HasKey(u => u.ID);
            modelBuilder.Entity<PlatformAccount>()
                .HasOne(u => u.ConsoleModel);
            modelBuilder.Entity<PlatformAccount>()
                .HasOne(u => u.Platform);

            modelBuilder.Entity<GameConsoleModel>()
                .HasKey(u => u.ID);


            modelBuilder.Entity<Role>()
                .Property(r => r.NormalizedName)
                .HasMaxLength(200);
            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .HasMaxLength(200);
        }
    }
}
