using FBLAManager.Views;
using FBLAManager.Views.Detail;
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

            Routing.RegisterRoute("MeetingsDetailPage", typeof(ArticleDetailPage));

        }
    }
}
