using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FBLAManager.Models
{
    public class Member : INotifyPropertyChanged
    {
        private int memberid;
        private string firstname, lastname, gender = "Female", address, city, state = "PA", zipcode, recruitedby, email, phone, password, grade = "11" ;

        public int MemberId { 
            get { return memberid; }
            set { memberid = value; OnPropertyChanged("MemberId"); } 
        }

        public string FirstName { 
            get { return firstname; }
            set { firstname = value; OnPropertyChanged("FirstName"); }
        }

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; OnPropertyChanged("LastName"); }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; OnPropertyChanged("Gender"); }
        }

        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged("Address"); }
        }

        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged("City"); }
        }

        public string State
        {
            get { return state; }
            set { state = value; OnPropertyChanged("State"); }
        }

        public string ZipCode
        {
            get { return zipcode; }
            set { zipcode = value; OnPropertyChanged("ZipCode"); }
        }

        public string Grade
        {
            get { return grade; }
            set { grade = value; OnPropertyChanged("Grade"); }
        }

        public string RecruitedBy
        {
            get { return recruitedby; }
            set { recruitedby = value; OnPropertyChanged("RecruitedBy"); }
        }

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; OnPropertyChanged("Phone"); }
        }

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
        }
    }
}
