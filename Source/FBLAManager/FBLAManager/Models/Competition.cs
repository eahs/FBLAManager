
namespace FBLAManager.Models
{
    /// <summary>
    /// Model for About us templates.
    /// </summary>
    public class Competition
    {
        /// <summary>
        /// The URL link to the FBLA web page for the competition.
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// The competition subject.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The competition type (test, report, project, presentation, etc).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The competition category (individual, team, or chapter). 
        /// </summary>
        public string Category { get; set; }
    }
}