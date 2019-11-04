using FBLAManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FBLAManager.ViewModels
{
    public class NationalOfficerViewModel : BaseViewModel
    {
        public NationalOfficerViewModel ()
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
            
            Officers.Add(
                    new Officer
                    {
                        Name = "Margo Boyd",
                        Position = "FBLA National Secretary",
                        Image = "MargoBoyd.jpg",
                        WebsiteLink = "https://www.fbla-pbl.org/fbla/officers/secretary/"
                    }
                );

            Officers.Add(
                    new Officer
                    {
                        Name = "Vivian Clarke",
                        Position = "FBLA National Treasurer",
                        Image = "VivianClarke.jpg",
                        WebsiteLink = "https://www.fbla-pbl.org/fbla/officers/treasurer/"
                    }
                );

            Officers.Add(
                    new Officer
                    {
                        Name = "Elizabeth Howell",
                        Position = "FBLA National Parliamentarian",
                        Image = "ElizabethHowell.jpg",
                        WebsiteLink = "https://www.fbla-pbl.org/fbla/officers/parliamentarian/"
                    }
                );

            Officers.Add(
                    new Officer
                    {
                        Name = "Drew Lojewski",
                        Position = "FBLA Eastern Region Vice President",
                        Image = "DrewLojewski.jpg",
                        WebsiteLink = "https://www.fbla-pbl.org/fbla/officers/eastern-region-vp/"
                    }
                );

            Officers.Add(
                    new Officer
                    {
                        Name = "Drake Vorderstrasse",
                        Position = "FBLA Mountain Plains Region Vice President",
                        Image = " DrakeVorderstrasse.jpg",
                        WebsiteLink = "https://www.fbla-pbl.org/fbla/officers/mountain-plains-region-vp/"
                    }
                );

            Officers.Add(
                    new Officer
                    {
                        Name = "Ben Morrison",
                        Position = "FBLA North Central Region Vice President",
                        Image = "BenMorrison.jpg",
                        WebsiteLink = "https://www.fbla-pbl.org/fbla/officers/north-central-region-vp/"
                    }
                );

            Officers.Add(
                    new Officer
                    {
                        Name = "Ethan Ghozali",
                        Position = "FBLA Southern Region Vice President",
                        Image = "EthanGhozali.jpg",
                        WebsiteLink = "https://www.fbla-pbl.org/fbla/officers/southern-region-vp/"
                    }
                );

            Officers.Add(
                    new Officer
                    {
                        Name = "Haneol (John) Lee",
                        Position = "FBLA Western Region Vice President",
                        Image = "HaneolLee.jpg",
                        WebsiteLink = "https://www.fbla-pbl.org/fbla/officers/western-region-vp/"
                    }
                );
        }

        public ObservableCollection<Officer> Officers { get; set; }
    }
}
