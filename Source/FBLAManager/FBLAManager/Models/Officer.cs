using System;
using System.Collections.Generic;
using System.Text;

namespace FBLAManager.Models
{
    public class Officer
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public bool HasImage
        {
            get
            {
                return Image.Length > 0;
            }
        }
        public string WebsiteLink { get; set; }
    }
}
