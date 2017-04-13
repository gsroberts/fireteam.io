﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Fireteam.Common.Models
{
    /// <summary>
    /// Represents a user of the fireteam.io service
    /// </summary>
    public class User
    {
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the user's username for the fireteam.io service
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets this user's email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets this users password
        /// 
        /// This is the salted and hashed version of the users password
        /// The actual value of the password is never stored
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the user's per-user salt
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// Gets or sets the user's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the user's last name / surname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the id of the user's timezone
        /// 
        /// Stores the time zone ID for this user
        /// </summary>
        /// <see cref="TimeZoneInfo"/>
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets a boolean value that represents
        /// whether or not the user will show up in public searches
        /// 
        /// The user will still show up in searches for people who
        /// they are friends with on the fireteam.io service
        /// </summary>
        public bool CanShowInSearches { get; set; }

        /// <summary>
        /// Gets or sets a list of users that this user has blocked from viewing
        /// their activity
        /// 
        /// When a user has been blocked and views an activity that this user is 
        /// signed up for, the blocked user will only see the name Anonymous and
        /// will not be able to click the name to view the user's profile
        /// </summary>
        public ICollection<User> BlockedUsers { get; set; }

        /// <summary>
        /// Gets or sets a list of accounts on a number of platforms that this user
        /// has access to
        /// 
        /// Platform accounts are intended to be unique as only one person can log in
        /// to the account at any given point
        /// </summary>
        public ICollection<PlatformAccount> PlatformAccounts { get; set; }
        
        /// <summary>
        /// Gets or sets a list of this users groups
        /// </summary>
        public ICollection<Group> Groups { get; set; }

        /// <summary>
        /// Gets or sets a list of this user's games
        /// </summary>
        public ICollection<Game> Games { get; set; }

        /// <summary>
        /// Gets or sets a list of the platforms this user plays on
        /// </summary>
        public ICollection<Platform> Platforms { get; set; }

        /// <summary>
        /// Gets or sets a list of this user's activities
        /// </summary>
        public ICollection<Activity> Activities { get; set; }

        /// <summary>
        /// Gets or sets a list of this user's friends
        /// </summary>
        public ICollection<User> Friends { get; set; }
    }          
}
