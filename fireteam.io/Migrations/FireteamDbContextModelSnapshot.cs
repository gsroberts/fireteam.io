using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Fireteam;

namespace Fireteam.Migrations
{
    [DbContext(typeof(FireteamDbContext))]
    partial class FireteamDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Fireteam.Models.Activity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityTypeID");

                    b.Property<int>("AvailableSlots");

                    b.Property<string>("Description");

                    b.Property<string>("Duration");

                    b.Property<int>("GameID");

                    b.Property<int?>("GroupID");

                    b.Property<bool>("IsHidden");

                    b.Property<bool>("IsInviteOnly");

                    b.Property<string>("Requirements");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("TimeZone");

                    b.Property<int>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("ActivityTypeID");

                    b.HasIndex("GameID");

                    b.HasIndex("GroupID");

                    b.HasIndex("UserId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Fireteam.Models.ActivityType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("ActivityTypes");
                });

            modelBuilder.Entity("Fireteam.Models.ActivityUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityID");

                    b.Property<bool>("HasBeenBooted");

                    b.Property<bool>("IsTentative");

                    b.Property<bool>("ReasonForBoot");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("ActivityID");

                    b.HasIndex("UserID");

                    b.ToTable("ActivityUser");
                });

            modelBuilder.Entity("Fireteam.Models.ConsoleModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("ConsoleModels");
                });

            modelBuilder.Entity("Fireteam.Models.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("GameTypeID");

                    b.Property<string>("Publisher");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.HasIndex("GameTypeID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Fireteam.Models.GamePlatform", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameID");

                    b.Property<int>("PlatformID");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.ToTable("GamePlatform");
                });

            modelBuilder.Entity("Fireteam.Models.GameType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConsoleModelID");

                    b.Property<string>("Description");

                    b.Property<bool>("IsConsoleGame");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("ConsoleModelID");

                    b.ToTable("GameTypes");
                });

            modelBuilder.Entity("Fireteam.Models.Group", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("GroupTypeID");

                    b.Property<bool>("IsHidden");

                    b.Property<bool>("IsInviteOnly");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("GroupTypeID");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Fireteam.Models.GroupActivity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityID");

                    b.Property<int>("GroupID");

                    b.HasKey("ID");

                    b.HasIndex("GroupID");

                    b.ToTable("GroupActivity");
                });

            modelBuilder.Entity("Fireteam.Models.GroupGame", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameID");

                    b.Property<int>("GroupID");

                    b.HasKey("ID");

                    b.HasIndex("GroupID");

                    b.ToTable("GroupGame");
                });

            modelBuilder.Entity("Fireteam.Models.GroupPlatform", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupID");

                    b.Property<int>("PlatformID");

                    b.HasKey("ID");

                    b.HasIndex("GroupID");

                    b.ToTable("GroupPlatform");
                });

            modelBuilder.Entity("Fireteam.Models.GroupType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("GroupTypes");
                });

            modelBuilder.Entity("Fireteam.Models.GroupUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupID");

                    b.Property<bool>("IsGroupLeadership");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("GroupID");

                    b.HasIndex("UserID");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("Fireteam.Models.Platform", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("Fireteam.Models.PlatformAccount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ConsoleModelID");

                    b.Property<string>("GamerTag");

                    b.Property<int>("PlatformID");

                    b.HasKey("ID");

                    b.HasIndex("ConsoleModelID");

                    b.HasIndex("PlatformID");

                    b.ToTable("PlatformAccounts");
                });

            modelBuilder.Entity("Fireteam.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanShowInSearches");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Salt");

                    b.Property<string>("TimeZone");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Fireteam.Models.UserActivity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityID");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("UserActivity");
                });

            modelBuilder.Entity("Fireteam.Models.UserFriends", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanAddToActivities");

                    b.Property<int?>("FriendID");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("FriendID");

                    b.ToTable("UserFriends");
                });

            modelBuilder.Entity("Fireteam.Models.UserGame", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameID");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("UserGame");
                });

            modelBuilder.Entity("Fireteam.Models.UserGroup", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupID");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("UserGroup");
                });

            modelBuilder.Entity("Fireteam.Models.UserPlatform", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PlatformID");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("UserPlatform");
                });

            modelBuilder.Entity("Fireteam.Models.UserPlatformAccount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PlatformAccountID");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("PlatformAccountID");

                    b.HasIndex("UserID");

                    b.ToTable("UserPlatformAccount");
                });

            modelBuilder.Entity("Fireteam.Models.Activity", b =>
                {
                    b.HasOne("Fireteam.Models.ActivityType", "ActivityType")
                        .WithMany()
                        .HasForeignKey("ActivityTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fireteam.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fireteam.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupID");

                    b.HasOne("Fireteam.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.ActivityUser", b =>
                {
                    b.HasOne("Fireteam.Models.Activity")
                        .WithMany("Participants")
                        .HasForeignKey("ActivityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fireteam.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.Game", b =>
                {
                    b.HasOne("Fireteam.Models.GameType", "GameType")
                        .WithMany()
                        .HasForeignKey("GameTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.GamePlatform", b =>
                {
                    b.HasOne("Fireteam.Models.Game")
                        .WithMany("Platforms")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.GameType", b =>
                {
                    b.HasOne("Fireteam.Models.ConsoleModel", "ConsoleModel")
                        .WithMany()
                        .HasForeignKey("ConsoleModelID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.Group", b =>
                {
                    b.HasOne("Fireteam.Models.GroupType", "GroupType")
                        .WithMany()
                        .HasForeignKey("GroupTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.GroupActivity", b =>
                {
                    b.HasOne("Fireteam.Models.Group")
                        .WithMany("Activities")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.GroupGame", b =>
                {
                    b.HasOne("Fireteam.Models.Group")
                        .WithMany("Games")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.GroupPlatform", b =>
                {
                    b.HasOne("Fireteam.Models.Group")
                        .WithMany("Platforms")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.GroupUser", b =>
                {
                    b.HasOne("Fireteam.Models.Group")
                        .WithMany("Members")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fireteam.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.PlatformAccount", b =>
                {
                    b.HasOne("Fireteam.Models.ConsoleModel", "ConsoleModel")
                        .WithMany()
                        .HasForeignKey("ConsoleModelID");

                    b.HasOne("Fireteam.Models.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.UserActivity", b =>
                {
                    b.HasOne("Fireteam.Models.User")
                        .WithMany("Activities")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.UserFriends", b =>
                {
                    b.HasOne("Fireteam.Models.User", "Friend")
                        .WithMany("Friends")
                        .HasForeignKey("FriendID");
                });

            modelBuilder.Entity("Fireteam.Models.UserGame", b =>
                {
                    b.HasOne("Fireteam.Models.User")
                        .WithMany("Games")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.UserGroup", b =>
                {
                    b.HasOne("Fireteam.Models.User")
                        .WithMany("Groups")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.UserPlatform", b =>
                {
                    b.HasOne("Fireteam.Models.User")
                        .WithMany("Platforms")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.UserPlatformAccount", b =>
                {
                    b.HasOne("Fireteam.Models.PlatformAccount", "PlatformAccount")
                        .WithMany()
                        .HasForeignKey("PlatformAccountID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fireteam.Models.User")
                        .WithMany("PlatformAccounts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
