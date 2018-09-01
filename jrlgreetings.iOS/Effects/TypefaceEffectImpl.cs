using jrlgreetings.Core.Effects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms.Platform.iOS;

[assembly: Xamarin.Forms.ResolutionGroupName("JonRLevy")]
[assembly: Xamarin.Forms.ExportEffect(typeof(jrlgreetings.iOS.Effects.TypefaceEffectImpl), "TypefaceEffect")]
namespace jrlgreetings.iOS.Effects
{
    public class TypefaceEffectImpl : PlatformEffect
    {
        UIFont prevUIFont = null;

        protected override void OnAttached()
        {
            TypefaceEffect typefaceEffect = (TypefaceEffect)Element.Effects.First(e => e is TypefaceEffect);

            string fontFamily;
            switch (typefaceEffect.Name)
            {
                case TypefaceEffect.InstalledTypeface.MonospaceTypewriter:
                    fontFamily = "MonospaceTypewriter";
                    break;
                case TypefaceEffect.InstalledTypeface.Immortal:
                    fontFamily = "Immortal";
                    break;
                default:
                    fontFamily = null;
                    break;
            }

            try
            {
                switch (Control)
                {
                    case UILabel lbl:
                        Xamarin.Forms.Label lblElem = Element as Xamarin.Forms.Label;
                        if (lblElem != null)
                        {
                            prevUIFont = lbl.Font;
                            lbl.Font = UIFont.FromName(fontFamily, new System.nfloat(lblElem.FontSize));
                            lblElem.FontFamily = lbl.Font.FamilyName;
                        }
                        break;
                    case UITextField tf:
                        Xamarin.Forms.Picker tfElem = Element as Xamarin.Forms.Picker;
                        if (tfElem != null)
                        {
                            prevUIFont = tf.Font;
                            tf.Font = UIFont.FromName(fontFamily, new System.nfloat(12f));
                        }
                        break;
                    case UIButton b:
                        Xamarin.Forms.Button bElem = Element as Xamarin.Forms.Button;
                        if (bElem != null)
                        {
                            prevUIFont = b.Font;
                            b.Font = UIFont.FromName(fontFamily, new System.nfloat(bElem.FontSize));
                            bElem.FontFamily = b.Font.FamilyName;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
            if (prevUIFont != null)
            {
                try
                {
                    switch (Control)
                    {
                        case UILabel lbl:
                            lbl.Font = prevUIFont;
                            break;
                        case UITextField tf:
                            tf.Font = prevUIFont;
                            break;
                        case UIButton b:
                            b.Font = prevUIFont;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
                }
                finally
                {
                    prevUIFont = null;
                }
            }
        }
    }
}
