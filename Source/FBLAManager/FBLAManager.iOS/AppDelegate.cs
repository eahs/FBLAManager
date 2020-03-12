using Syncfusion.XForms.iOS.Core;
using Syncfusion.SfMaps.XForms.iOS;
using Syncfusion.XForms.iOS.Graphics;
using Syncfusion.XForms.iOS.Border;
using Syncfusion.XForms.iOS.Buttons;
using Syncfusion.ListView.XForms.iOS;
using Foundation;
using UIKit;
using Syncfusion.SfBusyIndicator.XForms.iOS;
using InstabugLib;
using Xamarin.Forms;
using Lottie.Forms.iOS.Renderers;

namespace FBLAManager.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.SetFlags("Shell_Experimental", "Visual_Experimental", "CollectionView_Experimental", "FastRenderers_Experimental");
            Forms.SetFlags("CarouselView_Experimental", "IndicatorView_Experimental");
            global::Xamarin.Forms.Forms.Init();
            Core.Init();
            SfMapsRenderer.Init();
            SfGradientViewRenderer.Init();
            SfBorderRenderer.Init();
            SfButtonRenderer.Init();
            AnimationViewRenderer.Init();

            new SfBusyIndicatorRenderer();

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            Syncfusion.SfSchedule.XForms.iOS.SfScheduleRenderer.Init();
            Syncfusion.XForms.iOS.TabView.SfTabViewRenderer.Init();

            SfListViewRenderer.Init();

            LoadApplication(new App());

            Instabug.StartWithToken("de0e8acfa86980fd8b252abd14d086fc",IBGInvocationEvent.Shake);
            IBGBugReporting.InvocationEvents = IBGInvocationEvent.FloatingButton;


            return base.FinishedLaunching(app, options);
        }
    }
}
