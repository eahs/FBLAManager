using System;
using Xamarin.Forms;
using FBLAManager.Services;
using Com.Instabug.Bug;
using Com.Instabug.Library;

[assembly: Dependency(typeof(FBLAManager.Droid.BugReporterDroid))]
namespace FBLAManager.Droid
{
    public class BugReporterDroid : IBugReporter
    {
        public void Trigger()
        {
            Instabug.Show();
        }
    }
}
