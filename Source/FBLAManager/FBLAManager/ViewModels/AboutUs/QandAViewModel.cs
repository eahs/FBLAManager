using FBLAManager.Models;
using FBLAManager.Models.AboutUs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FBLAManager.ViewModels.AboutUs
{
    public class QandAViewModel : BaseViewModel
    {
        public QandAViewModel()
        {
            QandAs = new ObservableCollection<QandA>();
            QandAs.Add(
                    new QandA
                    {
                        Question = "What?",
                        Answer = "Yeah"
                    }
                );
        }

        public ObservableCollection<QandA> QandAs { get; set; }
    }
}
