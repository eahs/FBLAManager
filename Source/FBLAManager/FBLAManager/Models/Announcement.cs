using System;

namespace FBLAManager.Models
{
    /// <summary>
    /// Model for home page announcements.
    /// </summary>
    public class Announcement
    {
        /// <summary>
        /// The title of the announcement.
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// The text of the announcement.
        /// </summary>
        public String Message { get; set; }

        /// <summary>
        /// The person who posted the announcement.
        /// </summary>
        public String Director { get; set; }

        public String ImageURL { get; set; }

        public bool HasImage { get; set; }
    }
}