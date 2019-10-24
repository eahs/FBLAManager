using FBLAManager.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FBLAManager.ViewModels.Events
{
    //[QueryProperty("Meeting", "meeting")]
    public class MeetingDetailViewModel : BaseViewModel
    {
        public Meeting Meeting { get; set; }

            /*
        public Meeting Meeting
        {
            set
            {
                BindingContext = Meeting
            }
        } */

        public MeetingDetailViewModel(Meeting meeting = null)
        {
            Title = meeting?.EventName;
            Meeting = meeting;
        }
    }
}
