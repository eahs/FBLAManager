using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FBLAManager.Models.SocialMedia;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FBLAManager.ViewModels.SocialMedia
{
    /// <summary>
    /// ViewModel of AboutUs templates.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class AboutUsViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string productDescription;

        private string productIcon;

        private string cardsTopImage;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="T:FBLAManager.ViewModels.SocialMedia.AboutUsViewModel"/> class.
        /// </summary>
        public AboutUsViewModel()
        {
            productDescription = "temp";
                
            cardsTopImage =  "Mask.png";

            EmployeeDetails = new ObservableCollection<AboutUsModel>
            {
                new AboutUsModel
                {
                    EmployeeName = "Easton Twitter",
                    Image = App.BaseImageUrl + "TwitterIcon.png",
                    Designation = "https://twitter.com/eafbla?lang=en"
                },
                new AboutUsModel
                {
                    EmployeeName = "Easton Instagram",
                    Image = App.BaseImageUrl +   "ProfileImage10.png",
                    Designation = "https://www.instagram.com/eastonareafbla/?igshid=ipviirou3gr8"
                },
                new AboutUsModel
                {
                    EmployeeName = "PA Twitter",
                    Image = App.BaseImageUrl + "TwitterIcon.png",
                    Designation = "http://https://twitter.com/pafbla?lang=en"
                },
                new AboutUsModel
                {
                    EmployeeName = "PA Instagram",
                    Image = App.BaseImageUrl + "InstagramIcon.png",
                    Designation = "https://www.instagram.com/pennsylvaniafbla/?hl=en"
                }
                
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

            await OpenBrowser(new Uri(aboutUsModel.Designation));
        }

        public async Task OpenBrowser(Uri uri)
        {
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        #endregion
    }
}