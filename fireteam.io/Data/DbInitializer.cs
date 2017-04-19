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
                    ID = 1,
                    UserName = "leeeeroy",
                    FirstName = "Leroy",
                    LastName = "Jenkins",
                    CanShowInSearches = true,
                    Email = "leroyjenkins@gmaul.com",
                    Password = "abc1234567890",
                    Salt = "lkajsdlkajsdlkjasd",
                    TimeZone = "Central Time"
                    //Birthday = DateTime.Parse("6/15/1983")
                },
                new User()
                {
                    ID = 2,
                    UserName = "dmaul",
                    FirstName = "Darth",
                    LastName = "Maul",
                    CanShowInSearches = true,
                    Email = "darkside@msnn.au",
                    Password = "abc1234567890",
                    Salt = "lkajsdlkajsdlkjasd",
                    TimeZone = "Pacific Time"
                    //Birthday = DateTime.Parse("9/02/1972")
                },
                new User()
                {
                    ID = 3,
                    UserName = "kbecks",
                    FirstName = "Kate",
                    LastName = "Beckinsale",
                    CanShowInSearches = false,
                    Email = "kbecks@mybase.com",
                    Password = "abc1234567890",
                    Salt = "lkajsdlkajsdlkjasd",
                    TimeZone = "Eastern Time"
                    //Birthday = DateTime.Parse("8/06/1973")
                }
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();

            var groupTypes = new GroupType[]
            {
                new GroupType()
                {
                    ID = 1,
                    Name = "Clan",
                    Description = "A group of team mates with a loose but solid leadership structure"
                },
                new GroupType()
                {
                    ID = 2,
                    Name = "Guild",
                    Description = "A group of team mates with a common set of skills that often teach or train newcomers"
                },
                new GroupType()
                {
                    ID = 3,
                    Name = "Friends",
                    Description = "A group of friends that enjoy playing games together"
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
                    IsInviteOnly = true
                },
                new Group()
                {
                    ID = 2,
                    Name = "All_the_victories",
                    Description = "A dedicated guild of PvP players who seek to hone their craft and help others learn it as well",
                    GroupTypeID = 2,
                    IsHidden = false,
                    IsInviteOnly = false
                },
                new Group()
                {
                    ID = 3,
                    Name = "Colpeck Game Night Friends",
                    Description = "A group of friends that meet at the Colpecks to play silly games and get a little drunk",
                    GroupTypeID = 3,
                    IsHidden = false,
                    IsInviteOnly = true
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
                    GroupID = 1,
                    UserID = 2
                },
                new UserGroup()
                {
                    GroupID = 2,
                    UserID = 1
                },
                new UserGroup()
                {
                    GroupID = 2,
                    UserID = 1
                }
            };

            foreach (var userGroup in userGroups)
            {
                context.UserGroups.Add(userGroup);
            }
            context.SaveChanges();

            var activityTypes = new ActivityType[]
            {
                new ActivityType() { ID=1, Name = "Mission", Description = "An in-game mission requring multi-player participation" },
                new ActivityType() { ID=2, Name = "Quest", Description = "A multi-part quest line that encompasses several missions" },
                new ActivityType() { ID=3, Name = "Raid / Multi-player instance", Description = "An activity that requires specific fireteam composition and planning, usually granting end-game awards" },
                new ActivityType() { ID=4, Name = "Player vs Player (PVP)", Description = "PvP activities like \"Death Matches\" as well as objective based activities like \"Capture the Flag\"" }
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
                    Description = "A multiplayer online first-person shooter"
                },
                new GameType()
                {
                    ID = 2,
                    Name = "PvP Arena",
                    Description = "A game that pits teams of players against each other who then battle for supremacy"
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
                    Description = "Guardians, the last hope of the light, battle darkness in and around the last city on Earth.",
                    GameTypeID = 1,
                    Publisher = "Activision"
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
                    Name = "Playstation"
                },
                new Platform()
                {
                    ID = 2,
                    Name = "XBox"
                },
                new Platform()
                {
                    ID = 3,
                    Name ="Nintendo"
                },
                new Platform()
                {
                    ID =4,
                    Name = "PC"
                }
            };

            foreach (var platform in platforms)
            {
                context.Platforms.Add(platform);
            }
            context.SaveChanges();

            var gamePlatforms = new GamePlatform[]
            {
                new GamePlatform()
                {
                    ID = 1,
                    GameID = 1,
                    PlatformID = 1
                },
                new GamePlatform()
                {
                    ID = 2,
                    GameID = 1,
                    PlatformID = 2
                } 
            };

            var activities = new Activity[]
            {
                new Activity()
                {
                    ID = 1,
                    ActivityTypeID = 1, 
                    AvailableSlots = 5,
                    Description = "Black Spindle mission.  Come have a chill run and get things done!  Looking for a good team to get through this.",
                    Duration = "00:02:00",
                    GameID = 1,
                    UserId = 2,
                    Requirements = "Must have Y4 Ice Breaker... just cuz.",
                    TimeZone = "Central Time",
                    StartTime = DateTime.Parse("5/02/2017 01:30:00 PM"),
                    IsHidden = false,
                    IsInviteOnly = false
                }
            };

            foreach (var activity in activities)
            {
                context.Activities.Add(activity);
            }
            context.SaveChanges();
        }
    }
}
