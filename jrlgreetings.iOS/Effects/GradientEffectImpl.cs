using CoreAnimation;
using CoreGraphics;
using jrlgreetings.Core;
using jrlgreetings.Core.Effects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms.Platform.iOS;

[assembly: Xamarin.Forms.ExportEffect(typeof(jrlgreetings.iOS.Effects.GradientEffectImpl), "GradientEffect")]
namespace jrlgreetings.iOS.Effects
{
    public class GradientEffectImpl : PlatformEffect
    {
        private class GradientUIView : UIView
        {
            CAGradientLayer gradientLayer;

            internal GradientUIView(CGRect frame, GradientEffect gradientEffect) : base(frame)
            {
                CGColor startColor = gradientEffect.StartColor.ToCGColor();
                CGColor endColor = gradientEffect.EndColor.ToCGColor();

                CGPoint startPoint;
                CGPoint endPoint;
                switch (gradientEffect.Direction)
                {
                    case GradientDirection.LeftRight: startPoint = new CGPoint(0.0, 0.5); endPoint = new CGPoint(1.0, 0.5); break;
                    case GradientDirection.TopLeft_BottomRight: startPoint = new CGPoint(0.0, 0.0); endPoint = new CGPoint(1.0, 1.0); break;
                    case GradientDirection.TopRight_BottomLeft: startPoint = new CGPoint(1.0, 0.0); endPoint = new CGPoint(0.0, 1.0); break;
                    case GradientDirection.RightLeft: endPoint = new CGPoint(0.0, 0.5); startPoint = new CGPoint(1.0, 0.5); break;
                    case GradientDirection.BottomRight_TopLeft: endPoint = new CGPoint(0.0, 0.0); startPoint = new CGPoint(1.0, 1.0); break;
                    case GradientDirection.BottomTop: endPoint = new CGPoint(0.5, 0.0); startPoint = new CGPoint(0.5, 1.0); break;
                    case GradientDirection.BottomLeft_TopRight: endPoint = new CGPoint(1.0, 0.0); startPoint = new CGPoint(0.0, 1.0); break;
                    case GradientDirection.TopBottom:
                    default:
                        startPoint = new CGPoint(0.5, 0.0); endPoint = new CGPoint(0.5, 1.0); break;
                }

                gradientLayer = new CAGradientLayer
                {
                    Frame = frame,
                    Colors = new[] { startColor, endColor },
                    StartPoint = startPoint,
                    EndPoint = endPoint
                };

                Layer.InsertSublayer(gradientLayer, 0);
                UserInteractionEnabled = false;
            }

            public override void LayoutSubviews()
            {
                this.Frame = Superview.Frame;
                base.LayoutSubviews();
                gradientLayer.Frame = this.Frame;
            }

            protected override void Dispose(bool disposing)
            {
                if (Layer.Sublayers[0] == gradientLayer)
                    Layer.Sublayers[0].RemoveFromSuperLayer();

                gradientLayer = null;
                base.Dispose(true);
            }
        }

        GradientUIView gradientSubView = null;

        protected override void OnAttached()
        {
            UIView recipient = Control == null ? Container : Control;

            try
            {
                gradientSubView = new GradientUIView(recipient.Bounds, (GradientEffect)Element.Effects.First(e => e is GradientEffect));

                recipient.InsertSubview(gradientSubView, 0);
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
            }
        }

        protected override void OnDetached()
        {
            UIView recipient = Control == null ? Container : Control;
            if (gradientSubView != null)
            {
                gradientSubView.RemoveFromSuperview();

                gradientSubView.Dispose();
                gradientSubView = null;
            }
        }
    }
}
