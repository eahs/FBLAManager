using Syncfusion.SfImageEditor.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.IO;
using System;
using System.Threading.Tasks;
using FBLAManager.Helpers;


namespace FBLAManager.Views.Members
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileImageEditor : ContentPage
    {

        //int height; 

        public ProfileImageEditor()
        {
            InitializeComponent();       
            
            editor.ToolbarSettings.ToolbarItemSelected += ToolbarSettings_ToolbarItemSelected;
        }

        public ProfileImageEditor(ImageSource src)
        {
            InitializeComponent();

            editor.ToolbarSettings.ToolbarItemSelected += ToolbarSettings_ToolbarItemSelected;

            #region toolbar customization

            // The following built-in toolbar item names are available in image editor: 
            // Back, Text, Add, TextColor, FontFamily, Arial, Noteworthy, Marker Felt, Bradley Hand, 
            // SignPainter, Opacity, Path, StrokeThickness, Colors, Opacity, Shape, Rectangle, StrokeThickness, Circle, 
            // Arrow, Transform, Crop, free, original, square, 3:1, 3:2, 4:3, 5:4, 16:9, Rotate, Flip, Reset, Undo, Redo, 
            // Save, Effects, Hue, Saturation, Brightness, Contrast, Blur and Sharpen.
            var desiredOptions = new string[] { "Reset", "Effects", "Save", "Undo", "Redo", "Transform" };

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

            #endregion

            //height = src.Height;


        }

        /// <summary>
        /// Saves image to backend. 
        /// </summary>
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

        private void ToolbarSettings_ToolbarItemSelected(object sender, ToolbarItemSelectedEventArgs e)
        {
           
            
            if (e.ToolbarItem.Name == "Crop")
            {
                editor.SetToolbarItemVisibility("free,original,3:1,3:2,4:3,5:4,16:9", false);    
            }
        }
    }
}