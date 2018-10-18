using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace jrlgreetings.FormsUI.Effects
{
    /// <summary>
    /// For suppressing a default ThumToolTip on a Slider. Only relevant for UWP.
    /// </summary>
    public class ThumbToolTipEffect : RoutingEffect
    {
        public bool Suppressed { get; set; } = true;

        public ThumbToolTipEffect() : base("JonRLevy.ThumbToolTipEffect")
        { }
    }
}
