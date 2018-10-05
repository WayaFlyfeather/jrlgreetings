using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace jrlgreetings.FormsUI.Effects
{
    public class GradientEffect : RoutingEffect
    {
        public static readonly BindableProperty GradientDirectionProperty =
                BindableProperty.CreateAttached("GradientDirection", typeof(GradientDirection), typeof(GradientEffect), GradientDirection.TopBottom, propertyChanged: OnGradientDirectionChanged);

        public static GradientDirection GetGradientDirection(BindableObject view)
        {
            return (GradientDirection)view.GetValue(GradientDirectionProperty);
        }

        public static void SetGradientDirection(BindableObject view, GradientDirection value)
        {
            view.SetValue(GradientDirectionProperty, value);
        }

        public static readonly BindableProperty GradientStartColorProperty =
                BindableProperty.CreateAttached("GradientStartColor", typeof(Color), typeof(GradientEffect), Color.Transparent, propertyChanged: OnGradientStartColorChanged);

        public static Color GetGradientStartColor(BindableObject view)
        {
            return (Color)view.GetValue(GradientStartColorProperty);
        }

        public static void SetGradientStartColor(BindableObject view, Color value)
        {
            view.SetValue(GradientStartColorProperty, value);
        }

        public static readonly BindableProperty GradientEndColorProperty =
                BindableProperty.CreateAttached("GradientEndColor", typeof(Color), typeof(GradientEffect), Color.Black, propertyChanged: OnGradientEndColorChanged);

        public static Color GetGradientEndColor(BindableObject view)
        {
            return (Color)view.GetValue(GradientEndColorProperty);
        }

        public static void SetGradientEndColor(BindableObject view, Color value)
        {
            view.SetValue(GradientEndColorProperty, value);
        }

        public static readonly BindableProperty GradientDescriptorProperty =
        BindableProperty.CreateAttached("GradientDescriptor", typeof(GradientDescriptor), typeof(GradientEffect), null, propertyChanged: OnGradientDescriptorChanged);

        public static Color GetGradientDescriptor(BindableObject view)
        {
            return (Color)view.GetValue(GradientDescriptorProperty);
        }

        public static void SetGradientDescriptor(BindableObject view, GradientDescriptor value)
        {
            view.SetValue(GradientDescriptorProperty, value);
        }

        public GradientDescriptor Descriptor { get; set; } = new GradientDescriptor();
        public GradientDirection Direction
        {
            get => Descriptor.Direction;
            set => Descriptor.Direction = value;
        }
        public Color StartColor
        {
            get => Descriptor.StartColor;
            set => Descriptor.StartColor = value;
        }
        public Color EndColor
        {
            get => Descriptor.EndColor;
            set => Descriptor.EndColor = value;
        }

        public GradientEffect() : base("JonRLevy.GradientEffect")
        {
        }

        static void OnGradientDirectionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            View view = bindable as View;

            GradientEffect effect = getExistingOrNew(view);
            effect.Direction = (GradientDirection)newValue;

            view.Effects.Add(effect);
        }

        static void OnGradientStartColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            View view = bindable as View;

            GradientEffect effect = getExistingOrNew(view);
            effect.StartColor = (Color)newValue;

            view.Effects.Add(effect);
        }

        static void OnGradientEndColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            View view = bindable as View;

            GradientEffect effect = getExistingOrNew(view);
            effect.EndColor = (Color)newValue;

            view.Effects.Add(effect);
        }

        static void OnGradientDescriptorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            View view = bindable as View;

            GradientEffect effect = getExistingOrNew(view);
            effect.Descriptor = (GradientDescriptor)newValue;

            view.Effects.Add(effect);
        }

        static GradientEffect getExistingOrNew(View view)
        {
            //remove any previous version
            GradientEffect effect = (GradientEffect)view.Effects.FirstOrDefault(e => e is GradientEffect);
            if (effect != null)
                view.Effects.Remove(effect);
            else
                effect = new GradientEffect();

            return effect;
        }
    }
}
