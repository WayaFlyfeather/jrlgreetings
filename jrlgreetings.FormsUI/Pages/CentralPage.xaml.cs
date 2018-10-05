using jrlgreetings.Core.ViewModels;
using MvvmCross.Forms.Core;
using MvvmCross.Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jrlgreetings.FormsUI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CentralPage : MvxContentPage
	{
        CentralViewModel vm => ViewModel as CentralViewModel;

		public CentralPage ()
		{
			InitializeComponent ();
            Operand1Slider.BindingContext = vm;
            Operand2Slider.BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (vm != null)
            {
                vm.PropertyChanged += Vm_PropertyChanged;
                hackSliders();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnAppearing();
            if (vm != null)
                vm.PropertyChanged -= Vm_PropertyChanged;
        }

        private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName==nameof(CentralViewModel.OperandMax) || e.PropertyName == nameof(CentralViewModel.OperandMin) || String.IsNullOrEmpty(e.PropertyName)) 
            {
                hackSliders();
            }
        }

        void hackSliders()
        {
            DummyVM dummy = new DummyVM() { OperandMax = vm.OperandMax, OperandMin = vm.OperandMin, Operand1 = 0, Operand2 = 0 };
            Operand1Slider.BindingContext = dummy; //hack
            Operand1Slider.BindingContext = vm;
            Operand2Slider.BindingContext = dummy;
            Operand2Slider.BindingContext = vm;
        }

        public class DummyVM  //class for hack - force slider to update by changing BindingContext and Value
        {
            public int OperandMax { get; set; }
            public int OperandMin { get; set; }
            public int Operand1 { get; set; }
            public int Operand2 { get; set; }
        }
    }
}