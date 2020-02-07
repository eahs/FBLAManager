using Syncfusion.SfImageEditor.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using FBLAManager.Helpers;

namespace FBLAManager.Views.Members
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileImageEditor : ContentPage
    {
        public ProfileImageEditor()
        {
            InitializeComponent();    
        }

        public ProfileImageEditor(ImageSource src)
        {
            InitializeComponent();

            // The following built-in toolbar item names are available in image editor: 
            // Back, Text, Add, TextColor, FontFamily, Arial, Noteworthy, Marker Felt, Bradley Hand, 
            // SignPainter, Opacity, Path, StrokeThickness, Colors, Opacity, Shape, Rectangle, StrokeThickness, Circle, 
            // Arrow, Transform, Crop, free, original, square, 3:1, 3:2, 4:3, 5:4, 16:9, Rotate, Flip, Reset, Undo, Redo, 
            // Save, Effects, Hue, Saturation, Brightness, Contrast, Blur and Sharpen.
            var desiredOptions = new string[] { "Reset", "Effects", "Save", "Undo", "Redo" };

            editor.ImageSaving += Editor_ImageSaving;
            editor.Source = src;

            var toolbarItems = editor.ToolbarSettings.ToolbarItems;

            for (int i = toolbarItems.Count-1; i >= 0; i--)
            {
                var item = toolbarItems[i];

                if (!desiredOptions.Contains(item.Name))
                {
                    editor.ToolbarSettings.ToolbarItems.Remove(item);
                }
            }
            
            /*
            
            HeaderToolbarItem undo = new HeaderToolbarItem { Name = "Crop", Icon = ImageSource.FromResource("ImageEditor.crop.png") };
            HeaderToolbarItem redo = new HeaderToolbarItem { Icon = ImageSource.FromResource("ImageEditor.Redo.png") }; */

        }

        private void Editor_ImageSaving(object sender, ImageSavingEventArgs args)
        {
            args.Cancel = true;

            //args.Stream
            using (MemoryStream stream = new MemoryStream())
            {
                args.Stream.CopyTo(stream);
                byte[] rawImage = stream.ToArray();
                string encoded = Convert.ToBase64String(rawImage);

                // Send encoded string to backend
                Task.Run(async () =>
                {
                    await UserManager.Current.SaveProfileImage(encoded);
                });
            }

            Navigation.PopModalAsync();
        }


    }
}