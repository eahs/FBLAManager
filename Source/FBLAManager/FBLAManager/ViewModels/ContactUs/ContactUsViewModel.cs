using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FBLAManager.Models.ContactUs;
using Syncfusion.SfMaps.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

using FBLAManager.Views.ContactUs;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Collections.Generic;
using Microsoft.AppCenter.Crashes;

namespace FBLAManager.ViewModels.ContactUs
{
    /// <summary>
    /// ViewModel for contact us page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ContactUsViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<MapMarker> customMarkers;

        private Point geoCoordinate;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactUsViewModel" /> class.
        /// </summary>
        public ContactUsViewModel()
        {
            this.CustomMarkers = new ObservableCollection<MapMarker>();
            this.GetPinLocation();

            
        }

        #endregion   

        #region Event

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Commands


        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the CustomMarkers collection.
        /// </summary>
        public ObservableCollection<MapMarker> CustomMarkers
        {
            get
            {
                return this.customMarkers;
            }

            set
            {
                this.customMarkers = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the geo coordinate.
        /// </summary>
        public Point GeoCoordinate
        {
            get
            {
                return this.geoCoordinate;
            }

            set
            {
                this.geoCoordinate = value;
                this.OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

            /// <summary>
            /// This method is for getting the pin location detail.
            /// </summary>
            private void GetPinLocation()
        {
            this.CustomMarkers.Add(
                new LocationMarker
                {
                    PinImage = "Pin.png",
                    Header = "EAHS FBLA",
                    Address = "2601 William Penn Hwy, Easton, PA 18045",
                    EmailId = "kleinb@eastonsd.org",
                    PhoneNumber = "610-250-2400",
                    CloseImage = "Close.png",
                    Latitude = "40.682817", 
                    Longitude = "-75.252373"
                });

            foreach (var marker in this.CustomMarkers)
            {
                this.GeoCoordinate = new Point(Convert.ToDouble(marker.Latitude), Convert.ToDouble(marker.Longitude));
            }
        }

        #endregion
    }
}
