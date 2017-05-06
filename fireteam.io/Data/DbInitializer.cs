using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fireteam.Models;

namespace Fireteam.Data
{
    public static class DbInitializer
    {
        public static void Initialize(FireteamDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return; // Context has already been seeded
            }

            var users = new User[]
            {
                new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "leeeeroy",
                    FirstName = "Leroy",
                    LastName = "Jenkins",
                    CanShowInSearches = true,
                    Email = "leroyjenkins@gmaul.com",
                    Password = "abc1234567890",
                    Salt = "lkajsdlkajsdlkjasd",
                    TimeZone = "America/Chicago",
                    Birthday = DateTime.Parse("6/15/1983").ToUniversalTime(),
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "dmaul",
                    FirstName = "Darth",
                    LastName = "Maul",
                    CanShowInSearches = true,
                    Email = "darkside@msnn.au",
                    Password = "abc1234567890",
                    Salt = "lkajsdlkajsdlkjasd",
                    TimeZone = "America/Los_Angeles",
                    Birthday = DateTime.Parse("9/02/1972").ToUniversalTime(),
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "kbecks",
                    FirstName = "Kate",
                    LastName = "Beckinsale",
                    CanShowInSearches = false,
                    Email = "kbecks@mybase.com",
                    Password = "abc1234567890",
                    Salt = "lkajsdlkajsdlkjasd",
                    TimeZone = "America/New_York",
                    Birthday = DateTime.Parse("8/06/1973").ToUniversalTime(),
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                }
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            var userFriends = new UserFriend[]
            {
                new UserFriend(){ ID = 1, UserID = Guid.NewGuid().ToString(), FriendID = Guid.NewGuid().ToString(), CanAddToActivities = true, Created = DateTime.Now.ToUniversalTime(), IsDeleted = false },
                new UserFriend(){ ID = 2, UserID = Guid.NewGuid().ToString(), FriendID = Guid.NewGuid().ToString(), CanAddToActivities = false, Created = DateTime.Now.ToUniversalTime(), IsDeleted = false },
                new UserFriend(){ ID = 3, UserID = Guid.NewGuid().ToString(), FriendID = Guid.NewGuid().ToString(), CanAddToActivities = true, Created = DateTime.Now.ToUniversalTime(), IsDeleted = false },
                new UserFriend(){ ID = 4, UserID = Guid.NewGuid().ToString(), FriendID = Guid.NewGuid().ToString(), CanAddToActivities = true, Created = DateTime.Now.ToUniversalTime(), IsDeleted = false }
            };

            foreach (var userFriend in userFriends)
            {
                context.UserFriends.Add(userFriend);
            }
            context.SaveChanges();


            context.SaveChanges();

            var consoleModels = new ConsoleModel[]
            {
                new ConsoleModel()
                {
                    ID = 1,
                    Name = "Playstation 4",
                    Manufacturer = "Sony",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new ConsoleModel()
                {
                    ID = 2,
                    Name = "Playstation 3",
                    Manufacturer = "Sony",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new ConsoleModel()
                {
                    ID = 3,
                    Name = "PS Vita",
                    Manufacturer = "Sony",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new ConsoleModel()
                {
                    ID = 4,
                    Name = "XBox 360",
                    Manufacturer = "Microsoft",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new ConsoleModel()
                {
                    ID = 5,
                    Name = "XBox One",
                    Manufacturer = "Microsoft",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new ConsoleModel()
                {
                    ID = 6,
                    Name = "Wii",
                    Manufacturer = "Nintendo",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new ConsoleModel()
                {
                    ID = 7,
                    Name = "Wii U",
                    Manufacturer = "Nintendo",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new ConsoleModel()
                {
                    ID = 8,
                    Name = "Switch",
                    Manufacturer = "Nintendo",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new ConsoleModel()
                {
                    ID = 9,
                    Name = "DS/DSXL/3DS/2DS",
                    Manufacturer = "Nintendo",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                }
            };

            foreach (var consoleModel in consoleModels)
            {
                context.ConsoleModels.Add(consoleModel);
            }
            context.SaveChanges();

            var groupTypes = new GroupType[]
            {
                new GroupType()
                {
                    ID = 1,
                    Name = "Clan",
                    Description = "A group of team mates with a loose but solid leadership structure",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new GroupType()
                {
                    ID = 2,
                    Name = "Guild",
                    Description =
                        "A group of team mates with a common set of skills that often teach or train newcomers",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new GroupType()
                {
                    ID = 3,
                    Name = "Friends",
                    Description = "A group of friends that enjoy playing games together",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                }
            };

            foreach (var groupType in groupTypes)
            {
                context.GroupTypes.Add(groupType);
            }
            context.SaveChanges();

            var groups = new Group[]
            {
                new Group()
                {
                    ID = 1,
                    Name = "Master Blasters",
                    Description = "Two men enter, one man leaves...",
                    GroupTypeID = 1,
                    IsHidden = false,
                    IsInviteOnly = true,
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new Group()
                {
                    ID = 2,
                    Name = "All_the_victories",
                    Description =
                        "A dedicated guild of PvP players who seek to hone their craft and help others learn it as well",
                    GroupTypeID = 2,
                    IsHidden = false,
                    IsInviteOnly = false,
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new Group()
                {
                    ID = 3,
                    Name = "Colpeck Game Night Friends",
                    Description =
                        "A group of friends that meet at the Colpecks to play silly games and get a little drunk",
                    GroupTypeID = 3,
                    IsHidden = false,
                    IsInviteOnly = true,
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new Group()
                {
                    ID = 4,
                    Name = "Death Dealers",
                    Description =
                        "We wage a war that has raged on for over a thousand years.  Only Vampires need apply.",
                    GroupTypeID = 1,
                    IsHidden = false,
                    IsInviteOnly = true,
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                }
            };

            foreach (var group in groups)
            {
                context.Groups.Add(group);
            }
            context.SaveChanges();

            var userGroups = new UserGroup[]
            {
                new UserGroup()
                {
                    ID = 1,
                    GroupID = 1,
                    UserID = Guid.NewGuid().ToString(),
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new UserGroup()
                {
                    ID = 2,
                    GroupID = 2,
                    UserID = Guid.NewGuid().ToString(),
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new UserGroup()
                {
                    ID = 3,
                    GroupID = 2,
                    UserID = Guid.NewGuid().ToString(),
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new UserGroup()
                {
                    ID = 4,
                    GroupID = 3,
                    UserID = Guid.NewGuid().ToString(),
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                }
            };

            foreach (var userGroup in userGroups)
            {
                context.UserGroups.Add(userGroup);
            }
            context.SaveChanges();

            var groupUsers = new GroupUser[]
            {
                new GroupUser(){ ID = 1, GroupID = 4, UserID = Guid.NewGuid().ToString(), IsDeleted = false, IsGroupLeadership = true, Created = DateTime.Now.ToUniversalTime() },
                new GroupUser(){ ID = 2, GroupID = 1, UserID = Guid.NewGuid().ToString(), IsDeleted = false, IsGroupLeadership = true, Created = DateTime.Now.ToUniversalTime() },
                new GroupUser(){ ID = 3, GroupID = 2, UserID = Guid.NewGuid().ToString(), IsDeleted = false, IsGroupLeadership = true, Created = DateTime.Now.ToUniversalTime() },
                new GroupUser(){ ID = 4, GroupID = 2, UserID = Guid.NewGuid().ToString(), IsDeleted = false, IsGroupLeadership = false, Created = DateTime.Now.ToUniversalTime() }
            };

            foreach (var groupUser in groupUsers)
            {
                context.GroupUsers.Add(groupUser);
            }
            context.SaveChanges();

            var activityTypes = new ActivityType[]
            {
                new ActivityType()
                {
                    ID = 1,
                    Name = "Mission",
                    Description = "An in-game mission requring multi-player participation",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new ActivityType()
                {
                    ID = 2,
                    Name = "Quest",
                    Description = "A multi-part quest line that encompasses several missions",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new ActivityType()
                {
                    ID = 3,
                    Name = "Raid / Multi-player instance",
                    Description =
                        "An activity that requires specific fireteam composition and planning, usually granting end-game awards",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new ActivityType()
                {
                    ID = 4,
                    Name = "Player vs Player (PVP)",
                    Description =
                        "PvP activities like \"Death Matches\" as well as objective based activities like \"Capture the Flag\"",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                }
            };

            foreach (var activityType in activityTypes)
            {
                context.ActivityTypes.Add(activityType);
            }

            context.SaveChanges();

            var gameTypes = new GameType[]
            {
                new GameType()
                {
                    ID = 1,
                    Name = "Multiplayer FPS",
                    Description = "A multiplayer online first-person shooter",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new GameType()
                {
                    ID = 2,
                    Name = "PvP Arena",
                    Description = "A game that pits teams of players against each other who then battle for supremacy",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                }
            };

            foreach (var gameType in gameTypes)
            {
                context.GameTypes.Add(gameType);
            }
            context.SaveChanges();

            var games = new Game[]
            {
                new Game()
                {
                    ID = 1,
                    Title = "Destiny",
                    Description =
                        "Guardians, the last hope of the light, battle darkness in and around the last city on Earth.",
                    GameTypeID = 1,
                    Publisher = "Activision",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new Game()
                {
                    ID = 2,
                    Title = "Overwatch",
                    Description =
                        "In a time of global crisis, an international task force of heroes banded together to restore peace to a war-torn world: OVERWATCH.",
                    GameTypeID = 1,
                    Publisher = "Blizzard",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new Game()
                {
                    ID = 3,
                    Title = "Mass Effect: Andromeda",
                    Description =
                        "Chart your own course in a dangerous new galaxy. Unravel the mysteries of the Andromeda galaxy as you discover rich, alien worlds in the search for humanity's new home",
                    GameTypeID = 1,
                    Publisher = "Electronic Arts",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                }
            };

            foreach (var game in games)
            {
                context.Games.Add(game);
            }
            context.SaveChanges();

            var platforms = new Platform[]
            {
                new Platform()
                {
                    ID = 1,
                    Name = "Playstation",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new Platform()
                {
                    ID = 2,
                    Name = "XBox",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new Platform()
                {
                    ID = 3,
                    Name = "Nintendo",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new Platform()
                {
                    ID = 4,
                    Name = "PC",
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                }
            };

            foreach (var platform in platforms)
            {
                context.Platforms.Add(platform);
            }
            context.SaveChanges();

            var gamePlatforms = new GamePlatform[]
            {
                new GamePlatform(){ ID = 1, GameID = 1, PlatformID = 1, Created = DateTime.Now.ToUniversalTime(), IsDeleted = false},
                new GamePlatform(){ ID = 2, GameID = 1, PlatformID = 2, Created = DateTime.Now.ToUniversalTime(), IsDeleted = false},
                new GamePlatform(){ ID = 3, GameID = 1, PlatformID = 4, Created = DateTime.Now.ToUniversalTime(), IsDeleted = false}
            };

            foreach (var gamePlatform in gamePlatforms)
            {
                context.GamePlatforms.Add(gamePlatform);
            }
            context.SaveChanges();

            var platformAccounts = new PlatformAccount[]
            {
                new PlatformAccount(){ ID = 1, ConsoleModelID = 1, UserID = Guid.NewGuid().ToString(), PlatformID = 1, GamerTag = "selene", Created = DateTime.Now.ToUniversalTime(), IsDeleted = false},
                new PlatformAccount(){ ID = 2, ConsoleModelID = 2, UserID = Guid.NewGuid().ToString(), PlatformID = 1, GamerTag = "selene", Created = DateTime.Now.ToUniversalTime(), IsDeleted = false},
                new PlatformAccount(){ ID = 3, ConsoleModelID = 3, UserID = Guid.NewGuid().ToString(), PlatformID = 1, GamerTag = "selene", Created = DateTime.Now.ToUniversalTime(), IsDeleted = false},
                new PlatformAccount(){ ID = 4, ConsoleModelID = 4, UserID = Guid.NewGuid().ToString(), PlatformID = 2, GamerTag = "XxDarthDudexX", Created = DateTime.Now.ToUniversalTime(), IsDeleted = false},
                new PlatformAccount(){ ID = 5, UserID = Guid.NewGuid().ToString(), PlatformID = 4, GamerTag = "lroy_JEENKINS", Created = DateTime.Now.ToUniversalTime(), IsDeleted = false }
            };

            foreach (var platformAccount in platformAccounts)
            {
                context.PlatformAccounts.Add(platformAccount);
            }
            context.SaveChanges();

            var activities = new Activity[]
            {
                new Activity()
                {
                    ID = 1,
                    ActivityTypeID = 1,
                    AvailableSlots = 2,
                    Description = "Black Spindle mission.  Come have a chill run and get things done!  Looking for a good team to get through this.",
                    Duration = "00:02:00",
                    GameID = 1,
                    UserID = Guid.NewGuid().ToString(),
                    Requirements = "Must have Y4 Ice Breaker... just cuz.",
                    TimeZone = "America/Chicago",
                    StartTime = DateTime.Now.AddDays(14).ToUniversalTime(),
                    IsHidden = false,
                    IsInviteOnly = false,
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new Activity()
                {
                    ID = 2,
                    ActivityTypeID = 2,
                    AvailableSlots = 2,
                    Description = "Trying to get this stupid exotic quest done.  Need two to run some strikes with.",
                    Duration = "00:01:30",
                    GameID = 1,
                    UserID = Guid.NewGuid().ToString(),
                    Requirements = "Need a Hunter and a Warlock.  I'll bring my Titan",
                    TimeZone = "America/Los_Angeles",
                    StartTime = DateTime.Now.AddDays(21).ToUniversalTime(),
                    IsHidden = false,
                    IsInviteOnly = false,
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new Activity()
                {
                    ID = 3,
                    ActivityTypeID = 1,
                    AvailableSlots = 5,
                    Description = "Private raid with 'Selene' to expterminate these Lycans.. I mean Fallen... once and for all.",
                    Duration = "00:04:00",
                    GameID = 1,
                    UserID = Guid.NewGuid().ToString(),
                    GroupID = 4,
                    Requirements = "Request to join.  Your credentials will be checked at the door... by force, if necessary",
                    TimeZone = "America/New_York",
                    StartTime = DateTime.Now.AddDays(28).ToUniversalTime(),
                    IsHidden = false,
                    IsInviteOnly = true,
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                }
            };

            foreach (var activity in activities)
            {
                context.Activities.Add(activity);
            }
            context.SaveChanges();


            var userGames = new UserGame[]
            {
                new UserGame(){ ID = 1, UserID = Guid.NewGuid().ToString(), GameID = 1, Created = DateTime.Now.ToUniversalTime(), IsDeleted = false},
                new UserGame(){ ID = 2, UserID = Guid.NewGuid().ToString(), GameID = 1, Created = DateTime.Now.ToUniversalTime(), IsDeleted = false},
                new UserGame(){ ID = 3, UserID = Guid.NewGuid().ToString(), GameID = 1, Created = DateTime.Now.ToUniversalTime(), IsDeleted = false}, 
            };

            foreach (var userGame in userGames)
            {
                context.UserGames.Add(userGame);
            }
            context.SaveChanges();


            var activityUsers = new ActivityUser[]
            {
                new ActivityUser()
                {
                    ID = 1,
                    ActivityID = 1,
                    Created = DateTime.Now.ToUniversalTime(),
                    HasBeenBooted = false,
                    IsDeleted = false,
                    IsTentative = false,
                    ReasonForBoot = (int) BootReasons.None,
                    UserID = Guid.NewGuid().ToString()
                },
                new ActivityUser()
                {
                    ID = 2,
                    ActivityID = 1,
                    Created = DateTime.Now.ToUniversalTime(),
                    HasBeenBooted = true,
                    IsDeleted = false,
                    IsTentative = false,
                    ReasonForBoot = (int) BootReasons.Unfriendly,
                    UserID = Guid.NewGuid().ToString()
                },
                new ActivityUser()
                {
                    ID = 3,
                    ActivityID = 1,
                    Created = DateTime.Now.ToUniversalTime(),
                    HasBeenBooted = false,
                    IsDeleted = false,
                    IsTentative = false,
                    ReasonForBoot = (int) BootReasons.None,
                    UserID = Guid.NewGuid().ToString()
                }
            };

            foreach (var activityUser in activityUsers)
            {
                context.ActivityUsers.Add(activityUser);
            }
            context.SaveChanges();

            var blockedUsers = new BlockedUser[]
            {
                new BlockedUser()
                {
                    ID = 1,
                    ActivityID = 1,
                    UserID = Guid.NewGuid().ToString(),
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new BlockedUser()
                {
                    ID = 2,
                    BlockingUserID = Guid.NewGuid().ToString(),
                    UserID = Guid.NewGuid().ToString(),
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                },
                new BlockedUser()
                {
                    ID = 3,
                    BlockingGroupID = 1,
                    UserID = Guid.NewGuid().ToString(),
                    Created = DateTime.Now.ToUniversalTime(),
                    IsDeleted = false
                }
            };

            foreach (var blockedUser in blockedUsers)
            {
                context.BlockedUsers.Add(blockedUser);
            }
            context.SaveChanges();

            var gameConsoleModels = new GameConsoleModel[]
            {
                new GameConsoleModel() { ID = 1, GameID = 1, ConsoleModelID  = 1, Created = DateTime.Now.ToUniversalTime(), IsDeleted = false},
                new GameConsoleModel() { ID = 2, GameID = 1, ConsoleModelID  = 2, Created = DateTime.Now.ToUniversalTime(), IsDeleted = false },
                new GameConsoleModel() { ID = 3, GameID = 1, ConsoleModelID  = 4, Created = DateTime.Now.ToUniversalTime(), IsDeleted = false }
            };

            foreach (var gameConsoleModel in gameConsoleModels)
            {
                context.GameConsoleModels.Add(gameConsoleModel);
            }
            context.SaveChanges();
        }
    }
}
