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
                        Name = "Samantha",
                        Position = "Chief Axe Wielder"
                    }
                );
        }

        public ObservableCollection<Officer> Officers { get; set; }
    }
}
