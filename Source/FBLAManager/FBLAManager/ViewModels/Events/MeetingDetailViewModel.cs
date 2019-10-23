using FBLAManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FBLAManager.ViewModels.Events
{
    public class MeetingDetailViewModel : BaseViewModel
    {
        public Meeting Meeting { get; set; }

        public MeetingDetailViewModel(Meeting meeting = null)
        {
            Title = meeting?.EventName;
            Meeting = meeting;
        }
    }
}
