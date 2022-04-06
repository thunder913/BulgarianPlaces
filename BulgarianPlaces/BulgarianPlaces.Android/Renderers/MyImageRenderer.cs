using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using BulgarianPlaces.Droid.Renderers;
using BulgarianPlaces.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Image), typeof(MyImageRenderer))]
namespace BulgarianPlaces.Droid.Renderers
{
    [Obsolete]
    public class MyImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            var newImage = e.NewElement as MyImage;
            if (newImage != null)
            {
                newImage.GetBytes = () =>
                {
                    var drawable = this.Control.Drawable;
                    var bitmap = Bitmap.CreateBitmap(drawable.IntrinsicWidth, drawable.IntrinsicHeight, Bitmap.Config.Argb8888);
                    drawable.Draw(new Canvas(bitmap));
                    using (var ms = new MemoryStream())
                    {
                        bitmap.Compress(Bitmap.CompressFormat.Png, 100, ms);
                        return ms.ToArray();
                    }
                };
            }

            var oldImage = e.OldElement as MyImage;
            if (oldImage != null)
            {
                oldImage.GetBytes = null;
            }
        }
    }
}