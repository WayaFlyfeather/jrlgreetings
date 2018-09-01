using jrlgreetings.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Forms.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace jrlgreetings.Core.TriggerActions
{
    public class AllCompleteTriggerAction : TriggerAction<MvxContentPage>
    {
        protected override void Invoke(MvxContentPage sender)
        {
            IMvxBindingContext prevViewModel = sender.BindingContext;
            sender.ControlTemplate = (ControlTemplate)Application.Current.Resources["ColorfulRoomPageTemplate"];
            sender.BindingContext = null;
            sender.BindingContext = prevViewModel;
        }
    }
}
