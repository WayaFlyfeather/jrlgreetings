using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace jrlgreetings.Core.Effects
{
    public class TypefaceEffect : RoutingEffect
    {
        public enum InstalledTypeface { None, MonospaceTypewriter, Immortal };

        public static readonly BindableProperty TypefaceNameProperty =
            BindableProperty.CreateAttached("TypefaceName", typeof(InstalledTypeface), typeof(TypefaceEffect), InstalledTypeface.None, propertyChanged: OnTypefaceNameChanged);

        public static InstalledTypeface GetTypefaceName(BindableObject view)
        {
            return (InstalledTypeface)view.GetValue(TypefaceNameProperty);
        }

        public static void SetTypefaceName(BindableObject view, InstalledTypeface value)
        {
            view.SetValue(TypefaceNameProperty, value);
        }

        public InstalledTypeface Name { get; set; }

        public TypefaceEffect() : base("JonRLevy.TypefaceEffect")
        {
        }

        static void OnTypefaceNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            View view = bindable as View;
            if (view == null)
            {
                return;
            }

            //remove any previous version
            TypefaceEffect effect = (TypefaceEffect)view.Effects.FirstOrDefault(e => e is TypefaceEffect);
            if (effect != null)
                view.Effects.Remove(effect);

            effect = new TypefaceEffect() { Name = (InstalledTypeface)newValue };
            view.Effects.Add(effect);
        }
    }
}
