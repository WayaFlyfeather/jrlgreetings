﻿using jrlgreetings.FormsUI.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.UWP;

[assembly: Xamarin.Forms.ExportEffect(typeof(jrlgreetings.UWP.Effects.ThumbToolTipEffectImpl), "ThumbToolTipEffect")]
namespace jrlgreetings.UWP.Effects
{
    public class ThumbToolTipEffectImpl : PlatformEffect
    {
        bool previousIsThumbToolTipEnabled = true;

        protected override void OnAttached()
        {
            ThumbToolTipEffect thumbToolTipEffect = (ThumbToolTipEffect)Element.Effects.First(e => e is ThumbToolTipEffect);

            switch (Control)
            {
                case FormsSlider formsSlider:
                    previousIsThumbToolTipEnabled = formsSlider.IsThumbToolTipEnabled;
                    formsSlider.IsThumbToolTipEnabled = !thumbToolTipEffect.Suppressed;
                    break;
            }
        }

        protected override void OnDetached()
        {
            switch (Control)
            {
                case FormsSlider formsSlider:
                    formsSlider.IsThumbToolTipEnabled = previousIsThumbToolTipEnabled;
                    break;
            }
        }
    }
}
