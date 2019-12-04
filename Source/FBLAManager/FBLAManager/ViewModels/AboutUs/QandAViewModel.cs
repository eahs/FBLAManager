using FBLAManager.Models.AboutUs;
using System.Collections.ObjectModel;

namespace FBLAManager.ViewModels.AboutUs
{
    /// <summary>
    /// ViewModel of Q and A templates.
    /// </summary>
    public class QandAViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance for the <see cref="T:FBLAManager.ViewModels.AboutUs.QandAViewModel"/> class.
        /// </summary>
        public QandAViewModel()
        {
            QandAs = new ObservableCollection<QandA>
            {
                new QandA
                {
                    Question = "What are the official colors of FBLA?",
                    Answer = "The official colors of FBLA are blue and gold."
                },
                new QandA
                {
                    Question = "Who is the founder of FBLA?",
                    Answer = "Hamden L. Forkner founded FBLA in 1937."
                },
                new QandA
                {
                    Question = "What are the Five Regions of FBLA?",
                    Answer = "The Five Regions of FBLA are the Western, Mountain Plains, North Central, Southern and Eastern Regions."
                },
                new QandA
                {
                    Question = "In the absence of the president at a chapter meeting, which officer serves as the presiding officer?",
                    Answer = "The Vice-President."
                },
                new QandA
                {
                    Question = "In the absence of the president and vice-president at a regular meeting, who should call the meeting to order?",
                    Answer = "The Secretary."
                }
            };
        }

        /// <summary>
        /// Gets or sets the Q and As. 
        /// </summary>
        public ObservableCollection<QandA> QandAs { get; set; }
    }
}
