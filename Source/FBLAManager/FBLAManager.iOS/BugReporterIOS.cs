using System;
using Xamarin.Forms;
using FBLAManager.Services;
using FBLAManager.iOS;
using InstabugLib;

[assembly: Dependency(typeof(BugReporterIOS))]
namespace FBLAManager.iOS
{
    public class BugReporterIOS : IBugReporter
    {
        public void Trigger()
        {
            Instabug.Show();
        }
    }
}
