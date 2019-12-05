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
                    Question = "What is FBLA's mission statement?",
                    Answer = "Our mission is to bring business and education together in a positive working relationship through innovative leadership and career development programs."
                },
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
                },
                new QandA
                {
                    Question = "What is the parliamentary procedure term to suggest names to be considered for office?",
                    Answer = "\"Nominate.\""
                },
                new QandA
                {
                    Question = "What is the parliamentary term for the discussion of the merits of a motion?",
                    Answer = "\"Debate.\""
                },
                new QandA
                {
                    Question = "In a chapter meeting, if you want to change the wording of a motion that is being discussed, what do you have to do?",
                    Answer = "Make a motion to amend the main motion."
                },
                new QandA
                {
                    Question = "What is the name of the publication that each local chapter receives that contains all the information " +
                    "about FBLA—national constitution and bylaws, national programs, national organization, etc.?",
                    Answer = "The Chapter Management Handbook."
                },
                
            };
        }

        /// <summary>
        /// Gets or sets the Q and As. 
        /// </summary>
        public ObservableCollection<QandA> QandAs { get; set; }
    }
}
