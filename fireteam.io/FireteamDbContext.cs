using System;
using System.Collections.Generic;
using System.Text;
using Fireteam.Models;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using Microsoft.Extensions.Configuration;

namespace Fireteam
{
    public class FireteamDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<ConsoleModel> ConsoleModels { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<GroupType> GroupTypes { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<PlatformAccount> PlatformAccounts { get; set; }

        public FireteamDbContext(DbContextOptions<FireteamDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
