using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FBLAManager.Models.AboutUs;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System;

namespace FBLAManager.ViewModels.AboutUs
{
    /// <summary>
    /// ViewModel of AboutUs templates.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class AboutUsViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string productDescription;

        private string productVersion;

        private string productIcon;

        private string cardsTopImage;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="T:FBLAManager.ViewModels.AboutUs.AboutUsViewModel"/> class.
        /// </summary>
        public AboutUsViewModel()
        {
            this.productDescription =
                "FBLA-PBL inspires and prepares students to become community-minded business leaders in a global society through relevant career preparation and leadership experiences.";
            this.productIcon = App.BaseImageUrl + "FBLAlogo.png";
            this.productVersion = "1.0";
            this.cardsTopImage = App.BaseImageUrl + "FBLAlogo.png";

            this.EmployeeDetails = new ObservableCollection<AboutUsModel>
            {
                new AboutUsModel
                {
                    WebsiteName = "Home Page",
                    Image = App.BaseImageUrl + "MargoBoyd.jpg",
                    Link = "https://www.fbla-pbl.org/"
                },
                new AboutUsModel
                {
                    WebsiteName = "About FBLA",
                    Image = App.BaseImageUrl + "tab_about.png",
                    Link = "https://www.fbla-pbl.org/fbla/"
                },
                new AboutUsModel
                {
                    WebsiteName = "About FBLA-PBL",
                    Image = App.BaseImageUrl + "tab_about.png",
                    Link = "https://www.fbla-pbl.org/about/"
                },
                
            };

            this.ItemSelectedCommand = new Command(this.ItemSelected);
        }

        #endregion

        #region Event handler

        /// <summary>
        /// Occurs when the property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the top image source of the About us with cards view.
        /// </summary>
        /// <value>Image source location.</value>
        public string CardsTopImage
        {
            get
            {
                return this.cardsTopImage;
            }

            set
            {
                this.cardsTopImage = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the description of a product or a company.
        /// </summary>
        /// <value>The product description.</value>
        public string ProductDescription
        {
            get
            {
                return this.productDescription;
            }

            set
            {
                this.productDescription = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the product icon.
        /// </summary>
        /// <value>The product icon.</value>
        public string ProductIcon
        {
            get
            {
                return this.productIcon;
            }

            set
            {
                this.productIcon = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the product version.
        /// </summary>
        /// <value>The product version.</value>
        public string ProductVersion
        {
            get
            {
                return this.productVersion;
            }

            set
            {
                this.productVersion = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the employee details.
        /// </summary>
        /// <value>The employee details.</value>
        public ObservableCollection<AboutUsModel> EmployeeDetails { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        private async void ItemSelected(object selectedItem)
        {
            var model = selectedItem as Syncfusion.ListView.XForms.ItemTappedEventArgs;
            var aboutUsModel = model.ItemData as AboutUsModel;

            await OpenBrowser(new Uri(aboutUsModel.Link));
        }

        public async Task OpenBrowser(Uri uri)
        {
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        #endregion
    }
}
