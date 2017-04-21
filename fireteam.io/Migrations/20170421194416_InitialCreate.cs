using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fireteam.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GameTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GroupTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    CanShowInSearches = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    TimeZone = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GameTypeID = table.Column<int>(nullable: false),
                    IsConsoleGame = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Publisher = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Games_GameTypes_GameTypeID",
                        column: x => x.GameTypeID,
                        principalTable: "GameTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GroupTypeID = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsHidden = table.Column<bool>(nullable: false),
                    IsInviteOnly = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Groups_GroupTypes_GroupTypeID",
                        column: x => x.GroupTypeID,
                        principalTable: "GroupTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFriends",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CanAddToActivities = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    FriendID = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFriends", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserFriends_Users_FriendID",
                        column: x => x.FriendID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFriends_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsoleModels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    GameID = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsoleModels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ConsoleModels_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GamePlatforms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    GameID = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    PlatformID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatforms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GamePlatforms_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlatforms_Platforms_PlatformID",
                        column: x => x.PlatformID,
                        principalTable: "Platforms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGames",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    GameID = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGames", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserGames_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGames_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ActivityTypeID = table.Column<int>(nullable: false),
                    AvailableSlots = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    GameID = table.Column<int>(nullable: false),
                    GroupID = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsHidden = table.Column<bool>(nullable: false),
                    IsInviteOnly = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Requirements = table.Column<string>(nullable: true),
                    ReservedSlots = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    TimeZone = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityTypes_ActivityTypeID",
                        column: x => x.ActivityTypeID,
                        principalTable: "ActivityTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupUsers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    GroupID = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsGroupLeadership = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GroupUsers_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUsers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    GroupID = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserGroups_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroups_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameConsoleModels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ConsoleModelID = table.Column<int>(nullable: false),
                    GameID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConsoleModels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GameConsoleModels_ConsoleModels_ConsoleModelID",
                        column: x => x.ConsoleModelID,
                        principalTable: "ConsoleModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameConsoleModels_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformAccounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ConsoleModelID = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    GamerTag = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    PlatformID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformAccounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlatformAccounts_ConsoleModels_ConsoleModelID",
                        column: x => x.ConsoleModelID,
                        principalTable: "ConsoleModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlatformAccounts_Platforms_PlatformID",
                        column: x => x.PlatformID,
                        principalTable: "Platforms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformAccounts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityUsers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ActivityID = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    HasBeenBooted = table.Column<bool>(nullable: false),
                    IsAlternate = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsTentative = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    ReasonForBoot = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActivityUsers_Activities_ActivityID",
                        column: x => x.ActivityID,
                        principalTable: "Activities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityUsers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlockedUsers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ActivityID = table.Column<int>(nullable: true),
                    BlockingGroupID = table.Column<int>(nullable: true),
                    BlockingUserID = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockedUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BlockedUsers_Activities_ActivityID",
                        column: x => x.ActivityID,
                        principalTable: "Activities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlockedUsers_Groups_BlockingGroupID",
                        column: x => x.BlockingGroupID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlockedUsers_Users_BlockingUserID",
                        column: x => x.BlockingUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlockedUsers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityTypeID",
                table: "Activities",
                column: "ActivityTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_GameID",
                table: "Activities",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_GroupID",
                table: "Activities",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserID",
                table: "Activities",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityUsers_ActivityID",
                table: "ActivityUsers",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityUsers_UserID",
                table: "ActivityUsers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_BlockedUsers_ActivityID",
                table: "BlockedUsers",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_BlockedUsers_BlockingGroupID",
                table: "BlockedUsers",
                column: "BlockingGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_BlockedUsers_BlockingUserID",
                table: "BlockedUsers",
                column: "BlockingUserID");

            migrationBuilder.CreateIndex(
                name: "IX_BlockedUsers_UserID",
                table: "BlockedUsers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsoleModels_GameID",
                table: "ConsoleModels",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameTypeID",
                table: "Games",
                column: "GameTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_GameConsoleModels_ConsoleModelID",
                table: "GameConsoleModels",
                column: "ConsoleModelID");

            migrationBuilder.CreateIndex(
                name: "IX_GameConsoleModels_GameID",
                table: "GameConsoleModels",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatforms_GameID",
                table: "GamePlatforms",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatforms_PlatformID",
                table: "GamePlatforms",
                column: "PlatformID");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GroupTypeID",
                table: "Groups",
                column: "GroupTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_GroupID",
                table: "GroupUsers",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_UserID",
                table: "GroupUsers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformAccounts_ConsoleModelID",
                table: "PlatformAccounts",
                column: "ConsoleModelID");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformAccounts_PlatformID",
                table: "PlatformAccounts",
                column: "PlatformID");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformAccounts_UserID",
                table: "PlatformAccounts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_FriendID",
                table: "UserFriends",
                column: "FriendID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_UserID",
                table: "UserFriends",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_GameID",
                table: "UserGames",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_UserID",
                table: "UserGames",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_GroupID",
                table: "UserGroups",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_UserID",
                table: "UserGroups",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityUsers");

            migrationBuilder.DropTable(
                name: "BlockedUsers");

            migrationBuilder.DropTable(
                name: "GameConsoleModels");

            migrationBuilder.DropTable(
                name: "GamePlatforms");

            migrationBuilder.DropTable(
                name: "GroupUsers");

            migrationBuilder.DropTable(
                name: "PlatformAccounts");

            migrationBuilder.DropTable(
                name: "UserFriends");

            migrationBuilder.DropTable(
                name: "UserGames");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "ConsoleModels");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "ActivityTypes");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "GroupTypes");

            migrationBuilder.DropTable(
                name: "GameTypes");
        }
    }
}
