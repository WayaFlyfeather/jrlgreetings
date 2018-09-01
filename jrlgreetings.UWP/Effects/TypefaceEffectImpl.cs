using jrlgreetings.Core.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;

[assembly: Xamarin.Forms.ResolutionGroupName("JonRLevy")]
[assembly: Xamarin.Forms.ExportEffect(typeof(jrlgreetings.UWP.Effects.TypefaceEffectImpl), "TypefaceEffect")]

namespace jrlgreetings.UWP.Effects
{
    public class TypefaceEffectImpl : PlatformEffect
    {
        static Lazy<FontFamily> MonospaceTypewriterFont = new Lazy<FontFamily>(() => new FontFamily("/Assets/Fonts/MonospaceTypewriter.ttf#MonospaceTypewriter"));
        static Lazy<FontFamily> ImmortalFont = new Lazy<FontFamily>(() => new FontFamily("/Assets/Fonts/IMMORTAL.ttf#Immortal"));

        protected override void OnAttached()
        {
            try
            {
                TypefaceEffect typefaceEffect = (TypefaceEffect)Element.Effects.First(e => e is TypefaceEffect);

                FontFamily fontFamily;
                switch (typefaceEffect.Name)
                {
                    case TypefaceEffect.InstalledTypeface.MonospaceTypewriter:
                        fontFamily = MonospaceTypewriterFont.Value;
                        break;
                    case TypefaceEffect.InstalledTypeface.Immortal:
                        fontFamily = ImmortalFont.Value;
                        break;
                    default:
                        fontFamily = null;
                        break;
                }

                switch (Control)
                {
                    case TextBlock tb:
                        tb.FontFamily = fontFamily;
                        break;
                    case Button b:
                        b.FontFamily = fontFamily;
                        break;
                    case ComboBox cb:
                        cb.FontFamily = fontFamily;
                        break;
                    case TextBox tbx:
                        tbx.FontFamily = fontFamily;
                        break;
                    case ToggleSwitch tsw:
                        tsw.FontFamily = fontFamily;
                        break;
                    case Control cntr:
                        cntr.FontFamily = fontFamily;
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
        }
    }
}
