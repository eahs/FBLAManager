
namespace FBLAManager.Models
{
    /// <summary>
    /// Model for FBLA officers.
    /// </summary>
    public class Officer
    {
        /// <summary>
        /// The name of the officer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The officer's title.
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// The officer's image URL.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Whether or not the officer has an image file. 
        /// </summary>
        public bool HasImage
        {
            get
            {
                return Image.Length > 0;
            }
        }

        /// <summary>
        /// The link to the officer's FBLA web page. 
        /// </summary>
        public string WebsiteLink { get; set; }
    }
}
