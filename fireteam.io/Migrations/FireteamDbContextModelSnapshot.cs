﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Fireteam.Data;

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

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<string>("Duration");

                    b.Property<int>("GameID");

                    b.Property<int?>("GroupID");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsHidden");

                    b.Property<bool>("IsInviteOnly");

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("Requirements");

                    b.Property<int>("ReservedSlots");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("TimeZone");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("ActivityTypeID");

                    b.HasIndex("GameID");

                    b.HasIndex("GroupID");

                    b.HasIndex("UserID");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Fireteam.Models.ActivityType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("ActivityTypes");
                });

            modelBuilder.Entity("Fireteam.Models.ActivityUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityID");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("HasBeenBooted");

                    b.Property<bool>("IsAlternate");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsTentative");

                    b.Property<DateTime?>("LastModified");

                    b.Property<int>("ReasonForBoot");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("ActivityID");

                    b.HasIndex("UserID");

                    b.ToTable("ActivityUsers");
                });

            modelBuilder.Entity("Fireteam.Models.BlockedUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ActivityID");

                    b.Property<int?>("BlockingGroupID");

                    b.Property<int?>("BlockingUserID");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModified");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("ActivityID");

                    b.HasIndex("BlockingGroupID");

                    b.HasIndex("BlockingUserID");

                    b.HasIndex("UserID");

                    b.ToTable("BlockedUsers");
                });

            modelBuilder.Entity("Fireteam.Models.ConsoleModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int?>("GameID");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.ToTable("ConsoleModels");
                });

            modelBuilder.Entity("Fireteam.Models.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<int>("GameTypeID");

                    b.Property<bool>("IsConsoleGame");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("Publisher");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.HasIndex("GameTypeID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Fireteam.Models.GameConsoleModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConsoleModelID");

                    b.Property<DateTime>("Created");

                    b.Property<int>("GameID");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModified");

                    b.HasKey("ID");

                    b.HasIndex("ConsoleModelID");

                    b.HasIndex("GameID");

                    b.ToTable("GameConsoleModels");
                });

            modelBuilder.Entity("Fireteam.Models.GamePlatform", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int>("GameID");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModified");

                    b.Property<int>("PlatformID");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.HasIndex("PlatformID");

                    b.ToTable("GamePlatforms");
                });

            modelBuilder.Entity("Fireteam.Models.GameType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("GameTypes");
                });

            modelBuilder.Entity("Fireteam.Models.Group", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<int>("GroupTypeID");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsHidden");

                    b.Property<bool>("IsInviteOnly");

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("GroupTypeID");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Fireteam.Models.GroupType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("GroupTypes");
                });

            modelBuilder.Entity("Fireteam.Models.GroupUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int>("GroupID");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsGroupLeadership");

                    b.Property<DateTime?>("LastModified");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("GroupID");

                    b.HasIndex("UserID");

                    b.ToTable("GroupUsers");
                });

            modelBuilder.Entity("Fireteam.Models.Platform", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("Fireteam.Models.PlatformAccount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ConsoleModelID");

                    b.Property<DateTime>("Created");

                    b.Property<string>("GamerTag");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModified");

                    b.Property<int>("PlatformID");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("ConsoleModelID");

                    b.HasIndex("PlatformID");

                    b.HasIndex("UserID");

                    b.ToTable("PlatformAccounts");
                });

            modelBuilder.Entity("Fireteam.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<bool>("CanShowInSearches");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Salt");

                    b.Property<string>("TimeZone");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Fireteam.Models.UserFriend", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanAddToActivities");

                    b.Property<DateTime>("Created");

                    b.Property<int>("FriendID");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModified");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("FriendID");

                    b.HasIndex("UserID");

                    b.ToTable("UserFriends");
                });

            modelBuilder.Entity("Fireteam.Models.UserGame", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int>("GameID");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModified");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.HasIndex("UserID");

                    b.ToTable("UserGames");
                });

            modelBuilder.Entity("Fireteam.Models.UserGroup", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int>("GroupID");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModified");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("GroupID");

                    b.HasIndex("UserID");

                    b.ToTable("UserGroups");
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

                    b.HasOne("Fireteam.Models.User", "Organizer")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.ActivityUser", b =>
                {
                    b.HasOne("Fireteam.Models.Activity", "Activity")
                        .WithMany("Participants")
                        .HasForeignKey("ActivityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fireteam.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.BlockedUser", b =>
                {
                    b.HasOne("Fireteam.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityID");

                    b.HasOne("Fireteam.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("BlockingGroupID");

                    b.HasOne("Fireteam.Models.User", "BlockingUser")
                        .WithMany()
                        .HasForeignKey("BlockingUserID");

                    b.HasOne("Fireteam.Models.User", "UserBeingBlocked")
                        .WithMany("BlockedUsers")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.ConsoleModel", b =>
                {
                    b.HasOne("Fireteam.Models.Game")
                        .WithMany("ConsoleModels")
                        .HasForeignKey("GameID");
                });

            modelBuilder.Entity("Fireteam.Models.Game", b =>
                {
                    b.HasOne("Fireteam.Models.GameType", "GameType")
                        .WithMany()
                        .HasForeignKey("GameTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.GameConsoleModel", b =>
                {
                    b.HasOne("Fireteam.Models.ConsoleModel", "ConsoleModel")
                        .WithMany()
                        .HasForeignKey("ConsoleModelID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fireteam.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.GamePlatform", b =>
                {
                    b.HasOne("Fireteam.Models.Game", "Game")
                        .WithMany("Platforms")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fireteam.Models.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.Group", b =>
                {
                    b.HasOne("Fireteam.Models.GroupType", "GroupType")
                        .WithMany()
                        .HasForeignKey("GroupTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.GroupUser", b =>
                {
                    b.HasOne("Fireteam.Models.Group", "Group")
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

                    b.HasOne("Fireteam.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.UserFriend", b =>
                {
                    b.HasOne("Fireteam.Models.User", "Friend")
                        .WithMany()
                        .HasForeignKey("FriendID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fireteam.Models.User", "FriendedUser")
                        .WithMany("Friends")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.UserGame", b =>
                {
                    b.HasOne("Fireteam.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fireteam.Models.User", "User")
                        .WithMany("Games")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fireteam.Models.UserGroup", b =>
                {
                    b.HasOne("Fireteam.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fireteam.Models.User", "User")
                        .WithMany("Groups")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
