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
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ConsoleModels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Manufacturer = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsoleModels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GroupTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true),
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
                    CanShowInSearches = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
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
                name: "GameTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ConsoleModelID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsConsoleGame = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GameTypes_ConsoleModels_ConsoleModelID",
                        column: x => x.ConsoleModelID,
                        principalTable: "ConsoleModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true),
                    GroupTypeID = table.Column<int>(nullable: false),
                    IsHidden = table.Column<bool>(nullable: false),
                    IsInviteOnly = table.Column<bool>(nullable: false),
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
                name: "PlatformAccounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ConsoleModelID = table.Column<int>(nullable: true),
                    GamerTag = table.Column<string>(nullable: true),
                    PlatformID = table.Column<int>(nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "UserActivity",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ActivityID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserActivity_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
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
                    FriendID = table.Column<int>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserGame",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    GameID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGame", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserGame_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    GroupID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserGroup_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPlatform",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    PlatformID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPlatform", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserPlatform_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true),
                    GameTypeID = table.Column<int>(nullable: false),
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
                name: "GroupActivity",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ActivityID = table.Column<int>(nullable: false),
                    GroupID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupActivity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GroupActivity_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupGame",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    GameID = table.Column<int>(nullable: false),
                    GroupID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupGame", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GroupGame_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupPlatform",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    GroupID = table.Column<int>(nullable: false),
                    PlatformID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPlatform", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GroupPlatform_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupUser",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    GroupID = table.Column<int>(nullable: false),
                    IsGroupLeadership = table.Column<bool>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GroupUser_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUser_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPlatformAccount",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    PlatformAccountID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPlatformAccount", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserPlatformAccount_PlatformAccounts_PlatformAccountID",
                        column: x => x.PlatformAccountID,
                        principalTable: "PlatformAccounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPlatformAccount_Users_UserID",
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
                    Description = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    GameID = table.Column<int>(nullable: false),
                    GroupID = table.Column<int>(nullable: true),
                    IsHidden = table.Column<bool>(nullable: false),
                    IsInviteOnly = table.Column<bool>(nullable: false),
                    Requirements = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    TimeZone = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
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
                        name: "FK_Activities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlatform",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    GameID = table.Column<int>(nullable: false),
                    PlatformID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatform", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GamePlatform_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityUser",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ActivityID = table.Column<int>(nullable: false),
                    HasBeenBooted = table.Column<bool>(nullable: false),
                    IsTentative = table.Column<bool>(nullable: false),
                    ReasonForBoot = table.Column<bool>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityUser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActivityUser_Activities_ActivityID",
                        column: x => x.ActivityID,
                        principalTable: "Activities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityUser_Users_UserID",
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
                name: "IX_Activities_UserId",
                table: "Activities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityUser_ActivityID",
                table: "ActivityUser",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityUser_UserID",
                table: "ActivityUser",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameTypeID",
                table: "Games",
                column: "GameTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatform_GameID",
                table: "GamePlatform",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_GameTypes_ConsoleModelID",
                table: "GameTypes",
                column: "ConsoleModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GroupTypeID",
                table: "Groups",
                column: "GroupTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupActivity_GroupID",
                table: "GroupActivity",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupGame_GroupID",
                table: "GroupGame",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupPlatform_GroupID",
                table: "GroupPlatform",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_GroupID",
                table: "GroupUser",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_UserID",
                table: "GroupUser",
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
                name: "IX_UserActivity_UserID",
                table: "UserActivity",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_FriendID",
                table: "UserFriends",
                column: "FriendID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGame_UserID",
                table: "UserGame",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_UserID",
                table: "UserGroup",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlatform_UserID",
                table: "UserPlatform",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlatformAccount_PlatformAccountID",
                table: "UserPlatformAccount",
                column: "PlatformAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlatformAccount_UserID",
                table: "UserPlatformAccount",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityUser");

            migrationBuilder.DropTable(
                name: "GamePlatform");

            migrationBuilder.DropTable(
                name: "GroupActivity");

            migrationBuilder.DropTable(
                name: "GroupGame");

            migrationBuilder.DropTable(
                name: "GroupPlatform");

            migrationBuilder.DropTable(
                name: "GroupUser");

            migrationBuilder.DropTable(
                name: "UserActivity");

            migrationBuilder.DropTable(
                name: "UserFriends");

            migrationBuilder.DropTable(
                name: "UserGame");

            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropTable(
                name: "UserPlatform");

            migrationBuilder.DropTable(
                name: "UserPlatformAccount");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "PlatformAccounts");

            migrationBuilder.DropTable(
                name: "ActivityTypes");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "GameTypes");

            migrationBuilder.DropTable(
                name: "GroupTypes");

            migrationBuilder.DropTable(
                name: "ConsoleModels");
        }
    }
}
