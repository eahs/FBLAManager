using FBLAManager.Views;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FBLAManager
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

<<<<<<< Updated upstream
            Routing.RegisterRoute("MeetingsDetailPage", typeof(ArticleDetailPage));
=======
            Routing.RegisterRoute("ItemDetailPage", typeof(ItemDetailPage));
>>>>>>> Stashed changes

        }
    }
}
