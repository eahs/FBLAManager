using FBLAManager.Views;
using FBLAManager.Views.Events;
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

            Routing.RegisterRoute("ItemDetailPage", typeof(ItemDetailPage));
            Routing.RegisterRoute("MeetingDetailPage", typeof(MeetingDetailPage));
        }
    }
}
