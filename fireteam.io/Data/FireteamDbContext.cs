using System;
using System.Collections.Generic;
using System.Text;
using Fireteam.Models;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using Microsoft.Extensions.Configuration;

namespace Fireteam.Data
{
    public class FireteamDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityUser> ActivityUsers { get; set; }
        public DbSet<BlockedUser> BlockedUsers { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }
        public DbSet<GroupActivity> GroupActivities { get; set; }
        public DbSet<GroupGame> GroupGames { get; set; }
        public DbSet<GroupPlatform> GroupPlatforms { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<ConsoleModel> ConsoleModels { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<GroupType> GroupTypes { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<PlatformAccount> PlatformAccounts { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserPlatform> UserPlatforms { get; set; }
        public DbSet<UserPlatformAccount> UserPlatformAccounts { get; set; }

        public FireteamDbContext(DbContextOptions<FireteamDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.ID);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Groups);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Activities);
            modelBuilder.Entity<User>()
                .HasMany(u => u.BlockedUsers);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Games);
            modelBuilder.Entity<User>()
                .HasMany(u => u.PlatformAccounts);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Platforms);

            modelBuilder.Entity<Activity>()
                .HasKey(a => a.ID);
            modelBuilder.Entity<Activity>()
                .HasMany(a => a.Participants);
            modelBuilder.Entity<Activity>()
                .HasOne(a => a.User);
            modelBuilder.Entity<Activity>()
                .HasOne(a => a.ActivityType);

            modelBuilder.Entity<GroupActivity>()
                .HasKey(g => g.ID);
            modelBuilder.Entity<GroupActivity>()
                .HasOne(g => g.Group);
            modelBuilder.Entity<GroupActivity>()
                .HasOne(g => g.Activity);

            modelBuilder.Entity<UserActivity>()
                .HasKey(u => u.ID);
            modelBuilder.Entity<UserActivity>()
                .HasOne(u => u.User);
            modelBuilder.Entity<UserActivity>()
                .HasOne(u => u.Activity);

            modelBuilder.Entity<UserGame>()
                .HasKey(u => u.ID);
            modelBuilder.Entity<UserGame>()
                .HasOne(u => u.User);
            modelBuilder.Entity<UserGame>()
                .HasOne(u => u.Game);

            modelBuilder.Entity<ActivityUser>()
                .HasKey(a => a.ID);
            modelBuilder.Entity<ActivityUser>()
                .HasOne(a => a.Activity);
            modelBuilder.Entity<ActivityUser>()
                .HasOne(a => a.User);

            modelBuilder.Entity<BlockedUser>()
                .HasKey(b => b.ID);
            modelBuilder.Entity<BlockedUser>()
                .HasOne(b => b.BlockingUser);
            modelBuilder.Entity<BlockedUser>()
                .HasOne(b => b.Group);
            modelBuilder.Entity<BlockedUser>()
                .HasOne(b => b.Activity);
            modelBuilder.Entity<BlockedUser>()
                .HasOne(b => b.User);

            modelBuilder.Entity<Game>()
                .HasKey(g => g.ID);
            modelBuilder.Entity<Game>()
                .HasOne(g => g.GameType);
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Platforms);

            modelBuilder.Entity<GamePlatform>()
                .HasKey(g => g.ID);
            modelBuilder.Entity<GamePlatform>()
                .HasOne(g => g.Game);
            modelBuilder.Entity<GamePlatform>()
                .HasOne(g => g.Platform);

            modelBuilder.Entity<GameType>()
                .HasKey(g => g.ID);
            modelBuilder.Entity<GameType>()
                .HasMany(g => g.ConsoleModels);

            modelBuilder.Entity<Group>()
                .HasKey(g => g.ID);
            modelBuilder.Entity<Group>()
                .HasOne(g => g.GroupType);
            modelBuilder.Entity<Group>()
                .HasMany(g => g.Activities);
            modelBuilder.Entity<Group>()
                .HasMany(g => g.Games);
            modelBuilder.Entity<Group>()
                .HasMany(g => g.Members);
            modelBuilder.Entity<Group>()
                .HasMany(g => g.Platforms);


            modelBuilder.Entity<GroupGame>()
                .HasKey(g => g.ID);
            modelBuilder.Entity<GroupGame>()
                .HasOne(g => g.Group);
            modelBuilder.Entity<GroupGame>()
                .HasOne(g => g.Game);

            modelBuilder.Entity<GroupPlatform>()
                .HasKey(g => g.ID);
            modelBuilder.Entity<GroupPlatform>()
                .HasOne(g => g.Platform);
            modelBuilder.Entity<GroupPlatform>()
                .HasOne(g => g.Group);

            modelBuilder.Entity<GroupUser>()
                .HasKey(g => g.ID);
            modelBuilder.Entity<GroupUser>()
                .HasOne(g => g.User);
            modelBuilder.Entity<GroupUser>()
                .HasOne(g => g.Group);

            modelBuilder.Entity<PlatformAccount>()
                .HasKey(g => g.ID);
            modelBuilder.Entity<PlatformAccount>()
                .HasOne(g => g.Platform);
            modelBuilder.Entity<PlatformAccount>()
                .HasOne(g => g.ConsoleModel);


            modelBuilder.Entity<UserFriend>()
                .HasKey(u => u.ID);
            modelBuilder.Entity<UserFriend>()
                .HasOne(u => u.User);
            modelBuilder.Entity<UserFriend>()
                .HasOne(u => u.Friend);

            modelBuilder.Entity<UserGroup>()
                .HasKey(u => u.ID);
            modelBuilder.Entity<UserGroup>()
                .HasOne(u => u.User);
            modelBuilder.Entity<UserGroup>()
                .HasOne(u => u.Group);

            modelBuilder.Entity<UserPlatform>()
                .HasKey(u => u.ID);
            modelBuilder.Entity<UserPlatform>()
                .HasOne(u => u.User);
            modelBuilder.Entity<UserPlatform>()
                .HasOne(u => u.Platform);

            modelBuilder.Entity<UserPlatformAccount>()
                .HasKey(u => u.ID);
            modelBuilder.Entity<UserPlatformAccount>()
                .HasOne(u => u.User);
            modelBuilder.Entity<UserPlatformAccount>()
                .HasOne(u => u.PlatformAccount);

            modelBuilder.Entity<PlatformAccount>()
                .HasKey(u => u.ID);
            modelBuilder.Entity<PlatformAccount>()
                .HasOne(u => u.ConsoleModel);
            modelBuilder.Entity<PlatformAccount>()
                .HasOne(u => u.Platform);

        }
    }
}
