using jrlgreetings.Core;
using jrlgreetings.FormsUI;
using jrlgreetings.FormsUI.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;

[assembly: Xamarin.Forms.ExportEffect(typeof(jrlgreetings.UWP.Effects.GradientEffectImpl), "GradientEffect")]

namespace jrlgreetings.UWP.Effects
{
    public class GradientEffectImpl : PlatformEffect
    {
        Brush prevBrush = null;

        protected override void OnAttached()
        {
            GradientEffect gradientEffect = (GradientEffect)Element.Effects.First(e => e is GradientEffect);

            Color startColor = XFColorToWinColor(gradientEffect.StartColor);
            Color endColor = XFColorToWinColor(gradientEffect.EndColor);

            GradientStopCollection stops = new GradientStopCollection()
            {
                new GradientStop{ Color = startColor, Offset = 0.0 },
                new GradientStop() { Color = endColor, Offset = 1.0 }
            };

            double angle = 90.0;
            switch (gradientEffect.Direction)
            {
                case GradientDirection.LeftRight: angle = 0.0; break;
                case GradientDirection.TopLeft_BottomRight: angle = 45.0; break;
                case GradientDirection.TopBottom: angle = 90.0; break;
                case GradientDirection.TopRight_BottomLeft: angle = 135.0; break;
                case GradientDirection.RightLeft: angle = 180.0; break;
                case GradientDirection.BottomRight_TopLeft: angle = 225.0; break;
                case GradientDirection.BottomTop: angle = 270.0; break;
                case GradientDirection.BottomLeft_TopRight: angle = 315.0; break;
            }
            LinearGradientBrush gradientBrush = new LinearGradientBrush(stops, angle);
            if (Control != null)
            { 
                Control cntrl = Control as Control;
                if (cntrl != null)
                {
                    prevBrush = cntrl.Background;
                    cntrl.Background = gradientBrush;
                }
            }
            else
            {
                LayoutRenderer lrenderer = Container as LayoutRenderer;
                if (lrenderer != null)
                {
                    prevBrush = lrenderer.Background;
                    lrenderer.Background = gradientBrush;
                }
                else
                {
                    PageRenderer prenderer = Container as PageRenderer;
                    if (prenderer != null)
                    {
                        prevBrush = prenderer.Background;
                        prenderer.Background = gradientBrush;
                    }

                }
            }
        }

        protected override void OnDetached()
        {
            if (Control != null)
            {
                Control cntrl = Control as Control;
                if (cntrl != null)
                {
                    cntrl.Background = prevBrush;
                }
            }
            else
            {
                LayoutRenderer renderer = Container as LayoutRenderer;
                if (renderer != null)
                {
                    renderer.Background = prevBrush;
                }
                else
                {
                    PageRenderer prenderer = Container as PageRenderer;
                    if (prenderer != null)
                    {
                        prenderer.Background = prevBrush;
                    }

                }
            }
            prevBrush = null;
        }

        Color XFColorToWinColor(Xamarin.Forms.Color xfColor)
        {
            return Color.FromArgb((byte)(xfColor.A * 255), (byte)(xfColor.R * 255), (byte)(xfColor.G * 255), (byte)(xfColor.B * 255));
        }
    }
}
