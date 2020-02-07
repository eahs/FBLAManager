using Syncfusion.SfImageEditor.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

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
            foreach (Syncfusion.SfImageEditor.XForms.ToolbarItem item in editor.ToolbarSettings.ToolbarItems)
            {
                if (item.Name == "Text")
                {
                    editor.ToolbarSettings.ToolbarItems.Remove(item); 
                }
            } */

            /*
            editor.ToolbarSettings.ToolbarItems.Clear();
            
            HeaderToolbarItem undo = new HeaderToolbarItem { Name = "Undo", Icon = ImageSource.FromResource("ImageEditor.undo.png") };
            HeaderToolbarItem redo = new HeaderToolbarItem { Icon = ImageSource.FromResource("ImageEditor.Redo.png") };


            editor.ToolbarSettings.ToolbarItems.Add(undo);
            editor.ToolbarSettings.ToolbarItems.Add(redo);

            editor.ToolbarSettings.ToolbarItems.Add(new HeaderToolbarItem() { Name = "Undo" } ); */



        }

    }
}