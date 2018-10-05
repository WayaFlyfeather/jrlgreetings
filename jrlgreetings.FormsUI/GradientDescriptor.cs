using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace jrlgreetings.FormsUI
{
    public enum GradientDirection
    {
        LeftRight, TopLeft_BottomRight, TopBottom, TopRight_BottomLeft, RightLeft, BottomRight_TopLeft, BottomTop, BottomLeft_TopRight
    }

    public class GradientDescriptor
    {
        public GradientDirection Direction { get; set; } = GradientDirection.TopBottom;
        public Color StartColor { get; set; } = Color.Transparent;
        public Color EndColor { get; set; } = Color.Black;
    }
}
