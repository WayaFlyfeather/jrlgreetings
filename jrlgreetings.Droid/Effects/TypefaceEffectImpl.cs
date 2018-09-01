using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using jrlgreetings.Core.Effects;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ResolutionGroupName("JonRLevy")]
[assembly: Xamarin.Forms.ExportEffect(typeof(jrlgreetings.Droid.Effects.TypefaceEffectImpl), "TypefaceEffect")]
namespace jrlgreetings.Droid.Effects
{
    class TypefaceEffectImpl : PlatformEffect
    {
        static Lazy<Typeface> MonospaceTypewriterTypeface = new Lazy<Typeface>(() => Typeface.CreateFromAsset(Android.App.Application.Context.Assets, "MonospaceTypewriter.ttf"));
        static Lazy<Typeface> ImmortalTypeface = new Lazy<Typeface>(() => Typeface.CreateFromAsset(Android.App.Application.Context.Assets, "IMMORTAL.ttf"));

        Typeface prevTypeface = null;
        protected override void OnAttached()
        {
            try
            {
                TypefaceEffect typefaceEffect = (TypefaceEffect)Element.Effects.First(e => e is TypefaceEffect);
                Typeface typeface;
                switch (typefaceEffect.Name)
                {
                    case TypefaceEffect.InstalledTypeface.MonospaceTypewriter:
                        typeface = MonospaceTypewriterTypeface.Value;
                        break;
                    case TypefaceEffect.InstalledTypeface.Immortal:
                        typeface = ImmortalTypeface.Value;
                        break;
                    default:
                        typeface = null;
                        break;
                }

                if (typeface == null)
                    return;

                switch (Control)
                {
                    case TextView lbl:
                        prevTypeface = lbl.Typeface;
                        lbl.Typeface = typeface;
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }

        }

        protected override void OnDetached()
        {
            if (prevTypeface!=null)
            {
                switch (Control)
                {
                    case TextView lbl:
                        lbl.Typeface = prevTypeface;
                        break;
                }
                prevTypeface = null;
            }
        }
    }
}