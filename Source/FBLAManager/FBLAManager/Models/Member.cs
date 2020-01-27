using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FBLAManager.Models
{
    /// <summary>
    /// Model for club members (individual app users). 
    /// </summary>
    public class Member : INotifyPropertyChanged
    {
        #region Fields

        private int memberid;

        private string firstname, lastname, fullname;

        private string description; 

        private string gender = "Female";

        private string address, city, state = "PA", zipcode;

        private string recruitedby;

        private string email, phone;

        private string password;
        
        private string grade = "11" ;

        #endregion

        #region EventHandler

        /// <summary>
        /// EventHandler of property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the member ID. 
        /// </summary>
        public int MemberId { 
            get { return memberid; }
            set { memberid = value; OnPropertyChanged("MemberId"); } 
        }

        /// <summary>
        /// Gets or sets the member's first name. 
        /// </summary>
        public string FirstName { 
            get { return firstname; }
            set { firstname = value; OnPropertyChanged("FirstName"); }
        }

        /// <summary>
        /// Gets or sets the member's last name. 
        /// </summary>
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; OnPropertyChanged("LastName"); }
        }

        /// <summary>
        /// Gets or sets the member's full name. 
        /// </summary>
        public string FullName
        {
            get { return firstname + " " + lastname; }
            set { fullname = value; OnPropertyChanged("FullName"); }
        }

        /// <summary>
        /// Gets or sets the member's description. 
        /// </summary>
        public string Description
        {
            get { return description;  }
            set { description = value; OnPropertyChanged("Description"); }
        }

        /// <summary>
        /// Gets or sets the member's gender. 
        /// </summary>
        public string Gender
        {
            get { return gender; }
            set { gender = value; OnPropertyChanged("Gender"); }
        }

        /// <summary>
        /// Gets or sets the member's address. 
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged("Address"); }
        }

        /// <summary>
        /// Gets or sets the member's city of residence. 
        /// </summary>
        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged("City"); }
        }

        /// <summary>
        /// Gets or sets the member's state of residence. 
        /// </summary>
        public string State
        {
            get { return state; }
            set { state = value; OnPropertyChanged("State"); }
        }

        /// <summary>
        /// Gets or sets the member's zipcode. 
        /// </summary>
        public string ZipCode
        {
            get { return zipcode; }
            set { zipcode = value; OnPropertyChanged("ZipCode"); }
        }

        /// <summary>
        /// Gets or sets the member's grade. 
        /// </summary>
        public string Grade
        {
            get { return grade; }
            set { grade = value; OnPropertyChanged("Grade"); }
        }

        /// <summary>
        /// Gets or sets who recruited the member. 
        /// </summary>
        public string RecruitedBy
        {
            get { return recruitedby; }
            set { recruitedby = value; OnPropertyChanged("RecruitedBy"); }
        }

        /// <summary>
        /// Gets or sets the member's email address. 
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

        /// <summary>
        /// Gets or sets the member's phone number. 
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; OnPropertyChanged("Phone"); }
        }

        /// <summary>
        /// Gets or sets the member's password. 
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
        }

        #endregion
    }
}
