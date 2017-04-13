using System;
using System.Collections.Generic;
using System.Text;
using Fireteam.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Fireteam.Common
{
    public class FireteamDbContext : DbContext
    {
        public DbSet<User> Users;
        public DbSet<Game> Games;
        public DbSet<Activity> Activities;
        public DbSet<Group> Groups;

        public FireteamDbContext(DbContextOptions<FireteamDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
