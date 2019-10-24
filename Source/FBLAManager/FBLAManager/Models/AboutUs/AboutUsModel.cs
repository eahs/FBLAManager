using System.ComponentModel;
using Xamarin.Forms.Internals;

namespace FBLAManager.Models.AboutUs
{
    /// <summary>
    /// Model for About us templates.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class AboutUsModel : INotifyPropertyChanged
    {
        #region Fields

        private string websiteName;

        private string link;

        private string image;

        #endregion

        #region EventHandler

        /// <summary>
        /// EventHandler of property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of an employee.
        /// </summary>
        /// <value>The name.</value>
        public string WebsiteName
        {
            get
            {
                return this.websiteName;
            }

            set
            {
                this.websiteName = value;
                this.OnPropertyChanged("WebsiteName");
            }
        }

        /// <summary>
        /// Gets or sets the designation of an employee.
        /// </summary>
        /// <value>The designation.</value>
        public string Link
        {
            get
            {
                return this.link;
            }

            set
            {
                this.link = value;
                this.OnPropertyChanged("Link");
            }
        }

        /// <summary>
        /// Gets or sets the image of an employee.
        /// </summary>
        /// <value>The image.</value>
        public string Image
        {
            get
            {
                return this.image;
            }

            set
            {
                this.image = value;
                this.OnPropertyChanged("Image");
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
