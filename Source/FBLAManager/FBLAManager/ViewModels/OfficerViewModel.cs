using FBLAManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FBLAManager.ViewModels
{
    public class OfficerViewModel : BaseViewModel
    {
        public OfficerViewModel ()
        {
            Officers = new ObservableCollection<Officer>();
            Officers.Add(
                    new Officer
                    {
                        Name = "Travis Johnson",
                        Position = "FBLA National President",
                        Image = "TravisJohnson.jpg",
                        WebsiteLink = "https://www.fbla-pbl.org/fbla/officers/president/"
                    }
                );
            /*
            Officers.Add(
                    new Officer
                    {
                        Name = " ",
                        Position = "FBLA National ",
                        Image = " .jpg",
                        WebsiteLink = " "
                    }
                );
                */
        }

        public ObservableCollection<Officer> Officers { get; set; }
    }
}
