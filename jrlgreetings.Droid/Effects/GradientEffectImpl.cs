using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using jrlgreetings.FormsUI;
using jrlgreetings.FormsUI.Effects;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportEffect(typeof(jrlgreetings.Droid.Effects.GradientEffectImpl), "GradientEffect")]
namespace jrlgreetings.Droid.Effects
{
    class GradientEffectImpl : PlatformEffect
    {
        Drawable prevBackground = null;

        protected override void OnAttached()
        {            
            GradientEffect gradientEffect = (GradientEffect)Element.Effects.First(e => e is GradientEffect);

            Android.Graphics.Color startColor = gradientEffect.StartColor.ToAndroid();
            Android.Graphics.Color endColor = gradientEffect.EndColor.ToAndroid();

            int[] colors = new int[] { startColor, endColor };

            GradientDrawable.Orientation orientation = GradientDrawable.Orientation.TopBottom;
            switch (gradientEffect.Direction)
            {
                case GradientDirection.TopLeft_BottomRight: orientation = GradientDrawable.Orientation.TlBr; break;
                case GradientDirection.TopBottom: orientation = GradientDrawable.Orientation.TopBottom; break;
                case GradientDirection.TopRight_BottomLeft: orientation = GradientDrawable.Orientation.TrBl; break;
                case GradientDirection.LeftRight: orientation = GradientDrawable.Orientation.LeftRight; break;
                case GradientDirection.RightLeft: orientation = GradientDrawable.Orientation.RightLeft; break;
                case GradientDirection.BottomRight_TopLeft: orientation = GradientDrawable.Orientation.BrTl; break;
                case GradientDirection.BottomTop: orientation = GradientDrawable.Orientation.BottomTop; break;
                case GradientDirection.BottomLeft_TopRight: orientation = GradientDrawable.Orientation.BlTr; break;
            }

            GradientDrawable drawable = new GradientDrawable(orientation, colors);

            if (Control == null)
            {
                prevBackground = Container.Background;
                Container.Background = drawable; 
            }
            else
            {
                prevBackground = Control.Background;
                Control.Background = drawable;
            }
        }

        protected override void OnDetached()
        {
            try
            {
                if (Control == null)
                    Container.Background = prevBackground;
                else
                    Control.Background = prevBackground;
            }
            catch (ObjectDisposedException)
            {
                //do nothing, ok
            }

            prevBackground = null;
        }
    }
}